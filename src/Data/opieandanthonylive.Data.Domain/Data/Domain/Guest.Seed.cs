using Ccr.Data.EntityFrameworkCore;

namespace opieandanthonylive.Data.Domain
{
  public partial class Guest
    : ISeedableEntity
  {
    public static Guest Unknown_Guest = new Guest()
    { 
      GuestID = 001,
      LegacyGuestID = 30638,
      FirstName = "Unknown",
      LastName = "Guest",
      Gender = Gender.Unset,
      WebsiteUrl = "Unknown Guest.jpg"
    };
    public static Guest Nick_DiPaolo = new Guest
    {
      GuestID = 002,
      LegacyGuestID = 30632,
      FirstName = "Nick",
      LastName = "DiPaolo",
      Gender = Gender.Male,
      // FullName = "Nick DiPaolo"
    };
    public static Guest Greg_Giraldo = new Guest
    {
      GuestID = 003,
      LegacyGuestID = 30633,
      FirstName = "Greg",
      LastName = "Giraldo",
      Gender = Gender.Male,
      // FullName = "Greg Giraldo"
    };
    public static Guest Jim_Norton = new Guest
    {
      GuestID = 004,
      LegacyGuestID = 30634,
      FirstName = "Jim",
      LastName = "Norton",
      Gender = Gender.Male,
      // FullName = "Jim Norton"
    };
    public static Guest Keith_Robinson = new Guest
    {
      GuestID = 005,
      LegacyGuestID = 30635,
      FirstName = "Keith",
      LastName = "Robinson",
      Gender = Gender.Male,
      // FullName = "Keith Robinson"
    };
    public static Guest Caroline_Rhea = new Guest
    {
      GuestID = 006,
      LegacyGuestID = 30636,
      FirstName = "Caroline",
      LastName = "Rhea",
      Gender = Gender.Female,
      // FullName = "Caroline Rhea"
    };
    public static Guest Rich_Vos = new Guest
    {
      GuestID = 007,
      LegacyGuestID = 30637,
      FirstName = "Rich",
      LastName = "Vos",
      Gender = Gender.Male,
      // FullName = "Rich Vos"
    };
    public static Guest Jim_David = new Guest
    {
      GuestID = 008,
      LegacyGuestID = 30639,
      FirstName = "Jim",
      LastName = "David",
      Gender = Gender.Male,
      // FullName = "Jim David"
    };
    public static Guest Patrice_ONeal = new Guest
    {
      GuestID = 009,
      LegacyGuestID = 30640,
      FirstName = "Patrice",
      LastName = "ONeal",
      Gender = Gender.Male,
      // FullName = "Patrice ONeal"
    };
    public static Guest Sarah_Silverman = new Guest
    {
      GuestID = 010,
      LegacyGuestID = 30641,
      FirstName = "Sarah",
      LastName = "Silverman",
      Gender = Gender.Female,
      // FullName = "Sarah Silverman"
    };
    public static Guest Jerry_Seinfeld = new Guest
    {
      GuestID = 011,
      LegacyGuestID = 30642,
      FirstName = "Jerry",
      LastName = "Seinfeld",
      Gender = Gender.Male,
      HeadshotImagePath = "Jerry Seinfeld.jpeg"
    };
    public static Guest Sue_Costello = new Guest
    {
      GuestID = 012,
      LegacyGuestID = 30643,
      FirstName = "Sue",
      LastName = "Costello",
      Gender = Gender.Female,
      // FullName = "Sue Costello"
    };
    public static Guest Janeane_Garofalo = new Guest
    {
      GuestID = 013,
      LegacyGuestID = 30644,
      FirstName = "Janeane",
      LastName = "Garofalo",
      Gender = Gender.Female,
      // FullName = "Janeane Garofalo"
    };
    public static Guest T_Sean_Shannon = new Guest
    {
      GuestID = 014,
      LegacyGuestID = 30645,
      FirstName = "T.",
      MiddleName = "Sean",
      LastName = "Shannon",
      Gender = Gender.Male,
      // FullName = "T. Sean Shannon"
    };
    public static Guest Judy_Gold = new Guest
    {
      GuestID = 015,
      LegacyGuestID = 30646,
      FirstName = "Judy",
      LastName = "Gold",
      Gender = Gender.Female,
      // FullName = "Judy Gold"
    };
    public static Guest Kevin_Hart = new Guest
    {
      GuestID = 016,
      LegacyGuestID = 30647,
      FirstName = "Kevin",
      LastName = "Hart",
      Gender = Gender.Male,
      // FullName = "Kevin Hart"
    };
    public static Guest Marc_Maron = new Guest
    {
      GuestID = 017,
      LegacyGuestID = 30648,
      FirstName = "Marc",
      LastName = "Maron",
      Gender = Gender.Male,
      // FullName = "Marc Maron"
    };
    public static Guest Eddie_Izzard = new Guest
    {
      GuestID = 018,
      LegacyGuestID = 30649,
      FirstName = "Eddie",
      LastName = "Izzard",
      Gender = Gender.Male,
      // FullName = "Eddie Izzard"
    };
    public static Guest Chris_Rock = new Guest
    {
      GuestID = 019,
      LegacyGuestID = 30650,
      FirstName = "Chris",
      LastName = "Rock",
      Gender = Gender.Male,
      // FullName = "Chris Rock"
    };
    public static Guest George_Carlin = new Guest
    {
      GuestID = 020,
      LegacyGuestID = 30652,
      FirstName = "George",
      LastName = "Carlin",
      Gender = Gender.Male,
      // FullName = "George Carlin"
    };
    public static Guest Dom_Irrera = new Guest
    {
      GuestID = 021,
      LegacyGuestID = 30653,
      FirstName = "Dom",
      LastName = "Irrera",
      Gender = Gender.Male,
      // FullName = "Dom Irrera"
    };
    public static Guest Carole_Montgomery = new Guest
    {
      GuestID = 022,
      LegacyGuestID = 30654,
      FirstName = "Carole",
      LastName = "Montgomery",
      Gender = Gender.Female,
      // FullName = "Carole Montgomery"
    };
    public static Guest Scott_Thompson = new Guest
    {
      GuestID = 023,
      LegacyGuestID = 30655,
      FirstName = "Scott",
      LastName = "Thompson",
      Gender = Gender.Male,
      // FullName = "Scott Thompson"
    };
    public static Guest Ray_Garvey = new Guest
    {
      GuestID = 024,
      LegacyGuestID = 30656,
      FirstName = "Ray",
      LastName = "Garvey",
      Gender = Gender.Male,
      // FullName = "Ray Garvey"
    };
    public static Guest William_Stephenson = new Guest
    {
      GuestID = 025,
      LegacyGuestID = 30657,
      FirstName = "William",
      LastName = "Stephenson",
      Gender = Gender.Male,
      // FullName = "William Stephenson"
    };
    public static Guest Ed_Lover = new Guest
    {
      GuestID = 026,
      LegacyGuestID = 30658,
      FirstName = "Ed",
      LastName = "Lover",
      Gender = Gender.Male,
      // FullName = "Ed Lover"
    };
    public static Guest Louis_CK = new Guest
    {
      GuestID = 027,
      LegacyGuestID = 30659,
      FirstName = "Louis",
      LastName = "C.K.",
      AlternateName = "Louis CK",
      Gender = Gender.Male,
      // FullName = "Louis C.K."
    };
    public static Guest Ken_Ober = new Guest
    {
      GuestID = 028,
      LegacyGuestID = 30660,
      FirstName = "Ken",
      LastName = "Ober",
      Gender = Gender.Male,
      // FullName = "Ken Ober"
    };
    public static Guest Pat_Cooper = new Guest
    {
      GuestID = 029,
      LegacyGuestID = 30661,
      FirstName = "Pat",
      LastName = "Cooper",
      Gender = Gender.Male,
      // FullName = "Pat Cooper"
    };
    public static Guest Allan_Havey = new Guest
    {
      GuestID = 030,
      LegacyGuestID = 30662,
      FirstName = "Allan",
      LastName = "Havey",
      Gender = Gender.Male,
      // FullName = "Allan Havey"
    };
    public static Guest Paul_Mooney = new Guest
    {
      GuestID = 031,
      LegacyGuestID = 30663,
      FirstName = "Paul",
      LastName = "Mooney",
      Gender = Gender.Male,
      // FullName = "Paul Mooney"
    };
    public static Guest Graham_Norton = new Guest
    {
      GuestID = 032,
      LegacyGuestID = 30664,
      FirstName = "Graham",
      LastName = "Norton",
      Gender = Gender.Male,
      // FullName = "Graham Norton"
    };
    public static Guest Ross_Bennett = new Guest
    {
      GuestID = 033,
      LegacyGuestID = 30665,
      FirstName = "Ross",
      LastName = "Bennett",
      Gender = Gender.Male,
      // FullName = "Ross Bennett"
    };
    public static Guest Todd_Glass = new Guest
    {
      GuestID = 034,
      LegacyGuestID = 30666,
      FirstName = "Todd",
      LastName = "Glass",
      Gender = Gender.Male,
      // FullName = "Todd Glass"
    };
    public static Guest Rich_Francese = new Guest
    {
      GuestID = 035,
      LegacyGuestID = 30667,
      FirstName = "Rich",
      LastName = "Francese",
      Gender = Gender.Male,
      // FullName = "Rich Francese"
    };
    public static Guest Lewis_Black = new Guest
    {
      GuestID = 036,
      LegacyGuestID = 30668,
      FirstName = "Lewis",
      LastName = "Black",
      Gender = Gender.Male,
      // FullName = "Lewis Black"
    };
    public static Guest Ardie_Fuqua = new Guest
    {
      GuestID = 037,
      LegacyGuestID = 30669,
      FirstName = "Ardie",
      LastName = "Fuqua",
      Gender = Gender.Male,
      // FullName = "Ardie Fuqua",
      HeadshotImagePath = "Ardie Fuqua.jpeg"
    };
    public static Guest Matt_Walsh = new Guest
    {
      GuestID = 038,
      LegacyGuestID = 30670,
      FirstName = "Matt",
      LastName = "Walsh",
      Gender = Gender.Male,
      // FullName = "Matt Walsh"
    };
    public static Guest Dov_Davidoff = new Guest
    {
      GuestID = 039,
      LegacyGuestID = 30671,
      FirstName = "Dov",
      LastName = "Davidoff",
      Gender = Gender.Male,
      // FullName = "Dov Davidoff"
    };
    public static Guest Lea_Delaria = new Guest
    {
      GuestID = 040,
      LegacyGuestID = 30672,
      FirstName = "Lea",
      LastName = "Delaria",
      Gender = Gender.Female,
      // FullName = "Lea Delaria"
    };
    public static Guest Bobby_Collins = new Guest
    {
      GuestID = 041,
      LegacyGuestID = 30673,
      FirstName = "Bobby",
      LastName = "Collins",
      Gender = Gender.Male,
      // FullName = "Bobby Collins"
    };
    public static Guest Sherry_Davey = new Guest
    {
      GuestID = 042,
      LegacyGuestID = 30674,
      FirstName = "Sherry",
      LastName = "Davey",
      Gender = Gender.Female,
      // FullName = "Sherry Davey"
    };
    public static Guest Bobby_Slayton = new Guest
    {
      GuestID = 043,
      LegacyGuestID = 30675,
      FirstName = "Bobby",
      LastName = "Slayton",
      Gender = Gender.Male,
      HeadshotImagePath = "Bobby Slayton.jpeg"
    };
    public static Guest Doug_Stanhope = new Guest
    {
      GuestID = 044,
      LegacyGuestID = 30676,
      FirstName = "Doug",
      LastName = "Stanhope",
      Gender = Gender.Male,
      // FullName = "Doug Stanhope"
    };
    public static Guest Kerri_Louise = new Guest
    {
      GuestID = 045,
      LegacyGuestID = 30677,
      FirstName = "Kerri",
      LastName = "Louise",
      Gender = Gender.Female,
      // FullName = "Kerri Louise"
    };
    public static Guest Howie_Mandel = new Guest
    {
      GuestID = 046,
      LegacyGuestID = 30678,
      FirstName = "Howie",
      LastName = "Mandel",
      Gender = Gender.Male,
      // FullName = "Howie Mandel"
    };
    public static Guest Robert_Schimmel = new Guest
    {
      GuestID = 047,
      LegacyGuestID = 30679,
      FirstName = "Robert",
      LastName = "Schimmel",
      Gender = Gender.Male,
      // FullName = "Robert Schimmel"
    };
    public static Guest Hood = new Guest
    {
      GuestID = 048,
      LegacyGuestID = 30680,
      FirstName = "Hood",
      LastName = "",
      Gender = Gender.Male,
      // FullName = "Hood"
    };
    public static Guest DL_Hughley = new Guest
    {
      GuestID = 049,
      LegacyGuestID = 30681,
      FirstName = "D.L.",
      LastName = "Hughley",
      Gender = Gender.Male,
      // FullName = "D.L. Hughley"
    };
    public static Guest Jeff_Foxworthy = new Guest
    {
      GuestID = 050,
      LegacyGuestID = 30682,
      FirstName = "Jeff",
      LastName = "Foxworthy",
      Gender = Gender.Male,
      // FullName = "Jeff Foxworthy"
    };
    public static Guest George_Wallace = new Guest
    {
      GuestID = 051,
      LegacyGuestID = 30683,
      FirstName = "George",
      LastName = "Wallace",
      Gender = Gender.Male,
      // FullName = "George Wallace"
    };
    public static Guest Bill_Burr = new Guest
    {
      GuestID = 052,
      LegacyGuestID = 30684,
      FirstName = "Bill",
      LastName = "Burr",
      Gender = Gender.Male,
      // FullName = "Bill Burr"
    };
    public static Guest Hugh_Fink = new Guest
    {
      GuestID = 053,
      LegacyGuestID = 30685,
      FirstName = "Hugh",
      LastName = "Fink",
      Gender = Gender.Male,
      // FullName = "Hugh Fink"
    };
    public static Guest Macio = new Guest
    {
      GuestID = 054,
      LegacyGuestID = 30686,
      FirstName = "Macio",
      LastName = "",
      Gender = Gender.Male,
      // FullName = "Macio"
    };
    public static Guest Jamie_Kennedy = new Guest
    {
      GuestID = 055,
      LegacyGuestID = 30687,
      FirstName = "Jamie",
      LastName = "Kennedy",
      Gender = Gender.Male,
      // FullName = "Jamie Kennedy"
    };
    public static Guest Carlos_Mencia = new Guest
    {
      GuestID = 056,
      LegacyGuestID = 30688,
      FirstName = "Carlos",
      LastName = "Mencia",
      Gender = Gender.Male,
      // FullName = "Carlos Mencia"
    };
    public static Guest Patton_Oswalt = new Guest
    {
      GuestID = 057,
      LegacyGuestID = 30689,
      FirstName = "Patton",
      LastName = "Oswalt",
      Gender = Gender.Male,
      // FullName = "Patton Oswalt"
    };
    public static Guest Maria_Bamford = new Guest
    {
      GuestID = 058,
      LegacyGuestID = 30690,
      FirstName = "Maria",
      LastName = "Bamford",
      Gender = Gender.Female,
      // FullName = "Maria Bamford"
    };
    public static Guest Todd_Lynn = new Guest
    {
      GuestID = 059,
      LegacyGuestID = 30691,
      FirstName = "Todd",
      LastName = "Lynn",
      Gender = Gender.Male,
      // FullName = "Todd Lynn"
    };
    public static Guest Andrew_Maxwell = new Guest
    {
      GuestID = 060,
      LegacyGuestID = 30692,
      FirstName = "Andrew",
      LastName = "Maxwell",
      Gender = Gender.Male,
      // FullName = "Andrew Maxwell"
    };
    public static Guest Dave_Attell = new Guest
    {
      GuestID = 061,
      LegacyGuestID = 30693,
      FirstName = "Dave",
      LastName = "Attell",
      Gender = Gender.Male,
      // FullName = "Dave Attell"
    };
    public static Guest Stephen_Colbert = new Guest
    {
      GuestID = 062,
      LegacyGuestID = 30694,
      FirstName = "Stephen",
      LastName = "Colbert",
      Gender = Gender.Male,
      // FullName = "Stephen Colbert"
    };
    public static Guest Jake_Johannsen = new Guest
    {
      GuestID = 063,
      LegacyGuestID = 30695,
      FirstName = "Jake",
      LastName = "Johannsen",
      Gender = Gender.Male,
      // FullName = "Jake Johannsen"
    };
    public static Guest Lynne_Koplitz = new Guest
    {
      GuestID = 064,
      LegacyGuestID = 30696,
      FirstName = "Lynne",
      LastName = "Koplitz",
      Gender = Gender.Female,
      // FullName = "Lynne Koplitz"
    };
    public static Guest DC_Benny = new Guest
    {
      GuestID = 065,
      LegacyGuestID = 30697,
      FirstName = "D.C.",
      LastName = "Benny",
      Gender = Gender.Male,
      // FullName = "D.C. Benny"
    };
    public static Guest Greg_Proops = new Guest
    {
      GuestID = 066,
      LegacyGuestID = 30698,
      FirstName = "Greg",
      LastName = "Proops",
      Gender = Gender.Male,
      // FullName = "Greg Proops"
    };
    public static Guest Alexandra_Wentworth = new Guest
    {
      GuestID = 067,
      LegacyGuestID = 30699,
      FirstName = "Alexandra",
      LastName = "Wentworth",
      Gender = Gender.Female,
      // FullName = "Alexandra Wentworth"
    };
    public static Guest Artie_Lange = new Guest
    {
      GuestID = 068,
      LegacyGuestID = 30700,
      FirstName = "Artie",
      LastName = "Lange",
      Gender = Gender.Male,
      // FullName = "Artie Lange"
    };
    public static Guest Lizz_Winstead = new Guest
    {
      GuestID = 069,
      LegacyGuestID = 30701,
      FirstName = "Lizz",
      LastName = "Winstead",
      Gender = Gender.Female,
      // FullName = "Lizz Winstead"
    };
    public static Guest Wanda_Sykes = new Guest
    {
      GuestID = 070,
      LegacyGuestID = 30702,
      FirstName = "Wanda",
      LastName = "Sykes",
      Gender = Gender.Female,
      // FullName = "Wanda Sykes"
    };
    public static Guest Bob_Golub = new Guest
    {
      GuestID = 071,
      LegacyGuestID = 30703,
      FirstName = "Bob",
      LastName = "Golub",
      Gender = Gender.Male,
      // FullName = "Bob Golub"
    };
    public static Guest Cory_Kahaney = new Guest
    {
      GuestID = 072,
      LegacyGuestID = 30704,
      FirstName = "Cory",
      LastName = "Kahaney",
      Gender = Gender.Female,
      // FullName = "Cory Kahaney"
    };
    public static Guest Brian_Posehn = new Guest
    {
      GuestID = 073,
      LegacyGuestID = 30705,
      FirstName = "Brian",
      LastName = "Posehn",
      Gender = Gender.Male,
      // FullName = "Brian Posehn"
    };
    public static Guest Kevin_Robinson = new Guest
    {
      GuestID = 074,
      LegacyGuestID = 30706,
      FirstName = "Kevin",
      LastName = "Robinson",
      Gender = Gender.Male,
      // FullName = "Kevin Robinson"
    };
    public static Guest Lenny_Clarke = new Guest
    {
      GuestID = 075,
      LegacyGuestID = 30707,
      FirstName = "Lenny",
      LastName = "Clarke",
      Gender = Gender.Male,
      // FullName = "Lenny Clarke"
    };
    public static Guest Denis_Leary = new Guest
    {
      GuestID = 076,
      LegacyGuestID = 30708,
      FirstName = "Denis",
      LastName = "Leary",
      Gender = Gender.Male,
      // FullName = "Denis Leary"
    };
    public static Guest Laura_Kightlinger = new Guest
    {
      GuestID = 077,
      LegacyGuestID = 30709,
      FirstName = "Laura",
      LastName = "Kightlinger",
      Gender = Gender.Female,
      // FullName = "Laura Kightlinger"
    };
    public static Guest Jimmy_Kimmel = new Guest
    {
      GuestID = 078,
      LegacyGuestID = 30710,
      FirstName = "Jimmy",
      LastName = "Kimmel",
      Gender = Gender.Male,
      // FullName = "Jimmy Kimmel"
    };
    public static Guest Todd_Barry = new Guest
    {
      GuestID = 079,
      LegacyGuestID = 30711,
      FirstName = "Todd",
      LastName = "Barry",
      Gender = Gender.Male,
      // FullName = "Todd Barry"
    };
    public static Guest Colette_Hawley = new Guest
    {
      GuestID = 080,
      LegacyGuestID = 30712,
      FirstName = "Colette",
      LastName = "Hawley",
      Gender = Gender.Female,
      // FullName = "Colette Hawley"
    };
    public static Guest Sue_Murphy = new Guest
    {
      GuestID = 081,
      LegacyGuestID = 30713,
      FirstName = "Sue",
      LastName = "Murphy",
      Gender = Gender.Female,
      // FullName = "Sue Murphy"
    };
    public static Guest Kevin_Meaney = new Guest
    {
      GuestID = 082,
      LegacyGuestID = 30714,
      FirstName = "Kevin",
      LastName = "Meaney",
      Gender = Gender.Male,
      // FullName = "Kevin Meaney"
    };
    public static Guest Gregg_Rogell = new Guest
    {
      GuestID = 083,
      LegacyGuestID = 30715,
      FirstName = "Gregg",
      LastName = "Rogell",
      Gender = Gender.Male,
      // FullName = "Gregg Rogell"
    };
    public static Guest Rudy_Rush = new Guest
    {
      GuestID = 084,
      LegacyGuestID = 30716,
      FirstName = "Rudy",
      LastName = "Rush",
      Gender = Gender.Male,
      // FullName = "Rudy Rush"
    };
    public static Guest Laurie_Kilmartin = new Guest
    {
      GuestID = 085,
      LegacyGuestID = 30717,
      FirstName = "Laurie",
      LastName = "Kilmartin",
      Gender = Gender.Female,
      // FullName = "Laurie Kilmartin"
    };
    public static Guest Mauric_e = new Guest
    {
      GuestID = 086,
      LegacyGuestID = 30718,
      FirstName = "Maurice",
      LastName = "",
      Gender = Gender.Male,
      // FullName = "Maurice"
    };
    public static Guest Pete_Correale = new Guest
    {
      GuestID = 087,
      LegacyGuestID = 30719,
      FirstName = "Pete",
      LastName = "Correale",
      Gender = Gender.Male,
      // FullName = "Pete Correale"
    };
    public static Guest Tom_Papa = new Guest
    {
      GuestID = 088,
      LegacyGuestID = 30720,
      FirstName = "Tom",
      LastName = "Papa",
      Gender = Gender.Male,
      // FullName = "Tom Papa"
    };
    public static Guest Greer_Barnes = new Guest
    {
      GuestID = 089,
      LegacyGuestID = 30721,
      FirstName = "Greer",
      LastName = "Barnes",
      Gender = Gender.Male,
      // FullName = "Greer Barnes"
    };
    public static Guest Paul_Mecurio = new Guest
    {
      GuestID = 090,
      LegacyGuestID = 30722,
      FirstName = "Paul",
      LastName = "Mecurio",
      Gender = Gender.Male,
      // FullName = "Paul Mecurio"
    };
    public static Guest Richard_Belzer = new Guest
    {
      GuestID = 091,
      LegacyGuestID = 30723,
      FirstName = "Richard",
      LastName = "Belzer",
      Gender = Gender.Male,
      // FullName = "Richard Belzer",
      HeadshotImagePath = "Richard Belzer.jpeg"
    };
    public static Guest Rene_Hicks = new Guest
    {
      GuestID = 092,
      LegacyGuestID = 30724,
      FirstName = "Rene",
      LastName = "Hicks",
      Gender = Gender.Female,
      // FullName = "Rene Hicks"
    };
    public static Guest James_Smith = new Guest
    {
      GuestID = 093,
      LegacyGuestID = 30725,
      FirstName = "James",
      LastName = "Smith",
      Gender = Gender.Male,
      HeadshotImagePath = "James Smith.jpeg"
    };
    public static Guest Flex_Alexander = new Guest
    {
      GuestID = 094,
      LegacyGuestID = 30726,
      FirstName = "Flex",
      LastName = "Alexander",
      Gender = Gender.Male,
      // FullName = "Flex Alexander"
    };
    public static Guest Dante_Nero = new Guest
    {
      GuestID = 095,
      LegacyGuestID = 30727,
      FirstName = "Dante",
      LastName = "Nero",
      Gender = Gender.Male,
      // FullName = "Dante Nero"
    };
    public static Guest Sunda_Croonquist = new Guest
    {
      GuestID = 096,
      LegacyGuestID = 30728,
      FirstName = "Sunda",
      LastName = "Croonquist",
      Gender = Gender.Female,
      // FullName = "Sunda Croonquist"
    };
    public static Guest David_Cross = new Guest
    {
      GuestID = 097,
      LegacyGuestID = 30729,
      FirstName = "David",
      LastName = "Cross",
      Gender = Gender.Male,
      // FullName = "David Cross"
    };
    public static Guest Vic_Henley = new Guest
    {
      GuestID = 098,
      LegacyGuestID = 30730,
      FirstName = "Vic",
      LastName = "Henley",
      Gender = Gender.Male,
      // FullName = "Vic Henley"
    };
    public static Guest Robert_Klein = new Guest
    {
      GuestID = 099,
      LegacyGuestID = 30731,
      FirstName = "Robert",
      LastName = "Klein",
      Gender = Gender.Male,
      // FullName = "Robert Klein"
    };
    public static Guest David_Alan_Grier = new Guest
    {
      GuestID = 100,
      LegacyGuestID = 30732,
      FirstName = "David",
      MiddleName = "Alan",
      LastName = "Grier",
      Gender = Gender.Male,
      // FullName = "David Alan Grier"
    };
    public static Guest Rich_Hall = new Guest
    {
      GuestID = 101,
      LegacyGuestID = 30733,
      FirstName = "Rich",
      LastName = "Hall",
      Gender = Gender.Male,
      // FullName = "Rich Hall"
    };
    public static Guest Greg_Fitzsimmons = new Guest
    {
      GuestID = 102,
      LegacyGuestID = 30734,
      FirstName = "Greg",
      LastName = "Fitzsimmons",
      Gender = Gender.Male,
      // FullName = "Greg Fitzsimmons"
    };
    public static Guest Bonnie_McFarlane = new Guest
    {
      GuestID = 103,
      LegacyGuestID = 30735,
      FirstName = "Bonnie",
      LastName = "McFarlane",
      Gender = Gender.Female,
      // FullName = "Bonnie McFarlane"
    };
    public static Guest Dave_Chappelle = new Guest
    {
      GuestID = 104,
      LegacyGuestID = 30736,
      FirstName = "Dave",
      LastName = "Chappelle",
      Gender = Gender.Male,
      // FullName = "Dave Chappelle"
    };
    public static Guest Reggie_McFadden = new Guest
    {
      GuestID = 105,
      LegacyGuestID = 30737,
      FirstName = "Reggie",
      LastName = "McFadden",
      Gender = Gender.Male,
      // FullName = "Reggie McFadden"
    };
    public static Guest Jimmy_Shubert = new Guest
    {
      GuestID = 106,
      LegacyGuestID = 30738,
      FirstName = "Jimmy",
      LastName = "Shubert",
      Gender = Gender.Male,
      // FullName = "Jimmy Shubert"
    };
    public static Guest Wayne_Federman = new Guest
    {
      GuestID = 107,
      LegacyGuestID = 30739,
      FirstName = "Wayne",
      LastName = "Federman",
      Gender = Gender.Male,
      // FullName = "Wayne Federman"
    };
    public static Guest Kathy_Griffin = new Guest
    {
      GuestID = 108,
      LegacyGuestID = 30740,
      FirstName = "Kathy",
      LastName = "Griffin",
      Gender = Gender.Female,
      // FullName = "Kathy Griffin"
    };
    public static Guest John_DiResta = new Guest
    {
      GuestID = 109,
      LegacyGuestID = 30741,
      FirstName = "John",
      LastName = "DiResta",
      Gender = Gender.Male,
      // FullName = "John DiResta"
    };
    public static Guest Ralphie_May = new Guest
    {
      GuestID = 110,
      LegacyGuestID = 30742,
      FirstName = "Ralphie",
      LastName = "May",
      Gender = Gender.Male,
      // FullName = "Ralphie May"
    };
    public static Guest Mitch_Fatel = new Guest
    {
      GuestID = 111,
      LegacyGuestID = 30743,
      FirstName = "Mitch",
      LastName = "Fatel",
      Gender = Gender.Male,
      // FullName = "Mitch Fatel"
    };
    public static Guest Nick_Gaza = new Guest
    {
      GuestID = 112,
      LegacyGuestID = 30744,
      FirstName = "Nick",
      LastName = "Gaza",
      Gender = Gender.Male,
      // FullName = "Nick Gaza"
    };
    public static Guest Richard_Jeni = new Guest
    {
      GuestID = 113,
      LegacyGuestID = 30745,
      FirstName = "Richard",
      LastName = "Jeni",
      Gender = Gender.Male,
      // FullName = "Richard Jeni"
    };
    public static Guest Lisa_Lampanelli = new Guest
    {
      GuestID = 114,
      LegacyGuestID = 30746,
      FirstName = "Lisa",
      LastName = "Lampanelli",
      Gender = Gender.Female,
      // FullName = "Lisa Lampanelli"
    };
    public static Guest Don_Gavin = new Guest
    {
      GuestID = 115,
      LegacyGuestID = 30747,
      FirstName = "Don",
      LastName = "Gavin",
      Gender = Gender.Male,
      // FullName = "Don Gavin"
    };
    public static Guest Steve_Sweeney = new Guest
    {
      GuestID = 116,
      LegacyGuestID = 30748,
      FirstName = "Steve",
      LastName = "Sweeney",
      Gender = Gender.Male,
      // FullName = "Steve Sweeney"
    };
    public static Guest Jimmy_Tingle = new Guest
    {
      GuestID = 117,
      LegacyGuestID = 30749,
      FirstName = "Jimmy",
      LastName = "Tingle",
      Gender = Gender.Male,
      // FullName = "Jimmy Tingle"
    };
    public static Guest Donnell_Rawlings = new Guest
    {
      GuestID = 118,
      LegacyGuestID = 30750,
      FirstName = "Donnell",
      LastName = "Rawlings",
      Gender = Gender.Male,
      // FullName = "Donnell Rawlings"
    };
    public static Guest Franklyn_Ajaye = new Guest
    {
      GuestID = 119,
      LegacyGuestID = 30751,
      FirstName = "Franklyn",
      LastName = "Ajaye",
      Gender = Gender.Male,
      // FullName = "Franklyn Ajaye"
    };
    public static Guest Ben_Bailey = new Guest
    {
      GuestID = 120,
      LegacyGuestID = 30752,
      FirstName = "Ben",
      LastName = "Bailey",
      Gender = Gender.Male,
      // FullName = "Ben Bailey"
    };
    public static Guest Ty_Barnett = new Guest
    {
      GuestID = 121,
      LegacyGuestID = 30753,
      FirstName = "Ty",
      LastName = "Barnett",
      Gender = Gender.Male,
      // FullName = "Ty Barnett"
    };
    public static Guest Vinnie_Brand = new Guest
    {
      GuestID = 122,
      LegacyGuestID = 30754,
      FirstName = "Vinnie",
      LastName = "Brand",
      Gender = Gender.Male,
      // FullName = "Vinnie Brand"
    };
    public static Guest John_Mendoza = new Guest
    {
      GuestID = 123,
      LegacyGuestID = 30755,
      FirstName = "John",
      LastName = "Mendoza",
      Gender = Gender.Male,
      // FullName = "John Mendoza"
    };
    public static Guest Robert_Kelly = new Guest
    {
      GuestID = 124,
      LegacyGuestID = 30756,
      FirstName = "Robert",
      LastName = "Kelly",
      Gender = Gender.Male,
      // FullName = "Robert Kelly"
    };
    public static Guest Barry_Weintraub = new Guest
    {
      GuestID = 125,
      LegacyGuestID = 30757,
      FirstName = "Barry",
      LastName = "Weintraub",
      Gender = Gender.Male,
      // FullName = "Barry Weintraub"
    };
    public static Guest Kevin_Brennan = new Guest
    {
      GuestID = 126,
      LegacyGuestID = 30758,
      FirstName = "Kevin",
      LastName = "Brennan",
      Gender = Gender.Male,
      // FullName = "Kevin Brennan"
    };
    public static Guest David_Feldman = new Guest
    {
      GuestID = 127,
      LegacyGuestID = 30759,
      FirstName = "David",
      LastName = "Feldman",
      Gender = Gender.Male,
      // FullName = "David Feldman"
    };
    public static Guest Dane_Cook = new Guest
    {
      GuestID = 128,
      LegacyGuestID = 30760,
      FirstName = "Dane",
      LastName = "Cook",
      Gender = Gender.Male,
      // FullName = "Dane Cook"
    };
    public static Guest Bruce_Bruce = new Guest
    {
      GuestID = 129,
      LegacyGuestID = 30761,
      FirstName = "Bruce",
      LastName = "Bruce",
      Gender = Gender.Male,
      // FullName = "Bruce Bruce"
    };
    public static Guest Tim_Young = new Guest
    {
      GuestID = 130,
      LegacyGuestID = 30762,
      FirstName = "Tim",
      LastName = "Young",
      Gender = Gender.Male,
      // FullName = "Tim Young"
    };
    public static Guest John_Joseph = new Guest
    {
      GuestID = 131,
      LegacyGuestID = 30763,
      FirstName = "John",
      LastName = "Joseph",
      Gender = Gender.Male,
      // FullName = "John Joseph"
    };
    public static Guest Dina_Pearlman = new Guest
    {
      GuestID = 132,
      LegacyGuestID = 30764,
      FirstName = "Dina",
      LastName = "Pearlman",
      Gender = Gender.Male,
      // FullName = "Dina Pearlman"
    };
    public static Guest Drew_Hastings = new Guest
    {
      GuestID = 133,
      LegacyGuestID = 30765,
      FirstName = "Drew",
      LastName = "Hastings",
      Gender = Gender.Male,
      // FullName = "Drew Hastings"
    };
    public static Guest Goumba_Johnny = new Guest
    {
      GuestID = 134,
      LegacyGuestID = 30766,
      FirstName = "Goumba",
      LastName = "Johnny",
      Gender = Gender.Male,
      // FullName = "Goumba Johnny"
    };
    public static Guest Dat_Phan = new Guest
    {
      GuestID = 135,
      LegacyGuestID = 30767,
      FirstName = "Dat",
      LastName = "Phan",
      Gender = Gender.Male,
      // FullName = "Dat Phan"
    };
    public static Guest Eddie_Brill = new Guest
    {
      GuestID = 136,
      LegacyGuestID = 30768,
      FirstName = "Eddie",
      LastName = "Brill",
      Gender = Gender.Male,
      // FullName = "Eddie Brill"
    };
    public static Guest Jackie_Kashian = new Guest
    {
      GuestID = 137,
      LegacyGuestID = 30769,
      FirstName = "Jackie",
      LastName = "Kashian",
      Gender = Gender.Female,
      // FullName = "Jackie Kashian"
    };
    public static Guest Laura_Dinnebeil = new Guest
    {
      GuestID = 138,
      LegacyGuestID = 30770,
      FirstName = "Laura",
      LastName = "Dinnebeil",
      Gender = Gender.Female,
      // FullName = "Laura Dinnebeil"
    };
    public static Guest Rick_Shapiro = new Guest
    {
      GuestID = 139,
      LegacyGuestID = 30771,
      FirstName = "Rick",
      LastName = "Shapiro",
      Gender = Gender.Male,
      // FullName = "Rick Shapiro"
    };
    public static Guest Dan_Vitale = new Guest
    {
      GuestID = 140,
      LegacyGuestID = 30772,
      FirstName = "Dan",
      LastName = "Vitale",
      Gender = Gender.Male,
      // FullName = "Dan Vitale"
    };
    public static Guest Becky_Donohue = new Guest
    {
      GuestID = 141,
      LegacyGuestID = 30773,
      FirstName = "Becky",
      LastName = "Donohue",
      Gender = Gender.Female,
      // FullName = "Becky Donohue"
    };
    public static Guest Judah_Friedlander = new Guest
    {
      GuestID = 142,
      LegacyGuestID = 30774,
      FirstName = "Judah",
      LastName = "Friedlander",
      Gender = Gender.Male,
      // FullName = "Judah Friedlander"
    };
    public static Guest Dave_Mordal = new Guest
    {
      GuestID = 143,
      LegacyGuestID = 30775,
      FirstName = "Dave",
      LastName = "Mordal",
      Gender = Gender.Male,
      // FullName = "Dave Mordal"
    };
    public static Guest Joe_Rogan = new Guest
    {
      GuestID = 144,
      LegacyGuestID = 30776,
      FirstName = "Joe",
      LastName = "Rogan",
      Gender = Gender.Male,
      // FullName = "Joe Rogan"
    };
    public static Guest Jimmy_Martinez = new Guest
    {
      GuestID = 145,
      LegacyGuestID = 30777,
      FirstName = "Jimmy",
      LastName = "Martinez",
      Gender = Gender.Male,
      // FullName = "Jimmy Martinez"
    };
    public static Guest Ian_Bagg = new Guest
    {
      GuestID = 146,
      LegacyGuestID = 30778,
      FirstName = "Ian",
      LastName = "Bagg",
      Gender = Gender.Male,
      // FullName = "Ian Bagg"
    };
    public static Guest Paul_F_Tompkins = new Guest
    {
      GuestID = 147,
      LegacyGuestID = 30779,
      FirstName = "Paul",
      MiddleName = "F",
      LastName = "Tompkins",
      Gender = Gender.Male,
      // FullName = "Paul F. Tompkins"
    };
    public static Guest Adam_Ferrara = new Guest
    {
      GuestID = 148,
      LegacyGuestID = 30780,
      FirstName = "Adam",
      LastName = "Ferrara",
      Gender = Gender.Male,
      // FullName = "Adam Ferrara"
    };
    public static Guest Jeffrey_Ross = new Guest
    {
      GuestID = 149,
      LegacyGuestID = 30781,
      FirstName = "Jeffrey",
      LastName = "Ross",
      Gender = Gender.Male,
      // FullName = "Jeffrey Ross"
    };
    public static Guest Pauly_Shore = new Guest
    {
      GuestID = 150,
      LegacyGuestID = 30782,
      FirstName = "Pauly",
      LastName = "Shore",
      Gender = Gender.Male,
      // FullName = "Pauly Shore"
    };
    public static Guest Susie_Essman = new Guest
    {
      GuestID = 151,
      LegacyGuestID = 30783,
      FirstName = "Susie",
      LastName = "Essman",
      Gender = Gender.Female,
      // FullName = "Susie Essman"
    };
    public static Guest Jeff_Garlin = new Guest
    {
      GuestID = 152,
      LegacyGuestID = 30784,
      FirstName = "Jeff",
      LastName = "Garlin",
      Gender = Gender.Male,
      // FullName = "Jeff Garlin"
    };
    public static Guest John_Marshall = new Guest
    {
      GuestID = 153,
      LegacyGuestID = 30785,
      FirstName = "John",
      LastName = "Marshall",
      Gender = Gender.Male,
      // FullName = "John Marshall"
    };
    public static Guest Mario_Cantone = new Guest
    {
      GuestID = 154,
      LegacyGuestID = 30786,
      FirstName = "Mario",
      LastName = "Cantone",
      Gender = Gender.Male,
      // FullName = "Mario Cantone"
    };
    public static Guest Doctor_Dre = new Guest
    {
      GuestID = 155,
      LegacyGuestID = 30787,
      FirstName = "Doctor",
      LastName = "Dré",
      AlternateName = "Doctor Dre",
      Gender = Gender.Male,
      // FullName = "Doctor Dre"
    };
    public static Guest Vanessa_Hollingshead = new Guest
    {
      GuestID = 156,
      LegacyGuestID = 30788,
      FirstName = "Vanessa",
      LastName = "Hollingshead",
      Gender = Gender.Female,
      // FullName = "Vanessa Hollingshead"
    };
    public static Guest Andy_Kindler = new Guest
    {
      GuestID = 157,
      LegacyGuestID = 30789,
      FirstName = "Andy",
      LastName = "Kindler",
      Gender = Gender.Male,
      // FullName = "Andy Kindler"
    };
    public static Guest Louis_Ramey = new Guest
    {
      GuestID = 158,
      LegacyGuestID = 30790,
      FirstName = "Louis",
      LastName = "Ramey",
      Gender = Gender.Male,
      // FullName = "Louis Ramey"
    };
    public static Guest Pete_Tubbs = new Guest
    {
      GuestID = 159,
      LegacyGuestID = 30791,
      FirstName = "Pete",
      LastName = "Tubbs",
      Gender = Gender.Male,
      // FullName = "Pete Tubbs"
    };
    public static Guest Rick_Crom = new Guest
    {
      GuestID = 160,
      LegacyGuestID = 30792,
      FirstName = "Rick",
      LastName = "Crom",
      Gender = Gender.Male,
      // FullName = "Rick Crom"
    };
    public static Guest Ben_Stein = new Guest
    {
      GuestID = 161,
      LegacyGuestID = 30793,
      FirstName = "Ben",
      LastName = "Stein",
      Gender = Gender.Male,
      // FullName = "Ben Stein"
    };
    public static Guest Mike_Britt = new Guest
    {
      GuestID = 162,
      LegacyGuestID = 30794,
      FirstName = "Mike",
      LastName = "Britt",
      Gender = Gender.Male,
      // FullName = "Mike Britt"
    };
    public static Guest _ = new Guest
    {
      GuestID = 163,
      LegacyGuestID = 30795,
      FirstName = "Andrew",
      MiddleName = "Dice",
      LastName = "Clay",
      Gender = Gender.Male,
      // FullName = "Andrew Dice Clay"
    };
    public static Guest Jim_Florentine = new Guest
    {
      GuestID = 164,
      LegacyGuestID = 30796,
      FirstName = "Jim",
      LastName = "Florentine",
      Gender = Gender.Male,
      // FullName = "Jim Florentine"
    };
    public static Guest Bernadette_Pauley = new Guest
    {
      GuestID = 165,
      LegacyGuestID = 30797,
      FirstName = "Bernadette",
      LastName = "Pauley",
      Gender = Gender.Male,
      // FullName = "Bernadette Pauley"
    };
    public static Guest Mo_Rocca = new Guest
    {
      GuestID = 166,
      LegacyGuestID = 30798,
      FirstName = "Mo",
      LastName = "Rocca",
      Gender = Gender.Male,
      // FullName = "Mo Rocca"
    };
    public static Guest Jim_Gaffigan = new Guest
    {
      GuestID = 167,
      LegacyGuestID = 30799,
      FirstName = "Jim",
      LastName = "Gaffigan",
      Gender = Gender.Male,
      // FullName = "Jim Gaffigan"
    };
    public static Guest Mishna_Wolff = new Guest
    {
      GuestID = 168,
      LegacyGuestID = 30800,
      FirstName = "Mishna",
      LastName = "Wolff",
      Gender = Gender.Female,
      // FullName = "Mishna Wolff"
    };
    public static Guest Ellen_Cleghorne = new Guest
    {
      GuestID = 169,
      LegacyGuestID = 30801,
      FirstName = "Ellen",
      LastName = "Cleghorne",
      Gender = Gender.Female,
      // FullName = "Ellen Cleghorne"
    };
    public static Guest Jay_Mohr = new Guest
    {
      GuestID = 170,
      LegacyGuestID = 30802,
      FirstName = "Jay",
      LastName = "Mohr",
      Gender = Gender.Male,
      // FullName = "Jay Mohr"
    };
    public static Guest Kathleen_Madigan = new Guest
    {
      GuestID = 171,
      LegacyGuestID = 30803,
      FirstName = "Kathleen",
      LastName = "Madigan",
      Gender = Gender.Female,
      // FullName = "Kathleen Madigan"
    };
    public static Guest Tony_Woods = new Guest
    {
      GuestID = 172,
      LegacyGuestID = 30804,
      FirstName = "Tony",
      LastName = "Woods",
      Gender = Gender.Male,
      // FullName = "Tony Woods"
    };
    public static Guest Dan_Naturman = new Guest
    {
      GuestID = 173,
      LegacyGuestID = 30805,
      FirstName = "Dan",
      LastName = "Naturman",
      Gender = Gender.Male,
      // FullName = "Dan Naturman"
    };
    public static Guest Buddy_Bolton = new Guest
    {
      GuestID = 174,
      LegacyGuestID = 30806,
      FirstName = "Buddy",
      LastName = "Bolton",
      Gender = Gender.Male,
      // FullName = "Buddy Bolton"
    };
    public static Guest Hal_Sparks = new Guest
    {
      GuestID = 175,
      LegacyGuestID = 30807,
      FirstName = "Hal",
      LastName = "Sparks",
      Gender = Gender.Male,
      // FullName = "Hal Sparks"
    };
    public static Guest Fran_Solomita = new Guest
    {
      GuestID = 176,
      LegacyGuestID = 30808,
      FirstName = "Fran",
      LastName = "Solomita",
      Gender = Gender.Male,
      // FullName = "Fran Solomita"
    };
    public static Guest Tony_V = new Guest
    {
      GuestID = 177,
      LegacyGuestID = 30809,
      FirstName = "Tony",
      LastName = "V",
      Gender = Gender.Male,
      // FullName = "Tony V"
    };
    public static Guest Drew_Fraser = new Guest
    {
      GuestID = 178,
      LegacyGuestID = 30810,
      FirstName = "Drew",
      LastName = "Fraser",
      Gender = Gender.Male,
      // FullName = "Drew Fraser"
    };
    public static Guest Maz_Jobrani = new Guest
    {
      GuestID = 179,
      LegacyGuestID = 30811,
      FirstName = "Maz",
      LastName = "Jobrani",
      Gender = Gender.Male,
      // FullName = "Maz Jobrani"
    };
    public static Guest Mark_Ebner = new Guest
    {
      GuestID = 180,
      LegacyGuestID = 30812,
      FirstName = "Mark",
      LastName = "Ebner",
      Gender = Gender.Male,
      // FullName = "Mark Ebner"
    };
    public static Guest Leighann_Lord = new Guest
    {
      GuestID = 181,
      LegacyGuestID = 30813,
      FirstName = "Leighann",
      LastName = "Lord",
      Gender = Gender.Female,
      // FullName = "Leighann Lord"
    };
    public static Guest Frankie_Pace = new Guest
    {
      GuestID = 182,
      LegacyGuestID = 30814,
      FirstName = "Frankie",
      LastName = "Pace",
      Gender = Gender.Male,
      // FullName = "Frankie Pace"
    };
    public static Guest Greg_Behrendt = new Guest
    {
      GuestID = 183,
      LegacyGuestID = 30815,
      FirstName = "Greg",
      LastName = "Behrendt",
      Gender = Gender.Male,
      // FullName = "Greg Behrendt"
    };
    public static Guest Ted_Alexandro = new Guest
    {
      GuestID = 184,
      LegacyGuestID = 30816,
      FirstName = "Ted",
      LastName = "Alexandro",
      Gender = Gender.Male,
      // FullName = "Ted Alexandro"
    };
    public static Guest Penn_Jillette = new Guest
    {
      GuestID = 185,
      LegacyGuestID = 30817,
      FirstName = "Penn",
      LastName = "Jillette",
      Gender = Gender.Male,
      // FullName = "Penn Jillette"
    };
    public static Guest Tony_Camin = new Guest
    {
      GuestID = 186,
      LegacyGuestID = 30818,
      FirstName = "Tony",
      LastName = "Camin",
      Gender = Gender.Male,
      // FullName = "Tony Camin"
    };
    public static Guest Mike_Sweeney = new Guest
    {
      GuestID = 187,
      LegacyGuestID = 30819,
      FirstName = "Mike",
      LastName = "Sweeney",
      Gender = Gender.Male,
      // FullName = "Mike Sweeney"
    };
    public static Guest Sheryl_Underwood = new Guest
    {
      GuestID = 188,
      LegacyGuestID = 30820,
      FirstName = "Sheryl",
      LastName = "Underwood",
      Gender = Gender.Female,
      // FullName = "Sheryl Underwood"
    };
    public static Guest Carrot_Top = new Guest
    {
      GuestID = 189,
      LegacyGuestID = 30821,
      FirstName = "Carrot",
      LastName = "Top",
      Gender = Gender.Male,
      // FullName = "Carrot Top"
    };
    public static Guest Frank_Santorelli = new Guest
    {
      GuestID = 190,
      LegacyGuestID = 30822,
      FirstName = "Frank",
      LastName = "Santorelli",
      Gender = Gender.Male,
      // FullName = "Frank Santorelli"
    };
    public static Guest Kyle_Grooms = new Guest
    {
      GuestID = 191,
      LegacyGuestID = 30823,
      FirstName = "Kyle",
      LastName = "Grooms",
      Gender = Gender.Male,
      // FullName = "Kyle Grooms"
    };
    public static Guest Jeff_Cesario = new Guest
    {
      GuestID = 192,
      LegacyGuestID = 30824,
      FirstName = "Jeff",
      LastName = "Cesario",
      Gender = Gender.Male,
      // FullName = "Jeff Cesario"
    };
    public static Guest Chris_Murphy = new Guest
    {
      GuestID = 193,
      LegacyGuestID = 30825,
      FirstName = "Chris",
      LastName = "Murphy",
      Gender = Gender.Male,
      // FullName = "Chris Murphy"
    };
    public static Guest Al_Lubel = new Guest
    {
      GuestID = 194,
      LegacyGuestID = 30826,
      FirstName = "Al",
      LastName = "Lubel",
      Gender = Gender.Male,
      // FullName = "Al Lubel"
    };
    public static Guest Frank_Vignola = new Guest
    {
      GuestID = 195,
      LegacyGuestID = 30827,
      FirstName = "Frank",
      LastName = "Vignola",
      Gender = Gender.Male,
      // FullName = "Frank Vignola"
    };
    public static Guest Jim_Mendrinos = new Guest
    {
      GuestID = 196,
      LegacyGuestID = 30828,
      FirstName = "Jim",
      LastName = "Mendrinos",
      Gender = Gender.Male,
      // FullName = "Jim Mendrinos"
    };
    public static Guest Jackie_Mason = new Guest
    {
      GuestID = 197,
      LegacyGuestID = 30829,
      FirstName = "Jackie",
      LastName = "Mason",
      Gender = Gender.Male,
      // FullName = "Jackie Mason"
    };
    public static Guest Steve_Byrne = new Guest
    {
      GuestID = 198,
      LegacyGuestID = 30830,
      FirstName = "Steve",
      LastName = "Byrne",
      Gender = Gender.Male,
      // FullName = "Steve Byrne"
    };
    public static Guest Omid_Djalili = new Guest
    {
      GuestID = 199,
      LegacyGuestID = 30831,
      FirstName = "Omid",
      LastName = "Djalili",
      Gender = Gender.Male,
      // FullName = "Omid Djalili"
    };
    public static Guest Karen_Bergreen = new Guest
    {
      GuestID = 200,
      LegacyGuestID = 30832,
      FirstName = "Karen",
      LastName = "Bergreen",
      Gender = Gender.Female,
      // FullName = "Karen Bergreen"
    };
    public static Guest Tim_Meadows = new Guest
    {
      GuestID = 201,
      LegacyGuestID = 30833,
      FirstName = "Tim",
      LastName = "Meadows",
      Gender = Gender.Male,
      // FullName = "Tim Meadows"
    };
    public static Guest Tom_Cotter = new Guest
    {
      GuestID = 202,
      LegacyGuestID = 30834,
      FirstName = "Tom",
      LastName = "Cotter",
      Gender = Gender.Male,
      // FullName = "Tom Cotter"
    };
    public static Guest John_Fugelsang = new Guest
    {
      GuestID = 203,
      LegacyGuestID = 30835,
      FirstName = "John",
      LastName = "Fugelsang",
      Gender = Gender.Male,
      // FullName = "John Fugelsang"
    };
    public static Guest Jon_Stewart = new Guest
    {
      GuestID = 204,
      LegacyGuestID = 30836,
      FirstName = "Jon",
      LastName = "Stewart",
      Gender = Gender.Male,
      // FullName = "Jon Stewart"
    };
  }
}

