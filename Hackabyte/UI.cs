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
            Console.WriteLine("3. Option 3");
            Console.WriteLine("4. Option 4");
            Console.WriteLine("5. Print List");
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
                    break;
                case 3:
                    Console.WriteLine("You selected Option 3.");
                    break;
                case 4:
                    Console.WriteLine("You selected Option 4.");
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