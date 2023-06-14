using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
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
using System.Xml;
using System.Xml.Linq;
using Spire.Doc;

namespace Dogs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Scan_Click(object sender, RoutedEventArgs e)
        {
            Helper helper = new Helper();
            DateTime date = DogDate.DisplayDate;
            List<string> list = new List<string>();
            string[] ListDomens = DomenList.Text.Split(new string[] { "\t", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string Domen in ListDomens)
            {
                RequestDomen domen = new RequestDomen();
                var rawXml = domen.Requests(Domen.Trim());
                helper.Writer(rawXml);
                var result = helper.Reader(date);
                if (result)
                    list.Add(Domen);
            }
            if(list.FirstOrDefault()!=null)
                foreach(string Domen in list)
                {
                    ResultList.Text += Domen + "\t";
                }
            Dogs.Visibility = Visibility.Collapsed;
            Result.Visibility = Visibility.Visible;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            DomenList.Text = null;
            ResultList.Text = null;
            Dogs.Visibility = Visibility.Visible;
            Result.Visibility = Visibility.Collapsed;

        }
    }
}
