using HW_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_4.Controllers
{
    public class CarController : Controller
    {
        private static List<Car> availableCars = new List<Car> {
            new Car{Id=1,Name="Alto",PricePerDay=3000},
            new Car{Id=2,Name="Corolla",PricePerDay=6000},
            new Car{Id=3,Name="Civic",PricePerDay=8000}
        };
        private static List<Car> bookedCars = new List<Car>();

        [HttpGet]
        public IActionResult Index()
        {
            return View(availableCars);
        }
        [HttpPost]
        public IActionResult Book(int carId)
        {
            Car car = availableCars.Find(car=>car.Id==carId);
            if (car==null)
            {
                return RedirectToAction("Index");
            }
            bookedCars.Add(car);
            availableCars.Remove(car);
            return RedirectToAction("Booked");
        }
        [HttpGet]
        public IActionResult Booked()
        {
            return View(bookedCars);
        }
    }
}
