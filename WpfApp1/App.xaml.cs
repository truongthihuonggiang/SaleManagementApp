using SalesManagementApp.Data.Repositories;
using SalesManagementApp.domain.usecases;
using SalesManagementApp.presentation.viewmodels;
using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Windows;
using System;
using Microsoft.Extensions.DependencyInjection;
using SalesManagementApp.data.services;
using SalesManagementApp.data.repositories;
using System.Globalization;

namespace SalesManagementApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        
        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            // Đăng ký Repository và Service
            services.AddSingleton(new HttpClient());
            
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<UserViewModel>();
            services.AddSingleton<AddUserViewModel>();
            ServiceProvider = services.BuildServiceProvider();

            var culture = new CultureInfo("vi-VN"); // hoặc "fr-FR" cũng dùng dd/MM/yyyy
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            base.OnStartup(e);
        }
    }

}
