// ============================================================
// Observers/SujeitoConsulta.cs
//
// PADRÃO: OBSERVER (Comportamental) – Sujeito/Publisher
// Mantém a lista de observadores e os notifica quando
// uma nova consulta é criada no sistema.
// ============================================================

using HospitalApp.Models;

namespace HospitalApp.Observers
{
    /// <summary>
    /// Sujeito (Subject/Publisher) do padrão OBSERVER.
    /// Gerencia os observadores inscritos e dispara notificações
    /// quando uma nova consulta médica é registrada.
    /// </summary>
    public class SujeitoConsulta
    {
        // ---------------------------------------------------------
        // OBSERVER: lista de observadores inscritos.
        // Desacoplados do sujeito – o sujeito não sabe os detalhes
        // de implementação de cada observador.
        // ---------------------------------------------------------
        private readonly List<IObservador> _observadores = new List<IObservador>();

        /// <summary>
        /// Inscreve um novo observador para receber notificações.
        /// </summary>
        public void Inscrever(IObservador observador)
        {
            _observadores.Add(observador);
            Console.WriteLine($"  🔔 Observador '{observador.GetType().Name}' inscrito.");
        }

        /// <summary>
        /// Remove um observador da lista de notificações.
        /// </summary>
        public void Desinscrever(IObservador observador)
        {
            _observadores.Remove(observador);
            Console.WriteLine($"  🔕 Observador '{observador.GetType().Name}' removido.");
        }

        /// <summary>
        /// Notifica todos os observadores inscritos sobre a nova consulta.
        /// </summary>
        /// <param name="consulta">A consulta que foi criada.</param>
        public void Notificar(Consulta consulta)
        {
            Console.WriteLine($"\n  📢 Disparando notificações para {_observadores.Count} observador(es)...");
            foreach (var observador in _observadores)
            {
                observador.Atualizar(consulta);
            }
        }
    }
}
