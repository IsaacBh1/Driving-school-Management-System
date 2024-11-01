using Driving_school_BusinessLayer;
using Driving_School_Management_System.ShowInformationsForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class CondidateFileWindow : Form
    {


        private ContextMenuStrip contextMenuFile;
        private int selectedId = -1;
        private StatusMessageForm statusMessageForm;
        public CondidateFileWindow()
        {
            InitializeComponent();
            _initializeDrivingLicenseTypeCbox();
            DisplayCondidteFilesInformations(clsCondidateFile.GetAllCondidateFileInformations());
            InitializeContextMenuFile();
            DGVFiles.CellMouseClick += DGVFiles_CellMouseClick;



        }

        private void InitializeContextMenuFile()
        {
            contextMenuFile = new ContextMenuStrip();
            // Add menu items dynamically
            var ViewFileInformationsItem = new ToolStripMenuItem("إظهار معلومات الملف", Properties.Resources.eye);
            ViewFileInformationsItem.Click += ViewFileInformations_Click; // Define what happens when "Edit" is clicked

            var EditFileInformationsItem = new ToolStripMenuItem("تعديل معلومات الملف", Properties.Resources.gear);
            EditFileInformationsItem.Click += EditFileInformations_Click;

            var DeleteFileItem = new ToolStripMenuItem("حذف الملف", Properties.Resources.trash__1_);
            DeleteFileItem.Click += DeleteFileInformations_Click;

            var AddFilePayment = new ToolStripMenuItem("إضافة دفعة", Properties.Resources.file_bold);
            AddFilePayment.Click += AddFilePayment_Click;

            var AddFileExam = new ToolStripMenuItem("إضافة امتحان", Properties.Resources.exam);
            AddFileExam.Click += AddFileExam_Click;

            var DownloadFileInformationsItem = new ToolStripMenuItem("تنزيل معلومات الملف", Properties.Resources.download_simple);
            DownloadFileInformationsItem.Click += DownloadFileInformations_Click;


            contextMenuFile.Items.Add(ViewFileInformationsItem);
            contextMenuFile.Items.Add(EditFileInformationsItem);
            contextMenuFile.Items.Add(DeleteFileItem);
            contextMenuFile.Items.Add(AddFileExam);
            contextMenuFile.Items.Add(AddFilePayment);
            contextMenuFile.Items.Add(DownloadFileInformationsItem);
        }

        private void DownloadFileInformations_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddFilePayment_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _initializeDrivingLicenseTypeCbox()
        {
            CboxDrivingLisence.DataSource = clsDrivingLicenseType.GetAllNames().DefaultView;
            CboxDrivingLisence.DisplayMember = "Name";
        }
        public void DisplayCondidteFilesInformations(DataTable AllFiles)
        {
            DGVFiles.Rows.Clear();
            foreach (DataRow row in AllFiles.Rows)
            {
                DGVFiles.Rows.Add(row[0], row[1], row[2], row[3], _getFileStatus(row[4].ToString()), _getStudentStatus(row[5].ToString()), row[6], row[7]);
            }
        }



        private void AddFileExam_Click(object sender, EventArgs e)
        {
            // add exam to file feature 
            throw new NotImplementedException();
        }

        private void DeleteFileInformations_Click(object sender, EventArgs e)
        {
            YesNoDesisionForm yesNoForm = new YesNoDesisionForm("هل تريد حذف الملف ؟");
            yesNoForm.DoOperationEventHundler += DeleteFile;
            yesNoForm.ShowDialog();
        }

        private void DeleteFile()
        {
            clsCondidateFile FileToDelete = clsCondidateFile.Find(selectedId);

            if (!(FileToDelete is null) && (clsExam.DeleteExamByCondidatefile(FileToDelete.CandidateFileID)) && (clsCondidateFile.DeleteCondidateFile(FileToDelete.CandidateFileID)))
            {
                statusMessageForm = new StatusMessageForm("Operation done Successfully");
                statusMessageForm.ShowSuccess();
                DisplayCondidteFilesInformations(clsCondidateFile.GetAllCondidateFileInformations());
            }
            else
            {
                statusMessageForm = new StatusMessageForm("Operation Failed");
                statusMessageForm.ShowFailed();
            }
        }

        private void EditFileInformations_Click(object sender, EventArgs e)
        {
            AddCondidateFileForm condidateFileForm = new AddCondidateFileForm(selectedId, false);
            condidateFileForm.ShowDialog();
        }

        private void ViewFileInformations_Click(object sender, EventArgs e)
        {
            ShowFileInformations fileinfoForm = new ShowFileInformations(selectedId);
            fileinfoForm.ShowDialog();
        }



        private void btnAddCondidtefile_Click(object sender, EventArgs e)
        {
            AddCondidateFileForm CondidateFileForm = new AddCondidateFileForm();
            CondidateFileForm.OnCondidateFileAddedEventHundler += OnCondidateFileAdded;
            CondidateFileForm.ShowDialog();
        }

        private void OnCondidateFileAdded()
        {
            DisplayCondidteFilesInformations(clsCondidateFile.GetAllCondidateFileInformations());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DisplayCondidteFilesInformations(clsCondidateFile.GetAllCondidateFileInformations());
        }

        private void btnSSearchCondidteFIle_Click(object sender, EventArgs e)
        {
            SearchFieldCondidteFile();
        }



        private string _getFileStatus(string s) => s == "False" ? "نشط" : "مؤرشف";
        private string _getStudentStatus(string s) => s == "True" ? "نشط" : "منقطع";
        private bool _getIsActive(string s) => s == "نشط" ? true : false;
        private bool _getIsArchived(string s) => s == "مؤرشف" ? true : false;


        private void DGVFiles_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGVFiles.Rows[e.RowIndex].Cells[0].Value is null) return;

            if (e.RowIndex >= 0 && (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) && e.ColumnIndex == 8) // Check for right-click
            {
                var cellRect = DGVFiles.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                selectedId = Convert.ToInt32(DGVFiles.Rows[e.RowIndex].Cells[0].Value);
                Point menuLocation = DGVFiles.PointToScreen(new Point(cellRect.X, cellRect.Y + cellRect.Height));
                // Show the context menu at the calculated location
                contextMenuFile.Show(menuLocation);
            }
        }

        private void SearchFieldCondidteFile()
        {
            try
            {

                switch (CboxFilterCondidtateFile.Text.ToString())
                {

                    case "الاسم":
                        DisplayCondidteFilesInformations(clsCondidateFile.SearchCondidatesFileInfoFirstName_Arabic(textBoxFName_Arabic.Text));
                        break;
                    case "النسب":
                        DisplayCondidteFilesInformations(clsCondidateFile.SearchCondidatesFileInfoLastName_Arabic(textBoxLName_Arabic.Text));
                        break;
                    case "ID":
                        if (int.TryParse(textBoxID.Text.ToString(), out int ID))
                            DisplayCondidteFilesInformations(clsCondidateFile.SearchCondidateFileInfoByID(ID.ToString()));
                        break;
                    case "الكل":
                        if (int.TryParse(textBoxID.Text.ToString(), out int Id))
                            DisplayCondidteFilesInformations(clsCondidateFile.SearchByAll(Id, textBoxFName_Arabic.Text, textBoxLName_Arabic.Text, CboxDrivingLisence.Text, _getIsArchived(CboxFileStatus.Text), _getIsActive(CboxStudentStatus.Text)));
                        break;
                    case "الرخصة":
                        DisplayCondidteFilesInformations(clsCondidateFile.SearchCondidtesFilesByDrivingLisence(CboxDrivingLisence.Text));
                        break;
                    case "حالة الملف":
                        DisplayCondidteFilesInformations(clsCondidateFile.SearchArchivedStudentsFiles(_getIsArchived(CboxFileStatus.Text)));
                        break;
                    case "وضع المرشح":
                        DisplayCondidteFilesInformations(clsCondidateFile.SearchActiveStudentsFiles(_getIsActive(CboxStudentStatus.Text)));
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

    }

}
