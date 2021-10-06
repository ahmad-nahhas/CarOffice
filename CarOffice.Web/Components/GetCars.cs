using CarOffice.Shared.Entities;
using CarOffice.Shared.Filters;
using CarOffice.Shared.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarOffice.Web.Components
{
    public class GetCars : ViewComponent
    {
        private readonly IRepository<Car> _repository;

        public GetCars(IRepository<Car> repository)
            => _repository = repository;

        public async Task<IViewComponentResult> InvokeAsync(CarFilter filter)
            => View(await _repository.GetAsync(filter));
    }
}