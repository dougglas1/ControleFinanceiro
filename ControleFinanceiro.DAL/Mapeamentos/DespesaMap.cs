using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class DespesaMap : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.HasKey(d => d.DespesaId);

            builder.Property(d => d.Descricao).IsRequired().HasMaxLength(50);

            builder.Property(d => d.Valor).IsRequired();

            builder.Property(d => d.Dia).IsRequired();

            builder.Property(d => d.Ano).IsRequired();

            // 1 Despesa pode ter somente 1 Cartão, mas 1 Cartão pode ter várias Despesas
            builder.HasOne(d => d.Cartao).WithMany(d => d.Despesas).HasForeignKey(d => d.CartaoId).IsRequired();

            // 1 Despesa pode ter somente 1 Categoria, mas 1 Categoria pode ter várias Despesas
            builder.HasOne(d => d.Categoria).WithMany(d => d.Despesas).HasForeignKey(d => d.CategoriaId).IsRequired();

            // 1 Despesa pode ter somente 1 Mês, mas 1 Mês pode ter várias Despesas
            builder.HasOne(d => d.Mes).WithMany(d => d.Despesas).HasForeignKey(d => d.MesId).IsRequired();

            // 1 Despesa pode ter somente 1 Usuário, mas 1 Usuário pode ter várias Despesas
            builder.HasOne(d => d.Usuario).WithMany(d => d.Despesas).HasForeignKey(d => d.UsuarioId).IsRequired();
            
            builder.ToTable("Despesas");
        }
    }
}
