using SalesManagementApp.domain.usecases;
using SalesManagementApp.presentation.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesManagementApp.data.services
{
    public class DialogService : IDialogService
    {
        public bool ShowConfirmation(string message, string title, int width = 400, int height= 200)
        {
            var dialog = new ConfirmationDialog(message);
            dialog.Width = width;
            dialog.Height = height;
            dialog.Title = title;
            dialog.ShowDialog();
            return dialog.IsConfirmed;
        }
    }
}
