using opieandanthonylive.Data.Domain.Archive;
using opieandanthonylive.Data.Domain.Archive.Responses;

namespace opieandanthonylive.Data.API.Archive.Interpreters
{
	public class ArchiveAlbumInterpreter
	{
		public static ArchiveAlbum CreateArchiveAlbum(
			Doc doc)
		{
			ContentCreator GetCreator()
			{
				if (doc.Identifier.Contains("RF"))
					return ContentCreator.Ron_and_Fez;

				if (doc.Identifier.Contains("OA"))
					return ContentCreator.Opie_and_Anthony;

				if (doc.Identifier.Contains("RG"))
					return ContentCreator.Ricky_Gervais;

				return null;
			}

			return new ArchiveAlbum(
				doc.Identifier,
				GetCreator(),
				doc.Description,
				doc.Date,
				doc.Date.Year,
				doc.Date.Month,
				ArchiveFileInterpreter.ScrapeArchiveFiles);
		}
	}
}