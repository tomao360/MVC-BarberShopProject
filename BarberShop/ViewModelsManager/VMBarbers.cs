using BarberShop.Models;

namespace BarberShop.ViewModelsManager
{
    public class VMBarbers
    {
        public VMBarbers()
        {
            Barbers = new List<Barber>();
            Barber= new Barber();
        }

        public List<Barber> Barbers { get; set; }
        public Barber Barber { get; set; }
        public IFormFile File { get; set; }
    }
}
