using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportHTML_Test
{
    public partial class Example
    {
        public struct test_struct
        {
            public string dona;
            public int qualidade;
        };

        public Example()
        {
            List<int> int_list = new List<int>(new int[] { 1, 2, 3, 4 });
            List<test_struct> struct_list = new List<test_struct>();

            struct_list.Add(new Example.test_struct { dona = "Fst", qualidade = 5 });
            struct_list.Add(new Example.test_struct { dona = "Snd", qualidade = 0 });

            var report = new ReportHTML.ReportHTML();

            report.add_variable(nameof(int_list), int_list);
            report.add_variable(nameof(struct_list), struct_list);

            report.set_report(@"\Report.jsx");

            report.Show();
        }
    }
}
