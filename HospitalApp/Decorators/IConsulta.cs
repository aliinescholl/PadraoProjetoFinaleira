// ============================================================
// Decorators/IConsulta.cs
//
// PADRÃO: DECORATOR (Estrutural)
// Interface componente que define o contrato de uma consulta
// decorável. Todos os decoradores e a implementação concreta
// devem implementar esta interface.
// ============================================================

namespace HospitalApp.Decorators
{
    /// <summary>
    /// Interface base do padrão DECORATOR para consultas médicas.
    /// Define o contrato que tanto a implementação concreta quanto
    /// os decoradores devem seguir.
    /// </summary>
    public interface IConsulta
    {
        /// <summary>
        /// Retorna os detalhes completos da consulta,
        /// incluindo todos os recursos adicionados pelos decoradores.
        /// </summary>
        string ObterDetalhes();

        /// <summary>
        /// Retorna o custo total da consulta,
        /// acumulando os valores adicionados pelos decoradores.
        /// </summary>
        decimal ObterCusto();
    }
}
