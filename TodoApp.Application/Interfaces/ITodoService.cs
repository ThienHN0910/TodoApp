using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Interfaces
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllTask();
        Task<Todo> GetTaskById(int id);

        Task CreateTask(Todo task);


        //void UpdateTask(Todo task);


        Task<bool> ToggleStatusAsync(int id);

        Task<bool> DeleteAsync(int id);
       

    }
}
