﻿using DataLayer;
using AyodhyaYatra_Web.Global;
using AyodhyaYatra_Web.Infrastructure.Authentication;
using AyodhyaYatra_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static AyodhyaYatra_Web.Global.Enums;
using AyodhyaYatra_Web.BAL.Masters;
using AyodhyaYatra_Web.Models.Masters;
using System.Configuration;
using log4net.Util;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

namespace AyodhyaYatra_Web.Infrastructure.Utility
{
    public abstract class BaseViewPage : WebViewPage
    {
        //public virtual new CustomPrincipal User
        //{
        //    get { return base.User as CustomPrincipal; }
        //}

        //public virtual HospitalDetail GetHospitalDetail()
        //{
        //    HospitalDetails _details = new HospitalDetails();
        //    return _details.GetHospitalDetail();
        //}
        //public virtual int GetAppointmentCount()
        //{
        //    AppointDetails _details = new AppointDetails();
        //    return _details.PatientAppointmentCount(User.Id);
        //}

        public static List<MasterYatraModel> GetYatra()
        {
            return HttpClientHelper<List<MasterYatraModel>>.GetAPIResponse("MasterData/get/yatras", "");
        }

    }



    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual new CustomPrincipal User
        {
            get { return base.User as CustomPrincipal; }
        }
        public virtual List<NoticeModel> GetEntryTypeDetail()
        {
            GeneralDetails _details = new GeneralDetails();
            return _details.GetEntryType();
        }

        public virtual List<string> GetUserPermission()
        {
            int roleId = (int)User.RoleId;
            GeneralDetails _details = new GeneralDetails();
            return _details.GetUserPermission(roleId);
        }

        public virtual bool GetCaptchEnable()
        {
            return Convert.ToBoolean(ConfigurationManager.AppSettings["EnableCaptcha"]);
        }
        public virtual bool GetOTPEnable()
        {
            return Convert.ToBoolean(ConfigurationManager.AppSettings["EnableOTPLogin"]);
        }

        public static List<MasterYatraModel> GetYatra()
        {
            var data = HttpClientHelper<List<MasterYatraModel>>.GetAPIResponse("get/yatras", "");
            var cookieValue = HttpContext.Current.Request.Cookies["Language"]?.Value;
            if (cookieValue != null && cookieValue == "hi-IN")
                data.ForEach(x => x.EnName = x.hiName);
            return data;
        }

        public static MasterDataTypeModel GetMasterDataType()
        {
            var allMasterData = HttpClientHelper<MasterDataTypeModel>.GetAPIResponse("master/attraction/type?PageNo=1&PageSize=100", "");
            var templedataIndex = allMasterData.data.FindIndex(x => x.Name == "Temple");
            if (templedataIndex != -1)
                allMasterData.data.RemoveAt(templedataIndex);
            var cookieValue = HttpContext.Current.Request.Cookies["Language"]?.Value;
            if (cookieValue != null && cookieValue == "hi-IN")
                allMasterData.data.ForEach(x => x.Name = x.HiName);
            return allMasterData;
        }
        //public virtual AppointmentModel GetAppointmentDetail()
        //{
        //    if (User != null)
        //    {
        //        AppointDetails _details = new AppointDetails();
        //        return null;// _details.PatientAppointmentCount(User.Id);
        //    }
        //    return null;
        //}

        //public virtual PatientInfo GetPatientInfo()
        //{
        //    if (User != null)
        //    {
        //        PatientDetails _details = new PatientDetails();
        //        return null;// _details.GetPatientDetailById(User.Id);
        //    }
        //    return null;
        //}

        //public virtual PDModel GetPatientOPDDetail()
        //{
        //    //if (User != null)
        //    //{
        //    //    string crNumber = string.IsNullOrEmpty(WebSession.PatientCRNo) ? WebSession.PatientRegNo : WebSession.PatientCRNo;
        //    //    var opdDetail = (new WebServiceIntegration()).GetPatientOPDDetail(crNumber, (Convert.ToInt32(OPDTypeEnum.IPD)).ToString());
        //    //    return opdDetail;
        //    //}
        //    return null;
        //}
    }
}