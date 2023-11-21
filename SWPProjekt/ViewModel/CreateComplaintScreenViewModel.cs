using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SWPProjekt.Helpers;
using SWPProjekt.Model;

namespace SWPProjekt.ViewModel
{
    public class CreateComplaintScreenViewModel : BaseViewModel
    {
        User LoginUser;
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();
        public string NewTitle { get; set; }
        public string NewDescription { get; set; }
        public MainViewModel MainModel { get; set; }

        public RelayCommand CreateComplaint { get; set; }
        void NewComplaintFu(object a)
        {
            if (NewTitle != null && NewDescription != null)
            {
                Complaint NewComplaint = new();
                NewComplaint.Userid = LoginUser.Id;
                NewComplaint.Subject = NewTitle;
                NewComplaint.Description = NewDescription;
                context.Add<Complaint>(NewComplaint);
                context.SaveChanges();
                MessageBox.Show("Utworzyłeś nową skargę");
                MainModel.UpdateViewCommand.Execute("ComplaintsListScreen");
            }
            else
            {
                MessageBox.Show("Proszę wpisać dane");
            }
        }
        public CreateComplaintScreenViewModel(MainViewModel mainModel, User user)
        {
            LoginUser = user;
            MainModel = mainModel;
            CreateComplaint = new RelayCommand(NewComplaintFu);
        }
    }
}
