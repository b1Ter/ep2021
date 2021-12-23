using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
    /// Логика взаимодействия для PageClient.xaml
    /// </summary>
    public partial class PageClient : Page
    {
        public static bdBeautySaloneEntities context = new bdBeautySaloneEntities();
        List<Client> clients = context.Client.ToList();

        public static int oldDisplayingRow;
        public static int displayingRows = 10;
        public static int currentCountDataGrid = 0;
        public static int currentCountElements = context.Client.ToList().Count;
        private static bool canGoNext = true;
        private static bool canGoBack = false;
        public PageClient()
        {
            InitializeComponent();
            ShowTable();
            comboBoxGender.ItemsSource = context.Gender.ToList();
            currentCountDataGrid = displayingRows;
            getCurrentPageTextBlock();
            currentCountDataGrid = 0;
        }

        private void ShowTable()
        {
            var gender = (Gender)comboBoxGender.SelectedItem;
            if (comboBoxGender.SelectedItem != null)
                clients = clients.Where(x => x.GenderCode.ToString() == gender.Code.ToString()).ToList();

            if (Email_TextBox.Text != String.Empty)
                clients = clients.Where(x => x.Email.ToLower().Contains(Email_TextBox.Text.ToLower())).ToList();

            if (Phone_TextBox.Text != String.Empty)
                clients = clients.Where(x => x.Phone.Replace("(","").Replace(")", "").Replace(" ", "").Replace("-", "").ToString().Contains(Phone_TextBox.Text)).ToList();

            if (LastName_TextBox.Text != String.Empty)
                clients = clients.Where(x => x.LastName.ToLower().Contains(LastName_TextBox.Text.ToLower())).ToList();

            if (clients.ToList().Count <= displayingRows)
                displayingRows = clients.ToList().Count;
            currentCountDataGrid = 0;
            dataGridClients.ItemsSource = clients.ToList().GetRange(currentCountDataGrid, displayingRows);
            
            currentCountElements = clients.Count;
            currentCountDataGrid = (displayingRows >= clients.Count ? clients.Count : displayingRows);
            getCurrentPageTextBlock();
            currentCountDataGrid = 0;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button btnEdit = (Button)sender;
            var client = btnEdit.DataContext as Client;
            FrameManager.mainFrame.Navigate(new PageEditClient(context, client));
        }

        private void buttonBackToFirst_Click(object sender, RoutedEventArgs e)
        {
            dataGridClients.ItemsSource = clients.ToList().GetRange(0, displayingRows);
            canGoBack = false;
            canGoNext = true;
            currentCountDataGrid = displayingRows;
            getCurrentPageTextBlock();
            currentCountDataGrid = 0;
        }

        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            if (canGoBack)
            {
                if (currentCountDataGrid - displayingRows == 0)
                    dataGridClients.ItemsSource = clients.ToList().GetRange(currentCountDataGrid - displayingRows - clients.Count % displayingRows, displayingRows);
                canGoNext = true;
                if (currentCountDataGrid == 0)
                    canGoBack = false;
                getCurrentPageTextBlock();
                currentCountDataGrid -= displayingRows;
            }
            //if (displayingRows != 0)
            //{
            //    if (currentCountDataGrid - displayingRows > 0)
            //    {
            //        dataGridClients.ItemsSource = clients.ToList().GetRange(currentCountDataGrid - displayingRows, displayingRows);
            //        currentCountDataGrid -= displayingRows;
            //    }
            //    else
            //    {
            //        if (currentCountDataGrid - displayingRows == 0)
            //        {
            //            dataGridClients.ItemsSource = clients.ToList().GetRange(0, displayingRows);
            //            currentCountDataGrid = 0;
            //        }
            //    }
            //}
        }

        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            if (canGoNext)
            {
                if (currentCountDataGrid + displayingRows != clients.Count)
                    if (currentCountDataGrid + 2*displayingRows <= clients.ToList().Count)
                    {
                        dataGridClients.ItemsSource = clients.ToList().GetRange(currentCountDataGrid + displayingRows, displayingRows);
                        var oldCurrentCountDataGrid = currentCountDataGrid;
                        currentCountDataGrid += 2*displayingRows;
                        getCurrentPageTextBlock();
                        currentCountDataGrid = oldCurrentCountDataGrid + displayingRows;
                    }
                    else
                    {
                        dataGridClients.ItemsSource = clients.ToList().GetRange(((int)(clients.Count() / displayingRows)) * displayingRows, clients.Count % displayingRows);
                        currentCountDataGrid = clients.Count;
                        getCurrentPageTextBlock();
                        canGoNext = false;
                    }
                else canGoNext = false;
                canGoBack = true;
            }
            
        }

        private void buttonToLast_Click(object sender, RoutedEventArgs e)
        {
            if (currentCountDataGrid != clients.Count)
            {
                if (clients.Count % displayingRows != 0)
                    dataGridClients.ItemsSource = clients.ToList().GetRange(((int)(clients.Count() / displayingRows)) * 10, clients.Count % displayingRows);
                else
                {
                    oldDisplayingRow = displayingRows;
                    dataGridClients.ItemsSource = clients.ToList().GetRange(clients.Count - displayingRows, displayingRows);
                }
                currentCountDataGrid = clients.Count;
                getCurrentPageTextBlock();
                currentCountDataGrid -= (clients.Count % displayingRows != 0 ? clients.Count % displayingRows : displayingRows);
            }
            canGoNext = false;
            canGoBack = true;
        }

        private void buttonAddClient_Click(object sender, RoutedEventArgs e)
        {
            var client = new Client();
            context.Client.Add(client);
            FrameManager.mainFrame.Navigate(new PageEditClient(context, client));
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            displayingRows = 10;
            oldDisplayingRow = displayingRows;
            ShowTable();
        }

        private void button20_Click(object sender, RoutedEventArgs e)
        {
            displayingRows = 20;
            oldDisplayingRow = displayingRows;
            ShowTable();
        }

        private void button50_Click(object sender, RoutedEventArgs e)
        {
            displayingRows = 50;
            oldDisplayingRow = displayingRows;
            ShowTable();
        }

        private void button100_Click(object sender, RoutedEventArgs e)
        {
            displayingRows = 100;
            oldDisplayingRow = displayingRows;
            ShowTable();
        }

        private void buttonAll_Click(object sender, RoutedEventArgs e)
        {
            displayingRows = displayingRows = clients.ToList().Count;
            oldDisplayingRow = displayingRows;
            ShowTable();
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            clients = context.Client.ToList();
            displayingRows = 10;
            LastName_TextBox.Text = String.Empty;
            Email_TextBox.Text = String.Empty;
            Phone_TextBox.Text = String.Empty;
            canGoNext = true;
            ShowTable();
        }
        private void getCurrentPageTextBlock()
        {
            CountPagesDatagrid_TextBlock.Text = currentCountDataGrid.ToString() + " записей из " + currentCountElements;
        }

        private void sortToLastName_button_Click(object sender, RoutedEventArgs e)
        {
            clients = clients.OrderBy(x => x.LastName).ToList();
            ShowTable();
        }

        private void sortToLastVisit_button_Click(object sender, RoutedEventArgs e)
        {
            clients = clients.OrderBy(x => x.DateLastVisit).Reverse().ToList();
            ShowTable();
        }

        private void sortToCountVisit_button_Click(object sender, RoutedEventArgs e)
        {
            clients = clients.OrderBy(x => x.NumberOfVisitts).Reverse().ToList();
            ShowTable();
        }

        private void LastName_TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            clients = context.Client.ToList();
            ShowTable();
        }

        private void comboBoxGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clients = context.Client.ToList();
            ShowTable();
        }

        private void buttonRemoveClient_Click(object sender, RoutedEventArgs e)
        {
            var row = (Client)dataGridClients.SelectedItem;
            if (row == null)
            {
                MessageBox.Show("Не выбран клиент",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить клиента?",
                "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                context.Client.Remove(row);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void buttonRemoveTag_Click(object sender, RoutedEventArgs e)
        {
            Button buttonTagClient = (Button)sender;
            Tag tag = buttonTagClient.DataContext as Tag;
            Client client = (Client)dataGridClients.SelectedItem;

            List<Tag> tags = context.Tag.AsEnumerable().Where(x => x.Client.Contains(client)).ToList();
            tags.Remove(tag);

            client.Tag.Clear();

            foreach (var x in tags)
            {
                client.Tag.Add(x);
            }

            //((IObjectContextAdapter)context).ObjectContext.DeleteObject(tag);

            //context.Tag.Remove(context.Client.Where(x => x.Tag.Contains(tag) && x == client).Select(x => x).First());

            //context.Tag.Remove(context.Tag.
            //    Where(x => x == tag && 
            //    x.Client.Contains(client)).
            //    Select(x => x).First()).
            //    Client.Contains(client);
            //context.Client.Remove(context.Client.
            //    Where(x => x == client).
            //    Where(x => x.Tag.Contains(tag)).
            //    Select(x => x.Tag.Contains(tag)).
            //    FirstOrDefault());

            //MessageBoxResult result = MessageBox.Show(tagClient.Title.ToString(),
            //    "Тег", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            context.SaveChanges();
            ShowTable();
        }
    }
}
