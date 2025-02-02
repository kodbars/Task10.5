
using Task10._5;

namespace Task1
{
    class Calculator : ILogger
    {
        private string[] symbols = { "---", "|", "   " };
        string[] arifSimvol = { "*", "/", "+", "-" };
        public Calculator()
        {
            double result = 0;

            while (true)
            {
                try
                {
                    InfoCalculator();
                    Rendering();
                    Conclusion(result);
                    result = SolutionExecution(Console.ReadLine());
                    Console.Clear();
                }
                catch (Exception e)
                {
                    ExceptionLogRed(e.Message + "\nНажми Enter и введи заново арифметическую операцию правильно");
                    Console.ReadKey();
                    Console.Clear();
                }
                
            }
        }

        public void EventLogBlue(string str)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(str);
            Console.ResetColor();
        }

        public void ExceptionLogRed(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ResetColor();
        }

        private void Conclusion(double arifmOperations)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" => {arifmOperations}");
            Console.ResetColor();
        }

        private void InfoCalculator()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string info = "Ниже предоставлена информация по использованию калькулятора." +
                          "\nИспользуйте два числа и арифметический оператор( + , - , * , \\ ). " +
                          "\nДля вывода результата нажимите Enter." +
                          "\nПример ввода: 5 + 2 => Enter" +
                          "\nВывод результата.\n";
            Console.WriteLine(info);
            Console.ResetColor();
        }

        private void Rendering()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int[] counts = { 7, 8, 9, 4, 5, 6, 1, 2, 3, 0 };
            int count = 0;
            int count2 = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i % 2 == 0 && j < 4)
                    {
                        Console.Write(" " + symbols[0]);
                    }
                    else if (i % 2 == 1 && j % 2 == 0)
                    {
                        Console.Write(symbols[1]);
                    }
                    else if (j % 2 == 1 && i % 2 != 0)
                    {
                        if (j == 7 && i % 2 == 1 && i < 8 && count2 < 4)
                        {
                            Console.Write($" {arifSimvol[count2]} ");
                            count2++;
                        }
                        else if (i == 7 && j % 2 == 1 && j != 3)
                        {
                            Console.Write(symbols[2]);
                        }
                        else
                        {
                            Console.Write($" {counts[count]} ");
                            count++;
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        private double SolutionExecution(string s)
        {
            string arithmeticOperation = s.Replace(" ", "");
            string arifmetic = "";
            foreach (var item in arifSimvol)
            {
                if (arithmeticOperation.Contains(item))
                {
                    arifmetic = item;
                    break;
                }
            }

            string[] arithmeticOperations = arithmeticOperation.Split(arifmetic);

            return arifmetic switch
            {
                "+" => Convert.ToDouble(arithmeticOperations[0]) + Convert.ToDouble(arithmeticOperations[1]),
                "-" => Convert.ToDouble(arithmeticOperations[0]) - Convert.ToDouble(arithmeticOperations[1]),
                "*" => Convert.ToDouble(arithmeticOperations[0]) * Convert.ToDouble(arithmeticOperations[1]),
                "/" => Convert.ToDouble(arithmeticOperations[0]) / (Convert.ToDouble(arithmeticOperations[1]) == 0 ? throw new DivideByZeroException("На ноль делить нельзя!") : Convert.ToDouble(arithmeticOperations[1])),
                _ => throw new ArithmeticException($"Вы ввели неккоректный арифметический оператор: {arifmetic}")
            };
        }
    }
}
