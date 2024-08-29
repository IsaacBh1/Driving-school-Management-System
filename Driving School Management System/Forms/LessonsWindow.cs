﻿using Driving_school_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class LessonsWindow : Form
    {
        public LessonsWindow()
        {
            InitializeComponent();
            DisplayCondidteFilesInformations(clsLesson.GetAllLessons()); 
        }


        public void DisplayCondidteFilesInformations(DataTable AllLessons)
        {
            DGVLessons.Rows.Clear();
            foreach (DataRow row in AllLessons.Rows)
            {
                string DurationTime =row["DurationHours"].ToString() + ":" + row["DurationMin"] ;  
                DGVLessons.Rows.Add(row[0], clsGroup.GetGroupNameByID ((int)row[7]),clsInstructor.GetInsreuctorUserNameByID((int)row[6]), row[1], row[2] , DurationTime);
            }
            
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            AddLessonForm form = new AddLessonForm();
            form.ShowDialog();
        }
        //refersh btn
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DisplayCondidteFilesInformations(clsLesson.GetAllLessons());

        }
    }
}