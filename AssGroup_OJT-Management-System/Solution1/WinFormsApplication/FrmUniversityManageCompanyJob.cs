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
    public partial class FrmUniversityManageCompanyJob : Form
    {
        public FrmUniversityManageCompanyJob()
        {
            InitializeComponent();
        }

        //Method: open frm confirm job để thực hiện confirm denied or accepted job này của company
        private void DgvCompaniesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to accept this company's job?", "Company Job - Confirm Company's Job",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //thực hiện thay đổi trạng thái của job này sang trạng thái accepted
            } 
            else if (result == DialogResult.No)
            {
                //thực hiện thay đổi trạng thái của job này sang trạng thái dined
            }
            // nếu là cancel thì không thay đổi gì cả
        }

        //Method: thực hiện load các job lên
        private void FrmUniversityManageCompanyJob_Load(object sender, EventArgs e)
        {
            List<dynamic> liststudent = new List<dynamic>();
            liststudent.Add("Thái Quốc Toàn 1");
            liststudent.Add("Thái Quốc Toàn 2");
            liststudent.Add("Thái Quốc Toàn 3");
            liststudent.Add("Thái Quốc Toàn 4");
            BindingSource source = new BindingSource();
            source.DataSource = liststudent;
            DgvCompaniesList.DataSource = source;
        }
    }


}
