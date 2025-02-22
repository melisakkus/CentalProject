using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class FactCounterManager(IFactCounterDal _factCounterDal) : IFactCounterService
    {
        public int TGetCarCount()
        {
            return _factCounterDal.GetCarCount();
        }

        public int TGetReviewCount()
        {
            return _factCounterDal.GetReviewCount();
        }

        public int TGetBookingCount()
        {
            return _factCounterDal.GetBookingCount();
        }

        public int TGetUserCount()
        {
            return _factCounterDal.GetUserCount();
        }
    }
}
