using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace File_Explorer
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public string Find_path()
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Montaj Dosyası |*.sldasm|Montaj Dosyası |*.sldasm";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;
            file.CheckFileExists = false;
            file.Title = "Montaj Dosyası Şablonu Seçin:";
            file.ShowDialog();

            return file.FileName;
        }

        public string Find_folder()
        {
            FolderBrowserDialog file = new FolderBrowserDialog();
            file.RootFolder = System.Environment.SpecialFolder.MyComputer;
            file.ShowDialog();

            return file.SelectedPath;
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            path.Text = Find_folder();
            browser.Navigate(path.Text);
        }

        private void forward_Click(object sender, RoutedEventArgs e)
        {
            if (browser.CanGoForward)
                browser.GoForward();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (browser.CanGoBack)
                browser.GoBack();
        }
    }
}
