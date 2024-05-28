using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AyodhyaYatra_Web.Models.Masters
{
    public class MasterDataTypeModel
    {
        public int pageNo { get; set; }
        public int totalCount { get; set; }
        public int pageSize { get; set; }
        public List<MasterData> data { get; set; }
    }

    public class MasterData
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }

}