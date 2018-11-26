namespace opieandanthonylive
{
	using Microsoft.AspNetCore;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Configuration;
	using Configuration;

	public static class Program
	{
		public static void Main(
			string[] args)
		{
			var configuration = new ConfigurationBuilder()
				.AddEnvironmentVariables(EnvironmentVariables.ENVIRONMENT_VARIABLE_PREFIX)
				.Build();

			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.UseConfiguration(configuration)
				.Build()
				.Run();
		}
	}
}
