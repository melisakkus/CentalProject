using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class DashboardManager(IDashboardDal _dashboardDal) : IDashboardService
    {
        public int TGetBrandCount()
        {
            return _dashboardDal.GetBrandCount();
        }

        public List<Car> TGetLastAddesCars()
        {
            return _dashboardDal.GetLastAddesCars();
        }

        public int TGetReviewCount()
        {
            return _dashboardDal.GetReviewCount();
        }

        public double TGetTestimonialAvarage()
        {
            return _dashboardDal.GetTestimonialAvarage();
        }

        public int TGetTestimonialCount()
        {
            return _dashboardDal.GetTestimonialCount();
        }

        public int TTotalCarCount()
        {
            return _dashboardDal.TotalCarCount();
        }

        public int TTotalUserCount()
        {
            return _dashboardDal.TotalUserCount();
        }
    }
}
