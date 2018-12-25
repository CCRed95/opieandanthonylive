using System.Runtime.CompilerServices;
using Ccr.Data.EntityFrameworkCore.Infrastucture;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace opieandanthonylive.Data.Domain
{
	public partial class ShowRundownAuthor
    : EntityBase
  {
	  public int ShowRundownAuthorID { get; set; }

		public string AuthorName { get; set; }


    private ShowRundownAuthor() { }

		public ShowRundownAuthor(
			[NotNull] string authorName)
		    : this()
		{
			authorName.IsNotNull(nameof(authorName));

			AuthorName = authorName;
		}

		private ShowRundownAuthor(
			int showRundownAuthorID,
			[NotNull, CallerMemberName] string memberName = "")
		    : this(
		      memberName.Replace('_', ' '))
		{
			ShowRundownAuthorID = showRundownAuthorID;
		}
	}
}
