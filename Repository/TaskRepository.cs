using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Task_Repo_Pattern.Interfaces;
using Task_Repo_Pattern.Model;

namespace Task_Repo_Pattern.Repository
{
    public class TaskRepository : Repository<Model.Task>, ITaskRepository
    {
        public TaskRepository(TaskDbContext repositoryContext)
          : base(repositoryContext)
        {
            if (repositoryContext.Tasks.Count() == 0)
            {
                repositoryContext.Tasks.Add(new Model.Task { TaskName = "Task1" });
                repositoryContext.SaveChanges();
            }
        }

        public async System.Threading.Tasks.Task CreateTaskAsync(Model.Task task)
        {
            Create(task);
            await SaveAsync();
        }

        public async  System.Threading.Tasks.Task DeletetaskAsync(Model.Task task)
        {
            Delete(task);
            await SaveAsync();
        }

        public async Task<IEnumerable<Model.Task>> GetAllTasksAsync()
        {
            return await FindAll()
              .OrderBy(x => x.TaskName)
              .ToListAsync();
        }

        public async Task<Model.Task> GetTaskByIdAsync(long taskId)
        {
            return await FindByCondition(o => o.Id.Equals(taskId))
                .DefaultIfEmpty(new Model.Task())
                .SingleAsync();
        }
    }
}
