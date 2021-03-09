using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class GanhoMap : IEntityTypeConfiguration<Ganho>
    {
        public void Configure(EntityTypeBuilder<Ganho> builder)
        {
            builder.HasKey(d => d.GanhoId);

            builder.Property(d => d.Descricao).IsRequired().HasMaxLength(50);

            builder.Property(d => d.Valor).IsRequired();

            builder.Property(d => d.Dia).IsRequired();

            builder.Property(d => d.Ano).IsRequired();

            // 1 Ganho pode ter somente 1 Categoria, mas 1 Categoria pode ter vários Ganhos
            builder.HasOne(d => d.Categoria).WithMany(d => d.Ganhos).HasForeignKey(d => d.CategoriaId).IsRequired();

            // 1 Ganho pode ter somente 1 Mês, mas 1 Mês pode ter vários Ganhos
            builder.HasOne(d => d.Mes).WithMany(d => d.Ganhos).HasForeignKey(d => d.MesId).IsRequired();

            // 1 Ganho pode ter somente 1 Usuário, mas 1 Usuário pode ter vários Ganhos
            builder.HasOne(d => d.Usuario).WithMany(d => d.Ganhos).HasForeignKey(d => d.UsuarioId).IsRequired();
            
            builder.ToTable("Ganhos");
        }
    }
}
