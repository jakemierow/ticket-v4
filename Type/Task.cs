using System;
namespace Ticket
{
    public class Task : Ticket
    {
      public String projectName { get; set; }
      public String DueDate { get; set; }


        public override string Display()
        {
            return $"ID: {TicketID} Summary: {TicketSummary} Priority: {TicketPriority} Submitted By: {SubmittedBy} Assigned To: {AssignedTo} Watching: {Watching} Project Name: {projectName} Due Date: {DueDate}";
        }



    }
}
