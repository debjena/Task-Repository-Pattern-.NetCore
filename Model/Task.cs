using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Repo_Pattern.Model
{
    public class Task
    {
        public long Id { get; set; }
        public string TaskName { get; set; }
        public bool IsDone { get; set; }
    }
}
