using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            int numSides, lowestSide = 1, rollOne, rollTwo;
            string sides, zeroChoice, rollChoice, replayChoice;
            bool repeatSides;

            Console.WriteLine("Hello and welcome to the Dice Roller!");

            do
            {
                repeatSides = true;

                Console.Write("Please specify the number of sides the dice will have: ");
                sides = Console.ReadLine();

                do
                {
                    if (int.TryParse(sides, out numSides))
                    {
                        if (numSides <= 1)
                        {
                            Console.WriteLine("The dice must have two or more sides. Please choose a different number.");
                            sides = Console.ReadLine();
                        }
                        else
                        {
                            repeatSides = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                        sides = Console.ReadLine();
                    }
                } while (repeatSides);

               

                Console.Write("Do you want the dice to start from 0? (y/n): ");
                zeroChoice = Console.ReadLine().ToLower();

                while (zeroChoice != "y" && zeroChoice != "n")
                {
                    Console.WriteLine("Invalid Input");
                    zeroChoice = Console.ReadLine().ToLower();
                }

                if (zeroChoice == "y")
                {
                    lowestSide = 0;
                    numSides -= 1;
                }
                else if (zeroChoice == "n")
                {
                    lowestSide = 1;
                }

                do
                {
                    rollOne = DiceRoll(lowestSide, numSides);
                    rollTwo = DiceRoll(lowestSide, numSides);

                    Console.Write($"Die 1: {rollOne}");
                    Console.WriteLine();
                    Console.Write($"Die 2: {rollTwo}");
                    Console.WriteLine();

                    Console.WriteLine(DiceRollerApp.RollMessage(rollOne, rollTwo));

                    Console.Write("Would you like to reroll these dice? (y/n): ");
                    rollChoice = Console.ReadLine().ToLower();

                    while (rollChoice != "y" && rollChoice != "n")
                    {
                        Console.WriteLine("Invalid Input");
                        rollChoice = Console.ReadLine().ToLower();
                    }
                } while (rollChoice == "y");

                Console.Write("Would you like to change the number of sides? (y/n): ");
                replayChoice = Console.ReadLine().ToLower();

                while (replayChoice != "y" && replayChoice != "n")
                {
                    Console.WriteLine("Invalid Input");
                    replayChoice = Console.ReadLine().ToLower();
                }

            } while (replayChoice == "y");

            Console.WriteLine("Goodbye and thanks for rolling!");
            return;
        }

        public static int DiceRoll(int lowSide, int sides)
        {
            Random rnd = new Random();
            int roll = rnd.Next(lowSide, sides + 1);
            return roll;
        }
    }

    class DiceRollerApp
    {
        public static string RollMessage(int firstRoll, int secondRoll)
        {
            string snakeMessage = "", crapsMessage = "", boxcarMessage = "", message;

            if (firstRoll == 1 && secondRoll == 1)
            {
                snakeMessage = "Snake Eyes! ";
            }

            if (firstRoll + secondRoll == 2 || firstRoll + secondRoll == 3 || firstRoll + secondRoll == 12)
            {
                crapsMessage = "Craps! ";
            }

            if (firstRoll == 6 && secondRoll == 6)
            {
                boxcarMessage = "Boxcars! ";
            }

            message = snakeMessage + crapsMessage + boxcarMessage;
            return message;
        }
    }
}
