using System.Data.Entity.Migrations;
using Core.Model;

namespace Core.Persistence
{
    public class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Context context)
        {

            context.Articles.AddOrUpdate(
              x => x.Name,
              new Article { Name = "test 1" },
              new Article { Name = "test 2" },
              new Article { Name = "test 3" },
              new Article { Name = "test 4" }
            );
        }
    }
}
