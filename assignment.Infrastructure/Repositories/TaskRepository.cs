using assignment.Domain.Entities;
using assignment.Infrastructure.Gateway;
using Microsoft.EntityFrameworkCore;
using assignment.Infrastructure.Persistence;

namespace assignment.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {

        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> CreateTask(TaskItem task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTask(Guid id)
        {
            var deleteTask = await _context.Tasks.FindAsync(id);
            if (deleteTask == null)
            {
                return false;
            }

            _context.Tasks.Remove(deleteTask);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTask()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskItem?> GetTaskById(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<TaskItem?> UpdateTask(Guid id, TaskItem task)
        {
            var updateTask = await _context.Tasks.FindAsync(id);
            if (updateTask == null)
            {
                return null;
            }

            updateTask.Title = task.Title;
            updateTask.IsCompleted = task.IsCompleted;

            await _context.SaveChangesAsync();
            return updateTask;
        }
    }
}