using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SalesManagementApp.domain.models;
using SalesManagementApp.domain.usecases;
using SalesManagementApp.presentation.views;
using SalesManagementApp.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace SalesManagementApp.presentation.viewmodels.users
{
    public partial class EditUserViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        public PasswordBox? PasswordBoxRef { get; set; }
        public string? Password => PasswordBoxRef?.Password;

        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string fullName;

        [ObservableProperty]
        private string gender;

        [ObservableProperty]
        private string phone;

        [ObservableProperty]
        private string address;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string imagePath;

        [ObservableProperty]
        public string? code;

        [ObservableProperty]
        private string? photo;

        [ObservableProperty]
        public string? username;

        [ObservableProperty]
        public DateTime birthday;

        [ObservableProperty]
        private string role;

        [ObservableProperty]
        public string status;

        public ObservableCollection<string> Genders { get; } = new()
    {
        "Nam",
        "Nữ",
        "Khác"
    };

        public ObservableCollection<string> Roles { get; } = new()
    {
        "customer",
        "admin",
        "manager"
    };

        public ObservableCollection<string> Statuses { get; } = new()
    {
        "active",
        "inactive"
    };

        public IRelayCommand SelectImageCommand { get; }
        public IRelayCommand SaveCommand { get; }
        public IRelayCommand CancelCommand { get; }

        public EditUserViewModel(User user, IUserService userService)
        {
            _userService = userService;
            // Khởi tạo dữ liệu từ đối tượng user truyền vào
            
            Id = user.Id;
            FullName = user.FullName;
            Gender = user.Gender;
            Phone = user.Phone;
            Address = user.Address;
            Email = user.Email;
            Description = user.Description;
            Code = user.Code;
            Photo = user.Photo;
            Username = user.Username;
            Birthday = user.Birthday;
            Role = user.Role;
            Status = user.Status;

            SelectImageCommand = new RelayCommand(SelectImage);
            SaveCommand = new AsyncRelayCommand(SaveUserAsync);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void SelectImage()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Chọn ảnh đại diện",
                Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png",
                Multiselect = false
            };

            if (dialog.ShowDialog() == true)
            {
                Photo = dialog.FileName;
            }
        }

        private async Task SaveUserAsync()
        {
            var updatedUser = new User
            {
                Id = Id,
                FullName = FullName,
                Email = Email,
                Gender = Gender,
                Phone = Phone,
                Password = Password, // Nếu bạn muốn cho phép cập nhật mật khẩu
                Address = Address,
                Role = Role,
                Description = Description,
                Birthday = Birthday,
                Username = Username,
                Code = Code,
                Photo = Photo,
                Status = Status
            };

            try
            {
                await _userService.UpdateUserAsync(updatedUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật người dùng: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.SnackbarQueue.Enqueue("Đã cập nhật người dùng!");
            }
            NavigateBack();
        }

        private void Cancel()
        {
            NavigateBack();
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.SnackbarQueue.Enqueue("Đã huỷ chỉnh sửa!");
            }
            //MessageBox.Show("Đã hủy chỉnh sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void NavigateBack()
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
               
                mainWindow.MainContentFrame.Navigate(new UserManagementPage());
            }
        }
    }

}
