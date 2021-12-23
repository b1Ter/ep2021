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
    }
}
