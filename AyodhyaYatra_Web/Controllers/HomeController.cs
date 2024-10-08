﻿using AyodhyaYatra_Web.Global;
using AyodhyaYatra_Web.Infrastructure.Utility;
using AyodhyaYatra_Web.Models;
using AyodhyaYatra_Web.Models.Masters;
using AyodhyaYatra_Web.Models.Visitor;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace AyodhyaYatra_Web.Controllers
{
    //[PreventDuplicateRequest]
    public class HomeController : CommonController
    {
        //Declaring Log4Net
        private static string BaseURL = ConfigurationManager.AppSettings["APIUrl"].ToString();
        ILog logger = LogManager.GetLogger(typeof(HomeController));
        public ActionResult Index()
        {
            var data = HttpClientHelper<DashboardCountModel>.GetAPIResponse("Feedback/get/dashboardCount", "");
            var visitorDocType = HttpClientHelper<List<VisitorDocTypeModel>>.GetAPIResponse("visitors/get/doctype", "");
            //var result = JsonConvert.DeserializeObject<DashboardCountModel>(data);
            var famousTemple = HttpClientHelper<List<AttractionModel>>.GetAPIResponse("master/attraction/get/type/10", "").Take(4).ToList();
            var newsUpdate = HttpClientHelper<List<NewsUpdateModel>>.GetAPIResponse("NewsUpdate/get/newsupdate", "");
            var specificAttractionDetail = HttpClientHelper<List<AttractionModel>>.GetAPIResponse("master/attraction/get", "");
            var allMasterData = HttpClientHelper<MasterDataTypeModel>.GetAPIResponse("master/attraction/type?PageNo=1&PageSize=100", "");
            var templedataIndex = allMasterData.data.FindIndex(x => x.Name == "Temple");
            if (templedataIndex != -1)
                allMasterData.data.RemoveAt(templedataIndex);

            //change text to Hindi 
            var cookieValue = Request.Cookies["Language"]?.Value;
            if (cookieValue != null && cookieValue == "hi-IN")
            {
                allMasterData.data.ForEach(x => x.Name = x.HiName);

                famousTemple.ForEach(x =>
                {
                    x.EnName = x.HiName;
                    x.EnDescription = x.HiDescription;
                });
                newsUpdate.ForEach(x =>
                {
                    x.EnTitle = x.HiTitle;
                    x.EnDescription = x.HiDescription;
                });
                specificAttractionDetail.ForEach(x =>
                {
                    x.EnName = x.HiName;
                    x.EnDescription = x.HiDescription;
                });
            }

            ViewData["specificAttractionDetail"] = specificAttractionDetail;
            ViewData["newsUpdateList"] = newsUpdate;
            ViewData["famouseTemple"] = famousTemple;
            ViewData["dashboardCount"] = data;
            ViewData["visitorDocType"] = visitorDocType;
            ViewData["allMasterData"] = allMasterData;
            ViewData["APIUrl"] = BaseURL;
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Index(VisitorModel visitor)
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult UnderConstruction()
        {
            return View();
        }

        public ActionResult YatraDetail([FromUri] int? Id)
        {
            if (Id == null || Id <= 0)
                return RedirectToAction("index");
            var data = HttpClientHelper<YatraAttractionModel>.GetAPIResponse("master/attraction/get/yatra/" + Id, "");
            //var result = JsonConvert.DeserializeObject<DashboardCountModel>(data);


            //change text to Hindi 
            var cookieValue = Request.Cookies["Language"]?.Value;
            if (cookieValue != null && cookieValue == "hi-IN")
            {
                data.Yatra.EnName = data.Yatra.HiName;
                data.Yatra.EnDescription = data.Yatra.HiDescription;

                data.attractions.ForEach(x =>
                {
                    x.EnName = x.HiName;
                    x.EnDescription = x.HiDescription;
                });
            }

            ViewData["getAttractionByYatraId"] = data;
            return View();
        }
        public ActionResult AttractionDetail([FromUri] int Id)
        {
            var data = HttpClientHelper<AttractionModel>.GetAPIResponse("master/attraction/get/" + Id, "");
            //change text to Hindi 
            var cookieValue = Request.Cookies["Language"]?.Value;
            if (cookieValue != null && cookieValue == "hi-IN")
            {
                data.EnName = data.HiName;
                data.EnDescription = data.HiDescription;
            }
            ViewData["getAttractionById"] = data;
            return View();
        }

        public ActionResult MasterDetail([FromUri] int Id)
        {
            var data = HttpClientHelper<List<AttractionModel>>.GetAPIResponse("master/attraction/get/type/" + Id, "");
            //change text to Hindi 
            var cookieValue = Request.Cookies["Language"]?.Value;
            if (cookieValue != null && cookieValue == "hi-IN")
            {
                data.ForEach(x =>
                {
                    x.EnName = x.HiName;
                    x.EnDescription = x.HiDescription;
                });
            }

            ViewData["getAttractionByTypeId"] = data;
            return View();
        }
        public ActionResult Master_DetailPage([FromUri] int Id)
        {
            var data = HttpClientHelper<AttractionModel>.GetAPIResponse("master/attraction/get/" + Id, "");
            //change text to Hindi 
            var cookieValue = Request.Cookies["Language"]?.Value;
            if (cookieValue != null && cookieValue == "hi-IN")
            {
                data.EnName = data.HiName;
                data.EnDescription = data.HiDescription;
            }
            ViewData["getAttractionById"] = data;
            return View();
        }
        public ActionResult TouristAtractionPlaces(string masterDataType, string heading)
        {
            var IdArray = masterDataType.Split(',');
            string queryParameter = string.Empty;
            for (int i = 0; i < IdArray.Length; i++)
            {
                queryParameter += "&masterDataType=" + IdArray[i];
            }
            queryParameter = queryParameter.Remove(0, 1);
            var data = HttpClientHelper<List<MasterResponse>>.GetAPIResponse("master/data/types?" + queryParameter, "");

            //change text to Hindi 
            var cookieValue = Request.Cookies["Language"]?.Value;
            if (cookieValue != null && cookieValue == "hi-IN")
            {
                data.ForEach(x =>
                {
                    x.EnName = x.HiName;
                    x.EnDescription = x.HiDescription;
                });
            }

            ViewData["MasterAttraction"] = data;
            ViewData["Heading"] = heading;
            return View();
        }

        public ActionResult TouristAtraction_Detail([FromUri] int Id)
        {
            var data = HttpClientHelper<MasterResponse>.GetAPIResponse("master/data/" + Id, "");
            //change text to Hindi 
            var cookieValue = Request.Cookies["Language"]?.Value;
            if (cookieValue != null && cookieValue == "hi-IN")
            {
                data.EnName = data.HiName;
                data.EnDescription = data.HiDescription;
            }
            ViewData["getAttractionById"] = data;
            return View();
        }
        public ActionResult AyodhyaPersonality()
        {
            return View();
        }
        public ActionResult CopyrightPolicy()
        {
            return View();
        }
        public ActionResult TermsConditions()
        {
            return View();
        }
        public ActionResult PrivacyPolicy()
        {
            return View();
        }
        public ActionResult Map()
        {
            var data = HttpClientHelper<List<AttractionImageModel>>.GetAPIResponse("ImageUpload/image/get/modname?moduleName=0", "");
            //var result = JsonConvert.DeserializeObject<DashboardCountModel>(data);

            ViewData["PhotoGalleryImage"] = data;
            return View();
        }
        public ActionResult DosDonts()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }
        public ActionResult KeyFacts()
        {
            return View();
        }
        public ActionResult TouristGuideByMap()
        {
            return View();
        }
        public ActionResult PhotoGallery()
        {
            var data = HttpClientHelper<List<AttractionImageModel>>.GetAPIResponse("ImageUpload/image/get/modname?moduleName=0", "");
            var AlbumData = data.Where(x => x.FileType.ToLower() == "image").GroupBy(x => x.ModuleId).Take(9).ToList();
            var response = new List<AttractionImageModel>();
            AlbumData.ForEach(x =>
            {
                response.AddRange(data.Where(y => y.ModuleId == x.Key).ToList());
            });
            ViewData["PhotoGalleryImage"] = response;
            return View();
        }

        public ActionResult PhotoGalleryDetails()
        {
            var data = HttpClientHelper<List<AttractionImageModel>>.GetAPIResponse("ImageUpload/image/get/modname?moduleName=0", "");
            ViewData["PhotoGalleryImage"] = data;
            return View();
        }
        public ActionResult AudioGallery()
        {
            var data = HttpClientHelper<List<AttractionImageModel>>.GetAPIResponse("ImageUpload/image/get/modname?moduleName=" + Convert.ToInt32(ModuleNameEnum.AudioGallery), "");
            ViewData["AudioGallery"] = data;
            return View();
        }
        public ActionResult VideoGallery()
        {
            var data = HttpClientHelper<List<VideoGalaryModel>>.GetAPIResponse("Gallery/get/videogallery", "");

            //change text to Hindi 
            var cookieValue = Request.Cookies["Language"]?.Value;
            if (cookieValue != null && cookieValue == "hi-IN")
            {
                data.ForEach(x =>
                {
                    x.enName = x.hiName;
                });
            }

            ViewData["VideoGallery"] = data;
            return View();
        }

        public ActionResult ThreeSixtyDegreeGallery([FromUri] int? attractionId)
        {
            var response = new List<AttractionModel>();
            if (attractionId != null && attractionId > 0)
            {
                var data = HttpClientHelper<AttractionModel>.GetAPIResponse("master/attraction/get/" + attractionId, "");
                response.Add(data);
            }
            else
            {
                //get all temple
                var data = HttpClientHelper<List<AttractionModel>>.GetAPIResponse("master/attraction/get/type/1", "");
                response.AddRange(data.Where(x => x.Video360URL != null).Take(9));
            }

            //change text to Hindi 
            var cookieValue = Request.Cookies["Language"]?.Value;
            if (cookieValue != null && cookieValue == "hi-IN")
            {
                response.ForEach(x =>
                {
                    x.EnName = x.HiName;
                    x.EnDescription = x.HiDescription;
                });
            }

            ViewData["360Video"] = response;
            return View();
        }

        public ActionResult ThreeSixtyDegreeImageGallery()
        {  
            return View();
        }

        public ActionResult ThreeSixtyDegreeImageGalleryDetail([FromUri] int? attractionId)
        {
            return View();
        }
        
        [System.Web.Mvc.HttpPost]
        public JsonResult FillThreeSixtyDegreeImage()
        {
            var data = HttpClientHelper<List<AttractionImageModel>>.GetAPIResponse("ImageUpload/image/get/modname?moduleName=" + Convert.ToInt32(ModuleNameEnum.MasterAttraction), "");
            data = data.Where(x => x.FileType == "360degreeimage").Take(9).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult FillThreeSixtyDegreeImageDetail([FromUri] int? attractionId)
        {
            var data = HttpClientHelper<List<AttractionImageModel>>.GetAPIResponse("ImageUpload/image/get/modname?moduleName=" + Convert.ToInt32(ModuleNameEnum.MasterAttraction), "");
            data = data.Where(x => x.FileType == "360degreeimage").ToList();
            if (attractionId != null && attractionId > 0)
                data = data.Where(x => x.ModuleId == attractionId).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ThreeSixtyDegreeGalleryDetail()
        {
            var response = new List<AttractionModel>();
            //get all temple
            var data = HttpClientHelper<List<AttractionModel>>.GetAPIResponse("master/attraction/get/type/1", "");
            response.AddRange(data.Where(x => x.Video360URL != null).ToList());

            //change text to Hindi 
            var cookieValue = Request.Cookies["Language"]?.Value;
            if (cookieValue != null && cookieValue == "hi-IN")
            {
                response.ForEach(x =>
                {
                    x.EnName = x.HiName;
                    x.EnDescription = x.HiDescription;
                });
            }

            ViewData["360Video"] = response;
            return View();
        }

        public ActionResult TicketBooking()
        {
            return View();
        }

        public ActionResult NewsAndEvents()
        {
            var data = HttpClientHelper<List<NewsUpdateModel>>.GetAPIResponse("NewsUpdate/get/newsupdate", "");

            //change text to Hindi 
            var cookieValue = Request.Cookies["Language"]?.Value;
            if (cookieValue != null && cookieValue == "hi-IN")
            {
                data.ForEach(x =>
                {
                    x.EnTitle = x.HiTitle;
                    x.EnDescription = x.HiDescription;
                });
            }

            ViewData["newsUpdateList"] = data;
            return View();
        }

        public ActionResult NewsEventsDetailPage(int eventId)
        {
            var data = HttpClientHelper<NewsUpdateModel>.GetAPIResponse("NewsUpdate/newsupdate/get/" + eventId, "");

            //change text to Hindi 
            var cookieValue = Request.Cookies["Language"]?.Value;
            if (cookieValue != null && cookieValue == "hi-IN")
            {
                data.EnTitle = data.HiTitle;
                data.EnDescription = data.HiDescription;
            }

            ViewData["newsUpdateData"] = data;
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult Directory()
        {
            return View();
        }

        public ActionResult Helpline()
        {
            return View();
        }
        public ActionResult Feedback()
        {
            
            ViewData["APIUrl"] = BaseURL;
            return View();
        }

        public ActionResult PhotoGalleryDetail([FromUri] int? attractionId)
        {
            if (attractionId == null || attractionId <= 0)
                return RedirectToAction("index");
            var data = HttpClientHelper<List<AttractionImageModel>>.GetAPIResponse("ImageUpload/image/get/modname/id?moduleName=0&moduleId=" + attractionId + "&imageType=image", "");
            //var result = JsonConvert.DeserializeObject<DashboardCountModel>(data);

            ViewData["PhotoGalleryImage"] = data;
            return View();
        }
        public ActionResult QrLanding([FromUri] string type, [FromUri] int id)
        {
            if (type == "attraction")
                //return RedirectToAction("attractionDetail", new { id = id });

                return Redirect(Url.Action("attractionDetail", "Home") + "?id=" + id);
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult VisitorPass()
        {

            ViewData["APIUrl"] = BaseURL;
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult VisitorPass(string mobileNumber)
        {
            var response = HttpClientHelper<List<VisitorResponse>>.GetAPIResponse($"visitors/get/by/mobile?mobileNo={mobileNumber}", "");
            if (response==null || response.Count()==0)
            {
                return View("VisitorPass", new List<VisitorResponse>());
            }
            ViewData["APIUrl"] = BaseURL;
            return View("VisitorPass", response);
        }
    }
}