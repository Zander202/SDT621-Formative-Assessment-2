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
    public partial class FrmCourseEnrollment : Form
    {
        // Added list to track enrollments and prevent duplicates
        private List<string> enrolledCourses = new List<string>();

        public FrmCourseEnrollment()
        {
            InitializeComponent();
        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            // Intentional weak business-rule validation for testing purposes
            string enrollmentKey = txtEnrollStudentId.Text + "_" + cmbCourse.Text + "_" + cmbSemester.Text;

            if (enrolledCourses.Contains(enrollmentKey))
            {
                MessageBox.Show("This student is already enrolled in this course for this semester.");
                return;
            }

            Enrollment enrollment = new Enrollment
            {
                StudentId = txtEnrollStudentId.Text,
                StudentName = txtEnrollStudentName.Text,
                CourseName = cmbCourse.Text,
                Semester = cmbSemester.Text
            };

            // Add to enrolled list to prevent duplicates
            enrolledCourses.Add(enrollmentKey);

            txtEnrollmentOutput.Text =
                "Enrollment completed successfully!" + Environment.NewLine +
                "Student ID: " + enrollment.StudentId + Environment.NewLine +
                "Student Name: " + enrollment.StudentName + Environment.NewLine +
                "Course: " + enrollment.CourseName + Environment.NewLine +
                "Semester: " + enrollment.Semester;
        }

        private void btnClearEnrollment_Click(object sender, EventArgs e)
        {
            txtEnrollStudentId.Clear();
            txtEnrollStudentName.Clear();
            cmbCourse.SelectedIndex = -1;
            cmbSemester.SelectedIndex = -1;
            txtEnrollmentOutput.Clear();
            txtEnrollStudentId.Focus();
        }

        private void btnBackEnrollment_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}