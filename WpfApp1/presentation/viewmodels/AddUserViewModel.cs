using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using SalesManagementApp.data.services;
using SalesManagementApp.domain.models;
using SalesManagementApp.domain.usecases;
using SalesManagementApp.presentation.views;
using SalesManagementApp.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace SalesManagementApp.presentation.viewmodels
{
    public partial class AddUserViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        public PasswordBox? PasswordBoxRef { get; set; }
        public string? Password => PasswordBoxRef?.Password;

        [ObservableProperty]
        private string fullName;
        public ObservableCollection<string> Genders { get; } = new()
        {
            "Nam",
            "Nữ",
            "Khác"
        };
        [ObservableProperty]
        private string gender = "Nam";

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
        private string? photo; // đường dẫn ảnh

        [ObservableProperty]
        public string? username;

        [ObservableProperty]
        public DateTime birthday = DateTime.Now;

        public ObservableCollection<string> Roles { get; } = new()
        {
            "customer",
            "admin",
            "manager"
        };

        [ObservableProperty]
        private string role = "customer";

        public ObservableCollection<string> Statuses { get; } = new()
        {
            "active",
            "inactive",
            
        };
        [ObservableProperty]
        public string status = "active";
 

        public IRelayCommand SelectImageCommand { get; }
        public IRelayCommand SaveCommand { get; }
        public IRelayCommand CancelCommand { get; }

        public AddUserViewModel(IUserService userService)
        {
            _userService = userService;
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
             
            var anewUser = new User(FullName, Email, Gender, Phone, Password, Address,Role,Description);
           
            try
            {
                await _userService.AddUserAsync(anewUser);
               
                //MessageBox.Show("Người dùng đã được thêm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm người dùng: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //System.Windows.MessageBox.Show("Người dùng đã được lưu!", "Thông báo", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.SnackbarQueue.Enqueue("Thêm người dùng thành công!");
            }
            NavigateBack();
        }
        // Hàm điều hướng quay lại UserManagementPage
        private void NavigateBack()
        {
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.MainContentFrame.Navigate(new UserManagementPage());
            }
        }
        private void Cancel()
        {
            NavigateBack();
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.SnackbarQueue.Enqueue("Huỷ thêm người dùng!");
            }
            // Thêm logic hủy thao tác
            //System.Windows.MessageBox.Show("Đã hủy thao tác!", "Thông báo", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
        }
    }
}
