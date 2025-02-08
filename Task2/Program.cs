using System.Security.Cryptography.X509Certificates;
namespace Task2
{
    public delegate void Notify(string[] arr);
    class SortwEvent
    {
        public event Notify delofsort;
        public void StartSortwEvent(string[] arr)
        {
            delofsort?.Invoke(arr);
        }
    }

    class SurnameException : Exception
    {
        public SurnameException(string name) : base($"Неверное имя: {name}") // выводится вместо ex.Message в блоке catch для понимания 
        {
            
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] arr = new string[5];
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine("Введите фамилию №{0}", i + 1);
                    string Surname = Console.ReadLine();
                    arr[i] = Surname;
                    if (!IsValidName(Surname))
                    {
                        throw new SurnameException(Surname);
                    }
                }
                Console.WriteLine("Введите 1 для сортировки А-Я\nВведите 2 для сортировки Я-А");
                string value = Console.ReadLine();
                SortwEvent swe = new SortwEvent();
                if (value == "1")
                {
                    swe.delofsort += SortAZ;
                }
                else if (value == "2")
                {
                    swe.delofsort += SortZA;
                }
                else
                {
                    throw new SurnameException(value);
                }
                swe.StartSortwEvent(arr);
            }
            catch(SurnameException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void SortAZ(string[] arr)
        {
            Array.Sort(arr);
            Console.WriteLine("\nОт А-Я");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        public static void SortZA(string[] arr)
        {
            Array.Sort(arr);
            Console.WriteLine("\nОт Я-А");
            for (int i = 4; i >= 0; i--)
            {
                Console.WriteLine(arr[i]);
            }
        }

        public static bool IsValidName(string UserName) // проверка на буквы в введенном значении 
        {
            foreach (char us in UserName)
            {
                if (!Char.IsLetter(us))
                {
                    return false; // если есть не буква 
                }
            }
            return true; // если все буквы
        }
    }
}
