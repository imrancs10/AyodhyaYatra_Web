using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AyodhyaYatra_Web.Models
{
    public class DashboardCountModel
    {
        public int id { get; set; }
        public int yatraCount { get; set; }
        public int registrationCount { get; set; }
        public List<string> monthlyVisitorCounts { get; set; }
        public List<attractionCountsModel> attractionCounts { get; set; }
    }
    public class attractionCountsModel
    {
        public string attractionType { get; set; }
        public int count { get; set; }
    }
}