namespace ControleFinanceiro.DAL.Interfaces
{
    public interface IGraficoRepository
    {
        object BuscarGanhosAnuaisPorUsuarioId(string usuarioId, int ano);

        object BuscarDespesasAnuaisPorUsuarioId(string usuarioId, int ano);
    }
}
