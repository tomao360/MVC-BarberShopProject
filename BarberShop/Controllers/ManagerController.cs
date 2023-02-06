using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using BarberShop.ViewModelsManager;

namespace BarberShop.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                DataLayer.Data.GetUser = new Client { FirstName = "התחבר" };
                return RedirectToAction("Index", "Home");
            }

            User user = DataLayer.Data.Users.FirstOrDefault(u => u.RandomID == id);
            if (user != null)
            {
                if (user is Manager)
                {
                    DataLayer.Data.GetUser = user;
                    user.RND = 0;
                    DataLayer.Data.SaveChanges();
                    return View();
                }
            }

            DataLayer.Data.GetUser = new Client { FirstName = "התחבר" };
            return RedirectToAction("Index", "Home");
        }

        //---------------------------------------------------//
        //פונקציה המציגה את כל הספרים כולל האפשרות להוספת ספר
        //--------------------------------------------------//
        public IActionResult AddBarber()
        {
            List<User> users = DataLayer.Data.Users.ToList();
            List<Barber> barbers = new List<Barber>();

			foreach (User user in users)
            {
                if (user is Barber)
                {
					barbers.Add((Barber)user);
				}
            }		
            return View(new VMBarbers { Barbers = barbers});
        }

        [HttpPost, ValidateAntiForgeryToken]
		public IActionResult AddBarber(VMBarbers VM)
        {
            if (VM == null) return RedirectToAction("Index");
            VM.Barber.SetImage = VM.File;
            DataLayer.Data.Users.Add(VM.Barber);
            DataLayer.Data.SaveChanges();

            return RedirectToAction("AddBarber");
        }



		//---------------------------------------------------//
		//פונקציה המציגה את הפעולות כולל האפשרות להוספת פעולה
		//--------------------------------------------------//
		public IActionResult Actions()
        {   
            List<HaircutAction> haircutActions = DataLayer.Data.HaircutActions.ToList();     
            return View(new VMActions {HaircutActions = haircutActions });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddAction(VMActions VM)
        {
            if (VM == null) return RedirectToAction("Index");
            VM.HaircutAction.SetImage = VM.File;
            DataLayer.Data.HaircutActions.Add(VM.HaircutAction);           
            DataLayer.Data.SaveChanges();

            return RedirectToAction("Actions");
        }
    }
}
