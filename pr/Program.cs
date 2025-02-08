namespace pr
{



    internal class Program
    {

        static void Main(string[] args)
        {

            NumberReader nr = new NumberReader();
            nr.NumberEneteredEvent += ShowNumber;

            while (true)
            {
                try
                {
                    nr.Read();
                }

                catch (FormatException)
                {
                    Console.WriteLine("Введено некорректное значение");
                }
            }
            
        }

        public static void ShowNumber(int number)
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine("1");
                    break;
                case 2:
                    Console.WriteLine("2");
                    break;
            }
        }
       

        
    }

    class NumberReader
    {

        public delegate void NumberEneteredDelegate(int number);
        public event NumberEneteredDelegate NumberEneteredEvent;


        public void Read()
        {
            Console.WriteLine("Нужно ввести значение 1 или 2");
            int number = int.Parse(Console.ReadLine());
            if(number != 1 && number != 2)
            {
                throw new FormatException();
            }
            NumberEntered(number);

        }

        protected virtual void NumberEntered(int nubmer)
        {
            NumberEneteredEvent?.Invoke(nubmer);
        }

    }
}
