using Driving_school_BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class ExamsWindow : Form
    {

        ContextMenuStrip contextExam = null;
        private int selectedId = -1;
        StatusMessageForm statusMessageForm; 
        public ExamsWindow()
        {
            InitializeComponent();
            DisplayExamsInformations(clsExam.GetAllExamInformations());
            InetializeLessonMenu();
            DGVExams.CellMouseClick += DGVExam_CellMouseClick; 
        }

        private void DGVExam_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > 0 && DGVExams.Rows[e.RowIndex].Cells[0].Value is null) return;// this gives me an error here 
            if ((e.RowIndex >= 0) && (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) && e.ColumnIndex == 6)
            {
                var cellRect = DGVExams.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                selectedId = Convert.ToInt32(DGVExams.Rows[e.RowIndex].Cells[0].Value);
                Point menuLocation = DGVExams.PointToScreen(new Point(cellRect.X, cellRect.Y + cellRect.Height));
                // Show the context menu at the calculated location
                contextExam.Show(menuLocation);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddExamForm examForm = new AddExamForm();
            examForm.OnExamAddedEventHundler += RefreshExams;
            examForm.ShowDialog();
        }

        private void RefreshExams()
        {
            DisplayExamsInformations(clsExam.GetAllExamInformations());
        }
        private void InetializeLessonMenu()
        {
            contextExam= new ContextMenuStrip();
            var deleteLessonItem = new ToolStripMenuItem("حذف الامتحان", Properties.Resources.trash__1_);
            deleteLessonItem.Click += DeleteExam_Click;
            //var deleteExamItem = new ToolStripMenuItem("عرض معلومات الامتحان", Properties.Resources.exam);
            //deleteExamItem.Click += DeleteExam_Click;
            var UpdateExamItem = new ToolStripMenuItem("تعديل نتائج الامتحان", Properties.Resources.gear);
            UpdateExamItem.Click += UpdateExam_Click;
            /*var deleteLessonItem = new ToolStripMenuItem("حذف الدرس", Properties.Resources.trash__1_);
            deleteLessonItem.Click += DeleteExam_Click;*/
            //var ShowLessonItem = new ToolStripMenuItem("ShowLessonInfos", Properties.Resources.trash__1_);
            //ShowLessonItem.Click += ShowLesson_Click;
            contextExam.Items.Add(deleteLessonItem);
            //contextExam.Items.Add(deleteExamItem);
            contextExam.Items.Add(UpdateExamItem);

            //contextLesson.Items.Add(ShowLessonItem);
        }

        private void UpdateExam_Click(object sender, EventArgs e)
        {
            AddExamForm addExamForm = new AddExamForm(selectedId, true);
            addExamForm.OnExamAddedEventHundler += UpdateExamWindow;  
            addExamForm.ShowDialog(); 
        }

        private void UpdateExamWindow()
        {
           DisplayExamsInformations(clsExam.GetAllExamInformations());

        }

        private void DeleteExam_Click(object sender, EventArgs e)
        {
            YesNoDesisionForm yesNoForm = new YesNoDesisionForm("هل تريد حذف الامتحان؟");
            yesNoForm.DoOperationEventHundler += DeleteExam;
            yesNoForm.ShowDialog();
        }


        private void DeleteExam()
        {

            clsExam exam = clsExam.Find(selectedId);
            if ((!(exam is null)) && clsExam.DeleteExam(selectedId))
            {
                statusMessageForm = new StatusMessageForm("Operation done Successfully");
                statusMessageForm.ShowSuccess();
                DisplayExamsInformations(clsExam.GetAllExamInformations());

            }
        }
       


        private void DisplayExamsInformations(DataTable AllExams)
        {
            DGVExams.Rows.Clear();
            foreach (DataRow row in AllExams.Rows)
                DGVExams.Rows.Add(row[0] ,row[1] ,row[2] ,row[3], clsExam.GetExamType((int)row[4]),row[5]); 

        }

        private void MakeFieldsEmpty()
        {
            txtBoxID.Text = string.Empty;
            textbxCondidateFileID.Text = string.Empty ; 
        }

        private void DisplayExamsInformationsByField()
        {
            switch (CBoxExamsFilter.Text)
            {
                case "ID":
                    if (int.TryParse(txtBoxID.Text, out int ID))
                        DisplayExamsInformations(clsExam.GetExamsByID(ID)); 
                    break;
                case "الملف":
                    if (int.TryParse(textbxCondidateFileID.Text, out int CondidateFileID))
                        DisplayExamsInformations(clsExam.GetExamsByCondidateFile(CondidateFileID)); 
                    break;
                case "نوع الامتحان":
                    DisplayExamsInformations(clsExam.GetExamsByExamType(clsExam.GetExamType(CboxExamType.Text))); 
                    break;
                case "الحالة":
                    DisplayExamsInformations(clsExam.GetExamsByStatus(cboxStatus.Text)); 
                    break; 
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DisplayExamsInformations(clsExam.GetAllExamInformations());
        }

        private void btnSearchLesson_Click(object sender, EventArgs e)
        {
            DisplayExamsInformationsByField(); 
            MakeFieldsEmpty(); 
        }
    }
}
