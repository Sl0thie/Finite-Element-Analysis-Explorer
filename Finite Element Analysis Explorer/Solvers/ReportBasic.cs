namespace Finite_Element_Analysis_Explorer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.Storage;

    internal class ReportBasic
    {
        StorageFile tempFile = null;
        StringBuilder sb = new StringBuilder();

        internal async Task CreateReportAsync()
        {
            await CreateSimpleHTMLAsync();

            Model.IsReportBasic = true;
        }

        private async Task CreateSimpleHTMLAsync()
        {
            // Debug.WriteLine(FileManager.LocalFolder.Path);

            await CreateFolderAndFileAsync();
            CreateHTML();
            AddPrimaryTitle();
            AddSections();
            AddMembers();
            FinalizeHTML();
            await SaveFileAsync();
        }

        private async Task CreateFolderAndFileAsync()
        {
            try
            {
                StorageFolder reportsFolder = await FileManager.LocalFolder.CreateFolderAsync("Reports", CreationCollisionOption.ReplaceExisting);
                tempFile = await reportsFolder.CreateFileAsync("ReportBasic.html", CreationCollisionOption.ReplaceExisting);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error creating folder");
                WService.ReportException(ex);
            }
        }

        private async Task SaveFileAsync()
        {
            try
            {
                await FileIO.WriteTextAsync(tempFile, sb.ToString());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error creating file");
                WService.ReportException(ex);
            }
        }

        private void AddSections()
        {
            List<Section> sections = new List<Section>();

            foreach (var item in Model.Members)
            {
                if(!sections.Contains(item.Value.Section))
                {
                    sections.Add(item.Value.Section);
                }
            }

            if(sections.Count == 1)
            {
                sb.AppendLine("<div id=\"divsections\">");
                sb.AppendLine("<h2>Member Section</h2>");
                sb.AppendLine("<table style\"width:100%;\">");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td style=\"width:300px;\">");
                sb.AppendLine("Name");
                sb.AppendLine("</td>");
                sb.AppendLine("<td>");
                sb.AppendLine($"{sections[0].Name}");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>");
                sb.AppendLine("Young’s modulus (E)");
                sb.AppendLine("</td>");
                sb.AppendLine("<td>");
                sb.AppendLine($"{ConvertToEngineeringNotation(sections[0].E)}");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>");
                sb.AppendLine("Second moment of area (I)");
                sb.AppendLine("</td>");
                sb.AppendLine("<td>");
                sb.AppendLine($"{ConvertToEngineeringNotation(sections[0].I)} m<sup>4</sup>");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>");
                sb.AppendLine("Area");
                sb.AppendLine("</td>");
                sb.AppendLine("<td>");
                sb.AppendLine($"{ConvertToEngineeringNotation(sections[0].Area)} m<sup>2</sup>");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>");
                sb.AppendLine("Density");
                sb.AppendLine("</td>");
                sb.AppendLine("<td>");
                sb.AppendLine($"{ConvertToEngineeringNotation(sections[0].Density)} kg/m<sup>3</sup>");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>");
                sb.AppendLine("Material");
                sb.AppendLine("</td>");
                sb.AppendLine("<td>");
                sb.AppendLine($"{sections[0].Material}");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("</table>");

                sb.AppendLine("<div>");
            }
            else
            {
                sb.AppendLine("<div id=\"divsections\">");
                sb.AppendLine("<h2>Member Sections</h2>");
                sb.AppendLine("<table style\"width:100%;\">");

                for (int i = 0;i < sections.Count; i++)
                {
                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td style=\"width:300px;\">");
                    sb.AppendLine("Name");
                    sb.AppendLine("</td>");
                    sb.AppendLine("<td>");
                    sb.AppendLine($"{sections[i].Name}");
                    sb.AppendLine("</td>");
                    sb.AppendLine("</tr>");

                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>");
                    sb.AppendLine("Young’s modulus (E)");
                    sb.AppendLine("</td>");
                    sb.AppendLine("<td>");
                    sb.AppendLine($"{ConvertToEngineeringNotation(sections[i].E)}");
                    sb.AppendLine("</td>");
                    sb.AppendLine("</tr>");

                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>");
                    sb.AppendLine("Second moment of area (I)");
                    sb.AppendLine("</td>");
                    sb.AppendLine("<td>");
                    sb.AppendLine($"{ConvertToEngineeringNotation(sections[i].I)} m<sup>4</sup>");
                    sb.AppendLine("</td>");
                    sb.AppendLine("</tr>");

                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>");
                    sb.AppendLine("Area");
                    sb.AppendLine("</td>");
                    sb.AppendLine("<td>");
                    sb.AppendLine($"{ConvertToEngineeringNotation(sections[i].Area)} m<sup>2</sup>");
                    sb.AppendLine("</td>");
                    sb.AppendLine("</tr>");

                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>");
                    sb.AppendLine("Density");
                    sb.AppendLine("</td>");
                    sb.AppendLine("<td>");
                    sb.AppendLine($"{ConvertToEngineeringNotation(sections[i].Density)} kg/m<sup>3</sup>");
                    sb.AppendLine("</td>");
                    sb.AppendLine("</tr>");

                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>");
                    sb.AppendLine("Material");
                    sb.AppendLine("</td>");
                    sb.AppendLine("<td>");
                    sb.AppendLine($"{sections[i].Material}");
                    sb.AppendLine("</td>");
                    sb.AppendLine("</tr>");

                    sb.AppendLine("<tr>");
                    sb.AppendLine("<td>");
                    sb.AppendLine("&nbsp;");
                    sb.AppendLine("</td>");
                    sb.AppendLine("<td>");
                    sb.AppendLine("&nbsp;");
                    sb.AppendLine("</td>");
                    sb.AppendLine("</tr>");
                }

                sb.AppendLine("</table>");
                sb.AppendLine("<div>");

            }
        }

        private void AddMembers()
        {
            sb.AppendLine("<div id=\"divmembers\">");
            sb.AppendLine("<h2>Members</h2>");
            sb.AppendLine("<table style\"width:100%;\">");

            for (int i = 1; i < Model.Members.Count + 1; i++)
            {
                sb.AppendLine("<tr>");
                sb.AppendLine("<td style=\"width:300px;\">");
                sb.AppendLine("Name");
                sb.AppendLine("</td>");
                sb.AppendLine("<td>");
                sb.AppendLine($"Member {Model.Members[i].Index}");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>");
                sb.AppendLine("Section");
                sb.AppendLine("</td>");
                sb.AppendLine("<td>");
                sb.AppendLine($"{Model.Members[i].Section.Name}");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>");
                sb.AppendLine("Material");
                sb.AppendLine("</td>");
                sb.AppendLine("<td>");
                sb.AppendLine($"{Model.Members[i].Section.Material}");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>");
                sb.AppendLine("Length");
                sb.AppendLine("</td>");
                sb.AppendLine("<td>");
                sb.AppendLine($"{ConvertToEngineeringNotation(Model.Members[i].Length)} m");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>");
                sb.AppendLine("Angle");
                sb.AppendLine("</td>");
                sb.AppendLine("<td>");
                sb.AppendLine($"{ConvertToEngineeringNotation(Model.Members[i].Angle)} <sup>o</sup>");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>");
                sb.AppendLine("Location");
                sb.AppendLine("</td>");
                sb.AppendLine("<td>");
                sb.AppendLine($"[{ConvertToEngineeringNotation(Model.Members[i].NodeNear.Position.X)},{ConvertToEngineeringNotation(Model.Members[i].NodeNear.Position.Y)}] - [{ConvertToEngineeringNotation(Model.Members[i].NodeFar.Position.X)},{ConvertToEngineeringNotation(Model.Members[i].NodeFar.Position.Y)}]");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");

                sb.AppendLine("<tr>");
                sb.AppendLine("<td>");
                sb.AppendLine("&nbsp;");
                sb.AppendLine("</td>");
                sb.AppendLine("<td>");
                sb.AppendLine("&nbsp;");
                sb.AppendLine("</td>");
                sb.AppendLine("</tr>");
            }

            //Model.Members[i].

            sb.AppendLine("</table>");
            sb.AppendLine("<div>");
        }

        private void AddPrimaryTitle()
        {
            sb.AppendLine("<div>");
            sb.AppendLine($"<h1>Report for {FileManager.FileTitle}</h1>");
            sb.AppendLine($"<p>Created: {DateTime.Now}</p>");
            sb.AppendLine("</div>");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("");
        }

        private void CreateHTML()
        {
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine($"<title>Report for {FileManager.FileTitle}</title>");
            sb.AppendLine("<style>");
            sb.AppendLine("body {background-color: #FFFFFF; font-family:'Segoe UI'; font-size:14px;}");
            sb.AppendLine("h1   {color: #222222; font-family:Tahoma; font-size:28px;}");
            sb.AppendLine("p    {color: #000000;}");

            sb.AppendLine("#divreport    {max-width: 960px;margin-left: auto;margin-right: auto;}");

            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<div id=\"divreport\">");
        }

        private void FinalizeHTML()
        { 
            sb.AppendLine("</div>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");
        }

        private string ConvertToEngineeringNotation(decimal d)
        {
            string numberString;
            string exponentString;
            int roundingFactor = 6;

            double exponent = Math.Log10(Math.Abs((double)d));
            if (Math.Abs(d) >= 1)
            {
                switch ((int)Math.Floor(exponent))
                {
                    case 0:
                    case 1:
                    case 2:
                        numberString = Math.Round(d, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = string.Empty;
                        if (numberString == "1000.000")
                        {
                            numberString = "1.000";
                            exponentString = "e+03";
                        }

                        break;
                    case 3:
                    case 4:
                    case 5:
                        numberString = Math.Round(d / 1e3m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e+03";
                        break;
                    case 6:
                    case 7:
                    case 8:
                        numberString = Math.Round(d / 1e6m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e+06";
                        break;
                    case 9:
                    case 10:
                    case 11:
                        numberString = Math.Round(d / 1e9m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e+09";
                        break;
                    case 12:
                    case 13:
                    case 14:
                        numberString = Math.Round(d / 1e12m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e+12";
                        break;
                    case 15:
                    case 16:
                    case 17:
                        numberString = Math.Round(d / 1e15m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e+15";
                        break;
                    case 18:
                    case 19:
                    case 20:
                        numberString = Math.Round(d / 1e18m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e+18";
                        break;
                    case 21:
                    case 22:
                    case 23:
                        numberString = Math.Round(d / 1e21m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e+21";
                        break;
                    default:
                        numberString = Math.Round(d / 1e24m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e+24";
                        break;
                }
            }
            else if (Math.Abs(d) > 0)
            {
                switch ((int)Math.Floor(exponent))
                {
                    case -1:
                    case -2:
                    case -3:
                        numberString = Math.Round(d * 1e3m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e-03";
                        if (numberString == "1000.000")
                        {
                            numberString = "1.000";
                            exponentString = string.Empty;
                        }

                        break;
                    case -4:
                    case -5:
                    case -6:
                        numberString = Math.Round(d * 1e6m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e-06";
                        break;
                    case -7:
                    case -8:
                    case -9:
                        numberString = Math.Round(d * 1e9m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e-09";
                        break;
                    case -10:
                    case -11:
                    case -12:
                        numberString = Math.Round(d * 1e12m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e-12";
                        break;
                    case -13:
                    case -14:
                    case -15:
                        numberString = Math.Round(d * 1e15m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e-15";
                        break;
                    case -16:
                    case -17:
                    case -18:
                        numberString = Math.Round(d * 1e18m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e-18";
                        break;
                    case -19:
                    case -20:
                    case -21:
                        numberString = Math.Round(d * 1e21m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e-21";
                        break;
                    default:
                        numberString = Math.Round(d * 1e24m, roundingFactor).ToString("0.000") + string.Empty;
                        exponentString = "e-24";
                        break;
                }
            }
            else
            {
                numberString = "0.000";
                exponentString = string.Empty;
            }

            return numberString + " " + exponentString;
        }
    }
}