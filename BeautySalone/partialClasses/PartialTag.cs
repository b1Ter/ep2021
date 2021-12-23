using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BeautySalone
{
    public partial class Tag
    {
        public Color colorTag
        {
            get
            {
                return (Color)ColorConverter.ConvertFromString("#" + Color);
            }
        }
    }
}
