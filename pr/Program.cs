namespace pr
{
    internal class Program
    {
        class SurnameException : Exception 
        {
            public string Name { get; set; }
            public SurnameException(string name) : base($"Неверное имя: {name}") // выводится вместо ex.Message в блоке catch для понимания 
            {
                Name = name;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите имя пользователя");
                string UserName = Console.ReadLine();
                if (!IsValidName(UserName))
                {
                    throw new SurnameException(UserName);
                }
                else if(UserName.Length > 10)
                {
                    throw new IndexOutOfRangeException();
                }
                else if(UserName == null)
                {
                    throw new ArgumentNullException();
                }
                else if(UserName == "")
                {
                    throw new ArgumentException();
                }
                else
                {
                    Console.WriteLine("Имя успешно введено");
                }
            }

            catch(SurnameException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Проверка завершена");
            }
        }

       public static bool IsValidName(string UserName) // проверка на буквы в введенном значении 
       {
            foreach(char us in UserName)
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
