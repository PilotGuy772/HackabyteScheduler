namespace Hackabyte;

public class UI
{
    public static void Interface()
    {
        int choice;
        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Assignment");
            Console.WriteLine("2. Schedule Item");
            Console.WriteLine("3. Plan Schedule");
            Console.WriteLine("4. List Scheduled Items");
            Console.WriteLine("5. Print Assignment List");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice (1-6): ");

            // Read user input and validate it
            string input = Console.ReadLine();
            while (!int.TryParse(input, out choice) || choice < 1 || choice > 6)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 6.");
                input = Console.ReadLine();
            }

            // Perform action based on user choice
            switch (choice)
            {
                case 1:
                    Console.WriteLine("You selected Option 1.");
                    Console.WriteLine("Enter your assignment name:: ");
                    Assignment newAssignment = new();
                    newAssignment.Name = Console.ReadLine() ?? "";
                    Console.WriteLine("Enter due date of assignment (in MM/dd/yyyy format):: ");
                    string date = Console.ReadLine() ?? "";
                    {
                        // if (DateTime.ParseExact(date, "MM/dd/yyyy", null) < DateTime.Today)
                        // {
                        //     break;
                        // }
                        string[] dateArray = date.Split("/");
                        newAssignment.DueDate = new DateTime(int.Parse(dateArray[2]), int.Parse(dateArray[0]), int.Parse(dateArray[1]));
                        Console.WriteLine("Enter time span of assignment in 30 minute increments in hh:mm");
                        string timeString = Console.ReadLine() ?? "";
                        newAssignment.TimeEstimate = new TimeSpan(int.Parse(timeString.Split(":")[0]), int.Parse(timeString.Split(":")[1]), 0);
                        Assignment.Assignments.Add(newAssignment);
                        
                        break;
                    }

                    /*catch (FormatException)
                    {
                        Console.WriteLine("Invalid date format");
                        continue;
                    }*/
                case 2:
                    Console.WriteLine("You selected Option 2.");
                    //add schedule items
                    //takes name, start time, end time, whether it repeats, and, if it repeats, which days it repeats and when it stops repeating.
                    BlockTime block = new();
                    
                    Console.WriteLine("Entry name:");
                    block.Name = Console.ReadLine() ?? "";
                    
                    Console.WriteLine("Day of first occurence (MM/dd/yyyy):");
                    string dayString = Console.ReadLine() ?? "";
                    DateTime firstDay = new DateTime(int.Parse(dayString.Split("/")[2]), int.Parse(dayString.Split("/")[0]), int.Parse(dayString.Split("/")[1]), 0, 0, 0);
                    
                    Console.WriteLine("Daily start time (HH:mm):");
                    string startTimeString = Console.ReadLine() ?? "";
                    block.StartTime = firstDay + new TimeSpan(0, int.Parse(startTimeString.Split(":")[0]), int.Parse(startTimeString.Split(":")[1]), 0);
                    
                    Console.WriteLine("Daily end time (HH:mm):");
                    string endTimeString = Console.ReadLine() ?? "";
                    block.EndTime = firstDay + new TimeSpan(0, int.Parse(endTimeString.Split(":")[0]), int.Parse(endTimeString.Split(":")[1]), 0);

                    Console.WriteLine("Does this event repeat one or more times per week? [y/N]");
                    if (Console.ReadLine() != "y")
                    {
                        Schedule.ScheduleItems.Add(block);
                        break;
                    }

                    RecurringItem rule = new();
                    
                    //this event repeats
                    Console.WriteLine(
                        "What days of the week does this event repeat? Answer in comma-seperated numbers 1-7 where 1 is Monday and 7 is Sunday.");
                    List<DayOfWeek> days = new();
                    foreach (string day in Console.ReadLine().Split(","))
                    {
                        days.Add((DayOfWeek)byte.Parse(day));
                    }

                    rule.DaysOfWeek = days.ToArray();

                    rule.Event = block;
                    
                    Schedule.RecurringItems.Add(rule);
                    
                    break;
                case 3:
                    Console.WriteLine("You selected Option 3.");
                    AutoScheduler.ScheduleAssignments();
                    Console.WriteLine("Scheduling complete! Choose Option 4 to see your schedule.");
                    break;
                case 4:
                    Console.WriteLine("You selected Option 4.");
                    Console.WriteLine("These are your schedule items for today:");
                    Console.WriteLine
                    break;
                case 5:
                    Console.WriteLine("print");
                    Assignment.Assignments.ForEach(item => Console.WriteLine($"{item.Name} Due {item.DueDate.Date} time {item.TimeEstimate.TotalMinutes}"));
                    break;
                case 6:
                    Console.WriteLine("Exiting...");
                    break;
            }

        } while (choice != 6);

    }
}