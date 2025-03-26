using Microsoft.Extensions.DependencyInjection;
using SalesManagementApp.presentation.viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesManagementApp.presentation.views
{
    /// <summary>
    /// Interaction logic for AddNewUser.xaml
    /// </summary>
    public partial class AddNewUser : Page
    {
        public AddNewUser()
        {
            InitializeComponent();
            //DataContext = new AddUserViewModel(); // Gán ViewModel cho Page
            DataContext = App.ServiceProvider.GetService<AddUserViewModel>();
            if (DataContext is AddUserViewModel vm)
            {
                vm.PasswordBoxRef = PasswordBox;
            }
            //if (this.NavigationService == null)
            //{
            //    MessageBox.Show("NavigationService đang là NULL. Bạn có chắc ứng dụng đang sử dụng NavigationWindow không?", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }
    }
}
