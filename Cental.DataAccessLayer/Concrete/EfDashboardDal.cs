using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrete
{
    public class EfDashboardDal : IDashboardDal
    {
        protected readonly CentalContext _context;
        public EfDashboardDal(CentalContext context)
        {
            _context = context;
        }
        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }

        public List<Car> GetLastAddesCars()
        {
            var cars = _context.Cars.OrderByDescending(x => x.CarId).Take(4).ToList();
            return cars;
        }

        public int GetReviewCount()
        {
            return _context.Reviews.Count();
        }

        public double GetTestimonialAvarage()
        {
            var avarage = _context.Testimonials.Average(x => x.Review);
            return avarage;
        }

        public int GetTestimonialCount()
        {
            return _context.Testimonials.Count();
        }

        public int TotalCarCount()
        {
            return _context.Cars.Count();
        }

        public int TotalUserCount()
        {
            return _context.Users.Count();
        }
    }
}
