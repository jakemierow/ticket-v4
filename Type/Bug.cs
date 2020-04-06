using System;
namespace Ticket
{
    public class Bug : Ticket
    {
        public String Severity { get; set; }



        public override string Display()
        {
            return $"ID: {TicketID} Summary: {TicketSummary} Priority: {TicketPriority} Submitted By: {SubmittedBy} Assigned To: {AssignedTo} Watching: {Watching} Severity: {Severity}";
        }

    }


  


}
