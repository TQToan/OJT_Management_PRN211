using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApplication
{
    public partial class FrmCompanyAddNewJob : Form
    {
        public FrmCompanyAddNewJob()
        {
            InitializeComponent();
        }

        //Method: Load dữ liệu của major vào combobox major
        private void FrmCompanyAddNewJob_Load(object sender, EventArgs e)
        {

        }

        //Method: đóng form hiện tại
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
