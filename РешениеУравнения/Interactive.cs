namespace Решение_уравнения
{
    public class Interactive
    {
        public string? StorageA { get; set; }
        public string? StorageB { get; set; }
        public string? StorageC { get; set; }
        private int Counter { get; set; }
        public void Start()
        {
            InteracrivePart(StorageA, StorageB, StorageC);
        }
        public void InteracrivePart(string localStorageA, string localStorageB, string localStorageC)
        {
            ConsoleKeyInfo key;
            do
            {
                if (Counter == 0)
                {
                    Console.WriteLine($"a({localStorageA}) * x^2 + b({localStorageB}) * x + c({localStorageC}) = 0 " +
                        $"\n > Число a - {localStorageA} " +
                        $"\n Число b - {localStorageB} " +
                        $"\n Число c - {localStorageC}");
                }
                if (Counter == 1)
                {
                    Console.WriteLine($"a({localStorageA}) * x^2 + b({localStorageB}) * x + c({localStorageC}) = 0 " +
                        $"\n Число a - {localStorageA} " +
                        $"\n > Число b - {localStorageB} " +
                        $"\n Число c - {localStorageC}");
                }
                if (Counter == 2)
                {
                    Console.WriteLine($"a({localStorageA}) * x^2 + b({localStorageB}) * x + c({localStorageC}) = 0 " +
                        $"\n Число a - {localStorageA} " +
                        $"\n Число b - {localStorageB} " +
                        $"\n > Число c - {localStorageC}");
                }
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                        if (Counter == 0)    // для буквы А
                        {
                            if (localStorageA.Length == 0)
                            {
                                Console.Clear();
                                InteracrivePart(localStorageA, localStorageB, localStorageC);
                            }
                            else
                            {
                                var countA = localStorageA.Length - 1;
                                localStorageA = localStorageA.Remove(countA);
                                Console.Clear();
                                InteracrivePart(localStorageA, localStorageB, localStorageC);
                            }
                        }
                        if (Counter == 1)    // для буквы Б
                        {
                            if (localStorageB.Length == 0)
                            {
                                Console.Clear();
                                InteracrivePart(localStorageA, localStorageB, localStorageC);
                            }
                            else
                            {
                                var countB = localStorageB.Length - 1;
                                localStorageB = localStorageB.Remove(countB);
                                Console.Clear();
                                InteracrivePart(localStorageA, localStorageB, localStorageC);
                            }
                        }
                        if (Counter == 2)   // для Буквы C
                        {
                            if (localStorageC.Length == 0)
                            {
                                Console.Clear();
                                InteracrivePart(localStorageA, localStorageB, localStorageC);
                            }
                            else
                            {
                                var countC = localStorageC.Length - 1;
                                localStorageC = localStorageC.Remove(countC);
                                Console.Clear();
                                InteracrivePart(localStorageA, localStorageB, localStorageC);
                            }
                        }
                        break;
                    case ConsoleKey.Enter:

                        StorageA = localStorageA;
                        StorageB = localStorageB;
                        StorageC = localStorageC;
                        break;
                    case ConsoleKey.DownArrow:
                        if (Counter < 2)
                        {
                            Counter++;
                        }
                        else
                        {
                            Counter = 2;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey.UpArrow:
                        if (Counter > 0)
                        {
                            Counter--;
                        }
                        else
                        {
                            Counter = 0;
                        }
                        Console.Clear();
                        break;
                    case ConsoleKey:

                        if (Counter == 0)
                        {
                            var inputA = key.KeyChar;
                            localStorageA += inputA;
                            Console.Clear();
                        }
                        if (Counter == 1)
                        {
                            var inputB = key.KeyChar;
                            localStorageB += inputB;
                            Console.Clear();
                        }
                        if (Counter == 2)
                        {
                            var inputC = key.KeyChar;
                            localStorageC += inputC;
                            Console.Clear();
                        }
                        break;
                }
            }
            while (key.Key != ConsoleKey.Enter);
        }
    }
}