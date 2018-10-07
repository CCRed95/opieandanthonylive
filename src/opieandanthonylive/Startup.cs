namespace opieandanthonylive {

  using System;
  using System.Text;
  using Microsoft.AspNetCore.Authentication.JwtBearer;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.AspNetCore.SpaServices.Webpack;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.IdentityModel.Tokens;
  using opieandanthonylive.Auth;
  using opieandanthonylive.Data.Context;

  public partial class Startup {

    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services) {

      services.AddDbContext<CoreContext>(options =>
        options.UseSqlServer(
          Configuration.GetConnectionString("DefaultConnection"),
          b => b.MigrationsAssembly("opieandanthonylive.Data")));

      services.Configure<CookiePolicyOptions>(options => {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
      });

      ConfigureJwtAuth(services);
      ConfigureIdentity(services);

      services.AddMvc()
        .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
    }

    static void ConfigureJwtAuth(IServiceCollection services) {

      /*
       * TODO: put these in an environment variable.
       */
      const string JwtIssuer = "https://opieandanthonylive.net/api/auth/";
      const string JwtAudience = "https://opieandanthonylive.net/api/";

      /*
       * TODO: PUT THIS IN AN ENVIRONMENT VARIABLE.
       */
      const string jwtSecretKey = "1234567890abcdefghijklmnopqrstuvwxyz";
      var jwtSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecretKey));

      services.Configure<JwtIssuerOptions>(options => {
        options.Issuer      = JwtIssuer;
        options.Audience    = JwtAudience;
        options.Credentials = new SigningCredentials(jwtSigningKey, SecurityAlgorithms.HmacSha256);
      });

      var tokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
        ValidIssuer = JwtIssuer,

        ValidateAudience = true,
        ValidAudience = JwtAudience,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = jwtSigningKey,

        RequireExpirationTime = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(5),
      };

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => {
          options.ClaimsIssuer = JwtIssuer;
          options.TokenValidationParameters = tokenValidationParameters;
          options.SaveToken = true;
        });

      services.AddAuthorization(options => {
        options.AddPolicy("auth/test", p => p.RequireClaim("rol", "auth/test"));
      });

    }

    static void ConfigureIdentity(IServiceCollection services) {

      /* This has got to be one of the weirdest patterns for configuration */
      var identity = services.AddIdentityCore<IdentityUser>(o => {
        o.Password.RequireDigit = false;
        o.Password.RequireLowercase = false;
        o.Password.RequireUppercase = false;
        o.Password.RequireNonAlphanumeric = false;
        o.Password.RequiredLength = 6;
      });

      new IdentityBuilder(identity.UserType, typeof(IdentityRole), identity.Services)
        .AddEntityFrameworkStores<CoreContext>().AddDefaultTokenProviders();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
          HotModuleReplacement = true
        });
      } else {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();

      app.UseAuthentication();

      app.UseMvc(routes => {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");

        routes.MapSpaFallbackRoute(
            name: "spa-fallback",
            defaults: new { controller = "Home", action = "Index" });
      });
    }
  }
}