// ============================================================
// Decorators/DecoradorExames.cs
//
// PADRÃO: DECORATOR (Estrutural) – Decorador Concreto 1
// Adiciona a funcionalidade de "Exames Adicionais" à consulta
// sem modificar a ConsultaConcreta ou qualquer outro decorador.
// ============================================================

namespace HospitalApp.Decorators
{
    /// <summary>
    /// Decorador concreto que adiciona exames à consulta.
    /// Estende o comportamento da consulta decorada adicionando
    /// informações sobre exames solicitados e custo adicional.
    /// Não modifica nenhuma classe existente (OCP do SOLID).
    /// </summary>
    public class DecoradorExames : DecoradorConsulta
    {
        private readonly string _tiposExames;

        public DecoradorExames(IConsulta consultaDecorada, string tiposExames)
            : base(consultaDecorada)
        {
            _tiposExames = tiposExames;
        }

        // ---------------------------------------------------------
        // DECORATOR: sobrescreve e ESTENDE o comportamento original.
        // Chama o componente decorado e adiciona nova informação.
        // ---------------------------------------------------------

        /// <summary>
        /// Retorna os detalhes da consulta acrescidos de informações
        /// sobre os exames adicionais solicitados.
        /// </summary>
        public override string ObterDetalhes()
        {
            return base.ObterDetalhes() + $"\n  ➕ Exames Adicionais: {_tiposExames}";
        }

        /// <summary>
        /// Acrescenta o custo dos exames ao custo base da consulta.
        /// </summary>
        public override decimal ObterCusto()
        {
            return base.ObterCusto() + 200.00m;
        }
    }
}
