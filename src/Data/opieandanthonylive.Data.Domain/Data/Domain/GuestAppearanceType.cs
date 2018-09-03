using System.Runtime.CompilerServices;
using Ccr.Dnc.Core.Extensions;
using JetBrains.Annotations;

namespace opieandanthonylive.Data.Domain
{
	public partial class GuestAppearanceType
	{
	  public int GuestAppearanceTypeID { get; set; }

		public string AppearanceTypeName { get; set; }
		


		private GuestAppearanceType() { }

		public GuestAppearanceType(
			[NotNull] string appearanceTypeName = "") : this()
		{
			appearanceTypeName.IsNotNull(nameof(appearanceTypeName));

			AppearanceTypeName = appearanceTypeName;
		}

		private GuestAppearanceType(
			int guestAppearanceTypeID,
			[NotNull, CallerMemberName] string memberName = "") : this(
				memberName.Replace('_', ' '))
		{
			GuestAppearanceTypeID = guestAppearanceTypeID;
		}
	}
}
