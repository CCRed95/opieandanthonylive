namespace opieandanthonylive.Controllers.Auth {

  using System;
  using System.IdentityModel.Tokens.Jwt;
  using System.Security.Claims;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Options;
  using Microsoft.IdentityModel.Tokens;
  using opieandanthonylive.Auth;
  using opieandanthonylive.Data.Context;
  using opieandanthonylive.ViewModels;

  [Route("api/auth/[controller]")]
  public class RegisterController : Controller {

    readonly UserManager<IdentityUser> userManager;
    readonly CoreContext dbContext;
    readonly JwtIssuerOptions jwtOptions;

    public RegisterController(
      UserManager<IdentityUser> userManager,
      IOptions<JwtIssuerOptions> jwtIssuerOptions,
      CoreContext dbContext)
    {
      this.userManager = userManager;
      this.dbContext = dbContext;
      this.jwtOptions = jwtIssuerOptions.Value;
    }

    string GenerateJwtToken(string userName) {

      long ToUnixEpochDate(DateTime date) {
        var unixEpoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var dt = date.ToUniversalTime() - unixEpoch;
        return (long)dt.TotalSeconds;
      }

      var claims = new[] {
       new Claim(JwtRegisteredClaimNames.Sub, userName),
       new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
       new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.Now).ToString(), ClaimValueTypes.Integer64),
       new Claim("rol", "auth/test"),
     };

      var jwt = new JwtSecurityToken(
        issuer: jwtOptions.Issuer,
        audience: jwtOptions.Audience,
        claims: claims,
        expires: DateTime.Now.AddDays(7),
        signingCredentials: jwtOptions.Credentials);

      return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public async Task<IActionResult> Post([FromBody] RegisterViewModel model) {

      if (ModelState.IsValid == false)
        return BadRequest(ModelState);

      var result = await this.userManager.CreateAsync(
        new IdentityUser {
          Email = model.Email,
          UserName = model.Username,
        },
        model.Password);

      if (result.Succeeded == false) {
        foreach (var e in result.Errors)
          ModelState.TryAddModelError(e.Code, e.Description);

        return new BadRequestObjectResult(ModelState);
      }

      return new OkObjectResult(new {
        token = GenerateJwtToken(model.Username)
      });
    }

  }

}
