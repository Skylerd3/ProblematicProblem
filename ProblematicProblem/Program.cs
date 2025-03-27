using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        public static Random rng = new Random();
        public static bool cont = true;
        public static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            var UserResponse = Console.ReadLine().ToLower();

            while (UserResponse != "yes" && UserResponse != "no")
            {
                Console.WriteLine("Invalid response, Please type yes or no.");
                UserResponse = Console.ReadLine().ToLower();
            }

            if (UserResponse == "no")
            {
                Console.WriteLine("You selected NO, Thanks for playing.");
                return;
            }


            Console.WriteLine();
            Console.WriteLine("We are going to need your info first, What is your name?");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge;
            while (!int.TryParse(Console.ReadLine(), out userAge))
            {
                Console.WriteLine("Invalid response, Please type a valid age.");
            }

            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            UserResponse = (Console.ReadLine().ToLower());

            while (UserResponse != "sure" && UserResponse != "no thanks")
            {
                Console.WriteLine("Invlaid response, Please type sure or no thanks!");
                UserResponse = Console.ReadLine().ToLower();
            }




            if (UserResponse == "sure")
            {



                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }


                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                UserResponse = Console.ReadLine().ToLower();

                while (UserResponse != "yes" && UserResponse != "no")
                {
                    Console.WriteLine("Invalid response, Please type yes or no.");
                    UserResponse = Console.ReadLine().ToLower();
                }

                while (UserResponse == "yes")
                {
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    UserResponse = Console.ReadLine().ToLower();

                    while (UserResponse != "yes" && UserResponse != "no")
                    {
                        Console.WriteLine("Invalid response, Please type yes or no.");
                        UserResponse = Console.ReadLine().ToLower();
                    }
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                UserResponse = Console.ReadLine().ToLower();

                while (UserResponse != "keep" && UserResponse != "redo")
                {
                    Console.WriteLine("Invalid response, Please type keep or redo.");
                    UserResponse = Console.ReadLine().ToLower();
                }
                if (UserResponse == "keep")
                {
                    cont = false;
                }

            }
        }
    }
}
