using System.Xml.Serialization;

namespace lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Write("Enter task to run(1, 2, 3, 4, 0 - to exit): ");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Task1.Run();
                        break;
                    case 2:
                        Task2.Run();
                        break;
                    case 3:
                        Task3.Run();
                        break;
                    case 4:
                        Task4.Run();
                        break;
                }

            } while (choice != 0);
        }
    }
}