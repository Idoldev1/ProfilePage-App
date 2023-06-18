using System;
using Microsoft.EntityFrameworkCore;

namespace ProfileManagement.Models;


public static class SeedData
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProfileDetails>().HasData(
            new ProfileDetails
            {
                Id = 1,
                Name = "Mark",
                Department = Dept.IT,
                Email = "mark@gmail.com",
                Skills = "Writing",
                Experience = "1 year",
                Projects = "Teens book"
            },

            new ProfileDetails
            {
                Id = 2,
                Name = "John",
                Department = Dept.HR,
                Email = "john@gmail.com",
                Skills = "Singing",
                Experience = "2 years",
                Projects = "Album"
            },
            new ProfileDetails
            {
                Id = 3,
                Name = "Chloe",
                Department = Dept.Sales,
                Email = "chloe@gmail.com",
                Skills = "Web Design",
                Experience = "2 years",
                Projects = "Ecommerce App"
            }
        );
    }
}