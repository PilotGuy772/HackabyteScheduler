namespace Hackabyte;

public class UI
{
    public static void Interface()
    {
        int choice;
        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Option 1");
            Console.WriteLine("2. Option 2");
            Console.WriteLine("3. Option 3");
            Console.WriteLine("4. Option 4");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            // Read user input and validate it
            string input = Console.ReadLine();
            while (!int.TryParse(input, out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                input = Console.ReadLine();
            }

            // Perform action based on user choice
            switch (choice)
            {
                case 1:
                    Console.WriteLine("You selected Option 1.");
                    break;
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
                    Console.WriteLine("Exiting...");
                    break;
            }

        } while (choice != 5);

    }
}