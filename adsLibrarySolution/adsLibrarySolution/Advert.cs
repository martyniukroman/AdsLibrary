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
        //Advert ID
        public int ID { get; set; }
        //Advert Header
        public string Header { get; set; }
        //Advert Info
        public string Information { get; set; }
        //Advert Image
        public BitmapImage AdvertImage { get; set; }
    }
}
