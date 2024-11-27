using Driving_School_Management_System.Forms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Driving_School_Management_System
{
    public partial class MainForm : Form
    {
        const float SpeedPerSecond = 1000f / 30;
        const int BarWidth = 40;

        float _xPosition = 0;
        TimeSpan _lastFrameTime = TimeSpan.Zero;
        readonly Stopwatch _frameTimer = Stopwatch.StartNew();

        private bool _sideBarExpanded = true;
      



        int _tabIndex = 0;
        int _previousTabIndex = -1;

        // Array to hold references to forms
        private readonly Form[] _windows = new Form[12];

        public MainForm()
        {
            InitializeComponent();
            ShowWindow<MainWindow>(ref _windows[0]);
            DoubleBuffered = true;

       


        }

            
          
        

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            TimeSpan currentFrameTime = _frameTimer.Elapsed;
            float distance = (float)(currentFrameTime - _lastFrameTime).TotalSeconds * SpeedPerSecond;

            _xPosition = (_xPosition + distance) % this.Width;
            e.Graphics.FillRectangle(Brushes.Black, _xPosition, 0, BarWidth, ClientSize.Height);

            _lastFrameTime = currentFrameTime;
            Invalidate(); // Triggers repaint for smooth animation
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            ToggleSidebar();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ShowWindow<T>(ref Form form) where T : Form, new()
        {
            if (form == null)
            {
                form = new T { MdiParent = this, Dock = DockStyle.Fill };
                form.Show();
            }
            else
            {
                form.Activate();
            }
            UpdateTabColors();
        }

        private void UpdateTabColors()
        {
            SetButtonColor(_previousTabIndex, Color.Transparent);
            SetButtonColor(_tabIndex, ColorTranslator.FromHtml("#E5AF1D"));
        }

        private void SetButtonColor(int index, Color color)
        {
            Button[] buttons = {
                btnMain, btnCondidtes, btnFiles, btnLessons, btnExams, btnFinance,
                btnBoxBank, btnExpences, btnCars, btnInstructors, null, btnSettings
            };
            if (index >= 0 && index < buttons.Length && buttons[index] != null)
            {
                buttons[index].BackColor = color;
            }
        }

        private void ToggleSidebar()
        {
            _sideBarExpanded = !_sideBarExpanded;
            SideBar.Width = _sideBarExpanded ? 237 : 52;
            UserNamePanel.Visible = _sideBarExpanded;

        }

        #region Event Handlers
        private void btnMain_Click(object sender, EventArgs e) => SwitchTab(0, ref _windows[0], () => new MainWindow());
        private void btnCondidtes_Click(object sender, EventArgs e) => SwitchTab(1, ref _windows[1], () => new CondidatesWindow());
        private void btnFiles_Click(object sender, EventArgs e) => SwitchTab(2, ref _windows[2], () => new CondidateFileWindow());
        private void btnLessons_Click(object sender, EventArgs e) => SwitchTab(3, ref _windows[3], () => new LessonsWindow());
        private void btnExams_Click(object sender, EventArgs e) => SwitchTab(4, ref _windows[4], () => new ExamsWindow());
        private void btnFinance_Click(object sender, EventArgs e) => SwitchTab(5, ref _windows[5], () => new PaymentWindow());
        private void btnBoxBank_Click(object sender, EventArgs e) => SwitchTab(6, ref _windows[6], () => new BoxWindow());
        private void btnExpences_Click(object sender, EventArgs e) => SwitchTab(7, ref _windows[7], () => new ExpencesWindow());
        private void btnCars_Click(object sender, EventArgs e) => SwitchTab(8, ref _windows[8], () => new CarsWindow());
        private void btnInstructors_Click(object sender, EventArgs e) => SwitchTab(9, ref _windows[9], () => new InstructorsWindow());
        private void btnSettings_Click(object sender, EventArgs e) => SwitchTab(11, ref _windows[11], () => new Settings());
        #endregion

        private void SwitchTab(int newTabIndex, ref Form form, Func<Form> formFactory)
        {
            if (_tabIndex == newTabIndex) return; // No need to switch if it's the same tab
            _previousTabIndex = _tabIndex;
            _tabIndex = newTabIndex;

            if (form == null)
            {
                form = formFactory();
                form.MdiParent = this;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
            else
            {
                form.Activate();
            }

            UpdateTabColors();
        }

        private void btnclose_Click_1(object sender, EventArgs e)
        {
            Close(); 
        }

       
    }
}


/*using Driving_School_Management_System.Forms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Driving_School_Management_System
{
    public partial class MainForm : Form
    {
        const float SpeedPerSecond = 1000f / 30;
        const int BarWidth = 40;

        float _xPosition = 0;
        TimeSpan _lastFrameTime = TimeSpan.Zero;
        readonly Stopwatch _frameTimer = Stopwatch.StartNew();

        int _tabIndex = 1;
        int _previousTabIndex = -1;

        readonly Form[] _windows = new Form[12]; // Array to hold references to forms
        bool _sideBarExpanded = true;

        public MainForm()
        {
            InitializeComponent();
            ShowWindow<MainWindow>(ref _windows[0]);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            TimeSpan currentFrameTime = _frameTimer.Elapsed;
            float distance = (float)(currentFrameTime - _lastFrameTime).TotalSeconds * SpeedPerSecond;

            _xPosition = (_xPosition + distance) % this.Width;
            e.Graphics.FillRectangle(Brushes.Black, _xPosition, 0, BarWidth, ClientSize.Height);

            _lastFrameTime = currentFrameTime;
            Invalidate(); // Triggers repaint for smooth animation
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            ToggleSidebar();
        }

        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();

        private void btnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void ShowWindow<T>(ref Form form) where T : Form, new()
        {
            if (form == null)
            {
                form = new T { MdiParent = this, Dock = DockStyle.Fill };
                form.Show();
            }
            else
            {
                form.Activate();
            }
            UpdateTabColors();
        }

        private void UpdateTabColors()
        {
            SetButtonColor(_previousTabIndex, Color.Transparent);
            SetButtonColor(_tabIndex, ColorTranslator.FromHtml("#E5AF1D"));
        }

        private void SetButtonColor(int index, Color color)
        {
            Button[] buttons =
            {
                btnMain, btnCondidtes, btnFiles, btnLessons, btnExams, btnFinance,
                btnBoxBank, btnExpences, btnCars, btnInstructors, null, btnSettings
            };
            if (index >= 0 && index < buttons.Length && buttons[index] != null)
            {
                buttons[index].BackColor = color;
            }
        }

        private void ToggleSidebar()
        {
            _sideBarExpanded = !_sideBarExpanded;
            SideBar.Width = _sideBarExpanded ? 237 : 52;
            UserNamePanel.Visible = _sideBarExpanded;
        }

        #region Event Handlers
        private void btnMain_Click(object sender, EventArgs e) => SwitchTab(0, ref _windows[0], typeof(MainWindow));
        private void btnCondidtes_Click(object sender, EventArgs e) => SwitchTab(1, ref _windows[1], typeof(CondidatesWindow));
        private void btnFiles_Click(object sender, EventArgs e) => SwitchTab(2, ref _windows[2], typeof(CondidateFileWindow));
        private void btnLessons_Click(object sender, EventArgs e) => SwitchTab(3, ref _windows[3], typeof(LessonsWindow));
        private void btnExams_Click(object sender, EventArgs e) => SwitchTab(4, ref _windows[4], typeof(ExamsWindow));
        private void btnFinance_Click(object sender, EventArgs e) => SwitchTab(5, ref _windows[5], typeof(PaymentWindow));
        private void btnBoxBank_Click(object sender, EventArgs e) => SwitchTab(6, ref _windows[6], typeof(BoxWindow));
        private void btnExpences_Click(object sender, EventArgs e) => SwitchTab(7, ref _windows[7], typeof(ExpencesWindow));
        private void btnCars_Click(object sender, EventArgs e) => SwitchTab(8, ref _windows[8], typeof(CarsWindow));
        private void btnInstructors_Click(object sender, EventArgs e) => SwitchTab(9, ref _windows[9], typeof(InstructorsWindow));
        private void btnSettings_Click(object sender, EventArgs e) => SwitchTab(11, ref _windows[11], typeof(Settings));
        #endregion

        private void SwitchTab(int newTabIndex, ref Form form, Type formType)
        {
            if (_tabIndex == newTabIndex) return; // No need to switch if it's the same tab
            _previousTabIndex = _tabIndex;
            _tabIndex = newTabIndex;
            ShowWindow(formType, ref form);
        }

        private void ShowWindow(Type formType, ref Form form)
        {
            if (form == null)
            {
                form = (Form)Activator.CreateInstance(formType);
                form.MdiParent = this;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
            else
            {
                form.Activate();
            }
            UpdateTabColors();
        }
    }
}



*/
/*
using Driving_School_Management_System.Forms;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Driving_School_Management_System
{
    public partial class MainForm : Form
    {


        const float speedXPerSecond = 1000f / 30;
        const int bar_width = 40;

        float x_position = 0;
        TimeSpan _lastFrameTime = TimeSpan.Zero;
        Stopwatch _frameTimer = Stopwatch.StartNew();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            TimeSpan currentFrameTime = _frameTimer.Elapsed;
            float distance = (float)(currentFrameTime - _lastFrameTime).TotalSeconds * speedXPerSecond;

            x_position += distance;
            while (x_position > this.Width) x_position -= this.Width;
            e.Graphics.FillRectangle(Brushes.Black, x_position, 0, bar_width, 500);
            _lastFrameTime = currentFrameTime;

            Invalidate();
        }





        int tabIndex = 1;
        int previousTabIndex = -1;
        MainWindow mainWindow = null;
        CondidatesWindow condidatesWindow = null;
        LessonsWindow lessonsForm = null;
        ExamsWindow examsWindow = null;
        CarsWindow carsWindow = null;
        InstructorsWindow instructorsWindow = null;
        PaymentWindow paymentWindow = null;
        BoxWindow boxWindow = null;
        ExpencesWindow expencesWindow = null;
        CondidateFileWindow condidateFileWindow = null;
        Settings settings = null;
        public MainForm()
        {
            InitializeComponent();
            ShowWindow<MainWindow>(mainWindow);
            DoubleBuffered = true;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        bool SideBarExpand = true;
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (SideBarExpand)
            {
                UserNamePanel.Visible = false;
                SideBar.Width = 52;
                SideBarExpand = false;
            }
            else
            {
                UserNamePanel.Visible = true;
                SideBar.Width = 237;
                SideBarExpand = true;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void ShowWindow<FormType>(Form form) where FormType : Form, new()
        {
            if (form is null)
            {
                form = new FormType();
                form.MdiParent = this;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
            else
            {
                form.Activate();
            }
            updateTabColor();

        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 1;
            ShowWindow<MainWindow>(mainWindow);

        }



        private void btnCondidtes_Click(object sender, EventArgs e)
        {

            previousTabIndex = tabIndex;
            tabIndex = 2;
            //ShowCondidatesWindow(); 
            ShowWindow<CondidatesWindow>(condidatesWindow);
        }



        private void updateTabColor()
        {
            ChangeTabPrevButtonColor();
            ChangeTabCurrentButtonColor();
        }

        private void ChangeTabCurrentButtonColor()
        {
            switch (tabIndex)
            {
                case 1:
                    btnMain.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 2:
                    btnCondidtes.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 3:
                    btnFiles.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 4:
                    btnLessons.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 5:
                    btnExams.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 6:
                    btnFinance.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 7:
                    btnBoxBank.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 8:
                    btnExpences.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 9:
                    btnCars.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 10:
                    btnInstructors.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;
                case 12:
                    btnSettings.BackColor = ColorTranslator.FromHtml("#E5AF1D");
                    break;

                    //btnSettings
            }
        }


        private void ChangeTabPrevButtonColor()
        {
            switch (previousTabIndex)
            {
                case 1:
                    btnMain.BackColor = Color.Transparent;
                    break;
                case 2:
                    btnCondidtes.BackColor = Color.Transparent;
                    break;
                case 3:
                    btnFiles.BackColor = Color.Transparent;
                    break;
                case 4:
                    btnLessons.BackColor = Color.Transparent;
                    break;
                case 5:
                    btnExams.BackColor = Color.Transparent;
                    break;

                case 6:
                    btnFinance.BackColor = Color.Transparent;
                    break;
                case 7:
                    btnBoxBank.BackColor = Color.Transparent;
                    break;
                case 8:
                    btnExpences.BackColor = Color.Transparent;
                    break;
                case 9:
                    btnCars.BackColor = Color.Transparent;
                    break;
                case 10:
                    btnInstructors.BackColor = Color.Transparent;
                    break;
                case 12:
                    btnSettings.BackColor = Color.Transparent;
                    break;
            }
        }

        private void btnLessons_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 4;
            ShowWindow<LessonsWindow>(lessonsForm);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Lessons_Exams lessons_Exams = new Lessons_Exams();
            lessons_Exams.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 5;
            ShowWindow<ExamsWindow>(examsWindow);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 9;
            ShowWindow<CarsWindow>(carsWindow);
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 10;
            ShowWindow<InstructorsWindow>(instructorsWindow);
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 6;
            ShowWindow<PaymentWindow>(paymentWindow);
        }

        private void btnBoxBank_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 7;
            ShowWindow<BoxWindow>(boxWindow);
        }

        private void btnExpences_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 8;
            ShowWindow<ExpencesWindow>(expencesWindow);
        }

        private void btnFiles_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 3;
            ShowWindow<CondidateFileWindow>(condidateFileWindow);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            previousTabIndex = tabIndex;
            tabIndex = 12;
            ShowWindow<Settings>(settings);
        }
    }
}
*/