using Microsoft.EntityFrameworkCore;

namespace Model.Configuration;

public class MyDbContext : DbContext{

    public MyDbContext(DbContextOptions options) : base(options){
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
    }
}