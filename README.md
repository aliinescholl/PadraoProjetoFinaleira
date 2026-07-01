# 🏥 HospitalApp
Alunas <br>
ALINE SCHOLL SANTOS - 202410008775 <br>
ANA CLARA MAIBERG - 202410004629<br>
Link vídeo: https://drive.google.com/file/d/12FEwMw6Nqr2kH2AWzWBOPUD5BWKe397y/view?usp=sharing
## 📋 Índice

- [Sobre o Projeto](#-sobre-o-projeto)
- [Tecnologias](#-tecnologias)
- [Design Patterns](#-design-patterns)
- [Estrutura de Pastas](#-estrutura-de-pastas)
- [Como Executar](#-como-executar)
- [Saída Esperada](#-saída-esperada)
- [Princípios SOLID](#-princípios-solid)

---

## 💡 Sobre o Projeto

O **HospitalApp** é uma aplicação console que simula o gerenciamento de um sistema hospitalar, contemplando as entidades **Paciente**, **Médico** e **Consulta**. O objetivo principal é demonstrar, de forma didática, a implementação correta de quatro padrões de projeto clássicos, aplicados em um domínio real.

> Não há interface gráfica nem entrada de dados pelo usuário. Toda a demonstração ocorre no `Program.cs`.

---

## 🛠 Tecnologias

| Tecnologia | Versão |
|---|---|
| Linguagem | C# 12 |
| Plataforma | .NET 10.0 |
| Tipo de Projeto | Console Application |
| Dependências externas | Nenhuma |

---

## 🎯 Design Patterns

### 🔒 Singleton — `BancoDadosHospital`
> Padrão **Criacional**

Garante que apenas **uma instância** do banco de dados em memória exista durante toda a execução do programa. Implementado com `Lazy<T>` para ser **thread-safe** sem o uso de bloqueios manuais (`lock`).

```csharp
// Acesso sempre pela mesma instância
var banco = BancoDadosHospital.Instancia;
```

---

### 🔨 Builder — `ConsultaBuilder`
> Padrão **Criacional**

Permite construir o objeto `Consulta` passo a passo, com uma **API fluente** (method chaining). O objeto só é entregue após chamar `Construir()`, onde as validações obrigatórias são aplicadas.

```csharp
var consulta = new ConsultaBuilder()
    .DefinirPaciente(paciente)
    .DefinirMedico(medico)
    .DefinirDataHora(new DateTime(2025, 8, 15, 9, 30, 0))
    .DefinirEspecialidade("Cardiologia")
    .DefinirObservacoes("Dor no peito ao esforço físico.")
    .Construir();
```

---

### 🎨 Decorator — `DecoradorExames` / `DecoradorRetorno`
> Padrão **Estrutural**

Adiciona funcionalidades extras à consulta **sem modificar** as classes existentes, respeitando o princípio **Open/Closed** do SOLID. Os decoradores se encadeiam em camadas, acumulando detalhes e custos.

```
ConsultaConcreta        → R$ 150,00
  ↓ DecoradorExames     → R$ 350,00  (+Ecocardiograma, Holter 24h)
    ↓ DecoradorRetorno  → R$ 400,00  (+Retorno em 05/09/2025)
```

---

### 👀 Observer — `SujeitoConsulta` + Observadores
> Padrão **Comportamental**

Quando uma consulta é criada, o `SujeitoConsulta` **notifica automaticamente** todos os observadores inscritos. O sujeito não conhece os detalhes de cada observador — total desacoplamento.

| Observador | O que faz |
|---|---|
| `ObservadorNotificacaoPaciente` | Exibe notificação com dados do agendamento para o paciente |
| `ObservadorNotificacaoMedico` | Exibe notificação com dados do novo paciente para o médico |

---

## 📁 Estrutura de Pastas

```
HospitalApp/
│
├── 📂 Models/
│   ├── Paciente.cs                        → Entidade Paciente
│   ├── Medico.cs                          → Entidade Médico
│   └── Consulta.cs                        → Entidade Consulta (produto do Builder)
│
├── 📂 Singleton/
│   └── BancoDadosHospital.cs              → Banco em memória – padrão Singleton
│
├── 📂 Builders/
│   └── ConsultaBuilder.cs                 → Construção fluente – padrão Builder
│
├── 📂 Decorators/
│   ├── IConsulta.cs                       → Interface componente
│   ├── ConsultaConcreta.cs                → Componente concreto base
│   ├── DecoradorConsulta.cs               → Decorador abstrato base
│   ├── DecoradorExames.cs                 → Adiciona exames + custo
│   └── DecoradorRetorno.cs                → Adiciona retorno + custo
│
├── 📂 Observers/
│   ├── IObservador.cs                     → Interface do observador
│   ├── SujeitoConsulta.cs                 → Subject/Publisher
│   ├── ObservadorNotificacaoPaciente.cs   → Notifica o paciente
│   └── ObservadorNotificacaoMedico.cs     → Notifica o médico
│
├── 📄 Program.cs                          → Ponto de entrada e demonstração
├── 📄 HospitalApp.csproj                  → Arquivo de projeto .NET 10
├── 📄 README.md                           → Este arquivo
└── 📄 DesignPatterns.md                   → Documentação dos padrões com diagramas
```

---

## 🚀 Como Executar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) instalado
- Terminal (PowerShell, Bash ou CMD)

### Passos

```bash
# 1. Clone o repositório
git clone https://github.com/seu-usuario/PadraoProjetoFinaleira.git

# 2. Acesse a pasta do projeto
cd PadraoProjetoFinaleira/HospitalApp

# 3. Execute a aplicação
dotnet run
```

---

## 🖥 Saída Esperada

```
══════════════════════════════════════════════════════════════════════
  🏥  HOSPITAL APP — DEMONSTRAÇÃO DE DESIGN PATTERNS
══════════════════════════════════════════════════════════════════════

══════════════════════════════════════════════════════════════════════
  ETAPA 3 ➜ Armazenando no Singleton (BancoDadosHospital)
══════════════════════════════════════════════════════════════════════
  🔑 HashCode da instância do banco: 35342034
  🔑 HashCode da segunda referência:  35342034
  ✅ Mesma instância? True

══════════════════════════════════════════════════════════════════════
  ETAPA 5 ➜ Decorando a Consulta (Decorator)
══════════════════════════════════════════════════════════════════════
  [Sem decorador]         Custo: R$ 150,00
  [Com DecoradorExames]   Custo: R$ 350,00
  [Exames + Retorno]      Custo: R$ 400,00

══════════════════════════════════════════════════════════════════════
  ETAPA 6 ➜ Disparando Notificações (Observer)
══════════════════════════════════════════════════════════════════════
  📢 Disparando notificações para 2 observador(es)...

  📱 [NOTIFICAÇÃO AO PACIENTE]
     Olá, João Pereira! Sua consulta com Dr. Carlos Souza foi agendada.

  📋 [NOTIFICAÇÃO AO MÉDICO]
     Dr. Carlos Souza, uma nova consulta foi agendada.
```

---

## 📐 Princípios SOLID

| Princípio | Aplicação no projeto |
|---|---|
| **S** — Single Responsibility | Cada classe possui uma única responsabilidade bem definida |
| **O** — Open/Closed | Decoradores estendem comportamento sem modificar código existente |
| **L** — Liskov Substitution | Decoradores são substituíveis onde `IConsulta` é esperado |
| **I** — Interface Segregation | `IConsulta` e `IObservador` são interfaces coesas e focadas |
| **D** — Dependency Inversion | Decoradores e Observer dependem de abstrações, não de implementações |

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

<div align="center">
  Desenvolvido para fins didáticos — Demonstração de Design Patterns em C# / .NET 10
</div>
