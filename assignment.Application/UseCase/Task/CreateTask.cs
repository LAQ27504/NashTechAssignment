namespace assignment.Application.Task.Create
{
    public class CreateTask
    {
        public void Execute(string title)
        {
            // Validate the title
            if (string.IsNullOrWhiteSpace(title) || title.Length < 3 || title.Length > 100)
            {
                throw new ArgumentException("Title must be between 3 and 100 characters.");
            }

            // Create a new task item
            //var taskItem = new TaskItem(title);

            // Save the task item to the database (pseudo code)
            // _dbContext.TaskItems.Add(taskItem);
            // _dbContext.SaveChanges();
        }
    }
}