using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Core.Object;
using FluentNHibernate.Mapping;


namespace JustBlog.Core.Mappings
{
    public class PostMap:ClassMap<Post>
    {
     
        public PostMap()
        {
            Id(x => x.Id);
            Map(x => x.Title).Length(200).Not.Nullable();
            Map(x => x.Description).Length(5000).Not.Nullable();
            Map(x => x.ShortDescription).Length(2000);
            Map(x => x.Meta).Length(2000).Not.Nullable();
            Map(x => x.UrlSlug).Length(200).Not.Nullable();
            Map(x => x.Modified);
            Map(x => x.Published).Not.Nullable();
            Map(x => x.PostedOn).Not.Nullable();
            References(x => x.Category).Column("Category").Not.Nullable();
            HasManyToMany(x => x.Tags).Table("PostTagMap");
        }

    }
}
