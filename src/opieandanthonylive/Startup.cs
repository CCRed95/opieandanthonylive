namespace opieandanthonylive {

  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.SpaServices.Webpack;
  using Microsoft.EntityFrameworkCore;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using opieandanthonylive.Data.Context;
  using opieandanthonylive.Data.Respositories;

  public class Startup {


    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {

      services.AddDbContext<CoreContext>(
        t => t.UseSqlServer(Configuration.GetConnectionString( "DefaultConnection"))); 

      services.AddScoped<IAudibleItemMetadataRepository, AudibleItemMetadataRepository>();
      services.AddScoped<IGuestRepository, GuestRepository>();

      services.Configure<CookiePolicyOptions>(options => {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
      });

      services.AddMvc()
          .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

      app.UseMvc(routes => {
        routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}");

        routes.MapSpaFallbackRoute(
            name: "spa-fallback",
            defaults: new { controller = "Home", action = "Index" });
      });

      using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
      using (var context = serviceScope.ServiceProvider.GetRequiredService<CoreContext>()) {
        //foreach (var guest in context.Guests)
        //  guest.HeadshotImagePath = guest.FirstName + " " + guest.LastName + ".jpg";

        context.SaveChanges();
      }
    }
  }
}

#region old
//using (var context = new CoreContext(
//  new DbContextOptions<CoreContext>()))
//{

//}
//context.Database.Migrate();
//context.Database.EnsureCreated();
//context.SaveChanges();

//var test = new AudibleItemMetadata
//{
//  ItemTypeClassification = "Radio / TV Program",
//  Title = "Ron and Fez, May 17, 2007",
//  By = "Opie and Anthony" 
//context.AudibleItemMetadatas.Add(test);
//context.SaveChanges();
//context.Database.OpenConnection();
//context.SetIdentityInsert(t => t.Genders, true);
//context.Seed(t => t.Genders, t => t.GenderID);
//context.SaveChanges();
//context.SetIdentityInsert(t => t.Genders, false);
//context.Database.CloseConnection();

//context.Genders.Seed()
//context.SeedWithIdentities(t => t.Genders, t => t.GenderID);
//context.SeedWithIdentities(t => t.Guests, t => t.GuestID);
//context.SeedWithIdentities(t => t.GuestAppearanceTypes, t => t.GuestAppearanceTypeID);
//context.SeedWithIdentities(t => t.Shows, t => t.ShowID);
//context.SeedWithIdentities(t => t.ShowHosts, t => t.ShowHostID);
//context.SeedWithIdentities(t => t.ShowRundownAuthors, t => t.ShowRundownAuthorID);

#endregion
