using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
namespace adsLibrarySolution
{
    class Advert
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public string Information { get; set; }
        public BitmapImage AdvertImage { get; set; }
    }
}
