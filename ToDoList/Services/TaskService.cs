using ToDoList.Models;

namespace ToDoList.Services
{
    public class TaskService : ITaskService
    {
        private static List<TaskModel> tasks = new List<TaskModel>();
        private static int nextId = 1;

        public TaskModel CreateTask(TaskModel task)
        {
            task.Id = nextId++;
            tasks.Add(task);
            return task;
        }

        public List<TaskModel> GetAllTasks()
        {
            return tasks;
        }

        public TaskModel? GetTaskById(int id)
        {
            return tasks.FirstOrDefault(t => t.Id == id);
        }

        public bool DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;

            tasks.Remove(task);
            return true;
        }

        public TaskModel? UpdateTask(int id, TaskModel updatedTask)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return null;

            task.Title = updatedTask.Title;
            task.IsCompleted = updatedTask.IsCompleted;
            return task;
        }

        public List<TaskModel> BulkAddTasks(List<TaskModel> newTasks)
        {
            foreach (var task in newTasks)
            {
                task.Id = nextId++;
                tasks.Add(task);
            }
            return newTasks;
        }

        public bool BulkDeleteTasks(List<int> taskIds)
        {
            tasks.RemoveAll(task => taskIds.Contains(task.Id));
            return true;
        }
    }
}
