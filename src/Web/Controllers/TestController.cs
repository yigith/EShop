using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly ShopContext db;

        public TestController(IAsyncRepository<Category> categoryRepository, ShopContext db)
        {
            _categoryRepository = categoryRepository;
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            var urunler = db.Products.Where(x => x.CategoryId == 3);
            return View(await _categoryRepository.ListAllAsync());
        }
    }
}
