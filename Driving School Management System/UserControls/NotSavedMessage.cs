﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_School_Management_System.UserControls
{
    public partial class NotSavedMessage : UserControl
    {
        public NotSavedMessage(string message)
        {
            InitializeComponent();
            this.Message.Text = message;
        }
    }
}
