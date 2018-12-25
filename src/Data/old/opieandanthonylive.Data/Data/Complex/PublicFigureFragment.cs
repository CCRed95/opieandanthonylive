using JetBrains.Annotations;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.Complex
{
	public abstract class PublicFigureFragment
		: PersonFragment
	{
		[CanBeNull]
		public string AlternateName { get; set; }

		[CanBeNull]
		public string Description { get; set; }

		[CanBeNull]
		public string TwitterHandle { get; set; }

		[CanBeNull]
		public string WebsiteUrl { get; set; }

		[CanBeNull]
		public string HeadshotImagePath { get; set; }


		
		protected PublicFigureFragment() { }

	  protected PublicFigureFragment(
			[NotNull] string firstName,
			[NotNull] string lastName) : this(
				firstName,
				null,
				lastName,
				null,
				null,
				null,
				null,
				null,
				null)
		{
		}

	  protected PublicFigureFragment(
			[NotNull] string firstName,
			[NotNull] string middleNameOrInitial,
			[NotNull] string lastName) : this(
				firstName,
				middleNameOrInitial,
				lastName,
				null,
				null,
				null,
				null,
				null,
				null)
		{
		}

	  protected PublicFigureFragment(
			[NotNull] string firstName,
			[NotNull] string lastName,
			[NotNull] Gender gender) : this(
				firstName,
				null,
				lastName,
				gender,
				null,
				null,
				null,
				null,
				null)
		{
		}

    protected PublicFigureFragment(
			[NotNull] string firstName,
			[NotNull] string middleNameOrInitial,
			[NotNull] string lastName,
			[NotNull] Gender gender) : this(
				firstName,
				middleNameOrInitial,
				lastName,
				gender,
				null,
				null,
				null,
				null,
				null)
		{
		}

	  protected PublicFigureFragment(
			[NotNull] string firstName,
			[NotNull] string middleNameOrInitial,
			[NotNull] string lastName,
			[NotNull] Gender gender,
			[NotNull] string alternateName) : this(
				firstName,
				middleNameOrInitial,
				lastName,
				gender,
				alternateName,
				null,
				null,
				null,
				null)
		{
		}

	  protected PublicFigureFragment(
			[NotNull] string firstName,
			[NotNull] string middleNameOrInitial,
			[NotNull] string lastName,
			[NotNull] Gender gender,
			[NotNull] string alternateName,
			[NotNull] string description) : this(
				firstName,
				middleNameOrInitial,
				lastName,
				gender,
				alternateName,
				description,
				null,
				null,
				null)
		{
		}

	  protected PublicFigureFragment(
			[NotNull] string firstName,
			[NotNull] string middleNameOrInitial,
			[NotNull] string lastName,
			[NotNull] Gender gender,
			[NotNull] string alternateName,
			[NotNull] string description,
			[NotNull] string twitterHandle) : this(
				firstName,
				middleNameOrInitial,
				lastName,
				gender,
				alternateName,
				description,
				twitterHandle,
				null,
				null)
		{
		}

	  protected PublicFigureFragment(
			[NotNull] string firstName,
			[NotNull] string middleNameOrInitial,
			[NotNull] string lastName,
			[NotNull] Gender gender,
			[NotNull] string alternateName,
			[NotNull] string description,
			[NotNull] string twitterHandle,
			[NotNull] string websiteUrl) : this(
				firstName,
				middleNameOrInitial,
				lastName,
				gender,
				alternateName,
				description,
				twitterHandle,
				websiteUrl,
				null)
		{
		}

	  protected PublicFigureFragment(
			[NotNull] string firstName,
			[CanBeNull] string middleNameOrInitial,
			[NotNull] string lastName,
			[CanBeNull] Gender gender,
			[CanBeNull] string alternateName,
			[CanBeNull] string description,
			[CanBeNull] string twitterHandle,
			[CanBeNull] string websiteUrl,
			[CanBeNull] string headShotImagePath) : base(
				firstName,
				middleNameOrInitial,
				lastName,
				gender)
		{
			AlternateName = alternateName;
			Description = description;
			TwitterHandle = twitterHandle;
			WebsiteUrl = websiteUrl;
			HeadshotImagePath = headShotImagePath;
		}
	}
}

//protected PublicFigureFragmentImpl(
//	[NotNull] string firstName,
//	[NotNull] string lastName,
//	[CanBeNull] HonorificPrefix prefix = null,
//	[CanBeNull] string middleNameOrInitial = null,
//	[CanBeNull] PostNominalSuffix suffix = null,
//	[CanBeNull] Gender gender = null,
//	[CanBeNull] string alternateName = null,
//	[CanBeNull] string description = null,
//	[CanBeNull] string twitterHandle = null,
//	[CanBeNull] string websiteUrl = null,
//	[CanBeNull] string headShotImagePath = null) : base(
//		firstName,
//		lastName,
//		prefix,
//		middleNameOrInitial,
//		suffix,
//		gender)
//{
//	AlternateName = alternateName;
//	Description = description;
//	TwitterHandle = twitterHandle;
//	WebsiteUrl = websiteUrl;
//	HeadshotImagePath = headShotImagePath;
//}