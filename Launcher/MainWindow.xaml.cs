using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VsTools.Projects;

namespace Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            exeFinder();


        }
        
        public void exeFinder()
        {
            string sourceDirectory = @"D:\kloubma16\neco";
            //string archiveDirectory = @"C:\archive";
            List<string> Csproj = new List<string>();
            List<string> OrigCsproj = new List<string>();
            List<string> outputPath = new List<string>();

            List<string> FinalExeFiles = new List<string>();
            // https://stackoverflow.com/questions/20573063/creating-icon-view-mode-for-listview-wpf
            


            try
            {
                var csprojFiles = Directory.EnumerateFiles(sourceDirectory, "*.csproj", SearchOption.AllDirectories);

                foreach (string currentFile in csprojFiles)
                {
                    Csproj.Add(currentFile);
                    string fileName = currentFile.Substring(sourceDirectory.Length + 1 );
                   
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
                    //var proj = Project.Load(@"D:\kloubma16\neco\dedicnost\ConsoleApp1\ConsoleApp1\ConsoleApp1.csproj");
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
                        // names.Items.Add(exeFile);
                        SApp app = new SApp();
                        app.Name = "ExampleName";
                        app.Icon = "Launcher/defaultIcon.ico";
                        names = app; 
                        

                    }
                   
                }
               
            }
           
            catch (Exception e)
            {
               // names.Items.Add(e.Message);
            }
        }

        private void Names_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string item = (string) names.SelectedItem;


        }
       
        
    }
}
