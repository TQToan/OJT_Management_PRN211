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
    public partial class FrmUniversityHome : Form
    {
        public FrmUniversityHome()
        {
            InitializeComponent();
        }

        //Method: load dữ liệu để hiển thị trang home
        private void FrmUniversityHome_Load(object sender, EventArgs e)
        {
            // load dữ liệu về kì hiện tại dựa trên ngày bắt đầu và ngày kết thúc
            // Spring bắt đầu 31/12 - 30/4 mỗi năm
            // Summer bắt đầu 30/4 - 31/8 mỗi năm
            // Fall bắt đầu 31/8 - 31/12 mỗi năm
            if (1 == 1)// nếu ngày hôm này bằng với ngày kết thúc của kì hiện tại thì được phép mở add a new semester 
            {
                BtnAddNewSemester.Enabled = true;
            } 
            else
            {
                BtnAddNewSemester.Enabled = false;
            }
            // load dữ liệu về đếm số sinh viên của kì hiện tại

            // load dữ liệu về đếm số company
            
            // load dữ liệu về đếm số các bài post còn hạn và còn số lượng
            
            // load dữ liệu về đếm số lượng major mà trường đang có 

        }


        //Method: add a new semester
        private void BtnAddNewSemester_Click(object sender, EventArgs e)
        {
            // thực hiện load học kì trước đó và thực hiện tạo kì mới dựa vào label (Spring, summer, fall)
            // và năm của kì vừa rồi để thực hiện tính toán 
            // Spring bắt đầu 31/12 - 30/4 mỗi năm
            // Summer bắt đầu 30/4 - 31/8 mỗi năm
            // Fall bắt đầu 31/8 - 31/12 mỗi năm
        }

        //Method: add a new major
        private void BtnAddNewMajor_Click(object sender, EventArgs e)
        {
            FrmUniversityAddNewMajor frmUniversityAddNewMajor = new FrmUniversityAddNewMajor();
            DialogResult result = frmUniversityAddNewMajor.ShowDialog();
            
        }
    }
}
