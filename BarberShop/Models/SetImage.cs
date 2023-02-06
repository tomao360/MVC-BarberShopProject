using System.ComponentModel.DataAnnotations;

namespace BarberShop.Models
{
    // קלאס שלא ייכנס לדאטה בייס, הוא נועד רק למטרת המרת קובץ תמונה למערך של ביטים
    public class SetImage
    {
        public SetImage(IFormFile file)
        {
            if (file == null) return;
            MemoryStream stream = new MemoryStream();
            file.CopyTo(stream);
            Image = stream.ToArray();
        }

        public byte[] Image { get; }
    }
}
