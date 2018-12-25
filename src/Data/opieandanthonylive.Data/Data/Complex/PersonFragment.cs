using System.ComponentModel.DataAnnotations.Schema;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;
using opieandanthonylive.Data.Domain;

namespace opieandanthonylive.Data.Complex
{
  public abstract class PersonFragment
  {
   
    [NotNull]
    public string FirstName { get; set; }

    [CanBeNull]
    public string MiddleName { get; set; }

    [CanBeNull]
    public string MiddleInitial { get; set; }

    [NotNull]
    public string LastName { get; set; }

    //public int GenderID { get; set; }
    //[CanBeNull, ForeignKey("GenderID")]
    //public virtual Gender Gender { get; set; }



    protected PersonFragment() { }

    protected PersonFragment(
      [NotNull] string firstName,
      [NotNull] string lastName) : this(
        firstName,
        null,
        lastName,
        null)
    {
    }

    protected PersonFragment(
      [NotNull] string firstName,
      [NotNull] string middleNameOrInitial,
      [NotNull] string lastName) : this(
        firstName,
        middleNameOrInitial,
        lastName,
        null)
    {
    }

    protected PersonFragment(
      [NotNull] string firstName,
      [NotNull] string lastName,
      [NotNull] Gender gender) : this(
        firstName,
        null,
        lastName,
        gender)
    {
    }

    protected PersonFragment(
      [NotNull] string firstName,
      [CanBeNull] string middleNameOrInitial,
      [NotNull] string lastName,
      [CanBeNull] Gender gender) : this()
    {
      firstName.IsNotNull(nameof(firstName));
      lastName.IsNotNull(nameof(lastName));

      if (gender == null)
        gender = Gender.Unset;

      FirstName = firstName
        .Trim()
        .ToTitleCase();

      LastName = lastName
        .Trim()
        .ToTitleCase();

      //TODO Gender = gender;

      if (middleNameOrInitial == null)
        return;

      middleNameOrInitial = middleNameOrInitial
        .Trim()
        .ToTitleCase();

      if (!middleNameOrInitial.IsNullOrEmptyEx())
      {
        if (middleNameOrInitial.Length == 1)
        {
          MiddleInitial = middleNameOrInitial[0].ToString();
          MiddleName = null;
        }
        else if (middleNameOrInitial.Length == 2)
        {
          if (middleNameOrInitial[1] == '.')
          {
            MiddleInitial = middleNameOrInitial[0].ToString();
            MiddleName = null;
          }
          else
          {
            MiddleName = middleNameOrInitial
              .ToTitleCase()
              .Trim();

            MiddleInitial = MiddleName[0].ToString();
          }
        }
      }
      else
      {
        MiddleName = middleNameOrInitial
          .ToTitleCase()
          .Trim();

        MiddleInitial = MiddleName[0].ToString();
      }
    }
  }
}
