using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SWPProjekt.Helpers;
using SWPProjekt.Model;

namespace SWPProjekt.ViewModel
{
    class ComplaintsScreenViewModel : BaseViewModel
    {
        public MainViewModel MainModel { get; set; }

        public Complaint CurrentComplaint { get; set; }

        User LoginUser;
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();

        private Visibility stackPanelVisibility = Visibility.Collapsed;
        public Visibility StackPanelVisibility
        {
            get { return stackPanelVisibility; }
            set
            {
                if (stackPanelVisibility != value)
                {
                    stackPanelVisibility = value;
                    OnPropertyChanged(nameof(StackPanelVisibility));
                }
            }
        }
        private Response _response { get; set; }
        public Response Response
        {
            get
            {
                return _response;
            }
            set
            {
                _response =  value;
            }
        }
        public ComplaintsScreenViewModel(MainViewModel mainModel, Complaint CurrentComplaint, User user)
        {
            LoginUser = user;
            MainModel = mainModel;
            this.CurrentComplaint = CurrentComplaint;
            Response = context.Responses.FirstOrDefault(x => x.Id == CurrentComplaint.Responseid);
            if (CurrentComplaint.Responseid != null)
            {
                StackPanelVisibility = Visibility.Visible;
            }
        }
    }
}
