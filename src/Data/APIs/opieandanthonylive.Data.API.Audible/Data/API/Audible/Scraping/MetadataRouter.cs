using System;
using System.Linq.Expressions;
using AngleSharp.Dom;
using Ccr.Dnc.Core.Extensions;
using opieandanthonylive.Data.Domain.Audible;

namespace opieandanthonylive.Data.API.Audible.Scraping
{
  public class MetadataRouter<TProperty>
    : MetadataRouterBase
  {
    protected Func<IElement, TProperty> MetadataAccessor;

    protected Expression<Func<AudibleMediaItem, TProperty>> PropertyExpression;


    public MetadataRouter(
      Func<IElement, TProperty> metadataAccessor,
      Expression<Func<AudibleMediaItem, TProperty>> propertyExpression)
    {
      MetadataAccessor = metadataAccessor;
      PropertyExpression = propertyExpression;
    }


    public void ExecutePropertySet(
      AudibleMediaItem @this,
      TProperty value)
    {
      var lambda = PropertyExpression.Body.As<MemberExpression>();

      var param = Expression.Parameter(value.GetType(), "value");

      var assignment = Expression.Assign(lambda, param);


      var setterExpression = Expression.Lambda<
        Action<AudibleMediaItem, TProperty>>(
        assignment,
        PropertyExpression.Parameters[0],
        param);

      var action = setterExpression.Compile();
      action(@this, value);
    }

    public TProperty Scrape(
      IElement element)
    {
      return MetadataAccessor(element);
    }


    public override void ExecutePropertySetBase(
      AudibleMediaItem @this,
      object value)
    {
      if (value.GetType() != typeof(TProperty))
        throw new NotSupportedException(
          $"{value.GetType().FormatName().SQuote()} is not supported. " +
          $"Expected type was {typeof(TProperty).FormatName().SQuote()}.");

      ExecutePropertySet(
        @this,
        (TProperty)value);
    }

    public override object ScrapeBase(
      IElement element)
    {
      var scrapedValue = Scrape(element);
      return scrapedValue;
    }
  }
}