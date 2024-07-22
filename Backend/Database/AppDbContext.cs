using Backend.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database;

public class AppDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }

    public DbSet<AddressModel> Addresses { get; set; }  

    public DbSet<CityModel> Cities { get; set; }

    public DbSet<CountryModel> Countries { get; set; }

    public DbSet<LocationModel> Locations { get; set; } 

    public DbSet<DeskModel> Desks { get; set; } 

    public DbSet<MenuCardItemModel> MenuCardItems { get; set; }

    public DbSet<MenuCardModel> MenuCards { get; set; }

    public DbSet<RestaurentCategoryModel> RestaurentCategories { get; set; }

    public DbSet<RestaurentModel> Restaurents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        CreateSqliteDb(optionsBuilder);
    }

    protected virtual void CreateSqliteDb(DbContextOptionsBuilder builder)
    {
        string connectionString = new SqliteConnectionStringBuilder()
        {
            Mode = SqliteOpenMode.ReadWriteCreate,
            DataSource = "menuServedDb"
        }.ToString();

        builder.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
