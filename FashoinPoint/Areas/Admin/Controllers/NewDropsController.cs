using Fashion.Application.Common;
using Fashion.Application.Interfaces;
using Fashion.Domin.ApplicationEnums;
using Fashion.Domin.Model;
using Fashion.Domin.ViewModel;
using Fashion.Infrastructure.Repositorys;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FashoinPoint.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewDropsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NewDropsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            List<NewDrops> newDrops = await _unitOfWork.NewDrops.GetAllNewDrops();

            return View(newDrops);

        }

        [HttpGet]
        public IActionResult Create()
        {

            IEnumerable<SelectListItem> brandList = _unitOfWork.Brand.Query().Select(x => new SelectListItem
            {
                Text = x.Name.ToUpper(),
                Value = x.Id.ToString()
            });

            IEnumerable<SelectListItem> clothesList = _unitOfWork.Clothes.Query().Select(x => new SelectListItem
            {
                Text = x.Name.ToUpper(),
                Value = x.Id.ToString()
            });

            IEnumerable<SelectListItem> sizesList = Enum.GetValues(typeof(Sizes))
                .Cast<Sizes>()
                .Select(x => new SelectListItem
                {
                    Text = x.ToString().ToUpper(),
                    Value = ((int)x).ToString()
                });

         
            NewDropVM newDropsVM = new NewDropVM
            {
                NewDrops = new NewDrops(),
                BrandList = brandList,
                ClothesList = clothesList,
                SizesList = sizesList

            };

            return View(newDropsVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewDropVM newDropsVM)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;

            var file = HttpContext.Request.Form.Files;

            if (file.Count > 0)
            {
                string newFileName = Guid.NewGuid().ToString();

                var upload = Path.Combine(webRootPath, @"images\newDrops");

                var extension = Path.GetExtension(file[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(upload, newFileName + extension), FileMode.Create))
                {
                    file[0].CopyTo(fileStream);
                }
                newDropsVM.NewDrops.ClotheImage = @"\images\newDrops\" + newFileName + extension;
            }


            if (ModelState.IsValid)
            {
                await _unitOfWork.NewDrops.Create(newDropsVM.NewDrops);
                await _unitOfWork.SaveAsync();

                TempData["success"] = CommonMessages.RecordCreated;

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            NewDrops newDrops = await _unitOfWork.NewDrops.GetNewDropsById(id);
            return View(newDrops);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            NewDrops newDrops = await _unitOfWork.NewDrops.GetNewDropsById(id);

            IEnumerable<SelectListItem> brandList = _unitOfWork.Brand.Query().Select(x => new SelectListItem
            {
                Text = x.Name.ToUpper(),
                Value = x.Id.ToString()
            });

            IEnumerable<SelectListItem> ClothesList = _unitOfWork.Clothes.Query().Select(x => new SelectListItem
            {
                Text = x.Name.ToUpper(),
                Value = x.Id.ToString()
            });

            IEnumerable<SelectListItem> sizesList = Enum.GetValues(typeof(Sizes))
                .Cast<Sizes>()
                .Select(x => new SelectListItem
                {
                    Text = x.ToString().ToUpper(),
                    Value = ((int)x).ToString()
                });

          
            NewDropVM newDropsVM = new NewDropVM
            {
                NewDrops = newDrops,
                BrandList = brandList,
                ClothesList = ClothesList,
                SizesList = sizesList

            };

            return View(newDropsVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(NewDropVM newDropVM)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;

            var file = HttpContext.Request.Form.Files;

            if (file.Count > 0)
            {
                string newFileName = Guid.NewGuid().ToString();

                var upload = Path.Combine(webRootPath, @"images\newDrops");

                var extension = Path.GetExtension(file[0].FileName);

                /// delete old image

                var objFromDb = await _unitOfWork.NewDrops.GetByIdAsync(newDropVM.NewDrops.Id);

                if (objFromDb != null)
                {
                    var oldImagePath = Path.Combine(webRootPath, objFromDb.ClotheImage.Trim('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }

                }

                using (var fileStream = new FileStream(Path.Combine(upload, newFileName + extension), FileMode.Create))
                {
                    file[0].CopyTo(fileStream);
                }
                newDropVM.NewDrops.ClotheImage = @"\images\newDrops\" + newFileName + extension;
            }


            if (ModelState.IsValid)
            {
                await _unitOfWork.NewDrops.Update(newDropVM.NewDrops);
                await _unitOfWork.SaveAsync();

                TempData["warning"] = CommonMessages.RecordUpdated;

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            NewDrops newDrops = await _unitOfWork.NewDrops.GetByIdAsync(id);

            IEnumerable<SelectListItem> brandList = _unitOfWork.Brand.Query().Select(x => new SelectListItem
            {
                Text = x.Name.ToUpper(),
                Value = x.Id.ToString()
            });

            IEnumerable<SelectListItem> clothesList = _unitOfWork.Clothes.Query().Select(x => new SelectListItem
            {
                Text = x.Name.ToUpper(),
                Value = x.Id.ToString()
            });

            IEnumerable<SelectListItem> sizesList = Enum.GetValues(typeof(Sizes))
                .Cast<Sizes>()
                .Select(x => new SelectListItem
                {
                    Text = x.ToString().ToUpper(),
                    Value = ((int)x).ToString()
                });

            NewDropVM newDropsVM = new NewDropVM
            {
                NewDrops = newDrops,
                BrandList = brandList,
                ClothesList = clothesList,
                SizesList = sizesList
              
            };

            return View(newDropsVM);


        }
        [HttpPost]
        public async Task<IActionResult> Delete(NewDropVM newDropsVM)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            if (!string.IsNullOrEmpty(newDropsVM.NewDrops.ClotheImage))
            {
                /// delete old image

                var objFromDb = await _unitOfWork.NewDrops.GetByIdAsync(newDropsVM.NewDrops.Id);

                if (objFromDb != null)
                {
                    var oldImagePath = Path.Combine(webRootPath, objFromDb.ClotheImage.Trim('\\'));

                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }

                }

            }
            await _unitOfWork.NewDrops.Delete(newDropsVM.NewDrops);
            await _unitOfWork.SaveAsync();

            TempData["error"] = CommonMessages.RecordDeleted;

            return RedirectToAction(nameof(Index));
        }

    }
}
