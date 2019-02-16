using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.SameSiteMode;

namespace opieandanthonylive
{
  using Auth;
  using Ccr.Std.Core.Extensions;
  using Data.Context;
  using Microsoft.AspNetCore.Authentication.JwtBearer;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using Microsoft.IdentityModel.Tokens;
  using Controllers;
  using System;
  using System.IO;
  using System.Text;
  using static Configuration.EnvironmentVariables;

  public class Startup
  {
    public IConfiguration Configuration { get; }


    public Startup(
      IConfiguration configuration)
    {
      Configuration = configuration;
    }


    public void ConfigureServices(
      IServiceCollection services)
    {
      services.AddDbContext<CoreContext>(o => o
        .UseSqlServer(
          Configuration.GetConnectionString("DefaultConnection"),
          b => b.MigrationsAssembly("opieandanthonylive.Data")));

      services.Configure<CookiePolicyOptions>(
        options => {
          options.CheckConsentNeeded = context => true;
          options.MinimumSameSitePolicy = None;
        });

      ConfigureIdentity(services);
      ConfigureJwtAuth(services);

      services
        .AddMvc()
        .SetCompatibilityVersion(
          CompatibilityVersion.Version_2_1);

      services.AddScoped<IGuestsService, HardcodedGuestsService>();
    }

    private static void ConfigureIdentity(
      IServiceCollection services)
    {
      var identity = services.AddIdentityCore<IdentityUser>(
        o => {
          o.Password.RequireDigit = false;
          o.Password.RequireLowercase = false;
          o.Password.RequireUppercase = false;
          o.Password.RequireNonAlphanumeric = false;
          o.Password.RequiredLength = 6;
        });

      var _ = new IdentityBuilder(
          identity.UserType,
          typeof(IdentityRole),
          identity.Services)
        .AddEntityFrameworkStores<CoreContext>()
        .AddDefaultTokenProviders();
    }

    private void ConfigureJwtAuth(IServiceCollection services)
    {
      T GetConfigurationValue<T>(string environmentVariableName)
      {
        var value = Configuration.GetValue<T>(
          environmentVariableName);

        if (value == null)
          throw new ApplicationException(
            $"Missing configuration value {environmentVariableName.SQuote()}\n\n. " +
            $"Are you missing an environment variable?");

        return value;
      }

      var JwtIssuer = GetConfigurationValue<string>(JWT_ISSUER);
      var JwtAudience = GetConfigurationValue<string>(JWT_AUDIENCE);
      var jwtSecretKey = GetConfigurationValue<string>(JWT_SECRET);

      var jwtSigningKey = new SymmetricSecurityKey(
        Encoding.ASCII.GetBytes(jwtSecretKey));

      services.Configure<JwtIssuerOptions>(
        options =>
        {
          options.Issuer = JwtIssuer;
          options.Audience = JwtAudience;
          options.Credentials = new SigningCredentials(
            jwtSigningKey,
            SecurityAlgorithms.HmacSha256);
        });

      var tokenValidationParameters = new TokenValidationParameters
      {
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

      services
        .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(
          options =>
          {
            options.ClaimsIssuer = JwtIssuer;
            options.TokenValidationParameters = tokenValidationParameters;
            options.SaveToken = true;
          });

      services.AddAuthorization();
    }

    public void Configure(
      IApplicationBuilder app,
      IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }
      app.UseHttpsRedirection();
      app.UseAuthentication();
      app.MapWhen(
        x => x.Request.Path.Value.StartsWith("/api") == false,
        builder => {
          builder.Use(
              async (context, next) =>
              {
                await next();

                if (context.Response.StatusCode == 404 &&
                  !Path.HasExtension(context.Request.Path.Value))
                {
                  context.Request.Path = "/index.html";
                  await next();
                }
              })
            .UseDefaultFiles()
            .UseStaticFiles();
        });
      app.UseMvcWithDefaultRoute();
    }
  }
}