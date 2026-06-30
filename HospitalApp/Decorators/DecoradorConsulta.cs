// ============================================================
// Decorators/DecoradorConsulta.cs
//
// PADRÃO: DECORATOR (Estrutural) – Decorador Abstrato Base
// Classe abstrata que mantém uma referência para o componente
// (IConsulta) e delega as chamadas a ele.
// Todos os decoradores concretos herdam desta classe.
// ============================================================

namespace HospitalApp.Decorators
{
    /// <summary>
    /// Decorador abstrato base do padrão DECORATOR.
    /// Mantém referência ao componente (IConsulta) e delega
    /// as chamadas padrão para ele. As subclasses estendem
    /// o comportamento sem modificar a implementação original.
    /// </summary>
    public abstract class DecoradorConsulta : IConsulta
    {
        // ---------------------------------------------------------
        // DECORATOR: referência ao componente envolvido (wrapped).
        // Pode ser a ConsultaConcreta ou outro decorador,
        // formando uma cadeia de decoradores.
        // ---------------------------------------------------------
        protected readonly IConsulta _consultaDecorada;

        protected DecoradorConsulta(IConsulta consultaDecorada)
        {
            _consultaDecorada = consultaDecorada;
        }

        /// <summary>
        /// Delega para o componente decorado por padrão.
        /// As subclasses devem sobrescrever e adicionar comportamento.
        /// </summary>
        public virtual string ObterDetalhes() => _consultaDecorada.ObterDetalhes();

        /// <summary>
        /// Delega o custo para o componente decorado por padrão.
        /// As subclasses somam seus próprios custos.
        /// </summary>
        public virtual decimal ObterCusto() => _consultaDecorada.ObterCusto();
    }
}
