using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPProjekt.Model
{
    public class CombinedUser
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public int JobTitleid { get; set; }

        public string TaskName { get; set; } = null!;
        public int? TaskId { get; set; }

        public string ProductionName { get; set; } = null!;

        public int HoursNumber { get; set; }

        public CombinedUser(int id, string name, string surname, int jobTitleid, string TaskName, int Taskid)
        {
            Id = id;
            Name = name;
            Surname = surname;
            JobTitleid = jobTitleid;
            this.TaskName = TaskName;
            TaskId = Taskid;

        }
    }
}
