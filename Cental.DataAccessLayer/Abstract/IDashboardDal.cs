using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Abstract
{
    public interface IDashboardDal
    {
        int TotalUserCount();
        int TotalCarCount();
        int GetBrandCount();
        int GetReviewCount();
        int GetTestimonialCount();
        double GetTestimonialAvarage();
        List<Car> GetLastAddesCars();
    }
}
