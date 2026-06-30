// ============================================================
// Builders/ConsultaBuilder.cs
//
// PADRÃO: BUILDER (Criacional)
// Separa a construção de um objeto complexo (Consulta) da
// sua representação, permitindo criar objetos passo a passo
// com API fluente (method chaining).
// ============================================================

using HospitalApp.Models;

namespace HospitalApp.Builders
{
    /// <summary>
    /// Construtor fluente de Consulta.
    /// Implementa o padrão BUILDER para montar uma consulta médica
    /// passo a passo, garantindo que todos os campos obrigatórios
    /// sejam preenchidos antes da criação do objeto final.
    /// </summary>
    public class ConsultaBuilder
    {
        // ---------------------------------------------------------
        // Objeto sendo construído internamente.
        // ---------------------------------------------------------
        private readonly Consulta _consulta;

        // Contador estático simples para geração de IDs
        private static int _proximoId = 1;

        /// <summary>
        /// Inicializa o builder criando uma nova Consulta base.
        /// </summary>
        public ConsultaBuilder()
        {
            _consulta = new Consulta
            {
                Id = _proximoId++
            };
        }

        // ---------------------------------------------------------
        // BUILDER: Cada método retorna o próprio builder (this)
        // permitindo o encadeamento de chamadas (fluent interface).
        // ---------------------------------------------------------

        /// <summary>Define o paciente da consulta.</summary>
        public ConsultaBuilder DefinirPaciente(Paciente paciente)
        {
            _consulta.Paciente = paciente;
            return this;
        }

        /// <summary>Define o médico responsável pela consulta.</summary>
        public ConsultaBuilder DefinirMedico(Medico medico)
        {
            _consulta.Medico = medico;
            return this;
        }

        /// <summary>Define a data e hora da consulta.</summary>
        public ConsultaBuilder DefinirDataHora(DateTime dataHora)
        {
            _consulta.DataHora = dataHora;
            return this;
        }

        /// <summary>Define a especialidade médica da consulta.</summary>
        public ConsultaBuilder DefinirEspecialidade(string especialidade)
        {
            _consulta.Especialidade = especialidade;
            return this;
        }

        /// <summary>Define observações clínicas da consulta.</summary>
        public ConsultaBuilder DefinirObservacoes(string observacoes)
        {
            _consulta.Observacoes = observacoes;
            return this;
        }

        /// <summary>
        /// Finaliza a construção e retorna o objeto Consulta.
        /// Valida os campos obrigatórios antes de retornar.
        /// </summary>
        /// <returns>Objeto Consulta completamente configurado.</returns>
        public Consulta Construir()
        {
            // Validações básicas antes de retornar o produto final
            if (_consulta.Paciente is null)
                throw new InvalidOperationException("O paciente é obrigatório para criar uma consulta.");
            if (_consulta.Medico is null)
                throw new InvalidOperationException("O médico é obrigatório para criar uma consulta.");
            if (_consulta.DataHora == default)
                throw new InvalidOperationException("A data/hora é obrigatória para criar uma consulta.");

            return _consulta;
        }
    }
}
