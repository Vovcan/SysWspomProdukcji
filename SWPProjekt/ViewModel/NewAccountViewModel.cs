using Microsoft.Win32;
using SWPProjekt.Helpers;
using SWPProjekt.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Input;

namespace SWPProjekt.ViewModel
{
    internal class NewAccountViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public ProductionDatabaseContext context { get; set; } = new ProductionDatabaseContext();
        public string Base64PictureCode { get; set; }
        User LoginUser;
        public MainViewModel MainModel { get; set; }
        public JobTitle? Role { get; set; }
        public ObservableCollection<JobTitle>? Roles { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public RelayCommand SaveCommand { get; set; }
        private string validationFailedText;
        public string ValidationFailedText
        {
            get => validationFailedText;
            set
            {
                validationFailedText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ValidationFailedText"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public string SelectedImagePath { get; set; }
        public ICommand OpenFileCommand { get; set; }

        private void OpenFileDialog(object a)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Wybrać zdjęcie",
                Filter = "Zdjęcia|*.jpg;*.png;|Wszystkie pliki|*.*"

            };

            if (openFileDialog.ShowDialog() == true)
            {
                SelectedImagePath = openFileDialog.FileName;
            }
            try
            {
                byte[] imageBytes = File.ReadAllBytes(SelectedImagePath);

                // Кодуємо байти в рядок Base64
                Base64PictureCode = Convert.ToBase64String(imageBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd przy konwertacji pliku w Base64: {ex.Message}");

            }
        }
        private void SetSelectedImagePath(string imagePath)
        {
            SelectedImagePath = imagePath;
        }

        public NewAccountViewModel(MainViewModel mainModel, User loginUser)
        {
            SaveCommand = new RelayCommand(Save);
            MainModel = mainModel;
            LoginUser = loginUser;
            OpenFileCommand = new RelayCommand(OpenFileDialog);
            try
            {
                Roles = new ObservableCollection<JobTitle>(context.JobTitles.ToList());
                Debug.WriteLine("połączono");
            }
            catch
            {
                Debug.WriteLine("brak połączenia z bazą");
            }
        }

        public void Save(object o)
        {
            if (Validate())
            {
                User newUser = new User { Name = Name, Surname = Surname, Login = Login, Password = CreateMD5(Password), PhoneNumber=PhoneNumber,Email=Email, Active=1, TemporaryPassword=1, JobTitleid = Role.Id, Picture= Base64PictureCode };
                context.Add<User>(newUser);
                context.SaveChanges();
                MainModel.UpdateViewCommand.Execute("EmployeeListScreen");
            }
        }

        public string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                var a = Convert.ToHexString(hashBytes);
                return a;
            }
        }

        public bool Validate()
        {
            if (Name == "" || Surname == "" || Login == "" || Password == "" || PhoneNumber == 0 || Email == "" ||  Role == null)
            {
                ValidationFailedText = "Wymagane pola nie są wypełnione";
                return false;
            }
            if(context.Users.Any(u=>u.Login==Login))
            {
                ValidationFailedText = "Użytkownik z tym loginem już istnieje";
                return false;
            }
            if (context.Users.Any(u => u.Email == Email))
            {
                ValidationFailedText = "Użytkownik z tym adresem email już istnieje";
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
