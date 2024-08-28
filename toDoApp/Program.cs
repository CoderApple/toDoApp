

class Program
{
    static void Main(string[] args)
    {
        List<Tasks> tasks = new List<Tasks>();
        Dictionary<string, int> validPriorities = new Dictionary<string, int>
        { {"HIGH", 3 }, { "MEDIUM", 2}, { "LOW", 1}};
        bool running = true;
        while (running)
        {
            Console.WriteLine("\n-----MENU-----");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Update status of the task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit\n");
            
            Console.WriteLine("Choose an option:");

            string choice = Console.ReadLine();

            switch (choice)
            {

                case "1":
                    AddTask(tasks, validPriorities);
                    break;
                case "2":
                    ViewTasks(tasks, validPriorities);
                    break;
                case "3":
                    MarkAsCompleted(tasks);
                    break;
                case "4":
                    DeleteTask(tasks);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;

            }
        }
    }

    static void AddTask(List<Tasks> tasks, Dictionary<string, int> validPriorities)
    {
        Console.WriteLine("Enter the task Description");
        string descripion = Console.ReadLine();
        Console.WriteLine("Set Priority(Low/Medium/High): ");
        string priority = Console.ReadLine().ToUpper();
        //string[] validPriorities = { "LOW", "MEDIUM", "HIGH" };
        
        bool isValidPriority = validPriorities.ContainsKey(priority);
        if (isValidPriority)
        {
            tasks.Add(new Tasks { Description = descripion, isCompleted = false, Priority = priority });
            Console.WriteLine($"Task Added Successfully with {priority} priority");
        
        }
        else
        {
            Console.WriteLine("Invalid Priority. Please enter Low, Medium, High");

        }
    }
    //static void ViewTasks(List<Tasks> tasks, Dictionary<string, int> validPriorities)
    //{

    //    tasks.Sort((x, y) => validPriorities[y.Priority].CompareTo(validPriorities[x.Priority]));
    //    Console.WriteLine("\n-----Tasks List After Sorting-----\n");
    //    int count = 0;
    //    for (int i = 0; i < tasks.Count; i++)
    //    {
    //        string status = tasks[i].isCompleted ? "Completed" : "Not Completed";
    //        Console.WriteLine($"{i + 1}. \"{tasks[i].Description}\" - Priority: {tasks[i].Priority} - Status: {status}");
    //    }
    //    Console.WriteLine("\n-----END-----\n");
    //}

    static void ViewTasks(List<Tasks> tasks, Dictionary<string, int> validPriorities)
    {
      
        tasks.Sort((x, y) => validPriorities[y.Priority].CompareTo(validPriorities[x.Priority]));

        int maxDescriptionLength = tasks.Max(t => t.Description.Length);
        int maxStatusLength = "Not Completed".Length;

        int maxPriorityLength = "medium".Length;

        Console.WriteLine("\n-----Tasks List-----\n");
        Console.WriteLine($"{"Description".PadRight(maxDescriptionLength)} | {"Status".PadRight(maxStatusLength)} | {"Priority".PadRight(maxPriorityLength)}");
        Console.WriteLine(new string('-', maxDescriptionLength + maxStatusLength + maxPriorityLength + 6));

        for (int i = 0; i < tasks.Count; i++)
        {
            string description = tasks[i].Description.PadRight(maxDescriptionLength);
            string status = (tasks[i].isCompleted ? "Completed" : "Not Completed").PadRight(maxStatusLength);
            string priority = tasks[i].Priority.PadRight(maxPriorityLength);

            Console.WriteLine($"{description} | {status} | {priority}");
        }

        Console.WriteLine("\n-----END-----\n");
    }




    static void MarkAsCompleted(List<Tasks> tasks)
    {
        Console.WriteLine("Enter the number associated with task that has to be marked completed: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        tasks[index].isCompleted = true;
        Console.WriteLine("Task updated Successfully\n");
    }

    static void DeleteTask(List<Tasks> tasks)
    {
        Console.WriteLine("Enter the number associated with task that has to be deleted: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        tasks.Remove(tasks[index]);
        Console.WriteLine("Task deleted Successfully\n");
    }
}

class Tasks
{
    public string Description { get; set; }
    public bool isCompleted { get; set; }
    public string Priority { get; set; }

}