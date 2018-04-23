using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustBlog.Core;
using JustBlog.Models;

namespace JustBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public ViewResult Posts(int p = 1)
        {
            //Read and return posts from repository

            //pick latest 10 posts
            //var posts = _blogRepository.Posts(p - 1, 10);
            //var totalPosts = _blogRepository.TotalPosts();
            //var listViewModel = new ListViewModel
            //{
            //    Posts = posts,
            //    TotalPosts = totalPosts
            //};
            var viewModel = new ListViewModel(_blogRepository, p);
           
            ViewBag.Title = "Latest Posts";
            //return View("List", listViewModel);
            return View("List", viewModel);

        }
        // GET: Blog
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}