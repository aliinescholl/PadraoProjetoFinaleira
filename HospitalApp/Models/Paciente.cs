// ============================================================
// Models/Paciente.cs
// Entidade que representa um Paciente no domínio Hospital.
// Responsabilidade única: armazenar dados do paciente (SRP).
// ============================================================

namespace HospitalApp.Models
{
    /// <summary>
    /// Representa um paciente cadastrado no sistema hospitalar.
    /// </summary>
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }

        public Paciente(int id, string nome, string cpf, DateTime dataNascimento, string telefone)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Telefone = telefone;
        }

        public override string ToString()
        {
            return $"[Paciente] Id: {Id} | Nome: {Nome} | CPF: {Cpf} | Nascimento: {DataNascimento:dd/MM/yyyy} | Telefone: {Telefone}";
        }
    }
}
