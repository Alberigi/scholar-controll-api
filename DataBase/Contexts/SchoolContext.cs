using Microsoft.EntityFrameworkCore;
using School.Entity;
using System.Text.Json.Serialization;

namespace School.Context
{
    public class SchoolDbContext : DbContext
    {
        [JsonIgnore]
        public DbSet<SchoolEntity> School { get; set; }
        private IConfiguration _configuration;

        public SchoolDbContext(IConfiguration configuration, DbContextOptions<SchoolDbContext> options) : base(options)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration["ConnectionString"];
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
