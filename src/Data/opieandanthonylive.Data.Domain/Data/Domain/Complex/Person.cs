using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Ccr.Data.EntityFrameworkCore.Infrastucture;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace opieandanthonylive.Data.Domain.Complex
{
  public abstract class Person
    : EntityBase
  {
    protected class PersonImpl
      : Person
    {
      
    }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }


    public int? GenderID { get; set; }
    [CanBeNull, ForeignKey("GenderID")]
    public virtual Gender Gender { get; set; }


    [NotMapped]
    public string FullName
    {
      get
      {
        var sb = new StringBuilder();

        sb.Append(FirstName);

        if (!MiddleName.IsNullOrEmptyEx())
        {
          sb.Append(" ");
          sb.Append(MiddleName);
        }
        if (!LastName.IsNullOrEmptyEx())
        {
          sb.Append(" ");
          sb.Append(LastName);
        }
        return sb.ToString();
      }
      set
      {
        var person = PersonFactory.CreatePerson<PersonImpl>(value);

        FirstName = person.FirstName;
        MiddleName = person.MiddleName;
        LastName = person.LastName;
        //GenderID = person.GenderID;

      }
    }

    public string AlternateName { get; set; }
    
  }
}
