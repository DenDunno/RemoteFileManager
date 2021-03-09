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


namespace Server
{
    public partial class MainWindow : Window
    {
        private string _savePath = "C:";

        public MainWindow()
        {
            InitializeComponent();
            ShowFiles("C:\\Program Files\\Windows Media Player");
        }


        private void ShowFiles(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            List<DirectoryInfo> allDirectories = directory.GetDirectories().ToList();
            List<FileInfo> allFileInfoes = directory.GetFiles().ToList();

            allDirectories.ForEach(dir => _listBox.Items.Add(dir));
            allFileInfoes.ForEach(fileInfo => _listBox.Items.Add(fileInfo));
        }


        private void DownloadFileButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello");
        }


        private void SavePath_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your save path: " + "\"" + _savePath + "\"");
        }


        private void DirectoryWasChosen(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(sender.ToString());
        }
        
    }
}
