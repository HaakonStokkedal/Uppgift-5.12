using System.Reflection.Metadata;

namespace Uppgift_5._12
{
    internal class Program
    {
        static int numberOfDice = 5;
        static int numberOfSides = 6;
        static int[] result = new int[numberOfDice];
        static int maxRolls = 3;
        static void Main(string[] args)
        {
            var rolls = 0;
            while (rolls < maxRolls)
            {
                Console.Clear();
                Console.WriteLine("Sparade tärningar:");
                for (int i = 0; i < numberOfDice; i++)
                {
                    Console.Write($"[");
                    if (result[i] == 0)
                    {
                        Console.Write(" ] ");
                    }
                    else
                    {
                        Console.Write(result[i] + "] ");
                    }
                }
                Console.Write("\n\n");
                Console.WriteLine($"Kast nummer {rolls + 1}.");
                var diceRoll = DiceRoll(numberOfDice);
                for (int i = 0; i < diceRoll.Length; i++)
                {
                    if (diceRoll[i] != 0)
                    {
                        Console.WriteLine($"Tärning {i + 1}: {diceRoll[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"Tärning {i + 1}: -");
                    }
                }
                Console.Write("\nVilka tärningar ska sparas? ");
                var input = Console.ReadLine();
                try
                {
                    var choices = input.Split(' ');
                    foreach (var choice in choices)
                    {
                        result[int.Parse(choice) - 1] = diceRoll[int.Parse(choice) - 1];
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
                rolls++;
            }
            Console.ReadKey();

        }
        static int[] DiceRoll(int numberOfDiceToRoll)
        {
            Random rnd = new Random();
            int[] dice = new int[numberOfDiceToRoll];
            for (int i = 0; i < numberOfDiceToRoll; i++)
            {
                if (result[i] == 0)
                {
                    dice[i] = rnd.Next(1, numberOfSides);
                }
            }
            return dice;
        }
    }
}