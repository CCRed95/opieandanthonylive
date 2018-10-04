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

      return await Task.FromResult(new OkObjectResult("I didn't actually do anything!"));

    }

    // public async Task<IActionResult> Post() {

    //   if (ModelState.IsValid == false)
    //     return BadRequest(ModelState);

    //   return await Task.FromResult(new OkObjectResult("I didn't actually do anything!"));

    // }

  }

}
