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
        Client client;
        List<Tag> tagsList;
        public PageEditClient(bdBeautySaloneEntities context, Client client)
        {
            InitializeComponent();
            this.context = context;
            this.DataContext = client;
            this.client = client;
            this.tagsList = client.Tag.ToList();


            cmbGender.ItemsSource = context.Gender.ToList();
            cmbTags.ItemsSource = context.Tag.ToList();
            cmbGender.SelectedItem = client.Gender;
            getTags();
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

        private void getTags()
        {
            tags.Children.Clear();
            if (client.Tag.Any())
            {
                foreach (var x in client.Tag)
                {
                    StackPanel panelTag = new StackPanel();
                    panelTag.Orientation = Orientation.Horizontal;
                    SolidColorBrush brush = new SolidColorBrush(x.colorTag);
                    panelTag.Background = brush;
                    panelTag.Margin = new Thickness(1, 2, 2, 1);
                    panelTag.HorizontalAlignment = HorizontalAlignment.Left;
                    panelTag.VerticalAlignment = VerticalAlignment.Center;

                    TextBlock titleBlock = new TextBlock();
                    titleBlock.Text = x.Title.ToString();
                    titleBlock.Foreground = Brushes.White;
                    panelTag.Children.Add(titleBlock);
                    titleBlock.FontSize = 26;

                    Button removeTag = new Button();
                    removeTag.Content = "x";
                    removeTag.Background = brush;
                    removeTag.Foreground = Brushes.White;
                    removeTag.BorderThickness = new Thickness(0, 0, 0, 0);
                    removeTag.FontSize = 26;
                    removeTag.Margin = new Thickness(4, 1, 1, 1);
                    removeTag.Click += buttonRemoveTag_Click;
                    panelTag.Children.Add(removeTag);

                    tags.Children.Add(panelTag);
                }
            }
        }
        private void buttonRemoveTag_Click(object sender, RoutedEventArgs e)
        {
            Button buttonTagClient = (Button)sender;
            Tag tag = buttonTagClient.DataContext as Tag;
            tagsList.Remove(tag);

            client.Tag.Clear();

            foreach (var x in tagsList)
            {
                client.Tag.Add(x);
            }
            getTags();
        }

        private void btnAddTag_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTags.SelectedItem.ToString() != String.Empty)
                if (!client.Tag.Contains((Tag)cmbTags.SelectedItem))
                {
                    client.Tag.Add((Tag)cmbTags.SelectedItem);
                    getTags();
                }
        }
    }
}
