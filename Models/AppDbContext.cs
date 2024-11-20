using Microsoft.EntityFrameworkCore;

namespace Project.Models;

public class AppDbContext:DbContext
{
    public DbSet<ContactEntity> Contacts
    {
        get;
        set;
    }
    private string DbPath { get; set; }
    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactModel>().HasData(
            new ContactEntity()
            {
                Id = 1,
                FirstName = "Jakub",
                LastName = "Kowalski",
                PhoneNumber = "123456789",
                BirthDate = new DateTime(2000, 10, 10),
                Email = "jakub@wsei.edu.pl",
                Created = DateTime.Now,
            },
            new ContactEntity()
            {
                Id = 2,
                FirstName = "Karol",
                LastName = "Kowalski",
                PhoneNumber = "132556789",
                BirthDate = new DateTime(1990, 11, 15),
                Email = "karol@wsei.edu.pl",
                Created = DateTime.Now,
            }
        );
    }
}