using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstLINQ.Models;

namespace DatabaseFirstLINQ
{
    class Problems
    {
        private ECommerceContext _context;

        public Problems()
        {
            _context = new ECommerceContext();
        }
        public void RunLINQQueries()
        {
            //ProblemOne();
            //ProblemTwo();
            //ProblemThree();
            //ProblemFour();
            //ProblemFive();
            //ProblemSix();
            //ProblemSeven();
            //ProblemEight();
            //ProblemNine();
            //ProblemTen();
            //ProblemEleven();
            //ProblemTwelve();
            //ProblemThirteen();
            //ProblemFourteen();
            //ProblemFifteen();
            //ProblemSixteen();
            //ProblemSeventeen();
            //ProblemEighteen();
            //ProblemNineteen();
            //ProblemTwenty();
            //BonusOne();
            //BonusTwo();
            BonusThree();
        }

        // <><><><><><><><> R Actions (Read) <><><><><><><><><>
        private void ProblemOne()
        {
            // Write a LINQ query that returns the number of users in the Users table.
            var users = _context.Users;
            // HINT: .ToList().Count
            Console.WriteLine("-------Problem 1-------\n");
            Console.WriteLine(users.ToList().Count);
        }

        private void ProblemTwo()
        {
            // Write a LINQ query that retrieves the users from the User tables then print each user's email to the console.
            var users = _context.Users;
            Console.WriteLine("\n-------Problem 2-------\n");
            foreach (User user in users)
            {
                Console.WriteLine(user.Email);
            }

        }

        private void ProblemThree()
        {
            // Write a LINQ query that gets each product where the products price is greater than $150.
            var products = _context.Products;
            var productsOverOnefifty = products.Where(m => m.Price > 150);

            // Then print the name and price of each product from the above query to the console.
            Console.WriteLine("\n-------Problem 3-------\n");
            foreach (var product in productsOverOnefifty)
            {
                Console.WriteLine("Name: {0}, Price: {1}", product.Name, product.Price);
            }
        }

        private void ProblemFour()
        {
            // Write a LINQ query that gets each product that contains an "s" in the products name.
            var products = _context.Products;
            var productsOverOnefifty = products.Where(p => p.Name.Contains("s"));

            // Then print the name of each product from the above query to the console.
            Console.WriteLine("\n-------Problem 4-------\n");
            foreach (var product in productsOverOnefifty)
            {
                Console.WriteLine(product.Name);
            }

        }

        private void ProblemFive()
        {
            // Write a LINQ query that gets all of the users who registered BEFORE 2016
            var users = _context.Users;
            Console.WriteLine("\n-------Problem 5-------\n");
            DateTime twentySixteen = new DateTime(2016, 1, 1);
            var usersRegisteredBefore2016 = users.Where(u => u.RegistrationDate < twentySixteen);
            // Then print each user's email and registration date to the console.
            foreach (User user in usersRegisteredBefore2016)
            {
                Console.WriteLine("Email: {0} Registration Date: {1} ", user.Email, user.RegistrationDate);
            }

        }

        private void ProblemSix()
        {
            // Write a LINQ query that gets all of the users who registered AFTER 2016 and BEFORE 2018
            var users = _context.Users;
            Console.WriteLine("\n-------Problem 6-------\n");
            DateTime twentySixteen = new DateTime(2016, 1, 1);
            DateTime twentyEighteen = new DateTime(2018, 1, 1);
            var usersRegisteredBetween20162018 = users.Where(u => u.RegistrationDate > twentySixteen && u.RegistrationDate < twentyEighteen);

            // Then print each user's email and registration date to the console.

            foreach (User user in usersRegisteredBetween20162018)
            {
                Console.WriteLine("Email: {0} Registration Date: {1} ", user.Email, user.RegistrationDate);
            }

        }

        // <><><><><><><><> R Actions (Read) with Foreign Keys <><><><><><><><><>

        private void ProblemSeven()
        {
            // Write a LINQ query that retreives all of the users who are assigned to the role of Customer.
            // Then print the users email and role name to the console.
            Console.WriteLine("\n-------Problem 7-------\n");
            var customerUsers = _context.UserRoles.Include(ur => ur.Role).Include(ur => ur.User).Where(ur => ur.Role.RoleName == "Customer");
            foreach (UserRole userRole in customerUsers)
            {
                Console.WriteLine($"Email: {userRole.User.Email} Role: {userRole.Role.RoleName}");
            }
        }

        private void ProblemEight()
        {
            Console.WriteLine("\n-------Problem 8-------\n");
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "afton@gmail.com".
            var aftonShoppingCart = _context.ShoppingCarts.Include(pu => pu.Product).Include(pu => pu.User).Where(pu => pu.User.Email == "afton@gmail.com");
            // Then print the product's name, price, and quantity to the console.
            foreach (ShoppingCart item in aftonShoppingCart)
            {
                Console.WriteLine("Name: {0}\nPrice: {1}\nQuantity: {2}", item.Product.Name, item.Product.Price, item.Quantity);

            }



        }

        private void ProblemNine()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "oda@gmail.com" and returns the sum of all of the products prices.
            Console.WriteLine("\n-------Problem 9-------\n");
            var sum = _context.ShoppingCarts.Include(sc => sc.Product).Include(sc => sc.User).Where(sc => sc.User.Email == "oda@gmail.com").Select(sc => sc.Product.Price).Sum();
            // Then print the total of the shopping cart to the console.
            Console.WriteLine("Total: {0}", sum);
            // HINT: End of query will be: .Select(sc => sc.Product.Price).Sum();
        }

        private void ProblemTen()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of users who have the role of "Employee".
            // Then print the user's email as well as the product's name, price, and quantity to the console.

            Console.WriteLine("\n-------Problem 10-------\n");
            var employeeUsers = _context.UserRoles.Include(ur => ur.Role).Include(ur => ur.User).Where(ur => ur.Role.RoleName == "Employee").Select(ur => ur.User.Id).ToList();
            var shoppingCarts = _context.ShoppingCarts.Include(sc => sc.Product).Include(sc => sc.User).Where(sc => employeeUsers.Contains(sc.User.Id));

            foreach (ShoppingCart item in shoppingCarts)
            {
                Console.WriteLine("Email: {0} Name: {1}\nPrice: {2}\nQuantity: {3}", item.User.Email, item.Product.Name, item.Product.Price, item.Quantity);
            }

        }

        // <><><><><><><><> CUD (Create, Update, Delete) Actions <><><><><><><><><>

        // <><> C Actions (Create) <><>

        private void ProblemEleven()
        {
            Console.WriteLine("\n-------Problem 11-------\n");
            // Create a new User object and add that user to the Users table using LINQ.
            User newUser = new User()
            {
                Email = "david@gmail.com",
                Password = "DavidsPass123"
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        private void ProblemTwelve()
        {
            Console.WriteLine("\n-------Problem 12-------\n");
            // Create a new Product object and add that product to the Products table using LINQ.
            Product newProduct = new Product()
            {
                Name = "EastBlue Dog Chew Toy",
                Description = "Indestructible dog toy"
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();

        }

        private void ProblemThirteen()
        {
            Console.WriteLine("\n-------Problem 13-------\n");
            // Add the role of "Customer" to the user we just created in the UserRoles junction table using LINQ.
            var roleId = _context.Roles.Where(r => r.RoleName == "Customer").Select(r => r.Id).SingleOrDefault();
            var userId = _context.Users.Where(u => u.Email == "david@gmail.com").Select(u => u.Id).SingleOrDefault();
            UserRole newUserRole = new UserRole()
            {
                UserId = userId,
                RoleId = roleId
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        private void ProblemFourteen()
        {
            Console.WriteLine("\n-------Problem 14-------\n");
            // Add the product you create to the user we created in the ShoppingCart junction table using LINQ.
            var product = _context.Products.Where(p => p.Name == "EastBlue Dog Chew Toy").SingleOrDefault();
            var user = _context.Users.Where(u => u.Email == "david@gmail.com").SingleOrDefault();
            ShoppingCart newShoppingCart = new ShoppingCart()
            {
                UserId = user.Id,
                ProductId = product.Id,
                Quantity = 1,
            };
            _context.ShoppingCarts.Add(newShoppingCart);
            _context.SaveChanges();
        }

        // <><> U Actions (Update) <><>

        private void ProblemFifteen()
        {
            Console.WriteLine("\n-------Problem 15-------\n");
            // Update the email of the user we created to "mike@gmail.com"
            var user = _context.Users.Where(u => u.Email == "david@gmail.com").SingleOrDefault();
            user.Email = "mike@gmail.com";
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        private void ProblemSixteen()
        {
            Console.WriteLine("\n-------Problem 16-------\n");
            // Update the price of the product you created to something different using LINQ.
            var product = _context.Products.Where(p => p.Name == "EastBlue Dog Chew Toy").SingleOrDefault();

            product.Price = 999;
            _context.Products.Update(product);
            _context.SaveChanges();

        }

        private void ProblemSeventeen()
        {
            // Change the role of the user we created to "Employee"
            // HINT: You need to delete the existing role relationship and then create a new UserRole object and add it to the UserRoles table
            // See problem eighteen as an example of removing a role relationship
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == "mike@gmail.com").SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            UserRole newUserRole = new UserRole()
            {
                UserId = _context.Users.Where(u => u.Email == "mike@gmail.com").Select(u => u.Id).SingleOrDefault(),
                RoleId = _context.Roles.Where(r => r.RoleName == "Employee").Select(r => r.Id).SingleOrDefault()
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
        }

        // <><> D Actions (Delete) <><>

        private void ProblemEighteen()
        {
            // Delete the role relationship from the user who has the email "oda@gmail.com" using LINQ.
            var user = _context.Users.Where(u => u.Email == "oda@gmail.com").SingleOrDefault();
            var odaUserRole = _context.UserRoles.Where(ur => ur.UserId == user.Id).SingleOrDefault();
            _context.UserRoles.Remove(odaUserRole);
            _context.SaveChanges();

        }

        private void ProblemNineteen()
        {
            // Delete all of the product relationships to the user with the email "oda@gmail.com" in the ShoppingCart table using LINQ.
            // HINT: Loop
            var shoppingCartProducts = _context.ShoppingCarts.Where(sc => sc.User.Email == "oda@gmail.com");
            foreach (ShoppingCart userProductRelationship in shoppingCartProducts)
            {
                _context.ShoppingCarts.Remove(userProductRelationship);
            }
            _context.SaveChanges();
        }

        private void ProblemTwenty()
        {
            // Delete the user with the email "oda@gmail.com" from the Users table using LINQ.
            var oda = _context.Users.Where(u => u.Email == "oda@gmail.com").SingleOrDefault();
            _context.Users.Remove(oda);
            _context.SaveChanges();

        }

        // <><><><><><><><> BONUS PROBLEMS <><><><><><><><><>

        private void BonusOne()
        {
            Console.WriteLine("\n\t\tBONUS 1\t\t\n");
            // Prompt the user to enter in an email and password through the console.
            Console.WriteLine("Enter email address:");
            string emailAddress = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();
            // Take the email and password and check if the there is a person that matches that combination.
            var authenticated = _context.Users.Where(u => u.Email == emailAddress && u.Password == password).SingleOrDefault();
            // Print "Signed In!" to the console if they exists and the values match otherwise print "Invalid Email or Password.".
            if (authenticated == null)
            {
                Console.WriteLine("Invalid email or password.");
                Console.WriteLine("Select 1 to try again\n Or select any other key to cancel");
                var userInput = Console.ReadLine();
                if (userInput == "1" || userInput == "2")
                {
                    switch (userInput)
                    {
                        case "1":
                            BonusOne();
                            break;
                        case "2":
                            break;

                    }
                }

            }
            else
            {
                Console.WriteLine("Signed In!");
            }
        }

        private void BonusTwo()
        {
            // Write a query that finds the total of every users shopping cart products using LINQ.
            var shoppingCartRows = _context.ShoppingCarts.Include(pu => pu.User).Include(pu => pu.Product).ToList();
            var allCartTotal = _context.ShoppingCarts.Include(c => c.Product).Select(c => c.Product.Price).ToList().Sum();
            var users = _context.Users;
            foreach (User user in users)
            {
                var userCartTotal = _context.ShoppingCarts.Include(ci => ci.Product).Where(ci => ci.UserId == user.Id).Select(ci => ci.Product.Price).Sum();
                Console.WriteLine("User:{0} Cart Total:{1}", user.Email, userCartTotal);
            }
            Console.WriteLine("The total of all carts is {0}", allCartTotal);
            // Display the total of each users shopping cart as well as the total of the toals to the console.
        }

        // BIG ONE
        private void BonusThree()
        {

            Console.WriteLine("\n\t\tBONUS 3\t\t\n");

            Console.WriteLine("Enter email address:");
            string emailAddress = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            var authenticatedUser = _context.Users.Where(u => u.Email == emailAddress && u.Password == password).SingleOrDefault();
            if (authenticatedUser == null)
            {
                Console.WriteLine("Invalid email or password.");
                Console.WriteLine("Select 1 to try again\n Or select any other key to cancel");
                var userInput = Console.ReadLine();
                if (userInput == "1" || userInput == "2")
                {
                    switch (userInput)
                    {
                        case "1":
                            BonusThree();
                            break;
                        case "2":
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                mainMenu(authenticatedUser);
            }
        }

        private void mainMenu(User user)
        {

            Console.WriteLine("Signed In!");
            Console.WriteLine("your options are as follows.\n 1 for View Shopping Cart:\n 2 for View Products For Sale\n");
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    shoppingCartSubmenu(user);
                    break;
                case "2":
                    productSubmenu(user);
                    break;
                default:
                    break;
            }
        }

        private void shoppingCartSubmenu(User user)
        {
            var shoppingCartItems = _context.ShoppingCarts.Include(ci => ci.Product).Where(ci => ci.UserId == user.Id).ToList();
            Console.WriteLine("\n-------Your Shopping Cart-------\n");
            int counter = 0;
            foreach (ShoppingCart item in shoppingCartItems)
            {
                Console.WriteLine($"{counter}:Name, {item.Product.Name}, Price {item.Product.Price}, Quantity {item.Quantity}");
                counter++;
            }
            Console.WriteLine("If you would like to remove an item press 1\n if you would like to return to the main menu press 2");
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("enter the item number you would like to remove");
                    int itemIndex = int.Parse(Console.ReadLine());
                    var selectedItem = shoppingCartItems[itemIndex];
                    var itemToRemove = _context.ShoppingCarts.Where(ci => ci.ProductId == selectedItem.ProductId && ci.UserId == selectedItem.UserId).SingleOrDefault();
                    _context.ShoppingCarts.Remove(itemToRemove);
                    _context.SaveChanges();
                    shoppingCartSubmenu(user);
                    break;
                case "2":
                    mainMenu(user);
                    break;
                default:
                    shoppingCartSubmenu(user);
                    break;
            }
            Console.WriteLine("");
            Console.WriteLine("");
        }

        // View all products in the Products table
        // Add a product to the shopping cart (incrementing quantity if that product is already in their shopping cart)
        private void productSubmenu(User user)
        {
            var shoppingCartItems = _context.ShoppingCarts.Include(ci => ci.Product).Where(ci => ci.UserId == user.Id).ToList();
            Console.WriteLine("\n-------Products For Sale-------\n");
            var products = _context.Products.ToList();
            int index = 0;
            foreach (var product in products)
            {
                Console.WriteLine($"{index}: Name, {product.Name} Price, {product.Price}");
                index++;
            }
            Console.WriteLine("Press 1 to select a product, Press 2 to go back to main menu");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Enter the item number you would like to add");
                    int itemIndex = int.Parse(Console.ReadLine());
                    var selectedItem = products[itemIndex];
                    var existingShoppingCartItem = _context.ShoppingCarts.Where(ci => ci.ProductId == selectedItem.Id && ci.UserId == user.Id).SingleOrDefault();
                    if (existingShoppingCartItem != null)
                    {
                        existingShoppingCartItem.Quantity++;
                        _context.ShoppingCarts.Update(existingShoppingCartItem);
                        _context.SaveChanges();
                    }
                    else
                    {
                        var newShoppingCartItem = new ShoppingCart()
                        {
                            UserId = user.Id,
                            ProductId = selectedItem.Id,
                            Quantity = 1,
                        };
                        _context.ShoppingCarts.Add(newShoppingCartItem);
                        _context.SaveChanges();
                    }
                    productSubmenu(user);
                    break;
                case "2":
                    mainMenu(user);
                    break;
                default:
                    productSubmenu(user);
                    break;
            }
        }
    }
}
