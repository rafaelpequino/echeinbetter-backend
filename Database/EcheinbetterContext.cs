using Echeinbetter.Models;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Echeinbetter.Database
{
    public class EngenhariasSenacContext : DbContext
    {
        public DbSet<Inventory> Inventories { get; set; } = null!;

        private readonly string? connectionString;

        public EngenhariasSenacContext()
        {
            Env.Load();
            connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("CONNECTION_STRING environment variable not found");

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
