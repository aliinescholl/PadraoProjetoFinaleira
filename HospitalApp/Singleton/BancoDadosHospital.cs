// ============================================================
// Singleton/BancoDadosHospital.cs
//
// PADRÃO: SINGLETON (Criacional)
// Garante que apenas UMA instância de BancoDadosHospital
// exista durante toda a execução do programa.
// Utiliza Lazy<T> para implementação thread-safe sem locks.
// ============================================================

using HospitalApp.Models;

namespace HospitalApp.Singleton
{
    /// <summary>
    /// Banco de dados em memória do Hospital.
    /// Implementa o padrão SINGLETON para garantir instância única
    /// e acesso global de forma thread-safe usando Lazy&lt;T&gt;.
    /// </summary>
    public sealed class BancoDadosHospital
    {
        // ---------------------------------------------------------
        // SINGLETON: instância única criada de forma lazy e thread-safe.
        // Lazy<T> garante inicialização apenas quando acessada pela
        // primeira vez e é naturalmente thread-safe.
        // ---------------------------------------------------------
        private static readonly Lazy<BancoDadosHospital> _instancia =
            new Lazy<BancoDadosHospital>(() => new BancoDadosHospital());

        /// <summary>
        /// Ponto de acesso global à instância única.
        /// </summary>
        public static BancoDadosHospital Instancia => _instancia.Value;

        // ---------------------------------------------------------
        // Construtor privado impede instanciação externa.
        // ---------------------------------------------------------
        private BancoDadosHospital()
        {
            Pacientes = new List<Paciente>();
            Medicos = new List<Medico>();
            Consultas = new List<Consulta>();
        }

        // ---------------------------------------------------------
        // Coleções em memória
        // ---------------------------------------------------------
        public List<Paciente> Pacientes { get; private set; }
        public List<Medico> Medicos { get; private set; }
        public List<Consulta> Consultas { get; private set; }

        // ---------------------------------------------------------
        // Métodos de acesso às coleções
        // ---------------------------------------------------------

        public void AdicionarPaciente(Paciente paciente)
        {
            Pacientes.Add(paciente);
            Console.WriteLine($"  ✔ Paciente '{paciente.Nome}' cadastrado no banco de dados.");
        }

        public void AdicionarMedico(Medico medico)
        {
            Medicos.Add(medico);
            Console.WriteLine($"  ✔ Médico 'Dr. {medico.Nome}' cadastrado no banco de dados.");
        }

        public void AdicionarConsulta(Consulta consulta)
        {
            Consultas.Add(consulta);
            Console.WriteLine($"  ✔ Consulta (Id: {consulta.Id}) registrada no banco de dados.");
        }

        public Paciente? BuscarPacientePorId(int id)
            => Pacientes.FirstOrDefault(p => p.Id == id);

        public Medico? BuscarMedicoPorId(int id)
            => Medicos.FirstOrDefault(m => m.Id == id);
    }
}
