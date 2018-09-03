using System;
using Ccr.Dnc.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Ccr.Dnc.Data.EntityFrameworkCore.Attributes
{
  [AttributeUsage(AttributeTargets.Class)]
  public class EntityConfiguratorAttribute
    : Attribute
  {
    private static readonly Type expectedParamterImpl 
      = typeof(IEntityTypeConfiguration<>);

    public Type EntityConfigurationType { get; }


    public EntityConfiguratorAttribute(
      Type entityConfigurationType)
    {
      if (!expectedParamterImpl.IsInstanceOfType(entityConfigurationType))
        throw new InvalidOperationException(
          $"{entityConfigurationType.Name.SQuote()} is not valid for use on this type. " +
          $"Must be instance of type {entityConfigurationType.Name.SQuote()}.");

      EntityConfigurationType = entityConfigurationType;
    }
  }
}
