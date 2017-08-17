using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportHTML_Test
{
    public partial class Form1 : Form
    {
        public struct test_struct
        {
            public string dona;
            public int qualidade;
        };

        public Form1()
        {
            InitializeComponent();

            List<int> int_list = new List<int>(new int[] { 1, 2, 3, 4 });
            List<test_struct> struct_list = new List<test_struct>();

            struct_list.Add(new Form1.test_struct { dona = "hehehe", qualidade = 5 });
            struct_list.Add(new Form1.test_struct { dona = "marcelo", qualidade = 0 });

            var cu = new ReportHTML.ReportHTML();

            cu.add_variable(nameof(int_list), int_list);
            cu.add_variable(nameof(struct_list), struct_list);

            cu.set_report(@"D:\Desktop\teste.jsx");

            cu.Show();
        }
    }
}
