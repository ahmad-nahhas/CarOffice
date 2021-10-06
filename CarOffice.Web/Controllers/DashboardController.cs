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
        private readonly IRepository<CarImage> _image;
        private readonly IWebHostEnvironment _webHost;

        public DashboardController(
            IRepository<Car> car, 
            IRepository<CarImage> image, 
            IWebHostEnvironment webHostEnvironment)
        {
            _car = car;
            _image = image;
            _webHost = webHostEnvironment;
        }

        public async Task<ActionResult> Index()
            => View(await _car.GetAsync());

        public async Task<ActionResult> Details(Guid id)
            => View(await _car.GetAsync(id));

        public ActionResult Create()
            => View();

        [HttpPost]
        public async Task<ActionResult> Create(Car car)
        {
            if (!ModelState.IsValid)
                return View(car);

            await _car.AddAsync(car);
            await SaveImages(car.Files, car.Id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var car = await _car.GetAsync(id);

            return (car != null)
                ? View(car)
                : RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Car car)
        {
            if (!ModelState.IsValid)
                return View(car);

            await _car.UpdateAsync(car);
            await UpdateImages(car.Files, car.Id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            await DeleteImages(id);
            await _car.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task SaveImages(IEnumerable<IFormFile> files, Guid carId)
        {
            if (files == null || !files.Any())
                return;

            foreach (var file in files)
            {
                using var stream = new FileStream(
                    Path.Combine(_webHost.WebRootPath, "assets",
                    "images", file.FileName), FileMode.Create);
                await file.CopyToAsync(stream);
                await _image.AddAsync(new CarImage
                {
                    CarId = carId,
                    Path = file.FileName
                });
            }
        }

        private async Task DeleteImages(Guid carId)
        {
            foreach (var image in await _image.GetAsync(new ImageFilter
            {
                CarId = carId,
                ApplyPagination = false
            }))
            {
                System.IO.File.Delete(Path.Combine(_webHost.WebRootPath, 
                    "assets", "images", image.Path));
                await _image.DeleteAsync(image.Id);
            }
        }

        private async Task UpdateImages(IEnumerable<IFormFile> files, Guid carId)
        {
            if (files == null || !files.Any())
                return;

            await DeleteImages(carId);
            await SaveImages(files, carId);
        }
    }
}