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
using Path = System.IO.Path;

namespace Server
{
    public partial class MainWindow : Window
    {
        
        private string _savePath = "C:\\";
        private string _currentPath = "";


        public MainWindow()
        {
            InitializeComponent();
            ShowDisks();
        }


        private void ShowDirectoryСontent(string path)
        {            
            _listBox.Items.Clear();
            _listBox.Items.Add("..");

            DirectoryInfo directory = new DirectoryInfo(path);
            List<DirectoryInfo> allDirectories = directory.GetDirectories().ToList();
            FileInfo[] allFileInfoes = directory.GetFiles();

            allDirectories.ForEach(dir => _listBox.Items.Add(dir));

            foreach (var file in allFileInfoes)
            {
                ListBoxItem item = new ListBoxItem();
                item.FontWeight = FontWeights.Bold;
                item.Content = file.ToString();

                _listBox.Items.Add(item);
            }
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
            string newDirectory = _listBox.SelectedItem.ToString() + '\\';

            if (newDirectory == "..\\" && _currentPath.Length == 3) //  D:\\ , C:\\ , etc
            {
                ShowDisks();
                return;
            }

            try 
            {
                ShowDirectoryСontent(_currentPath + newDirectory);
                _currentPath = Path.GetFullPath(_currentPath + newDirectory);
                _textBlock.Text = _currentPath;
            }

            catch
            {
                ShowDirectoryСontent(_currentPath);
                MessageBox.Show("Eror");
            }
        }


        private void ShowDisks()
        {
            _textBlock.Text = "My computer";
            _listBox.Items.Clear();
            _currentPath = "";

            string[] Drives = Environment.GetLogicalDrives();
            foreach (string s in Drives)
            {
                _listBox.Items.Add(s);
            }
        }
    }
}

