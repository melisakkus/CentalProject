using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;

namespace Cental.BusinessLayer.Concrete
{
    public class BrandManager : GenericManager<Brand>, IBrandService
    {
        public BrandManager(IGenericDal<Brand> genericDal) : base(genericDal)
        {
        }
    }
}
