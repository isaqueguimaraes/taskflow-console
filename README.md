# ✅ TaskFlow

Gerenciador de tarefas (To-Do List) via console, em **C# / .NET 10**, com **testes unitários em xUnit** e histórico de commits seguindo o padrão **Conventional Commits**.

Projeto desenvolvido para a disciplina **Garantia da Qualidade de Software** (Gestão e Qualidade de Software, Ânima Educação), com foco em qualidade de código, testes automatizados e versionamento organizado.

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![xUnit](https://img.shields.io/badge/tests-xUnit-5E2D91)
![Conventional Commits](https://img.shields.io/badge/commits-conventional-FE5196?logo=conventionalcommits&logoColor=white)

---

## 📑 Sumário

- [Visão geral](#-visão-geral)
- [Requisitos técnicos](#-requisitos-técnicos)
- [Estrutura do projeto](#-estrutura-do-projeto)
- [Funcionalidades](#-funcionalidades)
- [Como clonar e compilar](#-como-clonar-e-compilar)
- [Como executar a aplicação](#-como-executar-a-aplicação)
- [Como executar os testes unitários](#-como-executar-os-testes-unitários)
- [Cobertura dos testes](#-cobertura-dos-testes)
- [Histórico de commits](#-histórico-de-commits)
- [Tecnologias utilizadas](#-tecnologias-utilizadas)
- [Contribuidores](#-contribuidores)

---

## 📖 Visão geral

O **TaskFlow** é uma aplicação de console que permite gerenciar uma lista de tarefas em memória: adicionar, listar e concluir tarefas por meio de um menu interativo.

A lógica está organizada em três partes:

| Componente | Responsabilidade |
|------------|------------------|
| `TaskItem` | Entidade de domínio que representa uma tarefa (`Id`, `Title`, `IsCompleted`) e a lógica para concluí-la. |
| `TaskManager` | Serviço que gerencia a lista de tarefas em memória (adicionar, buscar por ID e concluir). |
| `Program.cs` | Interface de console com menu interativo em loop. |

---

## 🛠 Requisitos técnicos

- **[.NET SDK 10.0](https://dotnet.microsoft.com/download)** (ou superior)
- **[Git](https://git-scm.com/downloads)**
- Terminal (PowerShell, CMD, Bash, Zsh etc.)
- IDE opcional: Visual Studio 2022+, VS Code (com extensão C# Dev Kit) ou JetBrains Rider

Para verificar a versão do .NET instalada:

```bash
dotnet --version
```

---

## 📂 Estrutura do projeto

```text
taskflow-console/
├── TaskFlow.sln
├── TaskFlow.Console/
│   ├── TaskFlow.Console.csproj
│   ├── Program.cs
│   ├── TaskItem.cs
│   └── TaskManager.cs
├── TaskFlow.Tests/
│   ├── TaskFlow.Tests.csproj
│   └── TaskManagerTests.cs
├── .gitignore
└── README.md
```

- **`TaskFlow.Console`**: projeto de console (`net10.0`) com o domínio, o serviço e o menu interativo.
- **`TaskFlow.Tests`**: projeto de testes xUnit (`net10.0`) que referencia o projeto `TaskFlow.Console`.

---

## 💼 Funcionalidades

### `TaskItem`

Entidade de domínio com as seguintes propriedades:

| Propriedade | Tipo | Descrição |
|-------------|------|-----------|
| `Id` | `Guid` | Identificador único gerado automaticamente. |
| `Title` | `string` | Título da tarefa (espaços nas extremidades são removidos). |
| `IsCompleted` | `bool` | Indica se a tarefa foi concluída (inicia como `false`). |

- O construtor lança `ArgumentException` se o título for **nulo, vazio ou composto apenas por espaços**.
- O método `Complete()` marca a tarefa como concluída.

### `TaskManager`

| Membro | Descrição |
|--------|-----------|
| `Tasks` | Coleção somente leitura com todas as tarefas cadastradas. |
| `AddTask(string title)` | Cria e adiciona uma nova tarefa. Lança `ArgumentException` se o título for inválido. |
| `GetById(Guid id)` | Retorna a tarefa correspondente ao ID ou `null` caso ela não exista (sem lançar exceção). |
| `CompleteTask(Guid id)` | Conclui a tarefa e retorna `true`; retorna `false` se o ID não existir. |

### Menu interativo (`Program.cs`)

Ao executar a aplicação, um menu em loop permite ao usuário adicionar, listar e concluir tarefas, além de encerrar o programa.

---

## 🚀 Como clonar e compilar

### 1. Clonar o repositório

```bash
git clone https://github.com/isaqueguimaraes/taskflow-console.git
```

### 2. Acessar a pasta do projeto

```bash
cd taskflow-console
```

### 3. Restaurar as dependências

```bash
dotnet restore
```

### 4. Compilar a solução

```bash
dotnet build
```

Se tudo estiver correto, a saída final indicará **Build succeeded** (compilação bem-sucedida), com 0 erros.

---

## ▶️ Como executar a aplicação

Na raiz do repositório, execute:

```bash
dotnet run --project TaskFlow.Console
```

O menu interativo será exibido no terminal, e você poderá gerenciar suas tarefas seguindo as opções apresentadas.

---

## ✅ Como executar os testes unitários

Na raiz do repositório (onde está o arquivo `TaskFlow.sln`), execute:

```bash
dotnet test
```

Para uma saída mais detalhada, com o nome de cada teste executado:

```bash
dotnet test --logger "console;verbosity=detailed"
```

Para executar apenas o projeto de testes:

```bash
dotnet test TaskFlow.Tests/TaskFlow.Tests.csproj
```

Ao final da execução, todos os testes devem ser aprovados, com uma saída semelhante a:

```text
Aprovado!  – Com falha: 0, Aprovado: 3, Ignorado: 0, Total: 3
```

---

## 🧪 Cobertura dos testes

Os testes estão na classe `TaskManagerTests`, utilizam o atributo `[Fact]` do xUnit e seguem o padrão **Arrange / Act / Assert**.

| Teste | Cenário validado |
|-------|------------------|
| `AddTask_Should_Add_Task_When_Title_Is_Valid` | Ao informar um título válido, a tarefa é criada com o título correto, não concluída, e adicionada à lista. |
| `AddTask_Should_Throw_Exception_When_Title_Is_Empty` | Ao informar um título vazio ou só com espaços, é lançada `ArgumentException`. |
| `GetById_Should_Return_Null_When_Task_Does_Not_Exist` | Ao buscar um ID inexistente, o método retorna `null` em vez de lançar exceção. |

---

## 🌿 Histórico de commits

O repositório segue o padrão **[Conventional Commits](https://www.conventionalcommits.org/)** no formato `tipo(escopo): descrição curta`. A sequência de commits do projeto é:

| Tipo | Commit |
|------|--------|
| `chore` | `chore(core): initialize .NET 10 solution and console project structure` |
| `chore` | `chore(test): add xUnit test project and reference to console Project` |
| `feat` | `feat(domain): implement TaskItem entity with completion logic` |
| `feat` | `feat(services): implement TaskManager logic for in-memory task management` |
| `test` | `test(unit): add xUnit test suite for TaskManager validation rules` |
| `fix` | `fix(manager): handle missing task gracefully in search method` |
| `refactor` | `refactor(console): implement interactive menu loop in Program.cs` |
| `docs` | `docs(readme): add build, run and test instructions` |

Para visualizar o grafo de commits:

```bash
git log --oneline --graph
```

---

## 🧰 Tecnologias utilizadas

- [C#](https://learn.microsoft.com/dotnet/csharp/)
- [.NET 10](https://dotnet.microsoft.com/)
- [xUnit](https://xunit.net/)
- [Conventional Commits](https://www.conventionalcommits.org/)
- [Git](https://git-scm.com/) e [GitHub](https://github.com/)
