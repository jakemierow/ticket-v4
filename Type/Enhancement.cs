using System;
namespace Ticket.Type
{
    public class Enhancement : Ticket
    {
        public String Software { get; set; }
        public String Cost { get; set; }
        public String Reason { get; set; }
        public String Estimate { get; set; }


        public override string Display()
        {
            return $"ID: {TicketID} Summary: {TicketSummary} Priority: {TicketPriority} Submitted By: {SubmittedBy} Assigned To: {AssignedTo} Watching: {Watching} Software: {Software} Cost: {Cost} Reason: {Reason} Estimate: {Estimate}";
        }


    }
}

       

    

