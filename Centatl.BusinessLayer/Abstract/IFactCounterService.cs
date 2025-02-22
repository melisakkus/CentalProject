﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Abstract
{
    public interface IFactCounterService
    {
        int TGetUserCount();
        int TGetCarCount();
        int TGetReviewCount();
        int TGetBookingCount();
    }
}
