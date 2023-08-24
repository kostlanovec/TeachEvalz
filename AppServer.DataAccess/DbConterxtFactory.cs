using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AppServer.DataAccess
{
	public class DbContextFactory : IDesignTimeDbContextFactory<DataContext>
	{
		public DataContext CreateDbContext(string[] args)
		{
			// Vytváří konfigurační instanci pomocí ConfigurationBuilder,
			// nastavuje cestu k aktuálnímu adresáři a načítá konfigurační data z JSON souboru "appsettings.json".
			IConfiguration Configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

			// Nastavuje spojení na SQL Server pomocí řetězce připojení z konfiguračních dat.
			optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

			// Vytváří novou instanci DataContextu s nastavenými možnostmi.
			DataContext context = new DataContext(optionsBuilder.Options);

			return context;
		}
	}
}
