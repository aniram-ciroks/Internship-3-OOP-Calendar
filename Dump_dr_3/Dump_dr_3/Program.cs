using Dump_dr_3.Classes;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Dump_dr_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            var PersonList = new List<Person>(10);
            var EventList = new List<Event>(5);

            //List of all persons (predefined)
            PersonList.Add(new Person("Skoric", "marinaskoric@gmail.com") { Name = "Marina" });
            PersonList.Add(new Person("Skoric", "lorenaskoric@gmail.com") { Name = "Lorena" });
            PersonList.Add(new Person("Sulenta", "mia_from_drasnice@gmail.com") { Name = "Mia" });
            PersonList.Add(new Person("Rizvan", "riza@gmail.com") { Name = "Nikola" });
            PersonList.Add(new Person("Toplak", "toplak00@gmail.com") { Name = "Mislav" });
            PersonList.Add(new Person("Eberhart", "robijagoda@gmail.com") { Name = "Robert" });
            PersonList.Add(new Person("Nincevic", "r_nine@gmail.com") { Name = "Robert" });
            PersonList.Add(new Person("Rakocija", "rakochija@gmail.com") { Name = "Ana" });
            PersonList.Add(new Person("Dzelalija", "natka_patka@gmail.com") { Name = "Natalija" });
            PersonList.Add(new Person("Relja", "reljaa@gmail.com") { Name = "Anja" });

            //List of all events (predefined)
            EventList.Add(new Event("Introductory lecture DUMP", "FESB", new DateTime(2022, 11, 4), new DateTime(2022, 11, 5)));
            EventList.Add(new Event("Cyber Security lecture", "FESB", new DateTime(2023, 01, 18), new DateTime(2023, 02, 02)));
            EventList.Add(new Event("C# lecture", "Dom mladih", new DateTime(2022, 11, 13), new DateTime(2022, 11, 14)));
            EventList.Add(new Event("JavaScript lecture", "NetScale, Split", new DateTime(2022, 11, 26), new DateTime(2022, 12, 03)));
            EventList.Add(new Event("Teambuilding workshop", "Dublin, Ireland", new DateTime(2022, 11, 29), new DateTime(2022, 12, 11)));

            //Who goes where xd
            EventList[0].ParticipantEmails(new List<string>() { "marinaskoric@gmail.com", "r_nine@gmail.com" });
            EventList[1].ParticipantEmails(new List<string>() { "marinaskoric@gmail.com", "toplak00@gmail.com", "reljaa@gmail.com", "robijagoda@gmail.com" });
            EventList[2].ParticipantEmails(new List<string>() { "marinaskoric@gmail.com", "lorenaskoric@gmail.com", "mia_from_drasnice@gmail.com" });
            EventList[3].ParticipantEmails(new List<string>() { "riza@gmail.com", "r_nine@gmail.com", "natka_patka@gmail.com" });
            EventList[4].ParticipantEmails(new List<string>() { "marinaskoric@gmail.com", "rakochija@gmail.com", "reljaa@gmail.com" });


            //DICTIONARY VALUE FOR ATTENDANCE
            //foreach (var item in PersonList)
            //{
            //    item.AttendanceTorF(EventList);
            //}

            MainMenu();


            void MainMenu()
            {
                bool loop = true;

                while (loop == true)
                {
                    Console.WriteLine($"******************** <MAIN MENU> ************************");
                    Console.WriteLine($"Select an operation:\n" +
                        $"1) Active events\n" +
                        $"2) Future events\n" +
                        $"3) Past events\n" +
                        $"4) Create new event\n" +
                        $"0) Exit app\n");
                    var userOperationChoice = int.Parse(Console.ReadLine());

                    switch (userOperationChoice)
                    {
                        case 0: loop = false; break;
                        case 1:
                            Console.WriteLine("\tActive events\n" +
                                "--------------------------------------------------"); 
                            foreach(var item in EventList)
                                item.PrintActiveEvents();  //SAME ==> EventList.ForEach(even => even.PrintActiveEvents())

                            Console.WriteLine($"**************** <OPTION 1 SUBMENU> ******************");
                            Console.WriteLine($"Select an operation:\n" +
                                $"1) Note absences\n" +
                                $"2) Return to <MAIN MENU>\n");
                            var userOperationChoiceSubMenu1 = int.Parse(Console.ReadLine());

                            switch (userOperationChoiceSubMenu1)
                            {
                                case 1:
                                    Console.WriteLine("\tNote absences\n" +
                                "ˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇ");
                                    Console.WriteLine("Enter Event ID:");
                                    var inputEventID =Console.ReadLine();

                                    Console.WriteLine("Enter emails for persons to note as absent:");
                                    var absent = new List<String>();
                                    absent.Add(Console.ReadLine());


                                    break;
                                case 2:
                                    Console.WriteLine("Returning to <MAIN MENU>");
                                    break;
                                default: Console.WriteLine($"Invalid operation entered! Returning to <MAIN MENU>\n");
                                    break;
                            }

                            break;

                        case 2:
                            Console.WriteLine("\tFuture events\n" +
                                "--------------------------------------------------");
                            EventList.ForEach(item =>  item.PrintFutureEvents());

                            Submenuoption2();

                            break;

                        case 3:
                            Console.WriteLine("\tPast events\n" +
                                "--------------------------------------------------");
                            EventList.ForEach(item => item.PrintPastEvents());
                            break;

                        case 4:
                            Console.WriteLine("\tCreate new event\n" +
                                "--------------------------------------------------");

                            CreateNewEvent();
                           
                            break;
                        default:
                            Console.WriteLine($"Invalid operation entered! Enter again.\nTo exit the app enter (zero)\n");
                            break;




                    }














                }
                Console.WriteLine("Exited app.");
            }


            void Submenuoption2()
            {
                Console.WriteLine($"**************** <OPTION 2 SUBMENU> ******************");
                Console.WriteLine($"Select an operation:\n" +
                    $"1) Delete an event\n" +
                    $"2) Remove attendees\n"+
                    $"3) Return to <MAIN MENU>\n");
                var userOperationChoiceSubMenu2 = int.Parse(Console.ReadLine());

                switch (userOperationChoiceSubMenu2)
                {
                    case 1:
                        Console.WriteLine("\tDelete an event\n" +
                    "ˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇ");
                        Console.WriteLine("Enter Event ID:");
                        var inputEventID = Console.ReadLine();

                        Console.WriteLine("Enter emails for persons to note as absent:");
                        var absent = new List<String>();
                        absent.Add(Console.ReadLine());


                        break;

                    case 2:
                        Console.WriteLine("\tRemove attendees\n" +
                    "ˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇˇ");



                        break;

                    case 3:
                        Console.WriteLine("Returning to <MAIN MENU>");
                        break;
                    default:
                        Console.WriteLine($"Invalid operation entered! Returning to <MAIN MENU>\n");
                        break;
                }
            }

            void CreateNewEvent()
            {
                //New Event Name
                Console.WriteLine("Enter new event name:");
                var name = Console.ReadLine();
                //New Event Location
                Console.WriteLine("Enter new element location:");
                var location = Console.ReadLine();

                //New event Start
                Console.WriteLine("Enter new event Start Date: (yyyy, mm, dd)");
                var start = new DateTime();
                DateTime.TryParse(Console.ReadLine(), out start);
                while (start < DateTime.Now)
                {
                    Console.WriteLine("New event must have a future start day! Enter again:");
                    DateTime.TryParse(Console.ReadLine(), out start);
                }

                //New Event End
                Console.WriteLine("Enter new event End Date: (yyyy, mm, dd)");
                var end = new DateTime();
                DateTime.TryParse(Console.ReadLine(), out end);
                while (end < DateTime.Now)
                {
                    Console.WriteLine("Inalid input!\n New event can't end before i even began! Enter again:");
                    DateTime.TryParse(Console.ReadLine(), out end);
                }

               //New Event Participants
                var newParticipants = new List<String>();
                Console.WriteLine($"Enter the emails of the participants for the new event '{name}'");
                newParticipants.Add(Console.ReadLine());    
               

                EventList.Add(new Event(name, location, start, end));
                EventList[EventList.Count].ParticipantEmails(newParticipants);

            }



        }
    }
}