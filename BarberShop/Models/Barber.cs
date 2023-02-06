using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class Barber:User
    {
        public Barber () 
        {
            HaircutList = new List<HaircutActionsPerBarber>();
        }

        [Display(Name = "תיאור הספר")]
        public string Description { get; set; }


        // רשימה של כל הפעולות שהספר מבצע 
        public List<HaircutActionsPerBarber> HaircutList { get; set; }


        [Display(Name = "תמונה")]
        public byte[] Image { get; set; }

        // לוקחת את הקובץ של התמונה, מעבירה לקלאס ששם מתבצעת ההמרה למערך של ביטים, מחזירה לפה את המערך של ביטים ומכניסה לתמונה שיש פה
        public IFormFile SetImage
        {
            set
            {
                Image = new SetImage(value).Image;
            }
        }

        // פונקציה המוסיפה פעולה
        public void AddHaircutAction(string haircut, int price, int duration, int percent)
        {
            HaircutAction haircutAction = DataLayer.Data.HaircutActions.ToList().Find(a => a.Name == haircut);
            if (haircutAction == null) return;

            // עושים מופע חדש של פעולה לספר ומכניסים לו את כל הערכים 
            HaircutActionsPerBarber haircutActionsPerBarber = new HaircutActionsPerBarber { HaircutAction = haircutAction, Barber = this, Duration = duration, Price = price, PercentFromTotalActions = percent };

            // הוספה לרשימה של הספר שנמצאת בקלאס הזה => Barber
            HaircutList.Add(haircutActionsPerBarber);

            // הוספה לרשימה של הפעולות שנמצאת בקלאס של פעולה => HaircutAction
            haircutAction.HaircutActionsPerBarbers.Add(haircutActionsPerBarber);
        }
    }
}