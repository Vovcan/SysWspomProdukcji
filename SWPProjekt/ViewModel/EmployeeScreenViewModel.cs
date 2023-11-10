using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using SWPProjekt.Model;
using System.Drawing;

namespace SWPProjekt.ViewModel
{
    class EmployeeScreenViewModel : BaseViewModel
    {
        public User CurrentUser { get; set; }
        public MainViewModel MainModel { get; set; }
        private ImageSource _imageSource;
        public ImageSource ImageSource
        {
            get
            {
                return _imageSource;
            }
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    OnPropertyChanged(nameof(ImageSource));
                }
            }
        }

        public void LoadImage()
        {
            string imagePath = CurrentUser.Picture;
            ImageSource = new BitmapImage(new Uri(imagePath, UriKind.Relative));
        }
        public EmployeeScreenViewModel(MainViewModel mainModel, User loginUser)
        {
            MainModel = mainModel;
            CurrentUser = loginUser;
        }
    }
}
