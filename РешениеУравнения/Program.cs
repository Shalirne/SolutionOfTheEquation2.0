
namespace Решение_уравнения
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Validation();
            }
            catch (Exception xException)
            {
                if (xException.InnerException == null)
                {
                    FormatData(xException.Data["ResultForExceptiong"].ToString(), Severity.error, xException.Data["A"].ToString(), xException.Data["B"].ToString(), xException.Data["C"].ToString());
                }
                else
                {
                    FormatData(xException.Message, Severity.warning, default, default, default);
                }
            }
            void Validation()
            {
                try
                {
                    Interactive intecative = new Interactive();
                    intecative.Start();
                    string resultForExceptiong = "";
                    resultForExceptiong = "";
                    string numberA = intecative.StorageA;
                    bool resultsA = int.TryParse(numberA, out int a);
                    string numberB = intecative.StorageB;
                    bool resultsB = int.TryParse(numberB, out int b);
                    string numberC = intecative.StorageC;
                    bool resultcC = int.TryParse(numberC, out int c);

                    if (resultsA == false)
                    {
                        resultForExceptiong = "a";
                    }
                    else if (resultsB == false)
                    {
                        resultForExceptiong += "b";
                    }
                    else if (resultcC == false)
                    {
                        resultForExceptiong += "c";
                    }
                    else if (resultForExceptiong.Length > 0)
                    {
                        var xException = new Exception();

                        if (numberA == null)
                        {
                            xException.Data["A"] = "Вы не ввели элемент";
                        }
                        else
                        {
                            xException.Data["A"] = numberA;
                        }
                        if (numberB == null)
                        {
                            xException.Data["B"] = "Вы не ввели элемент";
                        }
                        else
                        {
                            xException.Data["B"] = numberB;
                        }
                        if (numberC == null)
                        {
                            xException.Data["C"] = "Вы не ввели элемент";
                        }
                        else
                        {
                            xException.Data["C"] = numberC;
                        }
                        xException.Data["ResultForExceptiong"] =
                                $"-------------------------------------------------" +
                                $"\n Неверный формат параметра {resultForExceptiong} " +
                                $"\n-------------------------------------------------";
                        throw xException;
                    }
                    Calculation(a, b, c);
                }
                catch (HaveNoSolutionException es)
                {
                    throw new Exception("Вещественных значений не найдено", es);
                }
            }
            static void Calculation(int a, int b, int c)
            {
                float x1;
                float x2;
                try
                {
                    if (a == 0)
                    {
                        throw new HaveNoSolutionException();
                    }
                    int discriminant = b * b - 4 * a * c;
                    float root = float.Sqrt(discriminant);
                    if (discriminant < 0)
                    {
                        throw new HaveNoSolutionException();
                    }
                    else if (discriminant == 0)
                    {
                        x1 = (-b + float.Sqrt(discriminant)) / (2 * a);
                        Console.WriteLine($"x = {x1}");
                    }
                    else if (discriminant > 0)
                    {
                        x1 = (-b + root) / (2 * a);
                        x2 = (-b - root) / (2 * a);
                        Console.WriteLine($"x1 = {x1} , x2 = {x2}");
                    }
                }
                catch (HaveNoSolutionException es)
                {
                    throw new Exception("Вещественных значений не найдено", es);
                }
            }
        }
        public static void FormatData(string message, Severity severity, string a, string b, string c)
        {
            if (severity == Severity.error)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"a == {a}");
                Console.WriteLine($"b == {b}");
                Console.WriteLine($"c == {c}");
                Console.ResetColor();
            }
            else if (severity == Severity.warning)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }
}