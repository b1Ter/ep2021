using Microsoft.Win32;
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

namespace BeautySalone.pages
{
    /// <summary>
    /// Логика взаимодействия для PageEditClient.xaml
    /// </summary>
    public partial class PageEditClient : Page
    {
        bdBeautySaloneEntities context;
        public PageEditClient(bdBeautySaloneEntities context, Client client)
        {
            InitializeComponent();
            this.context = context;
            cmbGender.Items.Add(context.Gender.ToList());
            this.DataContext = client;
        }
        private void btnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.jpg, *.jpeg, *.png|*.jpg;*.jpeg;*.png;";
            ofd.ShowDialog();
            string pathOFD = ofd.FileName;
            byte[] image = File.ReadAllBytes(pathOFD);
            var add = this.DataContext as Client;
            add.PhotoPath = pathOFD;
            clientImage.UpdateLayout();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.mainFrame.Navigate(new PageClient());
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            FrameManager.mainFrame.Navigate(new PageClient());
        }
    }
}
