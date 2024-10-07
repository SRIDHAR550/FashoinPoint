using Fashion.Application.Common;
using Fashion.Application.Interfaces;
using Fashion.Domin.Model;
using Microsoft.AspNetCore.Mvc;

namespace FashoinPoint.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClothesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ClothesController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Clothes> clothes = await _unitOfWork.Clothes.GetAllAsync();

            return View(clothes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Clothes clothes)
        {

            if (ModelState.IsValid)
            {
                await _unitOfWork.Clothes.Create(clothes);
                await _unitOfWork.SaveAsync();

                TempData["success"] = CommonMessages.RecordCreated;

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            Clothes clothes = await _unitOfWork.Clothes.GetByIdAsync(id);
            return View(clothes);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Clothes clothes = await _unitOfWork.Clothes.GetByIdAsync(id);
            return View(clothes);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Clothes clothes)
        {

            if (ModelState.IsValid)
            {
                await _unitOfWork.Clothes.Update(clothes);
                await _unitOfWork.SaveAsync();

                TempData["warning"] = CommonMessages.RecordUpdated;

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            Clothes clothes = await _unitOfWork.Clothes.GetByIdAsync(id);
            return View(clothes);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Clothes clothes)
        {
            await _unitOfWork.Clothes.Delete(clothes);
            await _unitOfWork.SaveAsync();

            TempData["error"] = CommonMessages.RecordDeleted;

            return RedirectToAction(nameof(Index));
        }
    }
}
