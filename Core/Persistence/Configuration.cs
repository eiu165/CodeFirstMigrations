using System.Data.Entity.Migrations;
using Core.Model;
using System.Collections.Generic;

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
            var articles = new List<Article>();
            for (int i = 0; i < 10; i++)
            {
                articles.Add(new Article { Name = "test " + i, AssignedTo = "Tom", Url = "test-" + i, Content = "lourm ipsum", Title = "Test " + i });
            }
            var tags = new List<Tag>();
            for (int i = 0; i < 10; i++)
            {
                tags.Add(new Tag { Name = "tag " + i , Articles = new List<Article>{ new Article{ Title= "asdfas" , Url = "aaaaaaaaa"}}});
            }
            context.Articles.AddOrUpdate(x => x.Name, articles.ToArray());
            context.Tags.AddOrUpdate(x => x.Name, tags.ToArray());
        }
    }
}
