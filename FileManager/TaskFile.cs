using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ticket
{
    public class TaskFile
    {
       
        public string filePath { get; set; }
        public List<Task> TaskTickets { get; set; }


        public TaskFile(string path)
        {
            TaskTickets = new List<Task>();
            filePath = path;

            if (File.Exists(path))
            {

                StreamReader sr = new StreamReader(filePath);
                while (!sr.EndOfStream)
                {
                    Task TaskTicket = new Task();
                    string line = sr.ReadLine();

                    string[] ticketDetails = line.Split(',');
                    TaskTicket.TicketID = Int32.Parse(ticketDetails[0]);
                    TaskTicket.TicketSummary = ticketDetails[1];
                    TaskTicket.TicketStatus = ticketDetails[2];
                    TaskTicket.TicketPriority = ticketDetails[3];
                    TaskTicket.SubmittedBy = ticketDetails[4];
                    TaskTicket.AssignedTo = ticketDetails[5];
                    TaskTicket.Watching = ticketDetails[6];
                    TaskTicket.projectName = ticketDetails[7];
                    TaskTicket.DueDate = ticketDetails[8];

                    TaskTickets.Add(TaskTicket);

                }
                sr.Close();
            }



        }



        public void AddTicket(Task TaskTicket)
        {
            TaskTicket.TicketID = TaskTickets.Count == 0 ? 1 : TaskTickets.Max(t => t.TicketID) + 1;
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine($"{TaskTicket.TicketID},{TaskTicket.TicketSummary},{TaskTicket.TicketStatus},{TaskTicket.TicketPriority}," +
                $"{TaskTicket.SubmittedBy}, {TaskTicket.AssignedTo}, {TaskTicket.Watching}, {TaskTicket.projectName}, {TaskTicket.DueDate}");
            sw.Close();
            TaskTickets.Add(TaskTicket);


        }


        public List<Task> Search(string searchString)
        {
            return TaskTickets.Where(t => t.TicketStatus.Contains(searchString)).ToList();
        }


    }
}



