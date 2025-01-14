using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cental.DataAccessLayer.Abstract;

namespace Cental.BusinessLayer.Concrete
{
    public class BrandManager : GenericManager<Brand>, IBrandService
    {
        public BrandManager(IGenericDal<Brand> genericDal) : base(genericDal)
        {
        }
    }
}
