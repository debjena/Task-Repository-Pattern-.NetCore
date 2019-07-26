using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Repo_Pattern.Repository;

namespace Task_Repo_Pattern.Interfaces
{
    public interface ITaskRepository : IRepository<Model.Task>
    {
        Task<IEnumerable<Model.Task>> GetAllTasksAsync();
        Task<Model.Task> GetTaskByIdAsync(long taskId);
        Task CreateTaskAsync(Model.Task task);
        Task DeletetaskAsync(Model.Task task);
    }
}
