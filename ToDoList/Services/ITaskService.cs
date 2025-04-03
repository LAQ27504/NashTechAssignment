using ToDoList.Models;

namespace ToDoList.Services
{
    public interface ITaskService
    {
        TaskModel CreateTask(TaskModel task);
        List<TaskModel> GetAllTasks();
        TaskModel? GetTaskById(int id);
        bool DeleteTask(int id);
        TaskModel? UpdateTask(int id, TaskModel updatedTask);
        List<TaskModel> BulkAddTasks(List<TaskModel> tasks);
        bool BulkDeleteTasks(List<int> taskIds);
    }
}
