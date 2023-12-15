using SWPProjekt.Helpers;
using SWPProjekt.Model;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SWPProjekt.ViewModel
{
    class EmployeeScreenViewModel : BaseViewModel
    {
        public float? UpdatedHourWage { get; set; }
        public int? UpdatedMonthWage { get; set; }
        public RelayCommand EditSalaryCommand { get; set; }
        public Visibility EditVisibility { get; set; }
        private BitmapImage _imageSource;
        public BitmapImage ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }
        public User CurrentUser { get; set; }
        public User LoginUser { get; set; }
        public MainViewModel MainModel { get; set; }

        public EmployeeScreenViewModel(User user, MainViewModel mainModel, User loginUser)
        {
            LoginUser = loginUser;
            MainModel = mainModel;
            CurrentUser = user;
            if (CurrentUser.JobTitleid == 4 || CurrentUser.JobTitleid == 3)
                EditVisibility = Visibility.Visible;
            else
                EditVisibility= Visibility.Collapsed;
            LoadImage(user);
            EditSalaryCommand = new RelayCommand(EditSalary);
            UpdatedHourWage = CurrentUser.SalaryByHour;
            UpdatedMonthWage = CurrentUser.SalaryByMonth;
        }

        private void LoadImage(User user)
        {
            string base64String = user.Picture;
            BitmapImage bitmapImage = LoadImageFromBase64(base64String);
            ImageSource = bitmapImage;
        }

        private BitmapImage LoadImageFromBase64(string base64String)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64String);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(imageBytes);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bład ładowania obrazka: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public void EditSalary(object o)
        {
            try
            {
                ProductionDatabaseContext db = new ProductionDatabaseContext();
                CurrentUser.SalaryByHour = UpdatedHourWage;
                CurrentUser.SalaryByMonth = UpdatedMonthWage;
                MainModel.UpdateViewCommand.Execute(new EmployeeScreenViewModel(CurrentUser, MainModel, LoginUser));
            }
            catch
            {
                MessageBox.Show("Operacja nie udała się");
            }
        }
    }
}
