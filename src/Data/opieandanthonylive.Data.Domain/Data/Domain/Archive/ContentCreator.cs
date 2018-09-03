using System.Runtime.CompilerServices;

namespace opieandanthonylive.Data.Domain.Archive
{
  public partial class ContentCreator
  {
    public int ContentCreatorID { get; set; }

    public string ContentCreatorName { get; set; }


    private ContentCreator()
    {
    }

    public ContentCreator(
      [CallerMemberName] string memberName = "")
        : this()
    {
      ContentCreatorName = memberName.Replace("_", " ");
    }

    private ContentCreator(
      int contentCreatorID,
      [CallerMemberName] string memberName = "") 
        : this()
    {
      ContentCreatorID = contentCreatorID;
      ContentCreatorName = memberName.Replace("_", " ");
    }
  }
}
