using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class Manager:User
    {
        [Display(Name = "תאריך תחילת מינוי"), DataType(DataType.Date)] 
        public DateTime Date { get; set; }        
    }
}
