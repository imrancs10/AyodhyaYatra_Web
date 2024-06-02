using AyodhyaYatra_Web.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AyodhyaYatra_Web.Models
{
    public class NewsUpdateModel
    {
        public string Id { get; set; }
        public string EnTitle { get; set; }
        public string HiTitle { get; set; }
        public string TaTitle { get; set; }
        public string TeTitle { get; set; }
        public string TaDescription { get; set; }
        public string TeDescription { get; set; }
        public string WebUrl { get; set; }
        public ModuleNameEnum MasterDataType { get; set; }
        public NewsUpdateEnum NewsUpdateType { get; set; }
        public string MasterDataTypeName { get; set; }
        public string NewsUpdateTypeName { get; set; }
        public List<AttractionImageModel> Images { get; set; }
        public string EnDescription { get; set; }
        public string HiDescription { get; set; }
        public DateTime? EventDate { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}