using INFANTE_T3.WEB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFANTE_T3.WEB.DB;

public class VeterinariaMapping: IEntityTypeConfiguration<Veterinaria>
{
    public void Configure(EntityTypeBuilder<Veterinaria> builder)
    {
        builder.ToTable("Veter", "dbo");
        builder.HasKey(o => o.Id);
    }
    
}