using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.CategoriaId);

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(50);

            builder.Property(c => c.Icone).IsRequired().HasMaxLength(15);
            
            // 1 Categoria pode ter apenas 1 Tipo, mas 1 Tipo pode ter várias Categorias
            builder.HasOne(c => c.Tipo).WithMany(c => c.Categorias).HasForeignKey(c => c.TipoId).IsRequired();

            // 1 Categoria pode ter vários Ganhos, mas os Ganhos podem ter somente 1 Categoria
            builder.HasMany(c => c.Ganhos).WithOne(c => c.Categoria);
            
            // 1 Categoria pode ter várias Despesas, mas as Despesas podem ter somente 1 Categoria
            builder.HasMany(c => c.Despesas).WithOne(c => c.Categoria);

            builder.ToTable("Categorias");
        }
    }
}
