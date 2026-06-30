// ============================================================
// Observers/ObservadorNotificacaoMedico.cs
//
// PADRÃO: OBSERVER (Comportamental) – Observador Concreto 2
// Notifica o médico via console quando uma nova consulta é
// atribuída a ele. Demonstra múltiplos observadores no sistema.
// ============================================================

using HospitalApp.Models;

namespace HospitalApp.Observers
{
    /// <summary>
    /// Observador concreto do padrão OBSERVER.
    /// Ao ser notificado, exibe no console uma mensagem informando
    /// que o MÉDICO foi notificado sobre a nova consulta em sua agenda.
    /// </summary>
    public class ObservadorNotificacaoMedico : IObservador
    {
        // ---------------------------------------------------------
        // OBSERVER: segundo observador concreto.
        // Demonstra como múltiplos observadores podem reagir ao
        // mesmo evento de forma independente e desacoplada.
        // ---------------------------------------------------------

        /// <summary>
        /// Recebe a notificação do sujeito e informa o médico.
        /// </summary>
        public void Atualizar(Consulta consulta)
        {
            Console.WriteLine($"\n  📋 [NOTIFICAÇÃO AO MÉDICO]");
            Console.WriteLine($"     Dr. {consulta.Medico.Nome}, uma nova consulta foi agendada.");
            Console.WriteLine($"     Paciente      : {consulta.Paciente.Nome}");
            Console.WriteLine($"     Especialidade : {consulta.Especialidade}");
            Console.WriteLine($"     Data e Hora   : {consulta.DataHora:dd/MM/yyyy 'às' HH:mm}");
            Console.WriteLine($"     CRM           : {consulta.Medico.Crm}");
        }
    }
}
