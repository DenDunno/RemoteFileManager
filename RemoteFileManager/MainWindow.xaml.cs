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
        
        private string _savePath = "C:\\";
        private string _currentPath = "D:\\Business\\";


        public MainWindow()
        {
            InitializeComponent();
            ShowDirectoryСontent(_currentPath);
        }


        private void ShowDirectoryСontent(string path)
        {
            _textBlock.Text = path;
            _listBox.Items.Clear();
            _listBox.Items.Add("..");

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
            string newDirectoty = _listBox.SelectedItem.ToString() + "\\";

            if (newDirectoty == "..\\")
            {
                if (_currentPath == "D:\\")
                    return;

                _currentPath = _currentPath.Remove(_currentPath.Length - 1); // delete last '\'

                while (_currentPath.Last() != (char)92)  // (char)92 = '\'
                    _currentPath = _currentPath.Remove(_currentPath.Length - 1);

                newDirectoty = "";
            }

            try 
            {
                ShowDirectoryСontent(_currentPath + newDirectoty);
                _currentPath += newDirectoty;
            }

            catch
            {
                ShowDirectoryСontent(_currentPath);
                MessageBox.Show("Eror");
            }
        }
    }
}
