using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext dbContext) 
        {
            dbContext.Database.EnsureCreated();

            dbContext.Database.Migrate();

            if (!dbContext.Equipment.Any())
            {

                var assembly = typeof(DbInitializer).Assembly;
                var resourceName = "Infrastructure.Data.SeedData.seedData.json";

                using var stream = assembly.GetManifestResourceStream(resourceName);
               
                if (stream == null)
                    throw new FileNotFoundException($"Embedded resource '{resourceName}' not found.");

                using var reader = new StreamReader(stream);
                var jsonData = reader.ReadToEnd();
                var equipmentList = JsonSerializer.Deserialize<List<Equipment>>(jsonData);

                //var assemblyPath = Path.GetDirectoryName(typeof(DbInitializer).Assembly.Location);
                //var seedPath = Path.Combine(assemblyPath!, "SeedData", "seedData.json");
                //var jsonData = File.ReadAllText(seedPath);
                //var equipmentList = JsonSerializer.Deserialize<List<Equipment>>(jsonData);

                if (equipmentList != null)
                {
                    dbContext.Equipment.AddRange(equipmentList);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
