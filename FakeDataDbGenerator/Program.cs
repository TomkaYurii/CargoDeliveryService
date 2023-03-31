using FakeDataDriverDbGenerator.Data;
using FakeDataDriverDbGenerator.Entities;
using FakeDataDriverDbGenerator.Seeders;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8; 
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("=======================");
            Console.WriteLine("Выберите задачу:");
            Console.WriteLine("1. Видалення бази даних");
            Console.WriteLine("2. Розгортання бази даних");
            Console.WriteLine("3. Вихід");
            Console.WriteLine("=======================");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    await Task.Run(() => Task1());
                    break;
                case "2":
                    await Task.Run(() => Task2());
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Некоректне виведення");
                    break;
            }
           
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
    }

    static void Task1()
    {
        Console.Clear();
        Console.WriteLine("Task is started...\n");
        Task.Delay(1000).Wait();

        Console.WriteLine("==================");

        Console.Write("Введіть ім'я серверу, на якому необхідно видалити: \n");
        string serverName = Console.ReadLine().ToLower();
        Console.Write("Введіть ім'я бази даних, яку необхідно видалити: \n");
        string databaseName = Console.ReadLine().ToLower();
        
        string connectionString;

        // Перевіряєм, чи є у користувача логін та пароль для бази даних
        Console.WriteLine("Чи встановлено на бахі даних логін та пароль? (y/n): ");
        string response = Console.ReadLine().ToLower();

        if (response == "y")
        {
            Console.WriteLine("Введіть логін: \n");
            string username = Console.ReadLine().ToLower();
            Console.WriteLine("Введіть пароль: \n");
            string password = Console.ReadLine().ToLower();
            // Створення рядка підключенння до SQL серверу із логіном та паролем
            connectionString = $"Server={serverName};Database={databaseName};Trusted_Connection=True;User Id={username};Password={password};";

        }
        else
        {
            // Створення рядка підключення до SQL серверу без лоогіну та паролю
            connectionString = $"Server={serverName};Database={databaseName};Trusted_Connection=True;";
        }


        Console.WriteLine($"Рядок підключення до БД : {connectionString} \n");
        Task.Delay(500).Wait();
        Console.WriteLine($"Видаляю базу даних {databaseName} \n");


        // Створення контексту бази даних
        DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        builder.UseSqlServer(connectionString);
        using (var dbContext = new DbContext(builder.Options))
        {
            // Перевірка існування бази даних
            bool databaseExists = dbContext.Database.CanConnect();
            if (databaseExists)
            {
                // Видалення бази даних
                dbContext.Database.EnsureDeleted();
                Console.WriteLine($"База даних {databaseName} успішно видалена. \n");
            }
            else
            {
                Console.WriteLine($"База даних {databaseName} не знайдена. \n");
            }
        }
        
        Console.WriteLine("Task is finished...\n");
        Task.Delay(1000).Wait();
        Console.Clear();
    }

    static void Task2()
    {
        Console.WriteLine("Задача 2 выполняется...");
        // Выполнение задачи 2
    }

    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
    }

}