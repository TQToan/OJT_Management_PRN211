﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Repository;
using System.Text.RegularExpressions;
using Library.Models;
namespace WinFormsApplication
{
    public partial class FrmUniversityAddNewCompany : Form
    {
        IRepositoryTblAccount repositoryTblAccount = new RepositoryTblAccount();
        IRepositoryTblCompany repositoryTblCompany = new RepositoryTblCompany();

        public TblCompany TblCompany { get; set; }
        public FrmUniversityAddNewCompany()
        {
            InitializeComponent();
        }

        //Method: thực hiện insert new company
        private void BtnInsertANewCompany_Click(object sender, EventArgs e)
        {
            
            string pattern = "^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$";
            
            //get text
            string email = TxtCompanyEmail.Text;
            string password = TxtPassword.Text;
            string companyTax = TxtCompanyTax.Text;
            string companyName = TxtCompanyName.Text;
            string address = TxtCompanyAddress.Text;

            //TxtPassword.Text = string.Empty;

            string ppattern = "^[a-zA-Z0-9+_.-]@/fpt.edu.vn/+$";
            bool check = true;
            string msgError = ""; 
            //check invalid
            Match match = Regex.Match(email, pattern);
            
            if (email == string.Empty || password == string.Empty || companyTax == string.Empty || companyName == string.Empty || address == string.Empty)
            {
                //MessageBox.Show("Please enter full information !!!", "Notification");
                msgError += "Please enter full information\n";
                check = false;
            }
            else
            {
                if (!match.Success)
                {
                    //MessageBox.Show("Your email is invalid format !!!", "Notification");
                    msgError += "Your email is invalid format\n";
                    check = false;
                }
                if (repositoryTblAccount.GetAccount(email) != null)
                {
                    //MessageBox.Show("Company email id duplicated !!!", "Notification");
                    msgError += "Company email id duplicated\n";
                    check = false;
                }
                if (password.Length < 6)
                {
                    //MessageBox.Show("Password required is more than 8 characters !!!", "Notification");
                    msgError += "Password required is more than 6 characters\n";
                    check = false;
                }
                if (repositoryTblCompany.GetCompany(companyTax) != null)
                {
                    //MessageBox.Show("Company tax id duplicated !!!", "Notification");
                    msgError += "Company tax id duplicated\n";
                    check = false;
                }
            }                          
            if (!check)
            {
                MessageBox.Show(msgError, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var TblCompany = new TblCompany()
                {
                    TaxCode = companyTax,
                    Username = email,
                    CompanyName = companyName,
                    Address = address,
                    UsernameNavigation = new TblAccount() {
                    Username = email,
                    Password = password,
                    IsAdmin = 3,
                    },                  
                };
                bool result = repositoryTblCompany.CreateCompany(TblCompany);
                if (result)
                {
                    MessageBox.Show("Successfully added a new company", "Notification");
                    this.Close();
                }
            }
        }

        //Method: Thoát màn hình hiện tại
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
