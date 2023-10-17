using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DemoIdentityEntityFramework.Models;
using Bogus.DataSets;

namespace DemoIdentityEntityFramework.Pages.Blog
{
    public class IndexModel : PageModel
    {
        private readonly DemoIdentityEntityFramework.Models.MyBlogContext _context;

        public IndexModel(DemoIdentityEntityFramework.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;
        public const int Items_Per_page = 10;
        [BindProperty(SupportsGet =true, Name="p")]
        public int currentpage { get; set; }
        public int totalpage { get; set; }
        public async Task OnGetAsync(string SearchString)
        {
            int numberArticle = await _context.articles.CountAsync();
            totalpage = (int)Math.Ceiling((double)numberArticle/Items_Per_page);
            if(currentpage < 1)
            {
                currentpage = 1;
            }

            if(currentpage > totalpage)
            {
                currentpage = totalpage;
            }

            if (_context.articles != null)
            {
                var blogs = (from a in _context.articles
                            orderby a.Created descending
                            select a).Skip((currentpage - 1) * Items_Per_page).Take(Items_Per_page);
                if(string.IsNullOrEmpty(SearchString))
                {
                    Article = blogs.ToList();
                }
                else
                {
                    Article = blogs.Where(a => a.Title.Contains(SearchString)).ToList();
                }


                  
            }
        }
    }
}
