using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SurveyApp.Data;
using SurveyApp.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SurveyApp.Analysis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddEnvironmentVariables()
              .AddCommandLine(args)
              .Build();


            DbContextOptions<SurveyContext> options;
            var builder = new DbContextOptionsBuilder<SurveyContext>();
            builder.UseMySQL(Configuration["ConnectionStrings:SurveyDatabase"]);
            options = builder.Options;

            var dbContext = new SurveyContext(options);

            var pass = "the quick brown fox";
           
            CreatePasswordHash(pass,out var hash,out var salt);
            var password = new PasswordEntity()
            {
                PasswordHash = hash,
                PasswordSalt = salt
            };

            //dbContext.Password.Add(password);
            //dbContext.SaveChanges();

            //var maps = dbContext.GroupTextMapping
            //     .Include(map=> map.TextEntry)
            //     .Include(map=> map.Group)
            //     .Include(map=> map.Survey)
            //     .Where(map =>map.IsDeleted==false)
            //     .ToList();

            //int[,] results = new int[21, 21];

            //foreach (var map in maps)
            //{
            //    foreach (var map2 in maps)
            //    {
            //        if (map.TextEntry.TextId != map2.TextEntry.TextId)
            //        {
            //            if (map.Group.GroupId == map2.Group.GroupId)
            //            {
            //                results[map.TextEntry.TextId, map2.TextEntry.TextId] += 1;
            //            }
            //        }
            //    }
            //}

            //File.WriteAllLines(@"../../../data.csv", ToCsv(results));
        }

        private static IEnumerable<String> ToCsv<T>(T[,] data, string separator = ",")
        {
            for (int i = 1; i < data.GetLength(0); ++i)
                yield return string.Join(separator, Enumerable
                  .Range(1, data.GetLength(1) -1)
                  .Select(j => data[i, j]));
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
