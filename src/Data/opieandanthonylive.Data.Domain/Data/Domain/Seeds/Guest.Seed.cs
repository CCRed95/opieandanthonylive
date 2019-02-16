using Ccr.Data.EntityFrameworkCore;

namespace opieandanthonylive.Data.Domain
{
	public static class GuestBuilderExtensions
	{
		public static Guest IsMale(this Guest @this)
		{
			@this.GenderID = 2;
			return @this;
		}
		public static Guest IsFemale(this Guest @this)
		{
			@this.GenderID = 3;
			return @this;
		}
	}
	public partial class Guest
		: ISeedableEntity
	{
		public static Guest Unknown_Guest = new Guest()
		{
			//GuestID = 001,
			LegacyGuestID = 30638,
			FirstName = "Unknown",
			LastName = "Guest",
			GenderID = 1,
			WebsiteUrl = "Unknown Guest.jpg"
		};
		public static Guest Nick_DiPaolo = new Guest
		{
			//GuestID = 002,
			LegacyGuestID = 30632,
			FirstName = "Nick",
			LastName = "DiPaolo",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Nick DiPaolo"
		}.IsMale();
		public static Guest Greg_Giraldo = new Guest
		{
			//GuestID = 003,
			LegacyGuestID = 30633,
			FirstName = "Greg",
			LastName = "Giraldo",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Greg Giraldo"
		}.IsMale();
		public static Guest Jim_Norton = new Guest
		{
			//GuestID = 004,
			LegacyGuestID = 30634,
			FirstName = "Jim",
			LastName = "Norton",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jim Norton"
		}.IsMale();
		public static Guest Keith_Robinson = new Guest
		{
			//GuestID = 005,
			LegacyGuestID = 30635,
			FirstName = "Keith",
			LastName = "Robinson",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Keith Robinson"
		}.IsMale();
		public static Guest Caroline_Rhea = new Guest
		{
			//GuestID = 006,
			LegacyGuestID = 30636,
			FirstName = "Caroline",
			LastName = "Rhea",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Caroline Rhea"
		}.IsFemale();
		public static Guest Rich_Vos = new Guest
		{
			//GuestID = 007,
			LegacyGuestID = 30637,
			FirstName = "Rich",
			LastName = "Vos",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Rich Vos"
		}.IsMale();
		public static Guest Jim_David = new Guest
		{
			//GuestID = 008,
			LegacyGuestID = 30639,
			FirstName = "Jim",
			LastName = "David",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jim David"
		}.IsMale();
		public static Guest Patrice_ONeal = new Guest
		{
			//GuestID = 009,
			LegacyGuestID = 30640,
			FirstName = "Patrice",
			LastName = "ONeal",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Patrice ONeal"
		}.IsMale();
		public static Guest Sarah_Silverman = new Guest
		{
			//GuestID = 010,
			LegacyGuestID = 30641,
			FirstName = "Sarah",
			LastName = "Silverman",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Sarah Silverman"
		}.IsFemale();
		public static Guest Jerry_Seinfeld = new Guest
		{
			//GuestID = 011,
			LegacyGuestID = 30642,
			FirstName = "Jerry",
			LastName = "Seinfeld",
			//GenderID = Gender.Male.GenderID,
			HeadshotImagePath = "Jerry Seinfeld.jpeg"
		}.IsMale();
		public static Guest Sue_Costello = new Guest
		{
			//GuestID = 012,
			LegacyGuestID = 30643,
			FirstName = "Sue",
			LastName = "Costello",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Sue Costello"
		}.IsFemale();
		public static Guest Janeane_Garofalo = new Guest
		{
			//GuestID = 013,
			LegacyGuestID = 30644,
			FirstName = "Janeane",
			LastName = "Garofalo",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Janeane Garofalo"
		}.IsFemale();
		public static Guest T_Sean_Shannon = new Guest
		{
			//GuestID = 014,
			LegacyGuestID = 30645,
			FirstName = "T.",
			MiddleName = "Sean",
			LastName = "Shannon",
			//GenderID = Gender.Male.GenderID,
			// FullName = "T. Sean Shannon"
		}.IsMale();
		public static Guest Judy_Gold = new Guest
		{
			//GuestID = 015,
			LegacyGuestID = 30646,
			FirstName = "Judy",
			LastName = "Gold",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Judy Gold"
		}.IsFemale();
		public static Guest Kevin_Hart = new Guest
		{
			//GuestID = 016,
			LegacyGuestID = 30647,
			FirstName = "Kevin",
			LastName = "Hart",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Kevin Hart"
		}.IsMale();
		public static Guest Marc_Maron = new Guest
		{
			//GuestID = 017,
			LegacyGuestID = 30648,
			FirstName = "Marc",
			LastName = "Maron",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Marc Maron"
		}.IsMale();
		public static Guest Eddie_Izzard = new Guest
		{
			//GuestID = 018,
			LegacyGuestID = 30649,
			FirstName = "Eddie",
			LastName = "Izzard",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Eddie Izzard"
		}.IsMale();
		public static Guest Chris_Rock = new Guest
		{
			//GuestID = 019,
			LegacyGuestID = 30650,
			FirstName = "Chris",
			LastName = "Rock",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Chris Rock"
		}.IsMale();
		public static Guest George_Carlin = new Guest
		{
			//GuestID = 020,
			LegacyGuestID = 30652,
			FirstName = "George",
			LastName = "Carlin",
			//GenderID = Gender.Male.GenderID,
			// FullName = "George Carlin"
		}.IsMale();
		public static Guest Dom_Irrera = new Guest
		{
			//GuestID = 021,
			LegacyGuestID = 30653,
			FirstName = "Dom",
			LastName = "Irrera",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Dom Irrera"
		}.IsMale();
		public static Guest Carole_Montgomery = new Guest
		{
			//GuestID = 022,
			LegacyGuestID = 30654,
			FirstName = "Carole",
			LastName = "Montgomery",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Carole Montgomery"
		}.IsFemale();
		public static Guest Scott_Thompson = new Guest
		{
			//GuestID = 023,
			LegacyGuestID = 30655,
			FirstName = "Scott",
			LastName = "Thompson",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Scott Thompson"
		}.IsMale();
		public static Guest Ray_Garvey = new Guest
		{
			//GuestID = 024,
			LegacyGuestID = 30656,
			FirstName = "Ray",
			LastName = "Garvey",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Ray Garvey"
		}.IsMale();
		public static Guest William_Stephenson = new Guest
		{
			//GuestID = 025,
			LegacyGuestID = 30657,
			FirstName = "William",
			LastName = "Stephenson",
			//GenderID = Gender.Male.GenderID,
			// FullName = "William Stephenson"
		}.IsMale();
		public static Guest Ed_Lover = new Guest
		{
			//GuestID = 026,
			LegacyGuestID = 30658,
			FirstName = "Ed",
			LastName = "Lover",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Ed Lover"
		}.IsMale();
		public static Guest Louis_CK = new Guest
		{
			//GuestID = 027,
			LegacyGuestID = 30659,
			FirstName = "Louis",
			LastName = "C.K.",
			AlternateName = "Louis CK",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Louis C.K."
		}.IsMale();
		public static Guest Ken_Ober = new Guest
		{
			//GuestID = 028,
			LegacyGuestID = 30660,
			FirstName = "Ken",
			LastName = "Ober",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Ken Ober"
		}.IsMale();
		public static Guest Pat_Cooper = new Guest
		{
			//GuestID = 029,
			LegacyGuestID = 30661,
			FirstName = "Pat",
			LastName = "Cooper",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Pat Cooper"
		}.IsMale();
		public static Guest Allan_Havey = new Guest
		{
			//GuestID = 030,
			LegacyGuestID = 30662,
			FirstName = "Allan",
			LastName = "Havey",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Allan Havey"
		}.IsMale();
		public static Guest Paul_Mooney = new Guest
		{
			//GuestID = 031,
			LegacyGuestID = 30663,
			FirstName = "Paul",
			LastName = "Mooney",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Paul Mooney"
		}.IsMale();
		public static Guest Graham_Norton = new Guest
		{
			//GuestID = 032,
			LegacyGuestID = 30664,
			FirstName = "Graham",
			LastName = "Norton",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Graham Norton"
		}.IsMale();
		public static Guest Ross_Bennett = new Guest
		{
			//GuestID = 033,
			LegacyGuestID = 30665,
			FirstName = "Ross",
			LastName = "Bennett",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Ross Bennett"
		}.IsMale();
		public static Guest Todd_Glass = new Guest
		{
			//GuestID = 034,
			LegacyGuestID = 30666,
			FirstName = "Todd",
			LastName = "Glass",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Todd Glass"
		}.IsMale();
		public static Guest Rich_Francese = new Guest
		{
			//GuestID = 035,
			LegacyGuestID = 30667,
			FirstName = "Rich",
			LastName = "Francese",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Rich Francese"
		}.IsMale();
		public static Guest Lewis_Black = new Guest
		{
			//GuestID = 036,
			LegacyGuestID = 30668,
			FirstName = "Lewis",
			LastName = "Black",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Lewis Black"
		}.IsMale();
		public static Guest Ardie_Fuqua = new Guest
		{
			//GuestID = 037,
			LegacyGuestID = 30669,
			FirstName = "Ardie",
			LastName = "Fuqua",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Ardie Fuqua",
			HeadshotImagePath = "Ardie Fuqua.jpeg"
		}.IsMale();
		public static Guest Matt_Walsh = new Guest
		{
			//GuestID = 038,
			LegacyGuestID = 30670,
			FirstName = "Matt",
			LastName = "Walsh",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Matt Walsh"
		}.IsMale();
		public static Guest Dov_Davidoff = new Guest
		{
			//GuestID = 039,
			LegacyGuestID = 30671,
			FirstName = "Dov",
			LastName = "Davidoff",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Dov Davidoff"
		}.IsMale();
		public static Guest Lea_Delaria = new Guest
		{
			//GuestID = 040,
			LegacyGuestID = 30672,
			FirstName = "Lea",
			LastName = "Delaria",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Lea Delaria"
		}.IsFemale();
		public static Guest Bobby_Collins = new Guest
		{
			//GuestID = 041,
			LegacyGuestID = 30673,
			FirstName = "Bobby",
			LastName = "Collins",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Bobby Collins"
		}.IsMale();
		public static Guest Sherry_Davey = new Guest
		{
			//GuestID = 042,
			LegacyGuestID = 30674,
			FirstName = "Sherry",
			LastName = "Davey",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Sherry Davey"
		}.IsFemale();
		public static Guest Bobby_Slayton = new Guest
		{
			//GuestID = 043,
			LegacyGuestID = 30675,
			FirstName = "Bobby",
			LastName = "Slayton",
			//GenderID = Gender.Male.GenderID,
			HeadshotImagePath = "Bobby Slayton.jpeg"
		}.IsMale();
		public static Guest Doug_Stanhope = new Guest
		{
			//GuestID = 044,
			LegacyGuestID = 30676,
			FirstName = "Doug",
			LastName = "Stanhope",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Doug Stanhope"
		}.IsMale();
		public static Guest Kerri_Louise = new Guest
		{
			//GuestID = 045,
			LegacyGuestID = 30677,
			FirstName = "Kerri",
			LastName = "Louise",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Kerri Louise"
		}.IsFemale();
		public static Guest Howie_Mandel = new Guest
		{
			//GuestID = 046,
			LegacyGuestID = 30678,
			FirstName = "Howie",
			LastName = "Mandel",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Howie Mandel"
		}.IsMale();
		public static Guest Robert_Schimmel = new Guest
		{
			//GuestID = 047,
			LegacyGuestID = 30679,
			FirstName = "Robert",
			LastName = "Schimmel",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Robert Schimmel"
		}.IsMale();
		public static Guest Hood = new Guest
		{
			//GuestID = 048,
			LegacyGuestID = 30680,
			FirstName = "Hood",
			LastName = "",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Hood"
		}.IsMale();
		public static Guest DL_Hughley = new Guest
		{
			//GuestID = 049,
			LegacyGuestID = 30681,
			FirstName = "D.L.",
			LastName = "Hughley",
			//GenderID = Gender.Male.GenderID,
			// FullName = "D.L. Hughley"
		}.IsMale();
		public static Guest Jeff_Foxworthy = new Guest
		{
			//GuestID = 050,
			LegacyGuestID = 30682,
			FirstName = "Jeff",
			LastName = "Foxworthy",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jeff Foxworthy"
		}.IsMale();
		public static Guest George_Wallace = new Guest
		{
			//GuestID = 051,
			LegacyGuestID = 30683,
			FirstName = "George",
			LastName = "Wallace",
			//GenderID = Gender.Male.GenderID,
			// FullName = "George Wallace"
		}.IsMale();
		public static Guest Bill_Burr = new Guest
		{
			//GuestID = 052,
			LegacyGuestID = 30684,
			FirstName = "Bill",
			LastName = "Burr",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Bill Burr"
		}.IsMale();
		public static Guest Hugh_Fink = new Guest
		{
			//GuestID = 053,
			LegacyGuestID = 30685,
			FirstName = "Hugh",
			LastName = "Fink",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Hugh Fink"
		}.IsMale();
		public static Guest Macio = new Guest
		{
			//GuestID = 054,
			LegacyGuestID = 30686,
			FirstName = "Macio",
			LastName = "",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Macio"
		}.IsMale();
		public static Guest Jamie_Kennedy = new Guest
		{
			//GuestID = 055,
			LegacyGuestID = 30687,
			FirstName = "Jamie",
			LastName = "Kennedy",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jamie Kennedy"
		}.IsMale();
		public static Guest Carlos_Mencia = new Guest
		{
			//GuestID = 056,
			LegacyGuestID = 30688,
			FirstName = "Carlos",
			LastName = "Mencia",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Carlos Mencia"
		}.IsMale();
		public static Guest Patton_Oswalt = new Guest
		{
			//GuestID = 057,
			LegacyGuestID = 30689,
			FirstName = "Patton",
			LastName = "Oswalt",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Patton Oswalt"
		}.IsMale();
		public static Guest Maria_Bamford = new Guest
		{
			//GuestID = 058,
			LegacyGuestID = 30690,
			FirstName = "Maria",
			LastName = "Bamford",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Maria Bamford"
		}.IsFemale();
		public static Guest Todd_Lynn = new Guest
		{
			//GuestID = 059,
			LegacyGuestID = 30691,
			FirstName = "Todd",
			LastName = "Lynn",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Todd Lynn"
		}.IsMale();
		public static Guest Andrew_Maxwell = new Guest
		{
			//GuestID = 060,
			LegacyGuestID = 30692,
			FirstName = "Andrew",
			LastName = "Maxwell",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Andrew Maxwell"
		}.IsMale();
		public static Guest Dave_Attell = new Guest
		{
			//GuestID = 061,
			LegacyGuestID = 30693,
			FirstName = "Dave",
			LastName = "Attell",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Dave Attell"
		}.IsMale();
		public static Guest Stephen_Colbert = new Guest
		{
			//GuestID = 062,
			LegacyGuestID = 30694,
			FirstName = "Stephen",
			LastName = "Colbert",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Stephen Colbert"
		}.IsMale();
		public static Guest Jake_Johannsen = new Guest
		{
			//GuestID = 063,
			LegacyGuestID = 30695,
			FirstName = "Jake",
			LastName = "Johannsen",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jake Johannsen"
		}.IsMale();
		public static Guest Lynne_Koplitz = new Guest
		{
			//GuestID = 064,
			LegacyGuestID = 30696,
			FirstName = "Lynne",
			LastName = "Koplitz",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Lynne Koplitz"
		}.IsFemale();
		public static Guest DC_Benny = new Guest
		{
			//GuestID = 065,
			LegacyGuestID = 30697,
			FirstName = "D.C.",
			LastName = "Benny",
			//GenderID = Gender.Male.GenderID,
			// FullName = "D.C. Benny"
		}.IsMale();
		public static Guest Greg_Proops = new Guest
		{
			//GuestID = 066,
			LegacyGuestID = 30698,
			FirstName = "Greg",
			LastName = "Proops",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Greg Proops"
		}.IsMale();
		public static Guest Alexandra_Wentworth = new Guest
		{
			//GuestID = 067,
			LegacyGuestID = 30699,
			FirstName = "Alexandra",
			LastName = "Wentworth",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Alexandra Wentworth"
		}.IsFemale();
		public static Guest Artie_Lange = new Guest
		{
			//GuestID = 068,
			LegacyGuestID = 30700,
			FirstName = "Artie",
			LastName = "Lange",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Artie Lange"
		}.IsMale();
		public static Guest Lizz_Winstead = new Guest
		{
			//GuestID = 069,
			LegacyGuestID = 30701,
			FirstName = "Lizz",
			LastName = "Winstead",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Lizz Winstead"
		}.IsFemale();
		public static Guest Wanda_Sykes = new Guest
		{
			//GuestID = 070,
			LegacyGuestID = 30702,
			FirstName = "Wanda",
			LastName = "Sykes",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Wanda Sykes"
		}.IsFemale();
		public static Guest Bob_Golub = new Guest
		{
			//GuestID = 071,
			LegacyGuestID = 30703,
			FirstName = "Bob",
			LastName = "Golub",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Bob Golub"
		}.IsMale();
		public static Guest Cory_Kahaney = new Guest
		{
			//GuestID = 072,
			LegacyGuestID = 30704,
			FirstName = "Cory",
			LastName = "Kahaney",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Cory Kahaney"
		}.IsFemale();
		public static Guest Brian_Posehn = new Guest
		{
			//GuestID = 073,
			LegacyGuestID = 30705,
			FirstName = "Brian",
			LastName = "Posehn",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Brian Posehn"
		}.IsMale();
		public static Guest Kevin_Robinson = new Guest
		{
			//GuestID = 074,
			LegacyGuestID = 30706,
			FirstName = "Kevin",
			LastName = "Robinson",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Kevin Robinson"
		}.IsMale();
		public static Guest Lenny_Clarke = new Guest
		{
			//GuestID = 075,
			LegacyGuestID = 30707,
			FirstName = "Lenny",
			LastName = "Clarke",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Lenny Clarke"
		}.IsMale();
		public static Guest Denis_Leary = new Guest
		{
			//GuestID = 076,
			LegacyGuestID = 30708,
			FirstName = "Denis",
			LastName = "Leary",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Denis Leary"
		}.IsMale();
		public static Guest Laura_Kightlinger = new Guest
		{
			//GuestID = 077,
			LegacyGuestID = 30709,
			FirstName = "Laura",
			LastName = "Kightlinger",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Laura Kightlinger"
		}.IsFemale();
		public static Guest Jimmy_Kimmel = new Guest
		{
			//GuestID = 078,
			LegacyGuestID = 30710,
			FirstName = "Jimmy",
			LastName = "Kimmel",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jimmy Kimmel"
		}.IsMale();
		public static Guest Todd_Barry = new Guest
		{
			//GuestID = 079,
			LegacyGuestID = 30711,
			FirstName = "Todd",
			LastName = "Barry",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Todd Barry"
		}.IsMale();
		public static Guest Colette_Hawley = new Guest
		{
			//GuestID = 080,
			LegacyGuestID = 30712,
			FirstName = "Colette",
			LastName = "Hawley",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Colette Hawley"
		}.IsFemale();
		public static Guest Sue_Murphy = new Guest
		{
			//GuestID = 081,
			LegacyGuestID = 30713,
			FirstName = "Sue",
			LastName = "Murphy",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Sue Murphy"
		}.IsMale();
		public static Guest Kevin_Meaney = new Guest
		{
			//GuestID = 082,
			LegacyGuestID = 30714,
			FirstName = "Kevin",
			LastName = "Meaney",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Kevin Meaney"
		}.IsMale();
		public static Guest Gregg_Rogell = new Guest
		{
			//GuestID = 083,
			LegacyGuestID = 30715,
			FirstName = "Gregg",
			LastName = "Rogell",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Gregg Rogell"
		}.IsMale();
		public static Guest Rudy_Rush = new Guest
		{
			//GuestID = 084,
			LegacyGuestID = 30716,
			FirstName = "Rudy",
			LastName = "Rush",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Rudy Rush"//TODO gender?
		}.IsMale();
		public static Guest Laurie_Kilmartin = new Guest
		{
			//GuestID = 085,
			LegacyGuestID = 30717,
			FirstName = "Laurie",
			LastName = "Kilmartin",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Laurie Kilmartin"
		}.IsFemale();
		public static Guest Mauric_e = new Guest
		{
			//GuestID = 086,
			LegacyGuestID = 30718,
			FirstName = "Maurice",
			LastName = "",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Maurice"
		}.IsMale();
		public static Guest Pete_Correale = new Guest
		{
			//GuestID = 087,
			LegacyGuestID = 30719,
			FirstName = "Pete",
			LastName = "Correale",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Pete Correale"
		}.IsMale();
		public static Guest Tom_Papa = new Guest
		{
			//GuestID = 088,
			LegacyGuestID = 30720,
			FirstName = "Tom",
			LastName = "Papa",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Tom Papa"
		}.IsMale();
		public static Guest Greer_Barnes = new Guest
		{
			//GuestID = 089,
			LegacyGuestID = 30721,
			FirstName = "Greer",
			LastName = "Barnes",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Greer Barnes"
		}.IsMale();
		public static Guest Paul_Mecurio = new Guest
		{
			//GuestID = 090,
			LegacyGuestID = 30722,
			FirstName = "Paul",
			LastName = "Mecurio",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Paul Mecurio"
		}.IsMale();
		public static Guest Richard_Belzer = new Guest
		{
			//GuestID = 091,
			LegacyGuestID = 30723,
			FirstName = "Richard",
			LastName = "Belzer",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Richard Belzer",
			HeadshotImagePath = "Richard Belzer.jpeg"
		}.IsMale();
		public static Guest Rene_Hicks = new Guest
		{
			//GuestID = 092,
			LegacyGuestID = 30724,
			FirstName = "Rene",
			LastName = "Hicks",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Rene Hicks"
		}.IsFemale();
		public static Guest James_Smith = new Guest
		{
			//GuestID = 093,
			LegacyGuestID = 30725,
			FirstName = "James",
			LastName = "Smith",
			//GenderID = Gender.Male.GenderID,
			HeadshotImagePath = "James Smith.jpeg"
		}.IsMale();
		public static Guest Flex_Alexander = new Guest
		{
			//GuestID = 094,
			LegacyGuestID = 30726,
			FirstName = "Flex",
			LastName = "Alexander",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Flex Alexander"
		}.IsMale();
		public static Guest Dante_Nero = new Guest
		{
			//GuestID = 095,
			LegacyGuestID = 30727,
			FirstName = "Dante",
			LastName = "Nero",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Dante Nero"
		}.IsMale();
		public static Guest Sunda_Croonquist = new Guest
		{
			//GuestID = 096,
			LegacyGuestID = 30728,
			FirstName = "Sunda",
			LastName = "Croonquist",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Sunda Croonquist"
		}.IsFemale();
		public static Guest David_Cross = new Guest
		{
			//GuestID = 097,
			LegacyGuestID = 30729,
			FirstName = "David",
			LastName = "Cross",
			//GenderID = Gender.Male.GenderID,
			// FullName = "David Cross"
		}.IsMale();
		public static Guest Vic_Henley = new Guest
		{
			//GuestID = 098,
			LegacyGuestID = 30730,
			FirstName = "Vic",
			LastName = "Henley",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Vic Henley"
		}.IsMale();
		public static Guest Robert_Klein = new Guest
		{
			//GuestID = 099,
			LegacyGuestID = 30731,
			FirstName = "Robert",
			LastName = "Klein",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Robert Klein"
		}.IsMale();
		public static Guest David_Alan_Grier = new Guest
		{
			//GuestID = 100,
			LegacyGuestID = 30732,
			FirstName = "David",
			MiddleName = "Alan",
			LastName = "Grier",
			//GenderID = Gender.Male.GenderID,
			// FullName = "David Alan Grier"
		}.IsMale();
		public static Guest Rich_Hall = new Guest
		{
			//GuestID = 101,
			LegacyGuestID = 30733,
			FirstName = "Rich",
			LastName = "Hall",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Rich Hall"
		}.IsMale();
		public static Guest Greg_Fitzsimmons = new Guest
		{
			//GuestID = 102,
			LegacyGuestID = 30734,
			FirstName = "Greg",
			LastName = "Fitzsimmons",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Greg Fitzsimmons"
		}.IsMale();
		public static Guest Bonnie_McFarlane = new Guest
		{
			//GuestID = 103,
			LegacyGuestID = 30735,
			FirstName = "Bonnie",
			LastName = "McFarlane",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Bonnie McFarlane"
		}.IsFemale();
		public static Guest Dave_Chappelle = new Guest
		{
			//GuestID = 104,
			LegacyGuestID = 30736,
			FirstName = "Dave",
			LastName = "Chappelle",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Dave Chappelle"
		}.IsMale();
		public static Guest Reggie_McFadden = new Guest
		{
			//GuestID = 105,
			LegacyGuestID = 30737,
			FirstName = "Reggie",
			LastName = "McFadden",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Reggie McFadden"
		}.IsMale();
		public static Guest Jimmy_Shubert = new Guest
		{
			//GuestID = 106,
			LegacyGuestID = 30738,
			FirstName = "Jimmy",
			LastName = "Shubert",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jimmy Shubert"
		}.IsMale();
		public static Guest Wayne_Federman = new Guest
		{
			//GuestID = 107,
			LegacyGuestID = 30739,
			FirstName = "Wayne",
			LastName = "Federman",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Wayne Federman"
		}.IsMale();
		public static Guest Kathy_Griffin = new Guest
		{
			//GuestID = 108,
			LegacyGuestID = 30740,
			FirstName = "Kathy",
			LastName = "Griffin",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Kathy Griffin"
		}.IsMale();
		public static Guest John_DiResta = new Guest
		{
			//GuestID = 109,
			LegacyGuestID = 30741,
			FirstName = "John",
			LastName = "DiResta",
			//GenderID = Gender.Male.GenderID,
			// FullName = "John DiResta"
		}.IsMale();
		public static Guest Ralphie_May = new Guest
		{
			//GuestID = 110,
			LegacyGuestID = 30742,
			FirstName = "Ralphie",
			LastName = "May",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Ralphie May"
		}.IsMale();
		public static Guest Mitch_Fatel = new Guest
		{
			//GuestID = 111,
			LegacyGuestID = 30743,
			FirstName = "Mitch",
			LastName = "Fatel",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Mitch Fatel"
		}.IsMale();
		public static Guest Nick_Gaza = new Guest
		{
			//GuestID = 112,
			LegacyGuestID = 30744,
			FirstName = "Nick",
			LastName = "Gaza",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Nick Gaza"
		}.IsMale();
		public static Guest Richard_Jeni = new Guest
		{
			//GuestID = 113,
			LegacyGuestID = 30745,
			FirstName = "Richard",
			LastName = "Jeni",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Richard Jeni"
		}.IsMale();
		public static Guest Lisa_Lampanelli = new Guest
		{
			//GuestID = 114,
			LegacyGuestID = 30746,
			FirstName = "Lisa",
			LastName = "Lampanelli",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Lisa Lampanelli"
		}.IsFemale();
		public static Guest Don_Gavin = new Guest
		{
			//GuestID = 115,
			LegacyGuestID = 30747,
			FirstName = "Don",
			LastName = "Gavin",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Don Gavin"
		}.IsMale();
		public static Guest Steve_Sweeney = new Guest
		{
			//GuestID = 116,
			LegacyGuestID = 30748,
			FirstName = "Steve",
			LastName = "Sweeney",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Steve Sweeney"
		}.IsMale();
		public static Guest Jimmy_Tingle = new Guest
		{
			//GuestID = 117,
			LegacyGuestID = 30749,
			FirstName = "Jimmy",
			LastName = "Tingle",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jimmy Tingle"
		}.IsMale();
		public static Guest Donnell_Rawlings = new Guest
		{
			//GuestID = 118,
			LegacyGuestID = 30750,
			FirstName = "Donnell",
			LastName = "Rawlings",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Donnell Rawlings"
		}.IsMale();
		public static Guest Franklyn_Ajaye = new Guest
		{
			//GuestID = 119,
			LegacyGuestID = 30751,
			FirstName = "Franklyn",
			LastName = "Ajaye",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Franklyn Ajaye"
		}.IsMale();
		public static Guest Ben_Bailey = new Guest
		{
			//GuestID = 120,
			LegacyGuestID = 30752,
			FirstName = "Ben",
			LastName = "Bailey",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Ben Bailey"
		}.IsMale();
		public static Guest Ty_Barnett = new Guest
		{
			//GuestID = 121,
			LegacyGuestID = 30753,
			FirstName = "Ty",
			LastName = "Barnett",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Ty Barnett"
		}.IsMale();
		public static Guest Vinnie_Brand = new Guest
		{
			//GuestID = 122,
			LegacyGuestID = 30754,
			FirstName = "Vinnie",
			LastName = "Brand",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Vinnie Brand"
		}.IsMale();
		public static Guest John_Mendoza = new Guest
		{
			//GuestID = 123,
			LegacyGuestID = 30755,
			FirstName = "John",
			LastName = "Mendoza",
			//GenderID = Gender.Male.GenderID,
			// FullName = "John Mendoza"
		}.IsMale();
		public static Guest Robert_Kelly = new Guest
		{
			//GuestID = 124,
			LegacyGuestID = 30756,
			FirstName = "Robert",
			LastName = "Kelly",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Robert Kelly"
		}.IsMale();
		public static Guest Barry_Weintraub = new Guest
		{
			//GuestID = 125,
			LegacyGuestID = 30757,
			FirstName = "Barry",
			LastName = "Weintraub",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Barry Weintraub"
		}.IsMale();
		public static Guest Kevin_Brennan = new Guest
		{
			//GuestID = 126,
			LegacyGuestID = 30758,
			FirstName = "Kevin",
			LastName = "Brennan",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Kevin Brennan"
		}.IsMale();
		public static Guest David_Feldman = new Guest
		{
			//GuestID = 127,
			LegacyGuestID = 30759,
			FirstName = "David",
			LastName = "Feldman",
			//GenderID = Gender.Male.GenderID,
			// FullName = "David Feldman"
		}.IsMale();
		public static Guest Dane_Cook = new Guest
		{
			//GuestID = 128,
			LegacyGuestID = 30760,
			FirstName = "Dane",
			LastName = "Cook",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Dane Cook"
		}.IsMale();
		public static Guest Bruce_Bruce = new Guest
		{
			//GuestID = 129,
			LegacyGuestID = 30761,
			FirstName = "Bruce",
			LastName = "Bruce",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Bruce Bruce"
		}.IsMale();
		public static Guest Tim_Young = new Guest
		{
			//GuestID = 130,
			LegacyGuestID = 30762,
			FirstName = "Tim",
			LastName = "Young",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Tim Young"
		}.IsMale();
		public static Guest John_Joseph = new Guest
		{
			//GuestID = 131,
			LegacyGuestID = 30763,
			FirstName = "John",
			LastName = "Joseph",
			//GenderID = Gender.Male.GenderID,
			// FullName = "John Joseph"
		}.IsMale();
		public static Guest Dina_Pearlman = new Guest
		{
			//GuestID = 132,
			LegacyGuestID = 30764,
			FirstName = "Dina",
			LastName = "Pearlman",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Dina Pearlman"
		}.IsMale();
		public static Guest Drew_Hastings = new Guest
		{
			//GuestID = 133,
			LegacyGuestID = 30765,
			FirstName = "Drew",
			LastName = "Hastings",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Drew Hastings"
		}.IsMale();
		public static Guest Goumba_Johnny = new Guest
		{
			//GuestID = 134,
			LegacyGuestID = 30766,
			FirstName = "Goumba",
			LastName = "Johnny",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Goumba Johnny"
		}.IsMale();
		public static Guest Dat_Phan = new Guest
		{
			//GuestID = 135,
			LegacyGuestID = 30767,
			FirstName = "Dat",
			LastName = "Phan",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Dat Phan"
		}.IsMale();
		public static Guest Eddie_Brill = new Guest
		{
			//GuestID = 136,
			LegacyGuestID = 30768,
			FirstName = "Eddie",
			LastName = "Brill",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Eddie Brill"
		}.IsMale();
		public static Guest Jackie_Kashian = new Guest
		{
			//GuestID = 137,
			LegacyGuestID = 30769,
			FirstName = "Jackie",
			LastName = "Kashian",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Jackie Kashian"
		}.IsFemale();
		public static Guest Laura_Dinnebeil = new Guest
		{
			//GuestID = 138,
			LegacyGuestID = 30770,
			FirstName = "Laura",
			LastName = "Dinnebeil",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Laura Dinnebeil"
		}.IsFemale();
		public static Guest Rick_Shapiro = new Guest
		{
			//GuestID = 139,
			LegacyGuestID = 30771,
			FirstName = "Rick",
			LastName = "Shapiro",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Rick Shapiro"
		}.IsMale();
		public static Guest Dan_Vitale = new Guest
		{
			//GuestID = 140,
			LegacyGuestID = 30772,
			FirstName = "Dan",
			LastName = "Vitale",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Dan Vitale"
		}.IsMale();
		public static Guest Becky_Donohue = new Guest
		{
			//GuestID = 141,
			LegacyGuestID = 30773,
			FirstName = "Becky",
			LastName = "Donohue",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Becky Donohue"
		}.IsMale();
		public static Guest Judah_Friedlander = new Guest
		{
			//GuestID = 142,
			LegacyGuestID = 30774,
			FirstName = "Judah",
			LastName = "Friedlander",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Judah Friedlander"
		}.IsMale();
		public static Guest Dave_Mordal = new Guest
		{
			//GuestID = 143,
			LegacyGuestID = 30775,
			FirstName = "Dave",
			LastName = "Mordal",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Dave Mordal"
		}.IsMale();
		public static Guest Joe_Rogan = new Guest
		{
			//GuestID = 144,
			LegacyGuestID = 30776,
			FirstName = "Joe",
			LastName = "Rogan",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Joe Rogan"
		}.IsMale();
		public static Guest Jimmy_Martinez = new Guest
		{
			//GuestID = 145,
			LegacyGuestID = 30777,
			FirstName = "Jimmy",
			LastName = "Martinez",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jimmy Martinez"
		}.IsMale();
		public static Guest Ian_Bagg = new Guest
		{
			//GuestID = 146,
			LegacyGuestID = 30778,
			FirstName = "Ian",
			LastName = "Bagg",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Ian Bagg"
		}.IsMale();
		public static Guest Paul_F_Tompkins = new Guest
		{
			//GuestID = 147,
			LegacyGuestID = 30779,
			FirstName = "Paul",
			MiddleName = "F",
			LastName = "Tompkins",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Paul F. Tompkins"
		}.IsMale();
		public static Guest Adam_Ferrara = new Guest
		{
			//GuestID = 148,
			LegacyGuestID = 30780,
			FirstName = "Adam",
			LastName = "Ferrara",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Adam Ferrara"
		}.IsMale();
		public static Guest Jeffrey_Ross = new Guest
		{
			//GuestID = 149,
			LegacyGuestID = 30781,
			FirstName = "Jeffrey",
			LastName = "Ross",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jeffrey Ross"
		}.IsMale();
		public static Guest Pauly_Shore = new Guest
		{
			//GuestID = 150,
			LegacyGuestID = 30782,
			FirstName = "Pauly",
			LastName = "Shore",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Pauly Shore"
		}.IsMale();
		public static Guest Susie_Essman = new Guest
		{
			//GuestID = 151,
			LegacyGuestID = 30783,
			FirstName = "Susie",
			LastName = "Essman",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Susie Essman"
		}.IsFemale();
		public static Guest Jeff_Garlin = new Guest
		{
			//GuestID = 152,
			LegacyGuestID = 30784,
			FirstName = "Jeff",
			LastName = "Garlin",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jeff Garlin"
		}.IsMale();
		public static Guest John_Marshall = new Guest
		{
			//GuestID = 153,
			LegacyGuestID = 30785,
			FirstName = "John",
			LastName = "Marshall",
			//GenderID = Gender.Male.GenderID,
			// FullName = "John Marshall"
		}.IsMale();
		public static Guest Mario_Cantone = new Guest
		{
			//GuestID = 154,
			LegacyGuestID = 30786,
			FirstName = "Mario",
			LastName = "Cantone",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Mario Cantone"
		}.IsMale();
		public static Guest Doctor_Dre = new Guest
		{
			//GuestID = 155,
			LegacyGuestID = 30787,
			FirstName = "Doctor",
			LastName = "Dré",
			AlternateName = "Doctor Dre",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Doctor Dre"
		}.IsMale();
		public static Guest Vanessa_Hollingshead = new Guest
		{
			//GuestID = 156,
			LegacyGuestID = 30788,
			FirstName = "Vanessa",
			LastName = "Hollingshead",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Vanessa Hollingshead"
		}.IsFemale();
		public static Guest Andy_Kindler = new Guest
		{
			//GuestID = 157,
			LegacyGuestID = 30789,
			FirstName = "Andy",
			LastName = "Kindler",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Andy Kindler"
		}.IsMale();
		public static Guest Louis_Ramey = new Guest
		{
			//GuestID = 158,
			LegacyGuestID = 30790,
			FirstName = "Louis",
			LastName = "Ramey",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Louis Ramey"
		}.IsMale();
		public static Guest Pete_Tubbs = new Guest
		{
			//GuestID = 159,
			LegacyGuestID = 30791,
			FirstName = "Pete",
			LastName = "Tubbs",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Pete Tubbs"
		}.IsMale();
		public static Guest Rick_Crom = new Guest
		{
			//GuestID = 160,
			LegacyGuestID = 30792,
			FirstName = "Rick",
			LastName = "Crom",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Rick Crom"
		}.IsMale();
		public static Guest Ben_Stein = new Guest
		{
			//GuestID = 161,
			LegacyGuestID = 30793,
			FirstName = "Ben",
			LastName = "Stein",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Ben Stein"
		}.IsMale();
		public static Guest Mike_Britt = new Guest
		{
			//GuestID = 162,
			LegacyGuestID = 30794,
			FirstName = "Mike",
			LastName = "Britt",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Mike Britt"
		}.IsMale();
		public static Guest Andrew_Dice_Clay = new Guest
		{
			//GuestID = 163,
			LegacyGuestID = 30795,
			FirstName = "Andrew",
			MiddleName = "Dice",
			LastName = "Clay",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Andrew Dice Clay"
		}.IsMale();
		public static Guest Jim_Florentine = new Guest
		{
			//GuestID = 164,
			LegacyGuestID = 30796,
			FirstName = "Jim",
			LastName = "Florentine",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jim Florentine"
		}.IsMale();
		public static Guest Bernadette_Pauley = new Guest
		{
			//GuestID = 165,
			LegacyGuestID = 30797,
			FirstName = "Bernadette",
			LastName = "Pauley",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Bernadette Pauley"
		}.IsMale();
		public static Guest Mo_Rocca = new Guest
		{
			//GuestID = 166,
			LegacyGuestID = 30798,
			FirstName = "Mo",
			LastName = "Rocca",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Mo Rocca"
		}.IsMale();
		public static Guest Jim_Gaffigan = new Guest
		{
			//GuestID = 167,
			LegacyGuestID = 30799,
			FirstName = "Jim",
			LastName = "Gaffigan",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jim Gaffigan"
		}.IsMale();
		public static Guest Mishna_Wolff = new Guest
		{
			//GuestID = 168,
			LegacyGuestID = 30800,
			FirstName = "Mishna",
			LastName = "Wolff",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Mishna Wolff"
		}.IsFemale();
		public static Guest Ellen_Cleghorne = new Guest
		{
			//GuestID = 169,
			LegacyGuestID = 30801,
			FirstName = "Ellen",
			LastName = "Cleghorne",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Ellen Cleghorne"
		}.IsFemale();
		public static Guest Jay_Mohr = new Guest
		{
			//GuestID = 170,
			LegacyGuestID = 30802,
			FirstName = "Jay",
			LastName = "Mohr",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jay Mohr"
		}.IsMale();
		public static Guest Kathleen_Madigan = new Guest
		{
			//GuestID = 171,
			LegacyGuestID = 30803,
			FirstName = "Kathleen",
			LastName = "Madigan",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Kathleen Madigan"
		}.IsFemale();
		public static Guest Tony_Woods = new Guest
		{
			//GuestID = 172,
			LegacyGuestID = 30804,
			FirstName = "Tony",
			LastName = "Woods",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Tony Woods"
		}.IsMale();
		public static Guest Dan_Naturman = new Guest
		{
			//GuestID = 173,
			LegacyGuestID = 30805,
			FirstName = "Dan",
			LastName = "Naturman",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Dan Naturman"
		}.IsMale();
		public static Guest Buddy_Bolton = new Guest
		{
			//GuestID = 174,
			LegacyGuestID = 30806,
			FirstName = "Buddy",
			LastName = "Bolton",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Buddy Bolton"
		}.IsMale();
		public static Guest Hal_Sparks = new Guest
		{
			//GuestID = 175,
			LegacyGuestID = 30807,
			FirstName = "Hal",
			LastName = "Sparks",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Hal Sparks"
		}.IsMale();
		public static Guest Fran_Solomita = new Guest
		{
			//GuestID = 176,
			LegacyGuestID = 30808,
			FirstName = "Fran",
			LastName = "Solomita",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Fran Solomita"
		}.IsMale();
		public static Guest Tony_V = new Guest
		{
			//GuestID = 177,
			LegacyGuestID = 30809,
			FirstName = "Tony",
			LastName = "V",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Tony V"
		}.IsMale();
		public static Guest Drew_Fraser = new Guest
		{
			//GuestID = 178,
			LegacyGuestID = 30810,
			FirstName = "Drew",
			LastName = "Fraser",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Drew Fraser"
		}.IsMale();
		public static Guest Maz_Jobrani = new Guest
		{
			//GuestID = 179,
			LegacyGuestID = 30811,
			FirstName = "Maz",
			LastName = "Jobrani",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Maz Jobrani"
		}.IsMale();
		public static Guest Mark_Ebner = new Guest
		{
			//GuestID = 180,
			LegacyGuestID = 30812,
			FirstName = "Mark",
			LastName = "Ebner",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Mark Ebner"
		}.IsMale();
		public static Guest Leighann_Lord = new Guest
		{
			//GuestID = 181,
			LegacyGuestID = 30813,
			FirstName = "Leighann",
			LastName = "Lord",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Leighann Lord"
		}.IsFemale();
		public static Guest Frankie_Pace = new Guest
		{
			//GuestID = 182,
			LegacyGuestID = 30814,
			FirstName = "Frankie",
			LastName = "Pace",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Frankie Pace"
		}.IsMale();
		public static Guest Greg_Behrendt = new Guest
		{
			//GuestID = 183,
			LegacyGuestID = 30815,
			FirstName = "Greg",
			LastName = "Behrendt",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Greg Behrendt"
		}.IsMale();
		public static Guest Ted_Alexandro = new Guest
		{
			//GuestID = 184,
			LegacyGuestID = 30816,
			FirstName = "Ted",
			LastName = "Alexandro",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Ted Alexandro"
		}.IsMale();
		public static Guest Penn_Jillette = new Guest
		{
			//GuestID = 185,
			LegacyGuestID = 30817,
			FirstName = "Penn",
			LastName = "Jillette",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Penn Jillette"
		}.IsMale();
		public static Guest Tony_Camin = new Guest
		{
			//GuestID = 186,
			LegacyGuestID = 30818,
			FirstName = "Tony",
			LastName = "Camin",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Tony Camin"
		}.IsMale();
		public static Guest Mike_Sweeney = new Guest
		{
			//GuestID = 187,
			LegacyGuestID = 30819,
			FirstName = "Mike",
			LastName = "Sweeney",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Mike Sweeney"
		}.IsMale();
		public static Guest Sheryl_Underwood = new Guest
		{
			//GuestID = 188,
			LegacyGuestID = 30820,
			FirstName = "Sheryl",
			LastName = "Underwood",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Sheryl Underwood"
		}.IsFemale();
		public static Guest Carrot_Top = new Guest
		{
			//GuestID = 189,
			LegacyGuestID = 30821,
			FirstName = "Carrot",
			LastName = "Top",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Carrot Top"
		}.IsMale();
		public static Guest Frank_Santorelli = new Guest
		{
			//GuestID = 190,
			LegacyGuestID = 30822,
			FirstName = "Frank",
			LastName = "Santorelli",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Frank Santorelli"
		}.IsMale();
		public static Guest Kyle_Grooms = new Guest
		{
			//GuestID = 191,
			LegacyGuestID = 30823,
			FirstName = "Kyle",
			LastName = "Grooms",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Kyle Grooms"
		}.IsMale();
		public static Guest Jeff_Cesario = new Guest
		{
			//GuestID = 192,
			LegacyGuestID = 30824,
			FirstName = "Jeff",
			LastName = "Cesario",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jeff Cesario"
		}.IsMale();
		public static Guest Chris_Murphy = new Guest
		{
			//GuestID = 193,
			LegacyGuestID = 30825,
			FirstName = "Chris",
			LastName = "Murphy",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Chris Murphy"
		}.IsMale();
		public static Guest Al_Lubel = new Guest
		{
			//GuestID = 194,
			LegacyGuestID = 30826,
			FirstName = "Al",
			LastName = "Lubel",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Al Lubel"
		}.IsMale();
		public static Guest Frank_Vignola = new Guest
		{
			//GuestID = 195,
			LegacyGuestID = 30827,
			FirstName = "Frank",
			LastName = "Vignola",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Frank Vignola"
		}.IsMale();
		public static Guest Jim_Mendrinos = new Guest
		{
			//GuestID = 196,
			LegacyGuestID = 30828,
			FirstName = "Jim",
			LastName = "Mendrinos",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jim Mendrinos"
		}.IsMale();
		public static Guest Jackie_Mason = new Guest
		{
			//GuestID = 197,
			LegacyGuestID = 30829,
			FirstName = "Jackie",
			LastName = "Mason",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jackie Mason"
		}.IsMale();
		public static Guest Steve_Byrne = new Guest
		{
			//GuestID = 198,
			LegacyGuestID = 30830,
			FirstName = "Steve",
			LastName = "Byrne",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Steve Byrne"
		}.IsMale();
		public static Guest Omid_Djalili = new Guest
		{
			//GuestID = 199,
			LegacyGuestID = 30831,
			FirstName = "Omid",
			LastName = "Djalili",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Omid Djalili"
		}.IsMale();
		public static Guest Karen_Bergreen = new Guest
		{
			//GuestID = 200,
			LegacyGuestID = 30832,
			FirstName = "Karen",
			LastName = "Bergreen",
			//GenderID = Gender.Female.GenderID,
			// FullName = "Karen Bergreen"
		}.IsFemale();
		public static Guest Tim_Meadows = new Guest
		{
			//GuestID = 201,
			LegacyGuestID = 30833,
			FirstName = "Tim",
			LastName = "Meadows",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Tim Meadows"
		}.IsMale();
		public static Guest Tom_Cotter = new Guest
		{
			//GuestID = 202,
			LegacyGuestID = 30834,
			FirstName = "Tom",
			LastName = "Cotter",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Tom Cotter"
		}.IsMale();
		public static Guest John_Fugelsang = new Guest
		{
			//GuestID = 203,
			LegacyGuestID = 30835,
			FirstName = "John",
			LastName = "Fugelsang",
			//GenderID = Gender.Male.GenderID,
			// FullName = "John Fugelsang"
		}.IsMale();
		public static Guest Jon_Stewart = new Guest
		{
			//GuestID = 204,
			LegacyGuestID = 30836,
			FirstName = "Jon",
			LastName = "Stewart",
			//GenderID = Gender.Male.GenderID,
			// FullName = "Jon Stewart"
		}.IsMale();
	}
}

