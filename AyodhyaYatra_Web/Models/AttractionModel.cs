using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AyodhyaYatra_Web.Models
{
    using AyodhyaYatra_Web.Global;
    using System.Collections.Generic;

    public class AttractionImageModel
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string ThumbPath { get; set; }
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }
        public string Remark { get; set; }
        public string FileType { get; set; }
    }

    public class YatraModel
    {
        public int? Id { get; set; }
        public string EnName { get; set; }
        public string HiName { get; set; }
        public string TaName { get; set; }
        public string TeName { get; set; }
        public string EnDescription { get; set; }
        public string HiDescription { get; set; }
        public string TaDescription { get; set; }
        public string TeDescription { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? MasterDataType { get; set; }
        public string MasterDataTypeName { get; set; }
        public List<AttractionImageModel> Images { get; set; }
        public int? DistanceInKM { get; set; }
        public int? ParentYatraId { get; set; }
        public int? DisplayOrder { get; set; }
    }

    public class AttractionModel
    {
        public int? Id { get; set; }
        public string SequenceNo { get; set; }
        public int? AttractionTypeId { get; set; }
        public string AttractionType { get; set; }
        public string EnName { get; set; }
        public string HiName { get; set; }
        public string TaName { get; set; }
        public string TeName { get; set; }
        public string EnDescription { get; set; }
        public string HiDescription { get; set; }
        public string TaDescription { get; set; }
        public string TeDescription { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Video360URL { get; set; }
        public string AttractionURL { get; set; }
        public string VideoURL { get; set; }
        public string BarcodeId { get; set; }
        public List<AttractionImageModel> Images { get; set; }
    }

    public class YatraAttractionModel
    {
        public YatraModel Yatra { get; set; }
        public List<AttractionModel> attractions { get; set; }
    }
    public class MasterResponse
    {
        public MasterResponse()
        {
            Images = new List<AttractionImageModel>();
        }
        public int Id { get; set; }
        public string EnName { get; set; }
        public string HiName { get; set; }
        public string TaName { get; set; }
        public string TeName { get; set; }
        public string EnDescription { get; set; }
        public string HiDescription { get; set; }
        public string TaDescription { get; set; }
        public string TeDescription { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public ModuleNameEnum MasterDataType { get; set; }
        public string MasterDataTypeName { get; set; }
        public List<AttractionImageModel> Images { get; set; }
        public double? DistanceInKM { get; set; }
        public int? ParentYatraId { get; set; }
        public int? DisplayOrder { get; set; }
    }
}