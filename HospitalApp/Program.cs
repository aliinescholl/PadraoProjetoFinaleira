// ============================================================
// Program.cs
// Ponto de entrada da aplicação HospitalApp.
//
// Demonstração completa de todos os Design Patterns:
//   1. SINGLETON  → BancoDadosHospital
//   2. BUILDER    → ConsultaBuilder
//   3. DECORATOR  → DecoradorExames + DecoradorRetorno
//   4. OBSERVER   → SujeitoConsulta + Observadores
// ============================================================

using HospitalApp.Builders;
using HospitalApp.Decorators;
using HospitalApp.Models;
using HospitalApp.Observers;
using HospitalApp.Singleton;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Separador("🏥  HOSPITAL APP — DEMONSTRAÇÃO DE DESIGN PATTERNS");

// ===========================================================
// ETAPA 1 — Criar Médicos
// ===========================================================
Separador("ETAPA 1 ➜ Criando Médicos");

var medico1 = new Medico(1, "Carlos Souza", "CRM-12345/SP", "Cardiologia", "(11) 91234-5678");
var medico2 = new Medico(2, "Ana Lima", "CRM-98765/RJ", "Neurologia", "(21) 99876-5432");

Console.WriteLine(medico1);
Console.WriteLine(medico2);

// ===========================================================
// ETAPA 2 — Criar Pacientes
// ===========================================================
Separador("ETAPA 2 ➜ Criando Pacientes");

var paciente1 = new Paciente(1, "João Pereira", "123.456.789-00",
    new DateTime(1985, 3, 15), "(11) 98765-4321");
var paciente2 = new Paciente(2, "Maria Oliveira", "987.654.321-00",
    new DateTime(1992, 7, 22), "(21) 91234-5678");

Console.WriteLine(paciente1);
Console.WriteLine(paciente2);

// ===========================================================
// ETAPA 3 — Armazenar no SINGLETON (BancoDadosHospital)
// ===========================================================
Separador("ETAPA 3 ➜ Armazenando no Singleton (BancoDadosHospital)");

// PADRÃO SINGLETON: acesso via propriedade estática Instancia.
// Não é possível usar 'new BancoDadosHospital()' — construtor privado.
var banco = BancoDadosHospital.Instancia;

Console.WriteLine($"\n  🔑 HashCode da instância do banco: {banco.GetHashCode()}");

banco.AdicionarMedico(medico1);
banco.AdicionarMedico(medico2);
banco.AdicionarPaciente(paciente1);
banco.AdicionarPaciente(paciente2);

// Prova de que é Singleton (mesma referência)
var banco2 = BancoDadosHospital.Instancia;
Console.WriteLine($"\n  🔑 HashCode da segunda referência:  {banco2.GetHashCode()}");
Console.WriteLine($"  ✅ Mesma instância? {ReferenceEquals(banco, banco2)}");

// ===========================================================
// ETAPA 4 — Criar Consulta com o BUILDER (ConsultaBuilder)
// ===========================================================
Separador("ETAPA 4 ➜ Criando Consulta com ConsultaBuilder (Builder)");

// PADRÃO BUILDER: criação fluente com métodos encadeados.
// O objeto Consulta só é finalizado ao chamar Construir().
var consulta = new ConsultaBuilder()
    .DefinirPaciente(paciente1)
    .DefinirMedico(medico1)
    .DefinirDataHora(new DateTime(2025, 8, 15, 9, 30, 0))
    .DefinirEspecialidade("Cardiologia")
    .DefinirObservacoes("Dor no peito ao esforço físico. Pressão elevada.")
    .Construir();

Console.WriteLine($"\n  {consulta}");

// Salva no banco
banco.AdicionarConsulta(consulta);

// ===========================================================
// ETAPA 5 — Decorar a Consulta (Decorator)
// ===========================================================
Separador("ETAPA 5 ➜ Decorando a Consulta (Decorator)");

// PADRÃO DECORATOR: envolve a ConsultaConcreta sem modificar
// seu código, adicionando funcionalidades em camadas.

// Camada 1: Consulta base
IConsulta consultaDecorada = new ConsultaConcreta(consulta);
Console.WriteLine("\n  [Sem decorador]");
Console.WriteLine($"  Custo: R$ {consultaDecorada.ObterCusto():F2}");
Console.WriteLine($"  Detalhes: {consultaDecorada.ObterDetalhes()}");

// Camada 2: Adiciona exames
consultaDecorada = new DecoradorExames(consultaDecorada, "Ecocardiograma, Holter 24h, Raio-X Tórax");
Console.WriteLine("\n  [Com DecoradorExames]");
Console.WriteLine($"  Custo: R$ {consultaDecorada.ObterCusto():F2}");
Console.WriteLine($"  Detalhes: {consultaDecorada.ObterDetalhes()}");

// Camada 3: Adiciona retorno
consultaDecorada = new DecoradorRetorno(consultaDecorada, new DateTime(2025, 9, 5));
Console.WriteLine("\n  [Com DecoradorExames + DecoradorRetorno]");
Console.WriteLine($"  Custo Total: R$ {consultaDecorada.ObterCusto():F2}");
Console.WriteLine($"  Detalhes: {consultaDecorada.ObterDetalhes()}");

// ===========================================================
// ETAPA 6 — Notificação via Observer
// ===========================================================
Separador("ETAPA 6 ➜ Disparando Notificações (Observer)");

// PADRÃO OBSERVER: SujeitoConsulta gerencia observadores e os
// notifica ao criar uma consulta. Desacoplamento total.

var sujeito = new SujeitoConsulta();

// Inscreve observadores
sujeito.Inscrever(new ObservadorNotificacaoPaciente());
sujeito.Inscrever(new ObservadorNotificacaoMedico());

// Dispara as notificações
sujeito.Notificar(consulta);

// ===========================================================
// ETAPA 7 — Exibir todos os dados do Banco (Singleton)
// ===========================================================
Separador("ETAPA 7 ➜ Dados Armazenados no BancoDadosHospital");

Console.WriteLine($"\n  📋 MÉDICOS CADASTRADOS ({banco.Medicos.Count}):");
foreach (var m in banco.Medicos)
    Console.WriteLine($"     {m}");

Console.WriteLine($"\n  🏥 PACIENTES CADASTRADOS ({banco.Pacientes.Count}):");
foreach (var p in banco.Pacientes)
    Console.WriteLine($"     {p}");

Console.WriteLine($"\n  📅 CONSULTAS AGENDADAS ({banco.Consultas.Count}):");
foreach (var c in banco.Consultas)
    Console.WriteLine($"     {c}");

Separador("✅  DEMONSTRAÇÃO CONCLUÍDA COM SUCESSO");

// ===========================================================
// Método auxiliar de formatação do console
// ===========================================================
static void Separador(string titulo)
{
    Console.WriteLine();
    Console.WriteLine(new string('═', 70));
    Console.WriteLine($"  {titulo}");
    Console.WriteLine(new string('═', 70));
}
