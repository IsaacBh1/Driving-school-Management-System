using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Driving_School_Management_System.Forms
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            chart1.Titles.Add("الملفات لكل رخصة سياقة");
            chart1.Series[0].IsValueShownAsLabel = true;
            chart1.Series[0].Points.AddXY("A", "20"); 
            chart1.Series[0].Points.AddXY("B", "40"); 
            chart1.Series[0].Points.AddXY("AB", "35"); 
            chart1.Series[0].Points.AddXY("C", "5");
            
        }

     
    }
}
