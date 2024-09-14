using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Utilites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var objCategoryList = _unitOfWork.company.GetAll();
            return View(objCategoryList);
        }

        public IActionResult Upsert(int? id) //create and/or update
        {
            //create
            if (id == null || id == 0)
                return View(new Company());

            //update
            else
            {
                Company companyObj = _unitOfWork.company.Get(u => u.Id == id, null);
                return View(companyObj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Company companyObj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (companyObj.Id == 0)
                    _unitOfWork.company.Add(companyObj);
                else
                    _unitOfWork.company.Update(companyObj);

                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(companyObj);
            }
        }

        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //        return NotFound();

        //    Company objCategory = _unitOfWork.company.Get(u => u.Id == id, null);
        //    if (objCategory == null)
        //        return NotFound();

        //    return View(objCategory);
        //}

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Company? obj = _unitOfWork.company.Get(u => u.Id == id, null);
            if (obj == null)
                return NotFound();

            _unitOfWork.company.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Company deleted successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var objCategoryList = _unitOfWork.company.GetAll();
            return Json(new { data = objCategoryList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToDelete = _unitOfWork.company.Get(u => u.Id == id, null);
            if (productToDelete == null)
                return Json(new { success = false, message = "Error while deleting" });

            _unitOfWork.company.Remove(productToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Company deleted successfully" });
        }
    }
}
