﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string[] GetData(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.ReadLine() != null)
                {

                }
            }
        }
    }
}
