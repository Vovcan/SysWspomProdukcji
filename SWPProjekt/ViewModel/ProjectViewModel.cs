using SWPProjekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPProjekt.ViewModel
{
    class ProjectViewModel : BaseViewModel
    {
        public Project CurrentProject { get; set; }
        public ProjectViewModel(Project project)
        {
            CurrentProject=project;
        }
    }
}
