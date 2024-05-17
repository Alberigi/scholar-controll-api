using Microsoft.EntityFrameworkCore;
using Student.Entity;
using System.Text.Json.Serialization;

namespace Student.Context
{
    public class StudentDbContext : DbContext
    {
        [JsonIgnore]
        public DbSet<StudentEntity> Student { get; set; }
        private IConfiguration _configuration;

        public StudentDbContext(IConfiguration configuration, DbContextOptions<StudentDbContext> options) : base(options)
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
