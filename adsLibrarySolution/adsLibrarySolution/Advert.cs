﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
namespace adsLibrarySolution
{
    public class Advert : IDataErrorInfo
    {
        //Advert ID
        public int ID { get; set; }
        //Advert Header
        public string Header { get; set; }
        //Advert Info
        public string Information { get; set; }
        //Advert Image
        public string AdvertImageSource { get; set; }
        // Author
        public Client Author { set; get; }

        public string Error {
            get {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName] {
            get {
                string error = "";
                return error;
            }
        }
    }
}
