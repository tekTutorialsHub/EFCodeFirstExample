using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGettingStarted
{
    class Program
    {
        static void Main(string[] args)
        {

            addUser();
            //findUser(1);
            //editUser(1);
            //deleteUser(1);

            Console.WriteLine("Press any key to close");
            Console.ReadKey();
        }

        private static void deleteUser(int id)
        {
            Console.WriteLine("deleting "+id);

            try
            {
                using (var ctx = new EFContext())
                {
                    var user = ctx.Users.Find(id);
                    if (user != null)
                    {
                        Console.WriteLine("deleting " + user.UserID + " " + user.Name);
                        ctx.Users.Remove(user);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("user not found");
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            findUser(id);

        }

        private static void editUser(int id)
        {

            Console.WriteLine("editing " + id);
            try
            {
                using (var ctx = new EFContext())
                {
                    var user = ctx.Users.Find(id);
                    if (user!=null)
                    {
                        user.Name = "Sachin Tendulkar";
                        ctx.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("user not found");
                    }


                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            findUser(id);


        }

        private static void findUser(int id)
        {

            Console.WriteLine("finding " + id);

            try
            {
                using (var ctx = new EFContext())
                {
                    var user = ctx.Users.Find(id);
                    
                    if (user != null)
                    {
                        Console.WriteLine("found " + user.UserID + " " + user.Name);
                    }
                    else
                    {
                        Console.WriteLine("user not found");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void addUser()
        {

            Console.WriteLine("adding user ");
            User usr = new User() { Name = "Sachin", Email = "sachin@gmail.com" };
            try
            {
                using (var ctx = new EFContext())
                {
                    ctx.Users.Add(usr);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


    }
}
