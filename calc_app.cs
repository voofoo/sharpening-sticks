using System;

class CalculatorProgram
{
    static void Main()
    {
        // Greet the user
        Console.WriteLine("MyCalcApp!");

        // Declare variables to store user input
        double numb1, numb2;

        // Ask for the first number
        Console.Write("Enter the first number: \n");
        numb1 = Convert.ToDouble(Console.ReadLine());

        // Ask for the second number
        Console.Write("Enter the second number: \n");
        numb2 = Convert.ToDouble(Console.ReadLine());

        // Menu loop
        while (true)
        {
            // Display the menu
            Console.WriteLine("\nMenu:");
            Console.WriteLine("--");
            Console.WriteLine("1) Add");
            Console.WriteLine("2) Subtract");
            Console.WriteLine("3) Multiply");
            Console.WriteLine("4) Divide");
            Console.WriteLine("5) Exit");
            Console.WriteLine("--\n");

            // Prompt the user to choose an option
            Console.Write("Enter your choice (1-5): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            // Variables to store the result of the calculation
            double result = 0;

            // Perform calculation based on user's choice
            switch (choice)
            {
                case 1:
                    result = numb1 + numb2;
                    Console.WriteLine("Addition Result: {0} + {1} = {2}", numb1, numb2, result);
                    break;
                case 2:
                    result = numb1 - numb2;
                    Console.WriteLine("Subtraction Result: {0} - {1} = {2}", numb1, numb2, result);
                    break;
                case 3:
                    result = numb1 * numb2;
                    Console.WriteLine("Multiplication Result: {0} * {1} = {2}", numb1, numb2, result);
                    break;
                case 4:
                    // Check if the second number is not zero to avoid division by zero
                    if (numb2 != 0)
                    {
                        result = numb1 / numb2;
                        Console.WriteLine("Division Result: {0} / {1} = {2}", numb1, numb2, result);
                    }
                    else
                    {
                        Console.WriteLine("Error: Cannot divide by zero.");
                    }
                    break;
                case 5:
                    // Exit the program
                    Console.WriteLine("Exiting the Calculator Program. Goodbye!");
                    return;
                default:
                    // Display an error message for invalid choices
                    Console.WriteLine("Error: Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}
