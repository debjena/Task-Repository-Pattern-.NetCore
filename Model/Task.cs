using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Date)]
        [JsonConverter(typeof(IsoDateConverter))]
        public DateTime TaskDate { get; set; }
        public bool IsTaskDone { get; set; }
    }
    public class IsoDateConverter : IsoDateTimeConverter
    {
    public IsoDateConverter() => 
        this.DateTimeFormat = "MM/dd/yyyy";
    }
}
