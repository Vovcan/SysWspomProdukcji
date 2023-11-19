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
        public string NewResponse { get; set; }
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();

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

        private Visibility stackPanelVisibilityForAdmin = Visibility.Collapsed;
        public Visibility StackPanelVisibilityForAdmin
        {
            get { return stackPanelVisibilityForAdmin; }
            set
            {
                if (stackPanelVisibilityForAdmin != value)
                {
                    stackPanelVisibilityForAdmin = value;
                    OnPropertyChanged(nameof(StackPanelVisibilityForAdmin));
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

        public RelayCommand CreateNewResponse { get; set; }

        public void NewResponseFu(object a)
        {
            Response = new Response();
            Response.Description = NewResponse;
            Response.Userid = LoginUser.Id;

            context.Add<Response>(Response);
            context.SaveChanges();

            CurrentComplaint.Responseid = Response.Id;

            context.Update(CurrentComplaint);
            context.SaveChanges();

            MessageBox.Show("Zapisałeś odpowiedź");
            MainModel.UpdateViewCommand.Execute("ComplaintsListScreen");
        }
        public ComplaintsScreenViewModel(MainViewModel mainModel, Complaint CurrentComplaint, User user)
        {
            LoginUser = user;
            MainModel = mainModel;
            this.CurrentComplaint = CurrentComplaint;
            Response = context.Responses.FirstOrDefault(x => x.Id == CurrentComplaint.Responseid);
            if (CurrentComplaint.Responseid != null)
            {
                StackPanelVisibilityForAdmin = Visibility.Hidden;
                StackPanelVisibilityForUser = Visibility.Visible;
            }
            else if(LoginUser.JobTitleid == 5)
            {
                StackPanelVisibilityForUser = Visibility.Hidden;
                StackPanelVisibilityForAdmin = Visibility.Visible;
            }

            CreateNewResponse = new RelayCommand(NewResponseFu);
        }
    }
}
