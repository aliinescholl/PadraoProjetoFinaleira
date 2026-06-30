// ============================================================
// Decorators/DecoradorRetorno.cs
//
// PADRÃO: DECORATOR (Estrutural) – Decorador Concreto 2
// Adiciona a funcionalidade de "Consulta de Retorno" à consulta
// sem modificar a ConsultaConcreta ou qualquer outro decorador.
// ============================================================

namespace HospitalApp.Decorators
{
    /// <summary>
    /// Decorador concreto que marca a consulta como consulta de retorno.
    /// Adiciona informações de retorno e taxa adicional.
    /// Demonstra o encadeamento de decoradores (pode decorar
    /// uma consulta já decorada pelo DecoradorExames).
    /// </summary>
    public class DecoradorRetorno : DecoradorConsulta
    {
        private readonly DateTime _dataRetorno;

        public DecoradorRetorno(IConsulta consultaDecorada, DateTime dataRetorno)
            : base(consultaDecorada)
        {
            _dataRetorno = dataRetorno;
        }

        // ---------------------------------------------------------
        // DECORATOR: encadeia sobre o decorador anterior (Exames)
        // ou diretamente sobre a ConsultaConcreta.
        // ---------------------------------------------------------

        /// <summary>
        /// Retorna os detalhes acrescidos da informação de retorno.
        /// </summary>
        public override string ObterDetalhes()
        {
            return base.ObterDetalhes() +
                   $"\n  🔄 Retorno agendado para: {_dataRetorno:dd/MM/yyyy}";
        }

        /// <summary>
        /// Acrescenta a taxa de retorno ao custo acumulado.
        /// </summary>
        public override decimal ObterCusto()
        {
            return base.ObterCusto() + 50.00m;
        }
    }
}
