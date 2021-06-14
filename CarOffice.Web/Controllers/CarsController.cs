using CarOffice.Shared.Entities;
using CarOffice.Shared.Filters;
using CarOffice.Shared.Repositories.Interfaces;
using CarOffice.Web.Models;
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

        public async Task<IActionResult> Index([FromQuery] CarFilter filter = null)
            => View(new CarFilterViewModel
            {
                Cars = await _repository.GetAsync(filter ??= new CarFilter()),
                Filter = filter
            });

        public async Task<IActionResult> Details(Guid id)
            => View(await _repository.GetAsync(id));
    }
}