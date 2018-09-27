using System.Data.Entity;
using NotesApplicationApi.Migrations;

namespace NotesApplicationApi.Db
{
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
