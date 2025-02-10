using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DtoLayer.Enums;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Drawing.Drawing2D;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class CarsController(ICarService _carService, IBrandService _brandService, CentalContext _context) : Controller
    {
        public IActionResult Index()
        {
            if (TempData["FilterCars"] != null)
            {
                var data = TempData["FilterCars"].ToString();
                if (data != null)
                {
                    var filterCars = JsonSerializer.Deserialize<List<Car>>(data, new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.IgnoreCycles
                    });
                    return View(filterCars);

                }
            }
            var values = _carService.TGetAll();
            return View(values);

        }

        [HttpPost]
        public IActionResult FilterCars(string brand, string gear, string gas, int year)
        {
            IQueryable<Car> values = _context.Cars.AsQueryable(); //filtrelenebilir bir liste oluşturduk.
            //asqueryable kullandık çünkü value içerisinde şartlı sorgulama yani where koşullarını kullanabilmek için.

            if (!string.IsNullOrEmpty(brand)){ 
                values = values.Where(x => x.Brand.BrandName == brand);

            }

            if (!string.IsNullOrEmpty(gear))
            {
                values = values.Where(x => x.GearType == gear);

            }

            if (!string.IsNullOrEmpty(gas))
            {
                values = values.Where(x => x.GasType == gas);

            }

            if (year>0)
            {
                values = values.Where(x => x.Year >= year);

            }

            var filterList = values.ToList(); //filtrelenebilir listeyi normal listeye çevirdik
            //Iquaryable tipinde olduğu için listeye çeviriyoruz çünkü view'e liste tipinde veri taşıyacağız.
            //farklı view'e taşıyacağımız için TempData kullanıyoruz.   
            //tempdata tipini bilemeyeceğimiz için json formatına çevirip taşıyoruz.
            //ilişkili tablo olduğu için döngüye girmemesi adına ReferenceHandler.IgnoreCycles kullanıyoruz.
            TempData["FilterCars"] = JsonSerializer.Serialize(filterList, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            });
            return RedirectToAction("Index");
        }
    }
}