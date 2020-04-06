using System;
namespace Ticket
{
    public abstract class Ticket
    {
        public int TicketID { get; set; }
 
        public string TicketSummary { get; set; }

        public string TicketStatus { get; set; }

        public string TicketPriority { get; set; }

        public string SubmittedBy { get; set; }
        
        public string AssignedTo { get; set; }

        public string Watching { get; set; }


        public virtual string Display()
        {
            return $"ID: {TicketID} Summary: {TicketSummary} Priority: {TicketPriority} Submitted By: {SubmittedBy} Assigned To: {AssignedTo} Watching: {Watching}";
        }

    }

    




}
