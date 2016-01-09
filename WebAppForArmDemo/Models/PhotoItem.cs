using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebAppForArmDemo.Models
{
    public class PhotoItem
    {
        [DisplayName("File name")]
        public string FileName { get; set; }
        [DisplayName("Photo")]
        public string Url { get; set; }
    }
}