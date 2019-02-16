namespace opieandanthonylive.Data.API.Patreon.Query
{
	public static class PatreonQueryBuilderExtensions
	{
		public static PatreonQueryBuilder FromCreator(
			this PatreonQueryBuilder @this,
			string creatorName)
		{
			@this.CreatorName = creatorName;
			return @this;
		}

		public static PatreonQueryBuilder WithAuthKey(
			this PatreonQueryBuilder @this,
			string authKey)
		{
			@this.AuthKey = authKey;
			return @this;
		}

		public static PatreonQueryBuilder WithDefaultAuthKey(
			this PatreonQueryBuilder @this)
		{
			@this.AuthKey = PatreonQueryBuilder.defaultAuthKey;
			return @this;
		}
	}
}