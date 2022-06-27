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
    public partial class FrmStudentDetailJobCompany : Form
    {
        public FrmStudentDetailJobCompany()
        {
            InitializeComponent();
        }

        //Method: khi bấm nút Exit thì thoát form detail job company
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Method: Chức năng apply vào job của company
        private void BtnApply_Click(object sender, EventArgs e)
        {
            if (BtnApply.Text.Equals("Apply"))
            {
                //Code chức năng apply ở đây
                BtnApply.Text = "Cancel";
                TxtAppliedStatus.Text = "Applied";
            } else if (BtnApply.Text.Equals("Cancel"))
            {
                //code chức năng cancel apply ở đây
                BtnApply.Text = "Apply";
                TxtAppliedStatus.Text = "Not Yet";
            }
                
        }

        //Method: Load dữ liệu của major của job lên lên và chọn 
        private void FrmStudentDetailJobCompany_Load(object sender, EventArgs e)
        {

        }
    }
}
