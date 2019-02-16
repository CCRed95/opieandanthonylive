namespace opieandanthonylive.Data.API.Patreon.Query
{
	public static class ShoutEngineBuilderExtensions
	{
		public static ShoutEngineQueryBuilder FromCreator(
			this ShoutEngineQueryBuilder @this,
			string creatorName)
		{
			@this.CreatorName = creatorName;
			return @this;
		}
	}
}