using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Core.Object;
using FluentNHibernate.Mapping;

namespace JustBlog.Core.Mappings
{
    public class TagMap:ClassMap<Tag>
    {
        public TagMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description);
            Map(x => x.UrlSlug).Not.Nullable();
            HasManyToMany(x => x.Posts).Inverse().Cascade.All().Table("PostTagMap");
        }
    }
}
