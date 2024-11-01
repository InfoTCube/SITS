using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : DbContext
{
    protected DataContext() {}
    public DataContext(DbContextOptions options) : base(options) {}

    public DbSet<Item> Items { get; set; }
}