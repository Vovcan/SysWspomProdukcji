using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using SWPProjekt.Model;
using System.Drawing;
using System.IO;
using System.Windows;

namespace SWPProjekt.ViewModel
{
    class EmployeeScreenViewModel : BaseViewModel
    {
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
            LoadImage(user);
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
    }
}
