using NotesApplicationApi.Db;
using NotesApplicationApi.Migrations;

namespace NotesApplicationApi
{
    using System.Data.Entity;

    public partial class WeatherContex : DbContext
    {
        public WeatherContex()
            : base("WeatherDB")
        {
            Database.SetInitializer(new Configuration.WeatherDbContextInitializer());
        }

        public virtual DbSet<Weather> Weather { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

    }
}
