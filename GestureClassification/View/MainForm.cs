using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestureClassification.Model;
namespace GestureClassification.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Matrix a = new Matrix(2, 2);
            a[0, 0] = 4;
            a[0, 1] = 7;
            a[1, 0] = 2;
            a[1, 1] = 6;
           Matrix y= a.Invert();
           Matrix id = a*y;
           int f = 5;
        }
    }
}
