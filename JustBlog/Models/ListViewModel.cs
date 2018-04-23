using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JustBlog.Core;
using JustBlog.Core.Object;
namespace JustBlog.Models
{
    public class ListViewModel
    {
        public ListViewModel(IBlogRepository _blogRepository,int p)
        {
            Posts = _blogRepository.Posts(p - 1, 10);
            TotalPosts = _blogRepository.TotalPosts();
        }
        public IList<Post> Posts { get; set; }
        public int TotalPosts { get; set; }

    }
}