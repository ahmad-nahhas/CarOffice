using CarOffice.Shared.Entities;
using CarOffice.Shared.Filters;
using CarOffice.Shared.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarOffice.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IRepository<Car> _car;
        private readonly IRepository<CarBrand> _brand;
        private readonly IRepository<CarImage> _image;
        private readonly IWebHostEnvironment _webHost;

        public DashboardController(IRepository<Car> car,
                                   IRepository<CarBrand> brand,
                                   IRepository<CarImage> image,
                                   IWebHostEnvironment webHostEnvironment)
        {
            _car = car;
            _brand = brand;
            _image = image;
            _webHost = webHostEnvironment;
        }

        public async Task<ActionResult> Index()
            => View(await _car.GetAsync());

        public async Task<ActionResult> Details(Guid id)
            => View(await _car.GetAsync(id));

        public async Task<ActionResult> Create()
        {
            ViewBag.Brands = await _brand.GetAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Car car)
        {
            try
            {
                if (car == null || !ModelState.IsValid)
                    return RedirectToAction(nameof(Create));

                await _car.AddAsync(car);
                await SaveImages(car.Files, car.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Create));
            }
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                ViewBag.Brands = await _brand.GetAsync();

                var car = await _car.GetAsync(id);

                return (car != null) ? View(car) :
                    RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Car car)
        {
            try
            {
                if (car == null || !ModelState.IsValid)
                    return RedirectToAction(nameof(Edit));

                await _car.UpdateAsync(car);
                await UpdateImages(car.Files, car.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await DeleteImages(id);
                await _car.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        private async Task SaveImages(IEnumerable<IFormFile> files, Guid carId)
        {
            if (files != null && files.Any())
            {
                foreach (var file in files)
                {
                    string path = Path.Combine(_webHost.WebRootPath, "assets", "images", file.FileName);

                    using var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);

                    await _image.AddAsync(new CarImage { CarId = carId, Path = file.FileName });
                }
            }
        }

        private async Task UpdateImages(IEnumerable<IFormFile> files, Guid carId)
        {
            if (files != null && files.Any())
            {
                await DeleteImages(carId);
                await SaveImages(files, carId);
            }
        }

        private async Task DeleteImages(Guid carId)
        {
            var images = await _image.GetAsync(new ImageFilter() { CarId = carId, ApplyPagination = false });

            foreach (var image in images)
            {
                string path = Path.Combine(_webHost.WebRootPath, "assets", "images", image.Path);
                System.IO.File.Delete(path);

                await _image.DeleteAsync(image.Id);
            }
        }
    }
}