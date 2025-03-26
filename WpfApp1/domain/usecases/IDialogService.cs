using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagementApp.domain.usecases
{
    public interface IDialogService
    {
        bool ShowConfirmation(string message, string title, int width = 400, int height = 200);
    }
}
