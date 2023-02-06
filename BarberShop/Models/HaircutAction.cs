using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class HaircutAction
    {
        public HaircutAction()
        {
            HaircutActionsPerBarbers = new List<HaircutActionsPerBarber>();
        }


        [Key]
        public int ID { get; set; }


        [Required, Display(Name = "סוג")]
        public string Name { get; set; }


        [Display(Name = "תיאור")]
        public string Description { get; set; }


        // רשימה של כל הספרים שעושים פעולה מסויימת, למשל אם אחפש פעולה פן אני אקבל את כל הספרים שעושים פן
        public List<HaircutActionsPerBarber> HaircutActionsPerBarbers { get; set; }


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

    }
}
