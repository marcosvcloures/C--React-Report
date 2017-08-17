using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReportHTML
{
    public class ReportHTML
    {
        private string vars_json;

        private string vars
        {
            get
            {
                if (vars_json != string.Empty)
                    return "data={" + vars_json.Remove(vars_json.Length - 1) + "}";

                throw new Exception("vars empty!");
            }
        }

        public ReportHTML()
        {
            vars_json = string.Empty;
        }

        public void add_variable(string name, object variable)
        {
            vars_json += name + ":" + JsonConvert.SerializeObject(variable) + ",";

            return;
        }

        public void set_report(string report_filename)
        {
            var report = new StreamReader(report_filename);

            var report_jsx = report.ReadToEnd();

            report_jsx = report_jsx.Replace("class=", "className=").Replace("class =", "className=").Replace("class  =", "className=");

            report.Dispose();
            report.Close();

            var data = new StreamWriter(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location) + @"\Reporting\data.js", false);

            data.Write(vars);

            data.Flush();
            data.Dispose();
            data.Close();

            var old_html = new StreamReader(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location) + @"\Reporting\report_original.html");

            var ord_html_data = old_html.ReadToEnd();

            old_html.Dispose();
            old_html.Close();

            var html = new StreamWriter(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location) + @"\Reporting\report.html", false);

            html.Write(ord_html_data.Replace("%report%", report_jsx));

            html.Flush();
            html.Dispose();
            html.Close();
        }

        public void Show()
        {
            Process.Start(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location) + @"\Reporting\report.html");
        }
    }
}
