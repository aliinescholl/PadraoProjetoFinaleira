// ============================================================
// Observers/ObservadorNotificacaoPaciente.cs
//
// PADRÃO: OBSERVER (Comportamental) – Observador Concreto 1
// Notifica o paciente via console quando uma consulta é criada.
// ============================================================

using HospitalApp.Models;

namespace HospitalApp.Observers
{
    /// <summary>
    /// Observador concreto do padrão OBSERVER.
    /// Ao ser notificado, exibe no console uma mensagem informando
    /// que o PACIENTE foi notificado sobre a nova consulta agendada.
    /// </summary>
    public class ObservadorNotificacaoPaciente : IObservador
    {
        // ---------------------------------------------------------
        // OBSERVER: implementa a reação à notificação do sujeito.
        // Totalmente desacoplado do SujeitoConsulta.
        // ---------------------------------------------------------

        /// <summary>
        /// Recebe a notificação do sujeito e informa o paciente.
        /// </summary>
        public void Atualizar(Consulta consulta)
        {
            Console.WriteLine($"\n  📱 [NOTIFICAÇÃO AO PACIENTE]");
            Console.WriteLine($"     Olá, {consulta.Paciente.Nome}!");
            Console.WriteLine($"     Sua consulta com Dr. {consulta.Medico.Nome} foi agendada.");
            Console.WriteLine($"     Especialidade : {consulta.Especialidade}");
            Console.WriteLine($"     Data e Hora   : {consulta.DataHora:dd/MM/yyyy 'às' HH:mm}");
            Console.WriteLine($"     SMS enviado para: {consulta.Paciente.Telefone}");
        }
    }
}
