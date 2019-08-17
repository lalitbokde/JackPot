using System;
namespace WareHouseManagement.PCL.Common
{
    public class GlobalConstant
    {
        public static string BaseUrl= "http://13.58.35.117:8063/api/";
        public static string BaseUrlSignalR = "http://13.58.35.117:8063";
        public static string TokenURL = "http://13.58.35.117:8063/token";

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
        public static long iPanelUserID { get; set; }
        public static string sUserName { get; set; }
        public static int LocationId { get; set; }
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
        public static string GetEarlyHouseForTab = "BetEntry/GetEarlyHouse";
        public static string GetLateHouseForTab = "BetEntry/GetLateHouse";
        public static string TrancatioSaveBetEntry = "BetEntry/InsertTender";
        public static string GetTrancationNumber = "BetEntry/gettblLottoTicketData/";
        public static string GetBetEntryByTicketNo = "BetEntry/GetBetByPreviousTicket/";
        public static string GetTenderAmountbyTicketNo = "BetEntry/GetTenderAmountByTicketId/";
        public static string GetLateHouseByHouseID = "BetEntry/GetLateHouseByHouseID/";
    }
    public struct Sales
    {
        public static string GetSalesReport = "Report/GetSalesReportByDate?LocationId=";
        public static string GetCloseShiftGridDetai = "Report/GetCloseShiftGridDetai/";
        public static string GetCurrentPanelUserShift = "Report/GetCurrentPanelUserShift?PanelUser=";

    }
    public struct Winning
    {
        public static string GetWinningNumber = "Report/GetWinningNumberByCurrentDate/";
        public static string GetWinningNumberByTwoDate = "Report/GetWinningNumberByTwoDate?StartDate=";
    }

    public struct payout
    {
        public static string GetUnpaidTicket = "Payout/GetUnpaidTicket/";
        public static string MarkWinnerAsPaid = "Payout/MarkWinnerAsPaid";
    }
    public struct CustomerApi
    {
        public static string GetCustomerDetailByAccountno = "Customer/GetCustomerDetailByAccountno/";
        public static string InsertCustomerTransaction = "Customer/InsertCustomerTransaction";
        public static string GetCustomerDetailByUserNameAndPassword = "Customer/GetCustomerDetailByUserNameAndPassword?CustomerNo=";
    }
    public struct VoidTicketApi
    {
        public static string GetNonVoidedTicketBets = "BetEntry/GetNonVoidedTicketBets/";
        public static string GetLottoBets = "VoidTicket/GetLottoBets/";
        public static string AdjustBetsPerBall = "VoidTicket/AdjustBetsPerBall";
        public static string GetLottoTicketbyTicketId = "VoidTicket/GetLottoTicketbyTicketId/";
        public static string InsertUserTransaction = "VoidTicket/InsertUserTransaction";
        public static string UpdatetblLottoTicket = "VoidTicket/UpdatetblLottoTicket";
    }

 
}
