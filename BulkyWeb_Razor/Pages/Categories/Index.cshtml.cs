using BulkyWeb_Razor.Data;
using BulkyWeb_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWeb_Razor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> categories;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            categories = _db.Categories.ToList();
        }
    }
}
