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
            for (int i = 0; i < 4; i++)
            {
                articles.Add(new Article { Name = "test " + i,  Content = "lourm ipsum"  });
            }
            var tags = new List<Tag>();
            for (int i = 0; i < 4; i++)
            {
                tags.Add(new Tag { Name = "tag " + i });
            }
            var articleTag = new List<ArticleTag>();
            for (int i = 0; i < 4; i++)
            {
                articleTag.Add(new ArticleTag { Name="articleTag"+ i, Article = articles[i], Tag = tags[i] });
            }
            context.Articles.AddOrUpdate(x => x.Name, articles.ToArray());
            context.Tags.AddOrUpdate(x => x.Name, tags.ToArray());
            context.ArticleTags.AddOrUpdate(x => x.Name, articleTag.ToArray());
        }
    }
}
