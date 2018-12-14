namespace opieandanthonylive.Controllers {

  using Microsoft.AspNetCore.Mvc;
  using System.Collections.Generic;
  using System.Linq;

  public class GuestDto {
    public int Id { get; set; }
    public string Name { get; set; }
    public string HeadshotImagePath { get; set; }
  }

  public interface IGuestsService {
    List<GuestDto> GetAllGuests();
    GuestDto       GetGuest(int id);
  }

  public class HardcodedGuestsService : IGuestsService {

    static readonly string[] guestNames = new[] {
      "Adam Ferrara", "Al Lubel", "Alexandra Wentworth", "Allan Havey",
      "Andrew Dice Clay", "Andrew Maxwell", "Andy Kindler", "Ardie Fuqua",
      "Artie Lange", "Barry Weintraub", "Becky Donohue", "Ben Bailey",
      "Ben Stein", "Bernadette Pauley", "Bill Burr", "Bob Golub",
      "Bobby Collins", "Bobby Kelly", "Bobby Lee", "Bobby Slayton",
      "Bonnie McFarlane", "Brian Posehn", "Bruce Bruce", "Buddy Bolton",
      "Carlos Mencia", "Carole Montgomery", "Caroline Rhea", "Carrot Top",
      "Chris Murphy", "Chris Rock", "Colette Hawley", "Colin Quinn",
      "Cory Kahaney", "D.C. Benny", "D.L. Hughley", "Dan Naturman",
      "Dan Vitale", "Dane Cook", "Dante Nero", "Dat Phan", "Dave Attell",
      "Dave Chappelle", "Dave Mordal", "David Alan Grier", "David Cross",
      "David Feldman", "Denis Leary", "Dina Pearlman", "Doctor Dre",
      "Dom Irrera", "Don Gavin", "Donnell Rawlings", "Doug Stanhope",
      "Dov Davidoff", "Drew Fraser", "Drew Hastings", "Ed Lover",
      "Eddie Brill", "Eddie Izzard", "Ellen Cleghorne", "Flex Alexander",
      "Fran Solomita", "Frank Santorelli", "Frank Vignola", "Frankie Pace",
      "Franklyn Ajaye", "George Carlin", "George Wallace", "Goumba Johnny",
      "Graham Norton", "Greer Barnes", "Greg Behrendt", "Greg Fitzsimmons",
      "Greg Giraldo", "Greg Proops", "Gregg Rogell", "Hal Sparks",
      "Howie Mandel", "Hugh Fink", "Ian Bagg", "Jackie Kashian",
      "Jackie Mason", "Jake Johannsen", "James Smith", "Jamie Kennedy",
      "Janeane Garofalo", "Jay Mohr", "Jeff Cesario", "Jeff Foxworthy",
      "Jeff Garlin", "Jeffrey Ross", "Jerry Seinfeld", "Jim David",
      "Jim Florentine", "Jim Gaffigan", "Jim Jefferies", "Jim Mendrinos",
      "Jim Norton", "Jimmy Kimmel", "Jimmy Martinez", "Jimmy Shubert",
      "Jimmy Tingle", "Joe Rogan", "John DiResta", "John Fugelsang",
      "John Joseph", "John Marshall", "John Mendoza", "Jon Stewart",
      "Judah Friedlander", "Judy Gold", "Karen Bergreen", "Karl Pilkington",
      "Kathleen Madigan", "Kathy Griffin", "Keith Robinson", "Ken Ober",
      "Kerri Louise", "Kevin Brennan", "Kevin Hart", "Kevin Meaney",
      "Kevin Robinson", "Kyle Grooms", "Laura Dinnebeil", "Laura Kightlinger",
      "Laurie Kilmartin", "Lea Delaria", "Leighann Lord", "Lenny Clarke",
      "Lewis Black", "Lisa Lampanelli", "Lizz Winstead", "Louis C.K.",
      "Louis Ramey", "Lynne Koplitz", "Macio", "Marc Maron", "Maria Bamford",
      "Mario Cantone", "Mark Ebner", "Matt Walsh", "Maurice", "Maz Jobrani",
      "Mike Britt", "Mike Sweeney", "Mishna Wolff", "Mitch Fatel", "Mo Rocca",
      "Nick DiPaolo", "Nick Gaza", "Norm MacDonald", "Omid Djalili",
      "Pat Cooper", "Patrice ONeal", "Patton Oswalt", "Paul F. Tompkins",
      "Paul Mecurio", "Paul Mooney", "Pauly Shore", "Penn Jillette",
      "Pete Correale", "Pete Tubbs", "Ralphie May", "Ray Garvey",
      "Reggie McFadden", "Rene Hicks", "Rich Francese", "Rich Hall",
      "Rich Vos", "Richard Belzer", "Richard Jeni", "Rick Crom",
      "Rick Shapiro", "Ricky Gervais", "Robert Kelly", "Robert Klein",
      "Robert Schimmel", "Ross Bennett", "Rudy Rush", "Sarah Silverman",
      "Scott Thompson", "Sherry Davey", "Sheryl Underwood", "Stephen Colbert",
      "Stephen Merchant", "Steve Byrne", "Steve Sweeney", "Sue Costello",
      "Sue Murphy", "Sunda Croonquist", "Susie Essman", "T. Sean Shannon",
      "Ted Alexandro", "Tim Meadows", "Tim Young", "Todd Barry", "Todd Glass",
      "Todd Lynn", "Tom Cotter", "Tom Papa", "Tony Camin", "Tony V",
      "Tony Woods", "Ty Barnett","Vanessa Hollingshead", "Vic Henley",
      "Vinnie Brand", "Wanda Sykes", "Wayne Federman", "William Stephenson",
    };

    static readonly List<GuestDto> Guests =
      guestNames.Select((fullName, i) => {
        return new GuestDto {
          Id = i,
          Name = fullName,
          HeadshotImagePath = $"http://opieandanthonylive.info/alpha3/images/{fullName}.jpg",
        };
      }).ToList();

    public List<GuestDto> GetAllGuests() =>
      Guests;

    public GuestDto GetGuest(int id) =>
      0 <= id && id < Guests.Count
        ? Guests[id]
        : null;

  }

  [Route("api/[controller]")]
  public class GuestsController : Controller {

    readonly IGuestsService service;

    public GuestsController(IGuestsService service) =>
      this.service = service;

    [HttpGet("{id}")]
    public IActionResult Get(int id) {
      var guest = this.service.GetGuest(id);
      return guest == null
        ? (IActionResult)this.NotFound()
        : (IActionResult)this.Ok(guest);

    }

  }

  class ShowGuestDto {
    public string Name { get; set; }
    public string Image { get; set; }
    public int Shows { get; set; }
  }

  [Route("api/[controller]")]
  public class ShowsController : Controller {

    readonly IGuestsService service;

    public ShowsController(IGuestsService service) =>
      this.service = service;

    [HttpGet("{showId}/guests")]
    public IActionResult Get(int showId) {

      if (showId != 1)
        return this.Ok(new List<GuestDto>());

      var r = new System.Random();
      return this.Ok(
        this.service.GetAllGuests()
          .Select(x => new ShowGuestDto {
            Name = x.Name,
            Image = x.HeadshotImagePath,
            Shows = r.Next(0, 1000),
          })
          .OrderByDescending(x => x.Shows)
      );

    }

  }

}
