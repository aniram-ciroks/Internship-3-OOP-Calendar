using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dump_dr_3.Classes
{
    public class Event
    {
        public Guid Id { get; }
        public string EventName { get; set; }
        public string Location { get; set; }
        public DateTime EventStart { get; set; }
        public DateTime EventEnd { get; set; }
        public List<string> ParticipantEmail { get; private set; }



        public Event(string eventName,string location, DateTime eventStart, DateTime eventEnd)
        {
            Id = Guid.NewGuid();
            EventName = eventName;
            Location= location;
            EventStart = eventStart;
            EventEnd = eventEnd;
            ParticipantEmail = new List<string>();

        }

        public void ParticipantEmails(List<string> emails) { 

            foreach(var email in emails) {

                if(email != null)
                    ParticipantEmail.Add(email);
            }
        }



        public void PrintActiveEvents()
        {

            if (EventEnd > DateTime.Now)
            {
                
                Console.WriteLine($"{EventName}\n" +
                    $"Event ID: {Id}\n" +
                    $"Event location: {Location}\n" +
                    $"Event Ends in: {EndsIn(EventEnd)} days\n");

                Console.WriteLine("PARTICIPANTS:");
                foreach(var item in ParticipantEmail)
                    Console.WriteLine(item);
                
          
                Console.WriteLine("....................................\n");
            }

        }

        public double EndsIn(DateTime eventEnd)
        {
            var endingDate = DateTime.Now.Subtract(eventEnd);
            return  Math.Abs(endingDate.Days);
        }

        public void PrintFutureEvents()
        {

            if (EventStart > DateTime.Now)
            {

                Console.WriteLine($"{EventName}\n" +
                    $"Event ID: {Id}\n" +
                    $"Event location: {Location}\n" +
                    $"Event Starts in: {StartsIn(EventStart)} days\n");

                Console.WriteLine("PARTICIPANTS:");
                foreach (var item in ParticipantEmail)
                    Console.WriteLine(item);


                Console.WriteLine("....................................\n");
            }

        }

        public double StartsIn(DateTime eventStart)
        {
            var startingDate = eventStart.Subtract(DateTime.Now);
            return Math.Abs(startingDate.Days);
        }


        public void PrintPastEvents()
        {

            if (EventEnd < DateTime.Now)
            {

                Console.WriteLine($"{EventName}\n" +
                    $"Event ID: {Id}\n" +
                    $"Event location: {Location}\n" +
                    $"Event Ended {Ended(EventEnd)} days ago\n");

                Console.WriteLine("PARTICIPANTS:");
                foreach (var item in ParticipantEmail)
                    Console.WriteLine(item);


                Console.WriteLine("....................................\n");
            }

        }

        public int Ended(DateTime eventEnd)
        {
            var ended = DateTime.Now.Subtract(eventEnd);

            return Math.Abs(ended.Days);
        }







    }
}
