using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AyodhyaYatra_Web.Global
{
    public enum ModuleNameEnum
    {
        MasterAttraction = 0,
        Yatra = 1,
        Ghat = 2,
        EducationalInstitute = 3,
        Hotel = 4,
        Business = 5,
        Culture = 6,
        Restaurant = 7,
        Park = 8,
        ATM = 9,
        Padav = 10,
        WaterTaxi = 14,
        Cruise = 15,
        BoatRiding = 16,
        Heritage = 17,
        GangaAarti = 18,
        Industries = 19,
        Museum = 20,
        Railways = 21,
        ShoppingPlaces = 22,
        Hospital = 23,
        Transport = 24,
        Entertainment = 25,
        NewsUpdate = 26,
        PhotoAlbum = 27,
        PhotoGallery = 28,
        AudioGallery = 29,
        VideoGallery = 30,
        ThreeSixtyDegreeGallery = 31
    }
    public enum NewsUpdateEnum
    {
        News = 1,
        Notification = 2,
        Document = 3,
        Event = 4
    }
    public static class Enums
    {
        public enum OPDTypeEnum
        {
            IPD = 1,
            OPD = 2,
            DischargeSummary = 3,
            MyVisit = 4
        }
        public enum MasterLookupEnum
        {
            HelpLineNo,
            OPDNo,
            AdministrativeBlockPhNo,
            FaxNo,
            Website,
            EMail,
            MailingAddress
        }
        public enum TransactionType
        {
            Registration = 0,
            Renewal = 1,
            PayBill = 2
        }
        public enum LoginMessage
        {
            Authenticated = 1,
            InvalidCreadential = 2,
            LoginFailed,
            UserDeleted,
            UserInactive,
            UserBlocked,
            NoResponse
        }

        public enum CrudStatus
        {
            Saved = 1,
            NotSaved = 2,
            Updated,
            NotUpdated,
            Deleted,
            NotDeleted,
            DataNotFound,
            DataAlreadyExist,
            SessionExpired,
            InvalidPostedData,
            InvalidPastDate,
            InternalError,
            RegistrationExpired
        }

        public enum ReportType
        {
            Bill,
            Lab
        }

        public enum JsonResult
        {
            Data_NotFound = 100,
            Invalid_DataId = 101,
            Data_Expire = 102,
            Success = 103,
            Unsuccessful
        }
    }
}