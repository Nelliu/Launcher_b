using System;
using System.Collections.Generic;
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
        
        public MainWindow()
        {
            InitializeComponent();
            Locations = fil.exeFinder(names);
            List<string> CNames = fil.CutNames();
            ListSize = Locations.Count;
            for (int i = 0; i < ListSize; i++)
            {
                ImageBrush icon = new ImageBrush();
                icon.ImageSource = fil.GetIcon(Locations[i]).ToImageSource();
                SApp sApp = new SApp();
                sApp.Name = CNames[i];
                sApp.Iicon = fil.GetIcon(Locations[i]).ToImageSource();
                sApp.Path = Locations[i];
                names.Items.Add(sApp);
                

                
                
            }


        }


        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                names.SelectedItem
            }
        }
        //private void Names_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    string item = (string) names.SelectedItem;


        //}


    }

}
