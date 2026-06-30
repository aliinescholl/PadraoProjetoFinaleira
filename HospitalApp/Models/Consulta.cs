// ============================================================
// Models/Consulta.cs
// Entidade que representa uma Consulta no domínio Hospital.
// Esta classe é o produto final gerado pelo padrão Builder.
// ============================================================

namespace HospitalApp.Models
{
    /// <summary>
    /// Representa uma consulta médica no sistema hospitalar.
    /// É o "produto" criado pelo ConsultaBuilder (padrão Builder).
    /// </summary>
    public class Consulta
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; } = null!;
        public Medico Medico { get; set; } = null!;
        public DateTime DataHora { get; set; }
        public string Especialidade { get; set; } = string.Empty;
        public string Observacoes { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"[Consulta] Id: {Id} | Paciente: {Paciente.Nome} | Médico: Dr. {Medico.Nome} " +
                   $"| Especialidade: {Especialidade} | Data: {DataHora:dd/MM/yyyy HH:mm} " +
                   $"| Obs: {Observacoes}";
        }
    }
}
