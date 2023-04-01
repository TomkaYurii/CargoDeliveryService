using FakeDataDriverDbGenerator.Data;
using FakeDataDriverDbGenerator.Entities;
using FakeDataDriverDbGenerator.Seeders;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;
using static Program;

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
                    await Task.Run(() => DeleteDatabase());
                    break;
                case "2":
                    await Task.Run(() => CreateDatabase());
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

    /// <summary>
    /// ВИДАЛЕННЯ БАЗИ ДАНИХ
    /// </summary>
    static void DeleteDatabase()
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
        Console.WriteLine("Чи встановлено на базі даних логін та пароль? (y/n): ");
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
        using (var dbContext = new DbContext(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options))
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

    /// <summary>
    /// СТВОРЕННЯ БАЗИ ДАНИХ
    /// </summary>
    static void CreateDatabase()
    {
        Console.Clear();
        Console.WriteLine("Task is started...\n");
        Task.Delay(1000).Wait();

        Console.WriteLine("==================");
        Console.Write("Введіть ім'я серверу: \n");
        string serverName = Console.ReadLine();

        Console.Write("Введыть ім'я бази даних: \n");
        string databaseName = Console.ReadLine();

        Console.Write("Чи хочете ви використовувати логін ты пароль для доступу до бази даних? (y/n): \n");
        string useCredentials = Console.ReadLine();

        string connectionString;
        if (useCredentials.ToLower() == "y")
        {
            Console.Write("Введіть ім'я користувача: \n");
            string userName = Console.ReadLine();

            Console.Write("Введіть пароль: \n");
            string password = ReadPassword();

            connectionString = $"Server={serverName};Database={databaseName};User Id={userName};Password={password};Integrated Security=true;";
        }
        else
        {
            connectionString = $"Server={serverName};Database={databaseName};Integrated Security=true;";
        }


        using (var context = new DbContext(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options))
        {
            if (context.Database.CanConnect())
            {
                Console.WriteLine($"База даних {databaseName} вже існує. Бажаєте змінити ім'я бази даних? Якщо не змынимо - то відбудеться перезапис (y/n): \n");
                bool renameDatabase = Console.ReadLine().ToLower() == "y";

                if (renameDatabase)
                {
                    Console.Write("Введіть нове ім'я бази даних: \n");
                    string newDatabaseName = Console.ReadLine();
                    connectionString = RenameDatabase(connectionString, newDatabaseName);
                    context.Database.GetDbConnection().ConnectionString = connectionString;
                    Console.WriteLine($"Рядок підключення та контекст даних змінено з в рахуванням того, що ім'я бази даних тепер: {newDatabaseName} \n");
                    Console.WriteLine($"Рядок підключення: {connectionString} \n");
                    context.Database.EnsureCreated();
                    Console.WriteLine($"База даних {newDatabaseName} успішно створена! \n");
                    Task.Delay(1000).Wait();
                }
            }
            else
            {
                context.Database.EnsureCreated();
                Console.WriteLine($"База даних {databaseName} успішно створена! \n");
            }
        }

        Console.WriteLine("Task is finished...\n");
        Task.Delay(2000).Wait();
        Console.Clear();
    }

    /// <summary>
    /// Приховування вводимого паролю. По Enter завершується ввід
    /// </summary>
    /// <returns></returns>
    static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, (password.Length - 1));
                Console.Write("\b \b");
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();

        return password;
    }

    /// <summary>
    /// Зміна імені бази даних у рядку піключення
    /// </summary>
    /// <param name="connectionString"></param>
    /// <param name="newDatabaseName"></param>
    /// <returns></returns>
    static string RenameDatabase(string connectionString, string newDatabaseName)
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
        builder.InitialCatalog = newDatabaseName;
        string newConnectionString = builder.ToString();
        Console.WriteLine($"Ім'я бази даних успішно змінено на {newDatabaseName}.");
        return newConnectionString;
    }
}