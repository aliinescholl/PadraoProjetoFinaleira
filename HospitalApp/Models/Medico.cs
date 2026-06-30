// ============================================================
// Models/Medico.cs
// Entidade que representa um Médico no domínio Hospital.
// Responsabilidade única: armazenar dados do médico (SRP).
// ============================================================

namespace HospitalApp.Models
{
    /// <summary>
    /// Representa um médico cadastrado no sistema hospitalar.
    /// </summary>
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Crm { get; set; }
        public string Especialidade { get; set; }
        public string Telefone { get; set; }

        public Medico(int id, string nome, string crm, string especialidade, string telefone)
        {
            Id = id;
            Nome = nome;
            Crm = crm;
            Especialidade = especialidade;
            Telefone = telefone;
        }

        public override string ToString()
        {
            return $"[Médico]   Id: {Id} | Nome: {Nome} | CRM: {Crm} | Especialidade: {Especialidade} | Telefone: {Telefone}";
        }
    }
}
