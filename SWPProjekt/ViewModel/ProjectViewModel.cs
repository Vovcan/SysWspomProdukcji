using SWPProjekt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPProjekt.ViewModel
{
    class ProjectViewModel : BaseViewModel
    {
        public Project CurrentProject { get; set; }
        public User ProjectOwner { get; set; }
        public ProductionDatabaseContext db { get; set; }
        public ObservableCollection<Production>? ProductionList { get; set; }

        public ProjectViewModel(Project project)
        {
            CurrentProject=project;
            try
            {
                db = new ProductionDatabaseContext();
                ProjectOwner = db.Users.Single(u => u.Id == project.Userid);
                ProductionList = new ObservableCollection<Production>(db.Productions.Where(p => p.Projectid == project.Id).ToList());
            }
            catch
            {

            }
            
        }
    }
}
