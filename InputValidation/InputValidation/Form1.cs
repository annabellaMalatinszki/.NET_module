using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputValidation
{
    public partial class Form1 : Form
    {
        Validator validator = new Validator();

        public Form1()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!validator.ValidName(nameTextBox.Text))
            {
                MessageBox.Show("The name is invalid, only alphabetical characters are allowed");
            }

            if (!validator.ValidPhone(phoneTextBox.Text))
            {
                MessageBox.Show("The phone nummber is not a valid US phone number");
            }

            if (!validator.ValidEmail(emailTextBox.Text))
            {
                MessageBox.Show("The e-mail address is not valid");
            }

            phoneTextBox.Text = ReformatPhone(phoneTextBox.Text);

        }

        private string ReformatPhone(string phone)
        {
            Match m = Regex.Match(phone, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");

            return String.Format("({0}) {1}-{2}",
                         m.Groups[1],
                         m.Groups[2],
                         m.Groups[3]);
        }
    }
}
