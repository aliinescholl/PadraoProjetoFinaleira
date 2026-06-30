# 🏥 HospitalApp

Sistema hospitalar em memória desenvolvido como **Console Application em C# (.NET 8)**, com o objetivo de demonstrar boas práticas de programação orientada a objetos e a correta aplicação de quatro Design Patterns clássicos do catálogo **Gang of Four (GoF)**.

---

## 🛠 Tecnologias Utilizadas

| Tecnologia | Versão |
|---|---|
| C# | 12 |
| .NET | 8.0 |
| IDE recomendada | Visual Studio 2022 / VS Code |

Sem dependências externas. Apenas bibliotecas padrão do .NET.

---

## 📁 Estrutura de Pastas

```
HospitalApp/
│
├── Models/
│   ├── Paciente.cs             → Entidade Paciente
│   ├── Medico.cs               → Entidade Médico
│   └── Consulta.cs             → Entidade Consulta (produto do Builder)
│
├── Singleton/
│   └── BancoDadosHospital.cs   → Banco em memória (padrão Singleton)
│
├── Builders/
│   └── ConsultaBuilder.cs      → Construção fluente de Consulta (padrão Builder)
│
├── Decorators/
│   ├── IConsulta.cs            → Interface componente
│   ├── ConsultaConcreta.cs     → Componente concreto base
│   ├── DecoradorConsulta.cs    → Decorador abstrato base
│   ├── DecoradorExames.cs      → Adiciona exames à consulta
│   └── DecoradorRetorno.cs     → Adiciona retorno à consulta
│
├── Observers/
│   ├── IObservador.cs                      → Interface do observador
│   ├── SujeitoConsulta.cs                  → Sujeito/Publisher
│   ├── ObservadorNotificacaoPaciente.cs    → Notifica o paciente
│   └── ObservadorNotificacaoMedico.cs      → Notifica o médico
│
├── Program.cs                  → Ponto de entrada e demonstração
└── HospitalApp.csproj          → Arquivo de projeto .NET 8
```

---

## 🎯 Design Patterns Aplicados

### 1. 🔒 Singleton (Criacional)
**Classe:** `BancoDadosHospital`

Garante que apenas **uma instância** do banco de dados em memória exista durante toda a execução. Utiliza `Lazy<T>` para implementação **thread-safe** sem necessidade de bloqueios manuais.

### 2. 🔨 Builder (Criacional)
**Classe:** `ConsultaBuilder`

Permite criar objetos `Consulta` complexos **passo a passo** com uma API fluente (method chaining). Cada método retorna o próprio builder, finalizando com `Construir()` que valida e retorna o objeto pronto.

### 3. 🎨 Decorator (Estrutural)
**Classes:** `ConsultaConcreta`, `DecoradorExames`, `DecoradorRetorno`

Adiciona funcionalidades extras à consulta **sem modificar** as classes existentes (princípio Open/Closed). Os decoradores se encadeiam em camadas: `ConsultaConcreta → DecoradorExames → DecoradorRetorno`.

### 4. 👀 Observer (Comportamental)
**Classes:** `SujeitoConsulta`, `ObservadorNotificacaoPaciente`, `ObservadorNotificacaoMedico`

Quando uma consulta é criada, o `SujeitoConsulta` **notifica automaticamente** todos os observadores inscritos. Demonstra desacoplamento total entre quem produz o evento e quem reage a ele.

---

## 🚀 Instruções de Execução

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado
- Terminal (PowerShell, Bash ou CMD)

### Passos

```bash
# 1. Acesse a pasta do projeto
cd c:\www\PadraoProjetoFinaleira\HospitalApp

# 2. Restaure as dependências (se necessário)
dotnet restore

# 3. Compile o projeto
dotnet build

# 4. Execute a aplicação
dotnet run
```

### Saída esperada no console

```
══════════════════════════════════════════════════════════════════════
  🏥  HOSPITAL APP — DEMONSTRAÇÃO DE DESIGN PATTERNS
══════════════════════════════════════════════════════════════════════

══════════════════════════════════════════════════════════════════════
  ETAPA 1 ➜ Criando Médicos
══════════════════════════════════════════════════════════════════════
[Médico]   Id: 1 | Nome: Carlos Souza | CRM: CRM-12345/SP | ...
...

ETAPA 3 ➜ Armazenando no Singleton (BancoDadosHospital)
  🔑 HashCode da instância do banco: 58225482
  🔑 HashCode da segunda referência:  58225482
  ✅ Mesma instância? True
...

ETAPA 6 ➜ Disparando Notificações (Observer)
  📱 [NOTIFICAÇÃO AO PACIENTE]
     Olá, João Pereira! Sua consulta com Dr. Carlos Souza foi agendada.
...
```

---

## 📐 Princípios SOLID Aplicados

| Princípio | Como foi aplicado |
|---|---|
| **S** – Single Responsibility | Cada classe tem uma única responsabilidade (Models, Builder, Decorators, Observers) |
| **O** – Open/Closed | Decoradores estendem comportamento sem modificar código existente |
| **L** – Liskov Substitution | Decoradores substituem `IConsulta` sem quebrar o contrato |
| **I** – Interface Segregation | `IConsulta` e `IObservador` são interfaces coesas e focadas |
| **D** – Dependency Inversion | Decoradores e Observer dependem de abstrações, não de implementações concretas |

---

*Projeto desenvolvido para fins didáticos — demonstração de Design Patterns em C#/.NET 8.*
