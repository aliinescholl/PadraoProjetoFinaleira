// ============================================================
// Decorators/ConsultaConcreta.cs
//
// PADRÃO: DECORATOR (Estrutural) – Componente Concreto
// Implementação base da interface IConsulta.
// Representa a consulta simples, sem recursos adicionais.
// Os decoradores envolvem esta classe sem modificá-la.
// ============================================================

using HospitalApp.Models;

namespace HospitalApp.Decorators
{
    /// <summary>
    /// Componente concreto do padrão DECORATOR.
    /// Representa a consulta médica básica, sem adicionais.
    /// Os decoradores adicionam funcionalidades em cima desta classe
    /// sem alterar seu código (princípio Open/Closed – OCP do SOLID).
    /// </summary>
    public class ConsultaConcreta : IConsulta
    {
        private readonly Consulta _consulta;

        public ConsultaConcreta(Consulta consulta)
        {
            _consulta = consulta;
        }

        /// <summary>
        /// Retorna os detalhes básicos da consulta sem nenhum adicional.
        /// </summary>
        public string ObterDetalhes()
        {
            return $"Consulta Básica | Paciente: {_consulta.Paciente.Nome} " +
                   $"| Médico: Dr. {_consulta.Medico.Nome} " +
                   $"| Especialidade: {_consulta.Especialidade} " +
                   $"| Data: {_consulta.DataHora:dd/MM/yyyy HH:mm} " +
                   $"| Obs: {_consulta.Observacoes}";
        }

        /// <summary>
        /// Custo base da consulta simples.
        /// </summary>
        public decimal ObterCusto() => 150.00m;
    }
}
