using System;
using System.Collections.Generic;

namespace Task21
{
    class Program
    {
        private static List<string> statistics;
        static void Main(string[] args)
        {
            Console.WriteLine("Игра Камень-Ножницы-Бумага.");
            PlayGame();
        }
        static void PlayGame()
        {
            Console.WriteLine("Камень-Ножницы-Бумага");
            Console.WriteLine("Правила:");
            Console.WriteLine("Вы играете с компьютером.\nВаша главная цель - выиграть больше раз.");
            Console.WriteLine("Выигрышные комбинации:\n\tкамень > ножницы\n\tножницы > бумага\n\tбумага > камень");
            PrintCommands();
            statistics = new List<string>();
            while (true)
            {
                Console.Write("Введите команду: ");
                var command = Console.ReadLine().ToLower();

                string result;
                switch (command)
                {
                    case "камень":
                        Game(0);
                        break;
                    case "ножницы":
                        Game(1);
                        break;
                    case "бумага":
                        Game(2);
                        break;
                    case "выход":
                        PrintGameStatistic(statistics);
                        return;
                    default:
                        Console.WriteLine("Ошибка ввода.");
                        PrintCommands();
                        Console.WriteLine("Попробуйте еще раз.");
                        break;
                }
            }
        }
        static void Game(int command)
        {
            var computer = ComputerChoice();
            PrintComputerChoice(computer);
            var result = GetGameResult(command, computer);
            PrintGameResult(result);
            statistics.Add(result);
        }
        static void PrintCommands()
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\tкамень");
            Console.WriteLine("\tножницы");
            Console.WriteLine("\tбумага");
            Console.WriteLine("\tвыход\n");
        }
        static int ComputerChoice()
        {
            var random = new Random();
            var figure = random.Next(3);
            return figure;
        }
        static string GetGameResult(int person, int computer)
        {
            //0 - computer wins, 1 - person wins, 2 - draw
            person = (person + 1) % 3;
            computer = (computer + 1) % 3;
            if (person == computer) return "Draw.";
            else if ((computer + 1) % 3 == person) return "Компьютер выиграл.";
            else return "Вы выиграли!!!";
        }
        static void PrintComputerChoice(int comp)
        {
            Console.Write($"Computer's choice: ");
            if (comp == 0) Console.WriteLine("stone");
            else if (comp == 1) Console.WriteLine("scissors");
            else Console.WriteLine("paper");
        }
        static string PrintGameResult(string result)
        {
            Console.WriteLine($"Game result: {result}\n");
            return result;
        }

        static void PrintGameStatistic(List<string> statistics)
        {
            var size = statistics.Count;
            Console.Write($"\nYou have played {size} game");
            if (size != 1) Console.Write("s");
            Console.WriteLine();
            for (int i = 0; i < size; ++i)
            {
                Console.WriteLine($"Game #{i + 1} result: {statistics[i]}");
            }
        }
    }
}