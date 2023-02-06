using System.ComponentModel.DataAnnotations;

namespace BarberShop.ViewModelsHome
{
    public class VMLogin
    {
        public VMLogin() { }

        [Display(Name = "הכנס כתובת מייל"), EmailAddress(ErrorMessage = "נא הכנס כתובת מייל תקינה")]
        public string Email { get; set; }


        [Display(Name = "הכנס סיסמא"), DataType(DataType.Password)]
        public string Password { get; set; }

        public string Feedback { get; set; } = "התחבר";
        public string Color { get; set; } = "black";
    }
}
