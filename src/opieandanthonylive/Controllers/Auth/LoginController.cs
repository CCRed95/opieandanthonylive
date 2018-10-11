namespace opieandanthonylive.Controllers.Auth {

  using System;
  using System.IdentityModel.Tokens.Jwt;
  using System.Security.Claims;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Options;
  using opieandanthonylive.Auth;
  using opieandanthonylive.Data.Context;
  using opieandanthonylive.ViewModels;

  [Route("api/auth/[controller]")]
  public class LoginController : Controller {

    readonly UserManager<IdentityUser> userManager;
    readonly CoreContext dbContext;
    readonly JwtIssuerOptions jwtOptions;

    public LoginController(
      UserManager<IdentityUser> userManager,
      IOptions<JwtIssuerOptions> jwtIssuerOptions,
      CoreContext dbContext)
    {
      this.userManager = userManager;
      this.dbContext = dbContext;
      this.jwtOptions = jwtIssuerOptions.Value;
    }

    public async Task<IActionResult> Post([FromBody] LoginViewModel model) {

      if (ModelState.IsValid == false)
        return BadRequest(ModelState);

      var user = await this.userManager.FindByNameAsync(model.Username);
      if (user == null || await this.userManager.CheckPasswordAsync(user, model.Password) == false) {
        ModelState.AddModelError("login_failure", "Invalid username or password");
        return BadRequest(ModelState);
      }

      return new OkObjectResult(GenerateJwtToken(this.jwtOptions, model.Username));
    }

    public static string GenerateJwtToken(JwtIssuerOptions jwtOptions, string userName) {

      long ToUnixEpochDate(DateTime date) {
        var unixEpoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
        var dt = date.ToUniversalTime() - unixEpoch;
        return (long)dt.TotalSeconds;
      }

      var claims = new[] {
       new Claim(JwtRegisteredClaimNames.Sub, userName),
       new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
       new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.Now).ToString(), ClaimValueTypes.Integer64),
     };

      var jwt = new JwtSecurityToken(
        issuer: jwtOptions.Issuer,
        audience: jwtOptions.Audience,
        claims: claims,
        expires: DateTime.Now.AddDays(7),
        signingCredentials: jwtOptions.Credentials);

      return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

  }

}
