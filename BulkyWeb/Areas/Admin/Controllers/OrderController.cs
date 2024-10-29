using Bulky.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var objOrderHeaders = _unitOfWork.orderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
            return Json(new { data = objOrderHeaders });
        }
    }
}
