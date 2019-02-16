using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace opieandanthonylive.Markup.ValueConverters
{
	public class PathToImageSourceConverter
		: IValueConverter
	{
		private static readonly ImageSourceConverter _converter
			= new ImageSourceConverter();


		public object Convert(
			object value, 
			Type targetType, 
			object parameter, 
			CultureInfo culture)
		{
			if(value == null)
				return null;

			var str = value.ToString();
			var converterBoxed = _converter.ConvertFrom(str);

			if (converterBoxed is ImageSource imageSource)
				return imageSource;

			return null;
		}

		public object ConvertBack(
			object value,
			Type targetType, 
			object parameter,
			CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
