using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Task_Repo_Pattern.Model
{
    public class Task
    {
        public long Id { get; set; }
        [Required(ErrorMessage="Please enter task name.")]
        public string TaskName { get; set; }
        [CheckDateType(ErrorMessage="Please enter a valid date.")]
        public string TaskDate { get; set; }
        public bool IsTaskDone { get; set; }
    }
    public class CheckDateTypeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dtout;
            if(DateTime.TryParseExact(value.ToString(),"M/d/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,out dtout))
            {
                return true;
            }
            return false;
        }
    }
}
