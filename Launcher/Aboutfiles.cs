using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using VsTools.Projects;

namespace Launcher
{
    public class Aboutfiles
    {
        List<string> Csproj = new List<string>(); // cela cesta
        List<string> FinalExeFiles = new List<string>(); // final exe paths
        public List<string> exeFinder(ListView names, string path)
        {
            string sourceDirectory = path;
            //string archiveDirectory = @"C:\archive";
            
            List<string> OrigCsproj = new List<string>(); // cesta k cs proj
            List<string> outputPath = new List<string>(); // output path

            
            // https://stackoverflow.com/questions/20573063/creating-icon-view-mode-for-listview-wpf



            try
            {
                var csprojFiles = Directory.EnumerateFiles(sourceDirectory, "*.csproj", SearchOption.AllDirectories);

                foreach (string currentFile in csprojFiles)
                {
                    Csproj.Add(currentFile);
                    string fileName = currentFile.Substring(sourceDirectory.Length + 1);

                }

                //names.Text = Csproj[1] + "\n";
                for (int i = 0; i < Csproj.Count; i++)
                {
                    OrigCsproj.Add(Csproj[i]);
                    Csproj[i] = Csproj[i].Substring(0, Csproj[i].LastIndexOf("\\") + 1);

                    //names.Items.Add(Csproj[i]);
                }

                for (int a = 0; a < OrigCsproj.Count; a++)
                {

                    var proj = Project.Load(OrigCsproj[a]);
                    var debug = proj.PropertyGroups.First(x => x.Condition == " '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ");

                    outputPath.Add(debug["OutputPath"]);

                    // names.Items.Add(debug["OutputPath"]);

                    Csproj[a] = Csproj[a] + outputPath[a];
                    //names.Items.Add(Csproj[a]);



                    string exeDir = @Csproj[a];
                    //names.Items.Add(exeDir);
                    var exeFiles = Directory.EnumerateFiles(exeDir, "*.exe", SearchOption.AllDirectories);
                    foreach (string exeFile in exeFiles)
                    {
                        FinalExeFiles.Add(exeFile);
                        names.Items.Add(exeFile);
                        SApp app = new SApp();
                        app.Name = exeFile;

                        //names.Items.Add(app); 


                    }

                }
                
            }

            catch (Exception e)
            {
                // names.Items.Add(e.Message);
            }
            return FinalExeFiles;
        }

        public Icon GetIcon(string path)
        {
            
            Icon icon = Icon.ExtractAssociatedIcon(path);
            return icon;
        }

        public List<string> CutNames()
        {
            List<string> CutN = new List<string>();
            int LocationsC = FinalExeFiles.Count;
            for (int i = 0; i < LocationsC; i++)
            {
                int pos = FinalExeFiles[i].LastIndexOf(@"\") + 1;
                CutN.Add(FinalExeFiles[i].Substring(pos, FinalExeFiles[i].Length - pos));   
            }
            return CutN;
        }
    }
}
