using Driving_school_BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class LessonsWindow : Form
    {


        private ContextMenuStrip contextLesson;
        private int selectedId;
        private StatusMessageForm statusMessageForm; 
        public LessonsWindow()
        {
            InitializeComponent();
            _initializeGroupsCbox();
            DisplayLessonInformations(clsLesson.GetAllLessons());
            DGVLessons.CellMouseClick += DGVLessons_CellMouseClick;
            InetializeLessonMenu();
        }

        private void DGVLessons_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGVLessons.Rows[e.RowIndex].Cells[0].Value is null) return;
            if((e.RowIndex >= 0 )&& (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) && e.ColumnIndex == 7)
            {
                var cellRect = DGVLessons.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                selectedId = Convert.ToInt32(DGVLessons.Rows[e.RowIndex].Cells[0].Value);
                Point menuLocation = DGVLessons.PointToScreen(new Point(cellRect.X, cellRect.Y + cellRect.Height));
                // Show the context menu at the calculated location
                contextLesson.Show(menuLocation);
            }
        }

        private void InetializeLessonMenu()
        {
            contextLesson = new ContextMenuStrip();
            var deleteLessonItem = new ToolStripMenuItem("حذف الدرس" , Properties.Resources.trash__1_);
            deleteLessonItem.Click += DelteLesson_Click;
            var ShowLessonItem = new ToolStripMenuItem("ShowLessonInfos", Properties.Resources.trash__1_);
            ShowLessonItem.Click += ShowLesson_Click;
            contextLesson.Items.Add(deleteLessonItem); 
            contextLesson.Items.Add(ShowLessonItem);
        }

        private void ShowLesson_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DelteLesson_Click(object sender, EventArgs e)
        {
            // this is the code of deleting the lesson  
            clsLesson lessonSelected = clsLesson.Find(selectedId);
            if (!(lessonSelected is null) &&clsLesson.DelteLesson(lessonSelected.LessonID))
            {
                statusMessageForm = new StatusMessageForm("Lesson deleted Successfully");
                statusMessageForm.ShowSuccess();
                DisplayLessonInformations(clsLesson.GetAllLessons());

            }
            else
            {
                statusMessageForm = new StatusMessageForm("operation failed");
                statusMessageForm.ShowFailed();
            };
        }

        public void DisplayLessonInformations(DataTable AllLessons)
        {
            DGVLessons.Rows.Clear();
            foreach (DataRow row in AllLessons.Rows)
            {
                TimeSpan DurationTime =  (TimeSpan)row["TimeOfLesson"];  
                TimeSpan date = new TimeSpan( (int)row[4] , (int)row[5] ,0 );
                DGVLessons.Rows.Add(row[0], 
                    clsGroup.GetGroupNameByID ((int)row[7]),
                    clsInstructor.GetInsreuctorUserNameByID((int)row[6]), 
                    row[1], 
                    row[2],
                    date,
                    DurationTime);
            }
            
        }

        private void _initializeGroupsCbox()
        {
            CbxGroup.DataSource = clsGroup.GetAllGroupsNames().DefaultView;
            CbxGroup.DisplayMember = "Name";
        }

        private void mekeSearchFieldsEmpty()
        {
            txtBoxID.Text = string.Empty;
            CbxGroup.Text = string.Empty;
            CboxLessonType.Text = string.Empty; 
        }


        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            AddLessonForm form = new AddLessonForm();
            form.OnLessonsAddedEventHundler += RefreshLessons; 
            form.ShowDialog();
        }

        private void RefreshLessons()
        {
            DisplayLessonInformations(clsLesson.GetAllLessons());
        }

        //refersh btn
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DisplayLessonInformations(clsLesson.GetAllLessons());
            mekeSearchFieldsEmpty(); 
        }

        private void searchLessonField()
        {
            try
            {

                switch (CBoxLessonFilter.Text.ToString())
                {
                    case "ID":
                        if (int.TryParse(txtBoxID.Text, out int ID))
                            DisplayLessonInformations(clsLesson.SearchLessonByID(ID)); 
                        break;
                    case "المجموعة":
                        DisplayLessonInformations(clsLesson.SearchLessonByGroup(CbxGroup.Text));
                        break;

                    case "نوع الدرس":
                        DisplayLessonInformations(clsLesson.SearchLessonByLessonType(CboxLessonType.Text));
                        break;
                }

            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSearchLesson_Click(object sender, EventArgs e)
        {
            searchLessonField();
        }
        
    }
}
