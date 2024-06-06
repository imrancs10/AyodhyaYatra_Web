using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AyodhyaYatra_Web.Models
{

    public class VideoGalaryModel
    {
        public int id { get; set; }
        public string enName { get; set; }
        public string hiName { get; set; }
        public string taName { get; set; }
        public string teName { get; set; }
        public string videoUrl { get; set; }
        public List<AttractionImageModel> images { get; set; }
    }
}