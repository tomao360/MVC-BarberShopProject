using BarberShop.Models;

namespace BarberShop.ViewModelsManager
{
    public class VMActions
    {
        public VMActions()
        {
            HaircutActions = new List<HaircutAction>();
            HaircutAction = new HaircutAction();
        }

        public List<HaircutAction> HaircutActions { get; set;}
        public HaircutAction HaircutAction { get; set;}
        public IFormFile File { get; set;}       
    }
}
