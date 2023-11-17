using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWPProjekt.Model;

namespace SWPProjekt.ViewModel
{
    class ComplaintsListScreenViewModel : BaseViewModel
    {
        User LoginUser;
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();
        private List<Complaint> _complaintsList { get; set; }
        public List<Complaint> ComplaintsList
        {
            get
            {
                return _complaintsList;
            }
            set
            {
                _complaintsList = context.Complaints.Where(x => x.Userid == LoginUser.Id).ToList();
                OnPropertyChanged(nameof(ComplaintsList));
            }
        }
        public MainViewModel MainModel { get; set; }

        private Complaint _currentComplaint;
        public Complaint CurrentComplaint
        {
            get
            {
                return _currentComplaint;
            }
            set
            {
                _currentComplaint = value;
                ComplaintsScreenViewModel newView = new ComplaintsScreenViewModel(MainModel, CurrentComplaint, LoginUser);
                if (MainModel.UpdateViewCommand.CanExecute(newView))
                    MainModel.UpdateViewCommand.Execute(newView);
            }
        }
        public ComplaintsListScreenViewModel(MainViewModel mainModel, User user)
        {
            LoginUser = user;
            MainModel = mainModel;
            ComplaintsList = new List<Complaint>();
        }
    }
}
