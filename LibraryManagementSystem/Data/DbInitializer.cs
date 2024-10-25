//using LibraryManagementSystem.Models;
//using Microsoft.AspNetCore.Identity;

//namespace LibraryManagementSystem.Data
//{
//    public class DbInitializer
//    {
//        public static async Task Seed(IApplicationBuilder applicationBuilder)
//        {
//           ApplicationDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<ApplicationDbContext>();

//            UserManager<IdentityUser> userManager = applicationBuilder.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

//            // Add Lender
//            var user = new IdentityUser("Miroslav Mikus");
//            await userManager.CreateAsync(user, "%Miro1");

//            // Add Customers
//            var justin = new Customer { Name = "Justin Noon" };

//            var willie = new Customer { Name = "Willie Parodi" };

//            var leoma = new Customer { Name = "Leoma  Gosse" };

//            context.Customers.Add(justin);
//            context.Customers.Add(willie);
//            context.Customers.Add(leoma);

//            // Add Author
//            var authorDeMarco = new Author
//            {
//                Name = "M J DeMarco",
//                Books = new List<Book>()
//                {
//                    new Book { Title = "The Millionaire Fastlane" },
//                    new Book { Title = "Unscripted" }
//                }
//            };

//            var authorCardone = new Author
//            {
//                Name = "Grant Cardone",
//                Books = new List<Book>()
//                {
//                    new Book { Title = "The 10X Rule"},
//                    new Book { Title = "If You're Not First, You're Last"},
//                    new Book { Title = "Sell To Survive"}
//                }
//            };

//            context.Authors.Add(authorDeMarco);
//            context.Authors.Add(authorCardone);

//            context.SaveChanges();
//        }

//    }
//}
