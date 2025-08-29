using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;
using TodoApp.Infrastructure.Persistence;

namespace TodoApp.Infrastructure.Repositories
{
    public class TaskRepository
    {
        private readonly TodoDbContext _context;

        public TaskRepository(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> GetAllTask()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Todo> GetTaskById(int id)
        {
           return await _context.Tasks.FindAsync(id);
        }
        public async Task CreateTask(Todo task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        //public async void UpdateTask(Todo task)
        //{
        //    _context.Tasks.Update(task);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task SwitchCompleteTask(int id)
        //{
        //    var todo = await _context.Tasks.FindAsync(id);
        //    if (todo != null)
        //    {
        //        todo.Status = !todo.Status;
        //        await _context.SaveChangesAsync();
        //    }

        //}

        //public async Task DeleteTask(int id)
        //{
        //    var todo = await _context.Tasks.FindAsync(id);
        //    if (todo != null)
        //    {
        //        _context.Tasks.Remove(todo);
        //        await _context.SaveChangesAsync();
        //    }
        //}

        public async Task<bool> ToggleStatusAsync(int id)
        {
            var todo = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (todo is null) return false;

            todo.Status = !todo.Status;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var todo = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if (todo is null) return false;

            _context.Tasks.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }






    }
}
