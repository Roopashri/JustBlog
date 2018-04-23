using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Core.Object;
using FluentNHibernate.Mapping;

namespace JustBlog.Core.Mappings
{
    public class CategoryMap:ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description);
            Map(x => x.UrlSlug).Not.Nullable();
            HasMany(x => x.Posts).Inverse().Cascade.All().KeyColumn("Category");
        }
    }
}
