using System.Xml.Linq;

namespace LR12_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User[] usersToDb = new User[] {
                    new User { Name = "Ivan", Surname = "Petrov", Age = 35 },
                    new User { Name = "Anna", Surname = "Smirnova", Age = 28 },
                    new User { Name = "Mikhail", Surname = "Kozlov", Age = 42 }
                };

                for (int i = 0; i < usersToDb.Length; i++)
                {
                    db.Users.Add(usersToDb[i]);
                }
                
                db.SaveChanges();

                Console.WriteLine("Added successfully");

                var users = db.Users.ToList();
                Console.WriteLine("List of users:");

                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id}.{user.Name} {user.Surname} - {user.Age}");
                }
            }
        }
    }
}
