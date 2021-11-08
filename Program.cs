using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    using (FileContext db = new FileContext())
                    {
                        File file1 = new File { Name = "Tom", Size = 33.6 };

                        db.Files.Add(file1);

                        db.SaveChanges();

                        var files = db.Files;
                        Console.WriteLine("Список объектов:");
                        foreach (File u in files)
                        {
                            Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Size);
                        }
                        Console.ReadLine();
                    }
                });
    }
}
