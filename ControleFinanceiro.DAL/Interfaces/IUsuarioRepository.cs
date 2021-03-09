using ControleFinanceiro.BLL.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IUsuarioRepository : IRepositoryGeneric<Usuario>
    {
        Task<int> BuscarQuantidadeUsuariosRegistrados();

        Task<IdentityResult> CriarUsuario(Usuario usuario, string senha);

        Task IncluirUsuarioEmFuncao(Usuario usuario, string funcao);

        Task LogarUsuario(Usuario usuario, bool lembrar);
        
        Task<Usuario> BuscarUsuarioPorEmail(string email);
        
        Task<IList<string>> BuscarFuncoesUsuario(Usuario usuario);

        Task AtualizarUsuario(Usuario usuario);
    }
}
