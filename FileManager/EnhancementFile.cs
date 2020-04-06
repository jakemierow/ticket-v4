using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ticket
{
    public class EnhancementFile
    {
        public string filePath { get; set; }
        public List<Enhancement> EnhancementTickets { get; set; }

   
        public EnhancementFile(string path)
        {
            EnhancementTickets = new List<Enhancement>();
            filePath = path;

            if (File.Exists(path))
            {

                StreamReader sr = new StreamReader(filePath);
                while (!sr.EndOfStream)
                {
                    Enhancement EnhancementTicket = new Enhancement();
                    string line = sr.ReadLine();

                    string[] ticketDetails = line.Split(',');
                    EnhancementTicket.TicketID = Int32.Parse(ticketDetails[0]);
                    EnhancementTicket.TicketSummary = ticketDetails[1];
                    EnhancementTicket.TicketStatus = ticketDetails[2];
                    EnhancementTicket.TicketPriority = ticketDetails[3];
                    EnhancementTicket.SubmittedBy = ticketDetails[4];
                    EnhancementTicket.AssignedTo = ticketDetails[5];
                    EnhancementTicket.Watching = ticketDetails[6];
                    EnhancementTicket.Software = ticketDetails[7];
                    EnhancementTicket.Cost = ticketDetails[8];
                    EnhancementTicket.Reason = ticketDetails[9];
                    EnhancementTicket.Estimate = ticketDetails[10];

                    EnhancementTickets.Add(EnhancementTicket);

                }
                sr.Close();
            }



        }



        public void AddTicket(Enhancement EnhancementTicket)
        {
            EnhancementTicket.TicketID = EnhancementTickets.Count == 0 ? 1 : EnhancementTickets.Max(e => e.TicketID) + 1;
            StreamWriter sw = new StreamWriter(filePath, true);
            sw.WriteLine($"{EnhancementTicket.TicketID},{EnhancementTicket.TicketSummary},{EnhancementTicket.TicketStatus},{EnhancementTicket.TicketPriority}," +
                $"{EnhancementTicket.SubmittedBy}, {EnhancementTicket.AssignedTo}, {EnhancementTicket.Watching}, {EnhancementTicket.Software}, {EnhancementTicket.Cost}, {EnhancementTicket.Reason}, {EnhancementTicket.Estimate}");
            sw.Close();
            EnhancementTickets.Add(EnhancementTicket);

            
        }


        public List<Enhancement> Search(string searchString)
        {
            return EnhancementTickets.Where(t => t.TicketStatus.Contains(searchString)).ToList();
        }

    }
    }
