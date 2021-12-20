using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BeautySalone
{
    public partial class Client
    {
        bdBeautySaloneEntities context = new bdBeautySaloneEntities();
        public string NumberOfVisitts
        {
            get
            {
                var visitsCount = (from x in context.ClientService
                                   where x.ClientID == ID
                                   select x).Count();
                return visitsCount.ToString();
            }
        }
        public DateTime? DateLastVisit
        {
            get
            {
                if (context.ClientService.Any(x => x.ClientID == ID))
                {
                    var clientServiced = (from x in context.ClientService
                                      orderby x.StartTime
                                      where x.ClientID == ID
                                      select x.StartTime).First();
                    return clientServiced.Date;
                }
                else return null;
            }
        }
        public StackPanel TagsList
        {
            get
            {
                List<Tag> tagGet = (from x in context.Tag
                              where x.Client == this
                              select x).ToList();
                for (int i = 0; i < tagGet.Count(); i++)
                {
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Horizontal;
                    stackPanel.Background = (Brush)ColorConverter.ConvertFromString(tagGet[i].Color);

                    TextBlock nameBlock = new TextBlock();
                    nameBlock.Text = tagGet[i].Title;

                    Button removeButton = new Button();
                    removeButton.Content = "x";
                    removeButton.Style = (Style)BeautySalone.App.Current.FindResource("Simple_textBlock");
                    removeButton.Click += Button_Click;

                    stackPanel.Children.Add(nameBlock);
                    stackPanel.Children.Add(removeButton);
                }
                return TagsList;
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            var clientTag = (Button)sender;
            context.Client.Remove(clientTag.DataContext as Client);
        }
    }
}
