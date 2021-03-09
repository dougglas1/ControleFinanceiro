using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class CartaoMap : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.HasKey(c => c.CartaoId);

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.Nome).IsUnique();

            builder.Property(c => c.Bandeira).IsRequired().HasMaxLength(15);

            builder.Property(c => c.Numero).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.Numero).IsUnique();

            builder.Property(c => c.Limite).IsRequired();

            // 1 Cartão pertence somente a 1 Usuário, mas o Usuário pode ter mais de 1 Cartão
            builder.HasOne(c => c.Usuario).WithMany(c => c.Cartoes).HasForeignKey(c => c.UsuarioId).IsRequired().OnDelete(DeleteBehavior.NoAction);
            
            // 1 Cartão pode ter várias Despesas, mas a Depesa somente pode ter 1 Cartão
            builder.HasMany(c => c.Despesas).WithOne(c => c.Cartao);
            
            builder.ToTable("Cartoes");
        }
    }
}
