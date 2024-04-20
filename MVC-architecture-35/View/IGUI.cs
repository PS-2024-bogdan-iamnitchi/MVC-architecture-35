using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_architecture_35.View
{
    public interface IGUI
    {
        void SetMessage(string title, string message);
        void HideForm();
    }
}
