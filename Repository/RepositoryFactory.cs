using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_Repo_Pattern.Interfaces;
using Task_Repo_Pattern.Model;

namespace Task_Repo_Pattern.Repository
{
    public class RepositoryFactory:IRepositoryFactory
    {
        private TaskDbContext _repoContext;
        private ITaskRepository _task;
        public RepositoryFactory(TaskDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public ITaskRepository Task
        {
            get
            {
                if (_task == null)
                {
                    _task = new TaskRepository(_repoContext);
                }

                return _task;
            }
        }
    }
}
