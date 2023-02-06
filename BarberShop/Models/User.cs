using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberShop.Models
{
    public abstract class User  // קלאס שמיועד להורשה בלבד - לא מיועד לשימוש עצמי
    {
        public User()
        {
            RND = 0;
        }


        [Key]
        public int ID { get; set; }

        [Required, Display(Name = "שם פרטי")]
        public string FirstName { get; set; }


        [Display(Name = "שם משפחה")]
        public string LastName { get; set; }


        [Display(Name = "שם מלא"), NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }


        [Display(Name = "מספר טלפון")]
        public string PhoneNumber { get; set; }


        [Display(Name = "כתובת מייל"), EmailAddress(ErrorMessage = "נא הכנס כתובת מייל תקינה ")]
        public string Email { get; set; }


        [Display(Name = "סיסמא"), DataType(DataType.Password)]
        public string Password { get; set; }

        // מספר נוסף המשתנה רנדומלי עם כל התחברות למערכת
        public int RandomID { get; set; }

        [NotMapped]
        public int RND
        {
            get
            {
                return (ID * 100000) + RandomID;
            }
            set
            {
                Random random = new Random();
                RandomID = random.Next(10000, 99999);
            }
        }
    }
}
