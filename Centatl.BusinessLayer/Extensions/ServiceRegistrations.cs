using AutoMapper.Features;
using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Cental.DataAccessLayer.Abstract;
using Cental.DataAccessLayer.Concrete;
using Cental.EntityLayer.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddServiceRegistrations(this IServiceCollection services)
        {
            //IOC Container
            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IBannerDal, EfBannerDal>();
            services.AddScoped<IBannerService, BannerManager>();

            services.AddScoped<IBrandDal, EfBrandDal>();
            services.AddScoped<IBrandService, BrandManager>();

            services.AddScoped<ICarDal, EfCarDal>();
            services.AddScoped<ICarService, CarManager>();
            
            services.AddScoped<IFeatureDal, EfFeatureDal>();
            services.AddScoped<IFeatureService, FeatureManager>();

            services.AddScoped<IProcessDal,EfProcessDal>();
            services.AddScoped<IProcessService, ProcessManager>();

            services.AddScoped<IReviewDal, EfReviewDal>();
            services.AddScoped<IReviewService, ReviewManager>();

            services.AddScoped<IServiceDal, EfServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();

            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<IUserSocialService, UserSocialManager>();
            services.AddScoped<IUserSocialDal, EfUserSocialDal>();

            services.AddScoped<IDashboardDal, EfDashboardDal>();
            services.AddScoped<IDashboardService, DashboardManager>();

            services.AddScoped<IBookingDal, EfBookingDal>();
            services.AddScoped<IBookingService, BookingManager>();

            services.AddScoped<IFactCounterDal, EfFactCounterDal>();
            services.AddScoped<IFactCounterService, FactCounterManager>();

            services.AddScoped<IGeneralInfoDal, EfGeneralInfoDal>();
            services.AddScoped<IGeneralInfoService, GeneralInfoManager>();

            services.AddScoped<IImageService, ImageService>();

        }
    }
}
