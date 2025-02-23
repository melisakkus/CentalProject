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
        int TotalUserCount(); //tamam
        int TotalCarCount(); //tamam
        int GetBrandCount(); //tamam 
        int GetReviewCount();
        int GetTestimonialCount(); //tamam
        double GetTestimonialAvarage(); //tamam
        List<Car> GetLastAddesCars();
        List<Booking> GetBookings();
        int GetBookingCount(); //tamam
        int ApprovedBookingCount(); //tamam
        int WaitingBookingCount(); //tamam
        int DeclineBookingCount(); //tamam

        List<Message> GetMessages();
        int GetMessageCount(); //tamam
        List<Testimonial> GetTestimonials();
    }
}
