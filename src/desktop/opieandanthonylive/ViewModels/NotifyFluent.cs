using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Ccr.Std.Core.Extensions;

namespace opieandanthonylive.ViewModels
{
	public abstract class NotifyFluent
		: INotifyPropertyChanged
	{

		/// <summary>
		///		Notifies subscribers of the property change.
		/// </summary>
		/// <param name="propertyName">
		///		Name of the property.
		/// </param>
		public virtual void NotifyOfPropertyChange(
			string propertyName = null)
		{
			RaisePropertyChanged(new PropertyChangedEventArgs(propertyName));
		}

		public void NotifyOfPropertyChange<TProperty>(
			Expression<Func<TProperty>> property)
		{
			NotifyOfPropertyChange(
				property.GetMemberInfo().Name);
		}


		public event PropertyChangedEventHandler PropertyChanged;


		public void RaisePropertyChanged(
			PropertyChangedEventArgs args)
		{
			PropertyChanged?.Invoke(
				this,
				new PropertyChangedEventArgs(
					args.PropertyName));
		}
	}
}