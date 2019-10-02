using System.Configuration;
using Task.Data;
using Task.Services;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoriesService.CreateResultDirectory();
            GetClientXlsData();

            System.Console.WriteLine("Выполнено. Для выхода нажмите Enter.");
            System.Console.ReadLine();
        }

        public static void GetClientXlsData(string socialNumber = "12345678901234")
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var clientRepo = new ClientRepository(new DataContext(connectionString));
            var clientsService = new ClientsService(clientRepo);
            clientsService.WriteClientDataToXls(socialNumber);
        }
    }
}
