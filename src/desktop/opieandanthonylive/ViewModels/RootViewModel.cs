using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using opieandanthonylive.Data.Context;
using opieandanthonylive.Data.Domain;
using opieandanthonylive.Data.Seeding;

namespace opieandanthonylive.ViewModels
{
	public class RootViewModel
		: NotifyFluent
	{
		private ObservableCollection<Guest> _guests;
		public ObservableCollection<Guest> Guests
		{
			get => _guests;
			set
			{
				_guests = value;
				NotifyOfPropertyChange(() => Guests);
			}
		}

		
		public RootViewModel()
		{
			using (var context = new CoreContext())
			{

				//var guests = typeof(Guest).GetStaticFieldValuesOfType<Guest>();
				//var index = 0;


				//foreach (var guest in guests)
				//{
				//	context.Guests.Add(guest);
				//	index++;

				//	if (index > 5)
				//	{
				//		index = 0;
				//		context.SaveChanges();
				//	}
				//}
			

				var arr = context.Guests.ToArray();
				Guests = new ObservableCollection<Guest>(arr);
				context.SaveChanges();
			}
		}
	}
}
