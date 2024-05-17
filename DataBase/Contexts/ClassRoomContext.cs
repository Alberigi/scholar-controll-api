using Microsoft.EntityFrameworkCore;
using ClassRoom.Entity;
using System.Text.Json.Serialization;

namespace ClassRoom.Context
{
    public class ClassRoomDbContext : DbContext
    {
        [JsonIgnore]
        public DbSet<ClassRoomEntity> ClassRoom { get; set; }
        private IConfiguration _configuration;

        public ClassRoomDbContext(IConfiguration configuration, DbContextOptions<ClassRoomDbContext> options) : base(options)
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
