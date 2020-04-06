using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ticket.FileManager;
using Ticket.Type;

namespace Ticket
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            List<Ticket> Tickets = new List<Ticket>();

            String ticketFileName = AppDomain.CurrentDomain.BaseDirectory + "Tickets.txt";
            String EnhancementFileName = AppDomain.CurrentDomain.BaseDirectory + "Enhancements.txt";
            String TaskFileName = AppDomain.CurrentDomain.BaseDirectory + "Tasks.txt";
            String choice;
            TicketFile TicketFile = new TicketFile(ticketFileName);
            EnhancementFile enhancementFile = new EnhancementFile(EnhancementFileName);
            TaskFile taskFile = new TaskFile(TaskFileName);



         do
            {
                Console.WriteLine("\n");
                Console.WriteLine("1) Add Bug Ticket");
                Console.WriteLine("2) Display Bug Tickets");
                Console.WriteLine("3) Add Enhancement Ticket");
                Console.WriteLine("4) Display Enhancement Tickets");
                Console.WriteLine("5) Add Task Ticket");
                Console.WriteLine("6) Display Task Tickets");
                Console.WriteLine("7) Search tickets by status");
                Console.WriteLine("Enter to quit");
                // input response
                choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
           
                        
                        
                            Bug BugTicket = new Bug();
                           

                            // prompt for ticket summary
                            Console.WriteLine("Enter a summary: ");
                            // save ticket summary
                            BugTicket.TicketSummary = Console.ReadLine();

                            // prompt for ticket status
                            Console.WriteLine("Enter the status: ");
                            // save ticket status
                            BugTicket.TicketStatus = Console.ReadLine();

                            // prompt for priority
                            Console.WriteLine("Enter priority level: ");
                            // save priority
                            BugTicket.TicketPriority = Console.ReadLine();

                            // prompt for submitter name
                            Console.WriteLine("Enter name: ");
                            // save name
                            BugTicket.SubmittedBy = Console.ReadLine();

                            // prompt for assigned
                            Console.WriteLine("Enter name of person the ticket is assigned to: ");
                            // save assigned
                            BugTicket.AssignedTo = Console.ReadLine();

                            // prompt for watcher
                            Console.WriteLine("Enter name of person watching: ");
                            // save watcher
                            BugTicket.Watching = Console.ReadLine();


                            // prompt for severity
                            Console.WriteLine("Enter severity: ");
                            // save severity
                            BugTicket.Severity = Console.ReadLine();


                        TicketFile.AddTicket(BugTicket);
                        Console.WriteLine("Ticket created.");
                        
                        break;
                 case "2":
                        foreach (Bug b in TicketFile.BugTickets)
                        {
                            Console.WriteLine(b.Display());
                        }
                        break;
                 case "3":
                        Enhancement EnhancementTicket = new Enhancement();

                        
                        // prompt for ticket summary
                        Console.WriteLine("Enter a summary: ");
                        // save ticket summary
                        EnhancementTicket.TicketSummary = Console.ReadLine();

                        // prompt for ticket status
                        Console.WriteLine("Enter the status: ");
                        // save ticket status
                        EnhancementTicket.TicketStatus = Console.ReadLine();

                        // prompt for priority
                        Console.WriteLine("Enter priority level: ");
                        // save priority
                        EnhancementTicket.TicketPriority = Console.ReadLine();

                        // prompt for submitter name
                        Console.WriteLine("Enter name: ");
                        // save name
                        EnhancementTicket.SubmittedBy = Console.ReadLine();

                        // prompt for assigned
                        Console.WriteLine("Enter name of person the ticket is assigned to: ");
                        // save assigned
                        EnhancementTicket.AssignedTo = Console.ReadLine();

                        // prompt for watcher
                        Console.WriteLine("Enter name of person watching: ");
                        // save watcher
                        EnhancementTicket.Watching = Console.ReadLine();

                        //prompt for software
                        Console.WriteLine("Enter name of software: ");
                        // save software
                        EnhancementTicket.Software = Console.ReadLine();

                        //prompt for cost
                        Console.WriteLine("Enter cost: ");
                        // save cost
                        EnhancementTicket.Cost = Console.ReadLine();

                        //prompt for reason
                        Console.WriteLine("Enter reason: ");
                        // save reason
                        EnhancementTicket.Reason = Console.ReadLine();

                        //prompt for estimate
                        Console.WriteLine("Enter estimate: ");
                        // save restimate
                        EnhancementTicket.Estimate = Console.ReadLine();


                        enhancementFile.AddTicket(EnhancementTicket);
                        Console.WriteLine("Ticket created.");
                        break;

                 case "4":
                        foreach (Enhancement e in enhancementFile.EnhancementTickets)
                        {
                            Console.WriteLine(e.Display());
                        }
                        break;

                 case "5":
                        Task TaskTicket = new Task();

                      

                        // prompt for ticket summary
                        Console.WriteLine("Enter a summary: ");
                        // save ticket summary
                        TaskTicket.TicketSummary = Console.ReadLine();

                        // prompt for ticket status
                        Console.WriteLine("Enter the status: ");
                        // save ticket status
                        TaskTicket.TicketStatus = Console.ReadLine();

                        // prompt for priority
                        Console.WriteLine("Enter priority level: ");
                        // save priority
                        TaskTicket.TicketPriority = Console.ReadLine();

                        // prompt for submitter name
                        Console.WriteLine("Enter name: ");
                        // save name
                        TaskTicket.SubmittedBy = Console.ReadLine();

                        // prompt for assigned
                        Console.WriteLine("Enter name of person the ticket is assigned to: ");
                        // save assigned
                       TaskTicket.AssignedTo = Console.ReadLine();

                        // prompt for watcher
                        Console.WriteLine("Enter name of person watching: ");
                        // save watcher
                        TaskTicket.Watching = Console.ReadLine();

                        //prompt for project name
                        Console.WriteLine("Enter name of project: ");
                        // save project name
                        TaskTicket.projectName = Console.ReadLine();

                        //prompt for Due Date
                        Console.WriteLine("Enter Due Date: ");
                        // save cost
                        TaskTicket.DueDate = Console.ReadLine();


                        taskFile.AddTicket(TaskTicket);
                        Console.WriteLine("Ticket created.");
                        break;


                 case "6":
           

                        foreach (Task t in taskFile.TaskTickets)
                        {
                            Console.WriteLine(t.Display());
                        }
                        break;
                       
                    case "7":
                        Console.WriteLine("Enter the status you would like to search (Open/Closed)");
                        var searchString = Console.ReadLine();
                        var results = new List<Ticket>();

                        results.AddRange(taskFile.Search(searchString));
                        results.AddRange(enhancementFile.Search(searchString));
                        results.AddRange(TicketFile.Search(searchString));

                        foreach(var item in results)
                        {
                            Console.WriteLine(item.Display());
                        }
                        break;

                }    

            }
            while (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5" || choice == "6" || choice == "7");
        }

  

        }
    }

