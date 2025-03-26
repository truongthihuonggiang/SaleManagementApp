 
using SalesManagementApp.domain.models;
using SalesManagementApp.domain.usecases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using SalesManagementApp.presentation.views.users;
using SalesManagementApp.presentation.views;
using SalesManagementApp.Presentation.Views;

namespace SalesManagementApp.presentation.viewmodels
{
    public partial class UserViewModel : ObservableObject
    {
        private readonly IUserService _userService;
        private readonly IDialogService _dialogService;

        [ObservableProperty]
        private ObservableCollection<User> users = new();

        public UserViewModel(IUserService userService, IDialogService dialogService)
        {
            _userService = userService;
            _dialogService = dialogService;
            LoadUsersCommand = new AsyncRelayCommand(LoadUsers);
            AddUserCommand = new AsyncRelayCommand<User>(AddUser);
            DeleteUserCommand = new AsyncRelayCommand<int>(DeleteUser);
            EditUserCommand = new RelayCommand<User>(EditUser);
          

        }

        public IAsyncRelayCommand LoadUsersCommand { get; }
        public IAsyncRelayCommand<User> AddUserCommand { get; }
        public IAsyncRelayCommand<int> DeleteUserCommand { get; }
        public IRelayCommand<User> EditUserCommand { get; }
        private async Task LoadUsers()
        {
            var userList = await _userService.GetUsersAsync();
            Users.Clear();
            foreach (var user in userList)
            {
                Users.Add(user);
            }
        }
        private async Task AddUser(User user)
        {
            await _userService.AddUserAsync(user);
            await LoadUsers();
        }
        private async Task DeleteUser(int id)
        {
            var confirm = _dialogService.ShowConfirmation("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận xóa");

            if (confirm)
            {
                await _userService.DeleteUserAsync(id);
                await LoadUsers();
            }
        }
        private void EditUser(User user)
        {
            if (user == null) return;

            var editPage = new EditUserPage(user); // truyền user sang
            if (Application.Current.MainWindow is MainWindow mainWindow)
            {
                mainWindow.MainContentFrame.Navigate(editPage);
            }

           
        }
    }
}
