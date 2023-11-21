using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SWPProjekt.Helpers;
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
                if (LoginUser.JobTitleid == 5)
                {
                    _complaintsList = context.Complaints.ToList();
                }
                else
                {
                    _complaintsList = context.Complaints.Where(x => x.Userid == LoginUser.Id).ToList();
                }
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

        private Visibility stackPanelVisibilityForUser = Visibility.Collapsed;
        public Visibility StackPanelVisibilityForUser
        {
            get { return stackPanelVisibilityForUser; }
            set
            {
                if (stackPanelVisibilityForUser != value)
                {
                    stackPanelVisibilityForUser = value;
                    OnPropertyChanged(nameof(StackPanelVisibilityForUser));
                }
            }
        }

        public RelayCommand CreateNewComplaint { get; set; }

        public void NewComplaintFu(object a)
        {
            CreateComplaintScreenViewModel newView = new CreateComplaintScreenViewModel(MainModel, LoginUser);
            if (MainModel.UpdateViewCommand.CanExecute(newView))
                MainModel.UpdateViewCommand.Execute(newView);
        }
        public ComplaintsListScreenViewModel(MainViewModel mainModel, User user)
        {
            LoginUser = user;
            MainModel = mainModel;
            ComplaintsList = new List<Complaint>();
            if (LoginUser.JobTitleid == 5)
            {
                StackPanelVisibilityForUser = Visibility.Hidden;
            }
            CreateNewComplaint = new RelayCommand(NewComplaintFu);
        }
    }
}
