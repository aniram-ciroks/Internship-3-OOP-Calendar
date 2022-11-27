using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dump_dr_3.Classes
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; }
        public string PersonEmail { get; }
        public Dictionary<Guid, bool> Attendance { get; set; }


        public Person( string surname, string email) {

            Surname = surname;
            PersonEmail= email;

        }

        //DICTIONARY VALUE FOR ATTENDANCE

        //public void AttendanceTorF(List<Event> events)
        //{
        //    foreach (Event e in events) {
        //        if (string.Compare(PersonEmail, e.ParticipantEmail) = 0) ;
            
        //    }

        //    for (int i = 0; i < events.Count; i++)
        //    {
        //        Attendance.Add(events[i].Id, true);
        //        Console.WriteLine($"{Attendance.Count}");
        //    }
        //}











    }
}
