using CarOffice.Shared.Entities;
using CarOffice.Shared.Filters;
using CarOffice.Shared.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarOffice.Web.Controllers
{
    public class CarsController : Controller
    {
        private readonly IRepository<Car> _repository;

        public CarsController(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
            => View(new CarFilter());

        public IActionResult GetFiltered(CarFilter filter)
            => ViewComponent("GetCars", new { filter });

        public async Task<IActionResult> Details(Guid id)
            => View(await _repository.GetAsync(id));
    }
}