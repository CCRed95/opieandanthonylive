﻿namespace opieandanthonylive.Controllers.Auth {

  using Microsoft.AspNetCore.Authorization;
  using Microsoft.AspNetCore.Mvc;

  [Authorize]
  [Route("api/auth/[controller]")]
  public class TestController : Controller {

    public IActionResult Post([FromHeader(Name = "Authorization")] string auth) =>
      new OkObjectResult("Successfully validated token!");

  }

}
