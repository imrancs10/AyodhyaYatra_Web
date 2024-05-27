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
        public List<MonthlyVisitorCountModel> monthlyVisitorCounts { get; set; }
        public List<attractionCountsModel> attractionCounts { get; set; }
    }
    public class attractionCountsModel
    {
        public string attractionType { get; set; }
        public int count { get; set; }
    }

    public class MonthlyVisitorCountModel
    {
        public int MonthYear { get; set; }
        public int Count { get; set; }
    }
}