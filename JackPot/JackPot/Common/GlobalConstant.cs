using System;
namespace WareHouseManagement.PCL.Common
{
    public class GlobalConstant
    {
        public static string BaseUrl="http://3.16.25.240:8063/api/";
        public static string BaseUrlSignalR = "http://3.16.25.240:8063";
        public static string TokenURL = "http://3.16.25.240:8063/token";

        public static string AWS_ACCESS_KEY = "AWS_ACCESS_KEY";
        public static string AWS_SECRET_KEY = "AWS_SECRET_KEY";
        public static string PREF_USERID = "userId";
        public static string PREF_Password = "password";
        public static string PREF_AccessKEY = "accesskey";
        public static string PREF_Email = "email";
        public static string PREF_LONGITUDE = "longitude";
        public static string PREF_LATITUDE = "latitude";
        public static string AccessToken { get; set; }
       
        public static long UserName { get; set; }
        public static int UserId { get; set; }
        public static string CustomerName { get; set; }
        public static decimal BalanceAmt { get; set; }
        public static string UserPassword { get; set; }
        public static string Usertype { get; set; }
        public static string GetUserLoginDetail = "Login/getLogin";
       

        public static string GoogleMapApiKey = "AIzaSyC50XshkjneoleOy4CTQxRmWAv-qYGhd8Q";


    }
  


    public struct BetEntry
    {
        public static string GetLottoGameDetailByHouseIdandBalls = "BetEntry/GetLottoGameDetailByHouseIdandBalls?HouseId=";
        public static string GetHouseDetail = "BetEntry/getHousesDetailsMode";
        public static string TrancatioSaveBetEntry = "BetEntry/InsertTender";
        public static string GetTrancationNumber = "BetEntry/gettblLottoTicketData/";
        public static string GetBetEntryByTicketNo = "BetEntry/GetBetByPreviousTicket/";
        public static string GetTenderAmountbyTicketNo = "BetEntry/GetTenderAmountByTicketId/";
        public static string GetLateHouseByHouseID = "BetEntry/GetLateHouseByHouseID/";
    }
    public struct VoidTicketApi
    {
        public static string GetNonVoidedTicketBets = "BetEntry/GetNonVoidedTicketBets/";
        public static string GetLottoBets = "VoidTicket/GetLottoBets/";
        public static string AdjustBetsPerBall = "VoidTicket/AdjustBetsPerBall";
    }

 
}
