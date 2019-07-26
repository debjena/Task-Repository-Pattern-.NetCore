using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Repo_Pattern.Interfaces
{
    public interface IRepositoryFactory
    {
        ITaskRepository Task { get; }
    }
}
