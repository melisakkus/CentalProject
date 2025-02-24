using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DataAccessLayer.Repositories;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccessLayer.Concrete
{
    public class EfReviewDal : GenericRepository<Review>, IReviewDal
    {
        public EfReviewDal(CentalContext context) : base(context)
        {
        }

        public List<Review> GetReviewsById(int id)
        {
            var reviews = _context.Reviews.Where(x => x.ReviewId == id).ToList();
            return reviews;
        }
    }
}
