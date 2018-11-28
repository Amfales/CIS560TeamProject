using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApplication
{
    public partial class UpdateConditionForm : Form
    {
        FormClose handleClose;
        ReturnToMenu handleReturnToMenu;
        UpdateCondition handleUpdateCondition;

        public UpdateConditionForm(FormClose hClose, ReturnToMenu hReturn, UpdateCondition hUpdate)
        {
            handleClose = hClose;
            handleReturnToMenu = hReturn;
            handleUpdateCondition = hUpdate;

            InitializeComponent();
            BackColor = Color.SteelBlue;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            handleClose(e, this);
        }

        private void uxReturnButton_Click(object sender, EventArgs e)
        {
            uxBookIDBox.Text = "";
            uxConditionBox.Text = "";
            handleReturnToMenu(this);
        }

        private void uxUpdateButton_Click(object sender, EventArgs e)
        {
            bool success;

            try
            {
                success = handleUpdateCondition(Convert.ToInt32(uxBookIDBox.Text), uxConditionBox.Text);
            }
            catch
            {
                MessageBox.Show("Invalid BookID.");
                return;
            }

            if (success)
            {
                MessageBox.Show("Condition successfully updated to " + uxConditionBox.Text + ".");
                uxBookIDBox.Text = "";
                uxConditionBox.Text = "";
            }
            else
            {
                MessageBox.Show("Condition was not successfully updated. Contact a system administrator for assistance.");
            }
        }
    }
}
