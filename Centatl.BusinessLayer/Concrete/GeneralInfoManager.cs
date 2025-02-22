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
    public class GeneralInfoManager (IGeneralInfoDal _generalInfoDal):  IGeneralInfoService
    {
        public void TCreate(GeneralInfo entity)
        {
            _generalInfoDal.Create(entity);
        }

        public void TDelete(int id)
        {
            _generalInfoDal.Delete(id);
        }

        public List<GeneralInfo> TGetAll()
        {
            return _generalInfoDal.GetAll();
        }

        public GeneralInfo TGetById(int id)
        {
            return _generalInfoDal.GetById(id);
        }

        public void TUpdate(GeneralInfo entity)
        {
            _generalInfoDal.Update(entity);
        }
    }
}
