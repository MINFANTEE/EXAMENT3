//using INFANTE_T3.WEB.DB.Mapping;
using INFANTE_T3.WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace INFANTE_T3.WEB.DB;

public class DBEntities: DbContext
{
    
    public virtual DbSet<Veterinaria> Veterinarias { get; set; }

    public DBEntities()
    {
        
    }
    public DBEntities(DbContextOptions<DBEntities> options): base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new VeterinariaMapping() );
        
    }
    
    
}