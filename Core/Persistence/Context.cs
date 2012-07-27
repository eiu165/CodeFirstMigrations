using System.Data.Entity;
using Core.Model;

namespace Core.Persistence
{
	public partial class Context : DbContext
	{
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context, Configuration>());
		}
	}



    public partial class Context
    {
        static Context()
        {
            Database.SetInitializer(new TestDataInitializer());
        }


        private class TestDataInitializer :
            CreateDatabaseIfNotExists<Context>
            //DropCreateDatabaseIfModelChanges<Context>
            //DropCreateDatabaseAlways<Context>
        {

            protected override void Seed(Context context)
            {
                var u = new User { Name = "alpha", EmailAddress = "a@test.com" };
                context.Users.Add(u);
                context.Users.Add(new User { Name = "bbb", EmailAddress = "bbbb@test.com" });
                context.Users.Add(new User { Name = "ccc", EmailAddress = "ccc@test.com" });
                context.SaveChanges();
            }
        }
    }
}
