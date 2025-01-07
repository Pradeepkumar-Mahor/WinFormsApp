using Sensia.HCC2.SDK.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class FrmHCC2 : Form
    {
        public FrmHCC2()
        {
            InitializeComponent();
        }

        public void ReadDataUsingHCC2()
        {
            var realtimeControl = new RealtimeControl();
        }
    }
}