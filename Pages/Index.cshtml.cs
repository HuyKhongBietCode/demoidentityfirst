using DemoIdentityEntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoIdentityEntityFramework.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyBlogContext _blogcontext;

        public IndexModel(ILogger<IndexModel> logger, MyBlogContext blogcontext)
        {
            _logger = logger;
            _blogcontext = blogcontext;
        }

        public void OnGet()
        {
            var posts = from a in _blogcontext.articles
                        orderby a.Created descending
                        select a;
            ViewData["posts"] = posts.ToList();
        }
    }
}