namespace opieandanthonylive.Controllers {

  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.AspNetCore.Mvc;
  using opieandanthonylive.Data.Context;
  using opieandanthonylive.ViewModels;

  [Route("api/[controller]")]
  public class RegisterController : Controller {

    readonly UserManager<IdentityUser> userManager;
    readonly CoreContext dbContext;

    public RegisterController(UserManager<IdentityUser> userManager, CoreContext dbContext) {
      this.userManager = userManager;
      this.dbContext = dbContext;
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

      return new OkObjectResult("Created!");
    }

  }

}
