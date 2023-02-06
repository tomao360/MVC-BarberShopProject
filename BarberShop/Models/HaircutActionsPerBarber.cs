using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    public class HaircutActionsPerBarber
    {
        public HaircutActionsPerBarber() { }

        [Key]
        public int ID { get; set; }

        public Barber Barber { get; set; } // This will be a foreign key
        public HaircutAction HaircutAction { get; set; } // This will be a foreign key

        [Display(Name = "זמן בדקות")]
        public int Duration { get; set; }

        [Display(Name = "מחיר")]
        public int Price { get; set; }

        [Display(Name = "אחוז מסך כל הפעולות")]
        public int PercentFromTotalActions { get; set; }

    }
}
