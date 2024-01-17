using System;
using System.Security.Cryptography;
using System.Text;

class DiceSimulator
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Dice Simulator!");

        while (true)
        {
            // Display the options menu
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1) Throw a dice!");
            Console.WriteLine("2) Do something else");
            Console.WriteLine("3) Hash a value");
            Console.WriteLine("4) Exit");

            // Prompt the user for their choice
            Console.Write("Enter your choice (1-4): ");
            int userChoice = Convert.ToInt32(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    Console.Write("Enter the number of times to throw the dice (N): ");
                    int N = Convert.ToInt32(Console.ReadLine());

                    // Simulate dice throws
                    Dice(N);
                    break;

                case 2:
                    Console.WriteLine("Why not throwing a dice instead?");
                    break;

                case 3:
                    Console.Write("Enter an alphanumeric value: ");
                    string alphanumericValue = Console.ReadLine();

                    // Calculate double SHA256 hash
                    string hashResult = CalculateDoubleSHA256Hash(alphanumericValue);

                    Console.WriteLine($"Double SHA256 Hash of '{alphanumericValue}': {hashResult}");
                    break;

                case 4:
                    // Exit the program
                    Console.WriteLine("Exiting the Dice Simulator. Goodbye!");
                    return;

                default:
                    // Display an error message for invalid choices
                    Console.WriteLine("Error: Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }

    // Simulate dice throws
    static void Dice(int N)
    {
        Random random = new Random();
        int[] diceResults = new int[6];

        // Simulate N dice throws
        for (int i = 0; i < N; i++)
        {
            int result = random.Next(1, 7); // Generates a random number between 1 and 6
            diceResults[result - 1]++; // Increment the corresponding index in the array
        }

        // Print results in tabular form
        Console.WriteLine("\nDice Results:");
        Console.WriteLine("Number\tFrequency\tPercentage");
        for (int i = 0; i < 6; i++)
        {
            double percentage = (double)diceResults[i] / N * 100;
            Console.WriteLine($"{i + 1}\t{diceResults[i]}\t\t{percentage:F2}%");
        }
    }

    // Calculate double SHA256 hash
    static string CalculateDoubleSHA256Hash(string value)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(value));
            string firstHash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            byte[] secondHashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(firstHash));
            string secondHash = BitConverter.ToString(secondHashBytes).Replace("-", "").ToLower();

            return secondHash;
        }
    }
}
