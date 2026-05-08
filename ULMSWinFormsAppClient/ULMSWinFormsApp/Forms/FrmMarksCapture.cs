using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmMarksCapture : Form
    {
        public FrmMarksCapture()
        {
            InitializeComponent();
        }

        private void btnCalculateResults_Click(object sender, EventArgs e)
        {
            // Intentional weak validation and faulty average logic for testing purposes
            if (!double.TryParse(txtSubject1.Text, out double sub1) ||
                !double.TryParse(txtSubject2.Text, out double sub2) ||
                !double.TryParse(txtSubject3.Text, out double sub3))
            {
                MessageBox.Show("Please enter valid numeric marks.");
                return;
            }

            MarkRecord record = new MarkRecord();
            record.StudentId = txtMarkStudentId.Text;
            record.StudentName = txtMarkStudentName.Text;
            record.Subject1 = sub1;
            record.Subject2 = sub2;
            record.Subject3 = sub3;

            // Intentional faulty calculation - now corrected with brackets
            record.Average = (record.Subject1 + record.Subject2 + record.Subject3) / 3;

            if (record.Average >= 50)
            {
                record.ResultStatus = "PASS";
            }
            else
            {
                record.ResultStatus = "FAIL";
            }

            txtMarksOutput.Text =
                "Marks processed successfully!" + Environment.NewLine +
                "Student ID: " + record.StudentId + Environment.NewLine +
                "Student Name: " + record.StudentName + Environment.NewLine +
                "Subject 1: " + record.Subject1 + Environment.NewLine +
                "Subject 2: " + record.Subject2 + Environment.NewLine +
                "Subject 3: " + record.Subject3 + Environment.NewLine +
                "Average: " + record.Average + Environment.NewLine +
                "Final Result: " + record.ResultStatus;
        }

        private void btnClearMarks_Click(object sender, EventArgs e)
        {
            txtMarkStudentId.Clear();
            txtMarkStudentName.Clear();
            txtSubject1.Clear();
            txtSubject2.Clear();
            txtSubject3.Clear();
            txtMarksOutput.Clear();
            txtMarkStudentId.Focus();
        }

        private void btnBackMarks_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}