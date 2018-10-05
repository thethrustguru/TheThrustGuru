using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheThrustGuru.Utils
{
    public class MessagePrompt
    {
        public static bool displayPrompt(string title, string message)
        {
            string text = string.Format("You are about to {0}. Please confirm or cancel to proceed.", message);
            DialogResult result = MessageBox.Show(text, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                return true;
            else return false;
        }

        public static bool printPrompt(string msg)
        {
            string text = string.Format("Do you want to print this {0} document", msg);
            DialogResult result = MessageBox.Show(text, "Print", MessageBoxButtons.OKCancel, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                return true;
            else return false;
        }
    }
}
