using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Project.Models;



public class AppDbContext: IdentityDbContext<IdentityUser>
{
    public DbSet<ContactEntity> Contacts {
        get;
        set;
    }

    public DbSet<OrganizationEntity> Organizations { get; set; }
    
    
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
        base.OnModelCreating(modelBuilder);
        
        string  ADMIN_ID = Guid.NewGuid().ToString();
        string USER_ID = Guid.NewGuid().ToString();
        
        modelBuilder.Entity<OrganizationEntity>()
            .OwnsOne(o => o.Address)
            .HasData(
                new { OrganizationEntityId = 1, City ="Kraków", Street ="św Filipa"},
                new { OrganizationEntityId = 2, City ="Jędrzejów", Street ="Partyzantow"}
            );

        modelBuilder.Entity<ContactEntity>()
            .HasOne<OrganizationEntity>(c => c.Organization)
            .WithMany(o => o.Contacts)
            .HasForeignKey(c => c.OrganizationId);

        modelBuilder.Entity<OrganizationEntity>()
            .HasData(
                new OrganizationEntity()
                {
                    Id = 1,
                    Regon = "22223333",
                    Nip = "123123123",
                    Name = "WSEI"
                },
                new OrganizationEntity()
                {
                    Id = 2,
                    Regon = "4443331",
                    Nip = "1212121",
                    Name = "Webcon"
                }
            );
        
        modelBuilder.Entity<ContactEntity>()
            .HasData(
                new ContactEntity()
                {
                    Id = 1,
                    FirstName = "Marian",
                    LastName = "Kowalski",
                    BirthDate = new(2000, 10, 10),
                    PhoneNumber = "333 333 333",
                    Email = "mariankowalski@.wsei.edu.pl",
                    Created = DateTime.Now,
                    OrganizationId = 1
                },
                new ContactEntity()
                {
                    Id = 2,
                    FirstName = "Jakub",
                    LastName = "Nowak",
                    BirthDate = new(2000, 11, 10),
                    PhoneNumber = "111 111 111",
                    Email = "jn@wsei.edu.pl",
                    Created = DateTime.Now,
                    OrganizationId = 2
                }
            );
    }
}