using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Core.Object;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace JustBlog.Core
{
  public   class BlogRepository:IBlogRepository
    {
        //NHibernate Object 
        private readonly ISession _session;

        public BlogRepository(ISession session)
        {
            _session = session;
        }

        public IList<Post> Posts(int PageNo, int PageSize)
        {

            var posts = _session.Query<Post>()
                .Where(p => p.Published)
                .OrderByDescending(p => p.PostedOn)
                .Skip(PageNo * PageSize)
                .Take(PageSize)
                .Fetch(p => p.Category)
                .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return _session.Query<Post>()
                .Where(p => postIds.Contains(p.Id))
                .OrderByDescending(p => p.PostedOn)
                .FetchMany(p => p.Tags)
                .ToList();
        }

        public int TotalPosts()
        {
            return _session.Query<Post>().Where(p => p.Published).Count();
        }
    }
}
