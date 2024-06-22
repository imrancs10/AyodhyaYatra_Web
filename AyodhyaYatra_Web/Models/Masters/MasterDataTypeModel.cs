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
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string HiName { get; set; }
        public string TaName { get; set; }
        public string TeName { get; set; }
    }

}