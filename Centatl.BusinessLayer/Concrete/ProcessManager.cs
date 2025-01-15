﻿using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class ProcessManager : GenericManager<Process>, IProcessService
    {
        public ProcessManager(IGenericDal<Process> genericDal) : base(genericDal)
        { }
    }
}
