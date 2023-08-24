using Microsoft.EntityFrameworkCore;

namespace AppServer.DataAccess
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		/// <summary>
		/// Definuje mapování mezi třídami a tabulkami databáze.
		/// </summary>
		/// <param name="modelBuilder">Třída, která je zodpovědná za sestavneí modelu</param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
			//Seed.Initialize(modelBuilder);

			base.OnModelCreating(modelBuilder);
		}
		//#region DbSet
		//// Definice DbSetů pro každou třídu, kterou chceme mapovat na databázovou tabulku.§
		//public DbSet<User> Users { get; set; }
		//public DbSet<NetPromoterScore> NetPromoterScores { get; set; }
		//public DbSet<Server> Servers { get; set; }
		//public DbSet<Merchant> Merchants { get; set; }
		//#endregion

	}
}
