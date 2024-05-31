using MadunaFZ_Assign1.Models;
using Microsoft.EntityFrameworkCore;

namespace MadunaFZ_Assign1.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            EntityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<EntityDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Events.Any())
            {
                context.Events.AddRange(
                    new Event
                    {
                        EventTitle = "Freshers Ball",
                        EventDescription = "Welcoming all the freshman to the campus !",
                        EventStartDate = new DateTime(2024, 6, 15),
                        EventEndDate = new DateTime(2024, 6, 17),
                        EventLocation = "Kutlwamo Qwaqwa campus",
                        EventMaxAttendees = 500
                    },
                    new Event
                    {
                        EventTitle = "Summer Music Festival",
                        EventDescription = "Outdoor music extravaganza",
                        EventStartDate = new DateTime(2024, 7, 28),
                        EventEndDate = new DateTime(2024, 7, 30),
                        EventLocation = "Mandela Hall",
                        EventMaxAttendees = 15000
                    },
                    new Event
                    {
                        EventTitle = "iTSA ShowCase",
                        EventDescription = "IT Motivational Talk",
                        EventStartDate = new DateTime(2024, 7, 30),
                        EventEndDate = new DateTime(2024, 7, 31),
                        EventLocation = "2011/2022 Big Lab",
                        EventMaxAttendees = 110
                    },
                    new Event
                    {
                        EventTitle = "CSI Research ShowCase",
                        EventDescription = "Postgraduate student presents their project proposals.",
                        EventStartDate = new DateTime(2024, 8, 1),
                        EventLocation = "Online",
                        EventMaxAttendees = 1
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
