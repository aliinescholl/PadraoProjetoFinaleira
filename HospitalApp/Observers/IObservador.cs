// ============================================================
// Observers/IObservador.cs
//
// PADRÃO: OBSERVER (Comportamental)
// Interface que todos os observadores devem implementar.
// Define o contrato de atualização quando o sujeito notifica.
// ============================================================

using HospitalApp.Models;

namespace HospitalApp.Observers
{
    /// <summary>
    /// Interface do Observador no padrão OBSERVER.
    /// Todo observador deve implementar o método Atualizar()
    /// para receber notificações do SujeitoConsulta.
    /// </summary>
    public interface IObservador
    {
        /// <summary>
        /// Chamado pelo sujeito quando uma nova consulta é criada.
        /// </summary>
        /// <param name="consulta">Consulta que originou a notificação.</param>
        void Atualizar(Consulta consulta);
    }
}
