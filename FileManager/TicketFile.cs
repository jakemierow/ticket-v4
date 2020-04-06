using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ticket.FileManager
{
    public class TicketFile
    {
        public string filePath { get; set; }
        public List<Bug> BugTickets { get; set; }


        public TicketFile(string path)
        {
            BugTickets = new List<Bug>();
            filePath = path;

            if (File.Exists(path))
              {

                StreamReader sr = new StreamReader(filePath);
                while (!sr.EndOfStream)
                {
                    Bug BugTicket = new Bug();
                    string line = sr.ReadLine();

                    string[] ticketDetails = line.Split(',');
                    BugTicket.TicketID = Int32.Parse(ticketDetails[0]);
                    BugTicket.TicketSummary = ticketDetails[1];
                    BugTicket.TicketStatus = ticketDetails[2];
                    BugTicket.TicketPriority = ticketDetails[3];
                    BugTicket.SubmittedBy = ticketDetails[4];
                    BugTicket.AssignedTo = ticketDetails[5];
                    BugTicket.Watching = ticketDetails[6];
                    BugTicket.Severity = ticketDetails[7];

                   BugTickets.Add(BugTicket);

                }
                sr.Close();
            }
            //

            
        }

        

        public void AddTicket(Bug BugTicket)
        {
            BugTicket.TicketID = BugTickets.Count == 0 ? 1 : BugTickets.Max(b => b.TicketID) + 1;
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine($"{BugTicket.TicketID},{BugTicket.TicketSummary},{BugTicket.TicketStatus},{BugTicket.TicketPriority}," +
                $"{BugTicket.SubmittedBy}, {BugTicket.AssignedTo}, {BugTicket.Watching}, {BugTicket.Severity}");
            sw.Close();
            BugTickets.Add(BugTicket);


        }

        public List<Bug> Search(string searchString)
        {
            return BugTickets.Where(t => t.TicketStatus.Contains(searchString)).ToList();
        }



    }
}



