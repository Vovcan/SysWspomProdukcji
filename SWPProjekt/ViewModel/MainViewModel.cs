using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using SWPProjekt.Commands;
using SWPProjekt.Model;

namespace SWPProjekt.ViewModel
{
    public class MainViewModel : BaseViewModel
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
        private bool _interfaceChecked;
        private User _loginuser;

        public User LoginUser
        {
            get { return _loginuser; }
        }

        public bool InterfaceChecked
        {
            get { return _interfaceChecked; }
            set { _interfaceChecked = value;
                OnPropertyChanged(nameof(InterfaceChecked));
            }
        }

        private int _fontSize;

        public int FontSize
        {
            get { return _fontSize; }
            set {
                _fontSize = value;
                OnPropertyChanged(nameof(FontSize));
            }
        }

        public ICommand ChangeInterfaceCommand { get; set; }

        private BaseViewModel _selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { 
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel(User LoginUser, bool interaceChecked)
        {
            InterfaceChecked = interaceChecked;
            _loginuser = LoginUser;
            FontSize = 16;
            UpdateViewCommand = new UpdateViewCommand(this, LoginUser);
            ChangeInterfaceCommand = new ChangeInterfaceCommand(this);
            LoadImage(LoginUser);
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
