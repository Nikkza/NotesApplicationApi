using NotesApplicationApi.Db;
using System;
using System.Data.Entity;

namespace NotesApplicationApi.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<NotesApplicationApi.WeatherContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        public class WeatherDbContextInitializer : DropCreateDatabaseAlways<WeatherContex>
        {
            protected override void Seed(WeatherContex context)
            {
                context.Weather.Add(new Weather() { Date = DateTime.Now.AddDays(4), Notes = "I am a note..." });
                context.Weather.Add(new Weather() { Date = DateTime.Now.AddDays(3), Notes = "I Love to be a note..." });
                context.Weather.Add(new Weather() { Date = DateTime.Now, Notes = "I am the last note..." });

                base.Seed(context);
            }
        }
    }
}
