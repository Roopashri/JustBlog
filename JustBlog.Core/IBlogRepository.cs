using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Core.Object;

namespace JustBlog.Core
{
    public interface IBlogRepository
    {
        IList<Post> Posts(int PageNo, int PageSize);
        int TotalPosts();
    }
}
