using TaskFlow.Console;

var manager = new TaskManager();
bool running = true;

while (running)
{
  Console.WriteLine("\n=== TASKFLOW CONSOLE ===");
  Console.WriteLine("1. Adicionar Tarefa");
  Console.WriteLine("2. Listar Tarefas");
  Console.WriteLine("3. Concluir Tarefa");
  Console.WriteLine("4. Sair");
  Console.Write("Escolha uma opção: ");

  var option = Console.ReadLine();

  switch (option)
  {
    case "1":
      Console.Write("Digite o título da tarefa: ");
      var title = Console.ReadLine();
      try
      {
        var task = manager.AddTask(title ?? "");
        Console.WriteLine($"Tarefa adicionada com sucesso! ID: {task.Id}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Erro: {ex.Message}");
      }
      break;

    case "2":
      Console.WriteLine("\n--- Lista de Tarefas ---");
      if (!manager.Tasks.Any())
      {
        Console.WriteLine("Nenhuma tarefa cadastrada.");
      }
      else
      {
        foreach (var item in manager.Tasks)
        {
          string status = item.IsCompleted ? "[X]" : "[ ]";
          Console.WriteLine($"{status} {item.Id} - {item.Title}");
        }
      }
      break;

    case "3":
      Console.Write("Digite o ID da tarefa a concluir: ");
      if (Guid.TryParse(Console.ReadLine(), out Guid id))
      {
        if (manager.CompleteTask(id))
          Console.WriteLine("Tarefa concluída!");
        else
          Console.WriteLine("Tarefa não encontrada.");
      }
      else
      {
        Console.WriteLine("ID inválido.");
      }
      break;

    case "4":
      running = false;
      break;

    default:
      Console.WriteLine("Opção inválida.");
      break;
  }
}