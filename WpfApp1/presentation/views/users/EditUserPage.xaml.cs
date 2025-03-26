using Microsoft.Extensions.DependencyInjection;
using SalesManagementApp.domain.models;
using SalesManagementApp.domain.usecases;
using SalesManagementApp.presentation.viewmodels.users;
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

namespace SalesManagementApp.presentation.views.users
{
    /// <summary>
    /// Interaction logic for EditUserPage.xaml
    /// </summary>
    public partial class EditUserPage : Page
    {
        public EditUserPage(User user)
        {
            InitializeComponent();

            var userService = App.ServiceProvider.GetService<IUserService>();
            DataContext = new EditUserViewModel(user, userService);
        }
    }
}
