using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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

        public Aboutfiles fil = new Aboutfiles();
        public List<string> Locations = new List<string>();
        public int ListSize = 0;
        string result = "";

        public MainWindow()
        {
            InitializeComponent();
        }


        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                SApp SelectedItem = (SApp)names.SelectedItem;
                string path = SelectedItem.Path;
                //test.Text = path;

                Process.Start(path);
            }
        }
        private void ListViewItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                SApp SelectedItem = (SApp)names.SelectedItem;
                string path = SelectedItem.Path;
                //test.Text = path;

                File.Delete(path);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PathWin Folder = new PathWin();
            string result = Folder.GetPath("Select path");
            if (result != "")
            {
                Locations = fil.exeFinder(names, result);
                List<string> CNames = fil.CutNames();
                ListSize = Locations.Count;
                for (int i = 0; i < ListSize; i++)
                {
                    SApp sApp = new SApp();
                    sApp.Name = CNames[i];
                    sApp.Iicon = fil.GetIcon(Locations[i]).ToImageSource();
                    sApp.Path = Locations[i];
                    names.Items.Add(sApp);


                }
            }

        }
    }

}
