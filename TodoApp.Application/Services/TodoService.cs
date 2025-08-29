using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Application.DTOs;
using TodoApp.Application.Interfaces;
using TodoApp.Domain.Entities;
using TodoApp.Infrastructure.Repositories;

namespace TodoApp.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly TaskRepository _repository;
        public TodoService(TaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Todo>> GetAllTask()
        {
            return await _repository.GetAllTask();
        }
        public async Task<Todo> GetTaskById(int id)
        {
            return await _repository.GetTaskById(id);
        }
        public async Task CreateTask(Todo task)
        {
            await _repository.CreateTask(task);
        }

        //public async void UpdateTask(Todo task)
        //{
        //    _repository.UpdateTask(task);
        //}

        //public async void SwitchCompleteTask(int id)
        //{
        //    _repository.SwitchCompleteTask(id);
        //}

        //public async void DeleteTask(int id)
        //{
        //    _repository.DeleteTask(id);
        //}

        public Task<bool> ToggleStatusAsync(int id)
              => _repository.ToggleStatusAsync(id);

        public Task<bool> DeleteAsync(int id)
            => _repository.DeleteAsync(id);

    }
}
