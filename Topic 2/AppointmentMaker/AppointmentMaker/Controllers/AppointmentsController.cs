using AppointmentMaker.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentMaker.Controllers
{
    public class AppointmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowAppointmentDetails(AppointmentModel appointment)
        {

            if (IsValid(appointment) == true)
            {
                return View("ShowAppointmentDetails", appointment);
            }
            else
            {
                return View("DontShowDetails", appointment);
            }

        }

        public bool IsValid(AppointmentModel appointment)
        {
            if(appointment.PatientNetWorth > 89999 && appointment.PainLevel > 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
