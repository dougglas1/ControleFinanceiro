using ControleFinanceiro.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleFinanceiro.DAL.Mapeamentos
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.CPF).IsRequired().HasMaxLength(20);
            builder.HasIndex(u => u.CPF).IsUnique();

            builder.Property(u => u.Profissao).IsRequired().HasMaxLength(30);

            // 1 Usuário pode ter vários Cartões, mas 1 Cartão pode ter somente 1 Usuário
            builder.HasMany(u => u.Cartoes).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.NoAction);

            // 1 Usuário pode ter várias Despesas, mas 1 Despesa pode ter somente 1 Usuário
            builder.HasMany(u => u.Despesas).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.NoAction);

            // 1 Usuário pode ter vários Ganhos, mas 1 Ganho pode ter somente 1 Usuário
            builder.HasMany(u => u.Ganhos).WithOne(u => u.Usuario).OnDelete(DeleteBehavior.NoAction);
            
            builder.ToTable("Usuarios");
        }
    }
}
