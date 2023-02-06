using System.Data.Entity;
namespace BarberShop.Models
{
    public class DataLayer:DbContext
    {
        private DataLayer() : base("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BarberShop;Data Source=localhost\\SQLEXPRESS")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataLayer>());
            if (Users.Count() == 0) Seed();
        }

        private static DataLayer data;
        public static DataLayer Data
        {
            get
            {
                if (data == null) data = new DataLayer();
                return data;
            }
        }

        // היוזר המחובר כרגע
        public User GetUser = new Client { FirstName = "התחבר"};

        private void Seed()
        {
            User user = new Manager
            {
                FirstName = "תמרה",
                LastName = "אוסיפוב",
                Email = "tomao360@gmail.com",
                Password = "12345",
                PhoneNumber = "0500000000",
                Date = DateTime.Now
            };
            Users.Add(user);

            User user1 = new Barber
            {
                FirstName = "בר",
                LastName = "רחמין",
                Email = "mail@gmail.com",
                Password = "56789",
                PhoneNumber = "0500000000",
                Description = "ספר"
            }; 
            Users.Add(user1);

            SaveChanges();
        }

        public DbSet<HaircutAction> HaircutActions { get; set; }
        public DbSet<HaircutActionsPerBarber> HaircutActionsPerBarbers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
