using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        BigInteger[] tetranacciStart = new BigInteger[4];
        bool validInput = false;

        while (!validInput)
        {
            Console.Write("Zadejte první čtyři čísla Tetranacciho posloupnosti oddělená mezerou: ");
            string input = Console.ReadLine();
            string[] numbers = input.Split(' ');

            if (numbers.Length != 4)
            {
                Console.WriteLine("Chybný vstup. Zadejte prosím čtyři čísla.");
                continue;
            }

            validInput = true;
            for (int i = 0; i < 4; i++)
            {
                if (!BigInteger.TryParse(numbers[i], out tetranacciStart[i]))
                {
                    Console.WriteLine("Chybný vstup. Zadejte prosím platná čísla.");
                    validInput = false;
                    break;
                }
            }
        }

        bool continueGenerating = true;
        int sequenceLength = 0;

        while (continueGenerating)
        {
            validInput = false;

            while (!validInput)
            {
                Console.Write("Zadejte délku sekvence Tetranacciho posloupnosti (minimálně 12): ");
                if (!int.TryParse(Console.ReadLine(), out sequenceLength) || sequenceLength < 12)
                {
                    Console.WriteLine("Chybný vstup. Zadejte celé číslo alespoň 12.");
                }
                else
                {
                    validInput = true;
                }
            }

            // Vytvoření a vypsání Tetranacciho posloupnosti s různými barvami
            Console.ForegroundColor = ConsoleColor.Green; // Nastaví barvu textu na zelenou
            BigInteger[] tetranacciSequence = new BigInteger[sequenceLength];
            for (int i = 0; i < 4; i++)
            {
                tetranacciSequence[i] = tetranacciStart[i];
                Console.Write(tetranacciSequence[i] + " ");
            }

            for (int i = 4; i < sequenceLength; i++)
            {
                tetranacciSequence[i] = BigInteger.Add(BigInteger.Add(BigInteger.Add(tetranacciSequence[i - 1], tetranacciSequence[i - 2]), tetranacciSequence[i - 3]), tetranacciSequence[i - 4]);
                
                // Nastaví různé barvy pro každé číslo
                Console.ForegroundColor = (ConsoleColor)((i % 14) + 1); // Modulo 14 zajistí opakování barev, +1 kvůli tomu, že ConsoleColor začíná od 1
                
                Console.Write(tetranacciSequence[i] + " ");
            }

            Console.ResetColor(); // Obnoví výchozí barvy konzole
            Console.WriteLine(); // Oddělení výstupu pro lepší čitelnost

            // Kontrola zda uživatel chce pokračovat nebo ukončit program
            Console.Write("Chcete pokračovat (p) nebo ukončit program (k)? ");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "k")
                continueGenerating = false;
        }
    }
}
