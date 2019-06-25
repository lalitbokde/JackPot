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
        public static string GetHouseDetail = "BetEntry/getHousesDetailsMode";
        public static string GoogleMapApiKey = "AIzaSyC50XshkjneoleOy4CTQxRmWAv-qYGhd8Q";


    }
    public struct PalletMaintainanceServiceUrl
    {
        public static string GetPalletMaintainanceDetai = "PalletBarcode/PostDetail";
        public static string GetUserLoginDetail = "Users/Authenticate";
        public static string GetPalletreceivinglog = "WarehouseReceiveLog";
        public static string PostPalletreceivinglog = "Pallet";
        public static string GetlotNoreceive = "PalletBarcode/GetLotNoList?ValueType=";
        public static string DeletePalletItem = "Pallet/DeletePalletItem";
        public static string DeletePallet = "Pallet/DeletePalletId?=";

        public static string GetPalletItemByPalletId = "Pallet/GetPalletItemByPalletId";
        public static string updatePalletItemByPalletId = "Pallet/UpdatePalletItemByPalletId?palletId=";
        public static string checkquantityUpdatePalletItemByPalletId = "Pallet/CheckQuantityUpdatePalletItemByPalletId";
        public static string GetReportRecord = "WarehouseReceiveLog/GetPalletMaintainanceReportDetail?Count=";
        public static string GetBarcode = "PalletBarcode/GetBarcodeList?wrreceivinglogid=";
    }


    public struct StockInServiceUrl
    {

        public static string PostStockIn = "StockInPallet";
        public static string GetQuantity = "Pallet/";

    }

   
    public struct PickUpUrl
    {
        public static string getshippinglist = "pickup/GetShipping?ID=";
        public static string Deletepickuplist = "Pickup/DeletePickUpList?pickListId=";
        public static string getPickUpListById = "Pickup/GetPickUpListById?pickListId=";
        public static string getshippingDetails = "pickup/GetShippingAdress?CustomerId=";
        public static string getshipperTo = "pickup/GetShipperAddress";
        public static string PostDetail = "pickup/CreatePickup";
        public static string getProducts = "pickup/GetPickUpProduct?CustomerId=";
        public static string deleteWrPickupproduct = "pickup/DeleteWrPickProductByWrPickupProductId?WrPickupProductId=";
        public static string getBinDetailsByProductId = "pickup/GetBins";
        public static string getPickUpList = "pickup/GetPickUpList";
        public static string postPickUpEditBin = "pickup/AddEditeProductBin?pickuplistId=";
        public static string postResetPickUpEditProductBin = "pickup/ResetEditeProductBin?pickuplistId=";
        public static string getGetShippingProducts = "pickup/GetShippingProducts?Id=";
        public static string getProcessPicupList = "Picking/PickingApiList?id=";
        public static string postBinsDetails = "pickup/AddEditeProductBin?pickuplistId=";
        public static string postgetProgressPicupListdetails = "Picking/CompleteApiPickingList";

    }
    public struct PrinterUrl
    {
        public static string PrinterNames = "Printer/GetPrinters";
        public static string PrintOut = "Printer/PrintOut";
    }

    public struct ClearPalletTagUrl
    {
        public static string ClearPalletTag = "PalletClear";

    }
    public struct ProductUrl
    {
        public static string DeleteProduct = "Product/DeleteProduct?productid=";
        public static string Creatingproduct = "Product/CreatingProduct";
        public static string GetProductList = "Product/GetProductList";
        public static string GetProduct = "BinDetailByProduct/GetProductList";
        public static string GetProductDetails = "BinDetailByProduct/GetBinsDetail";
        public static string postproducts = "WrReceivingLogProduct/AddProductWrRecLog";
        public static string postEditproducts = "WrReceivingLogProduct/EditProductWrRecLog";
        public static string postdeleteproducts = "WrReceivingLogProduct/DeleteWrReceivingLogProduct";
  

    }

    public struct ClearBinTagUrl
    {
        public static string ClearBinTag = "BinClear";

    }
    public struct DashBoardURL
    {
        public static string GetCalender = "Dashboard/GetCalender";
        public static string GetCalenderByDate = "Dashboard/GetCalenderByDate";

    }

    public struct GetPickUpListUrl
    {
        public static string GetPickUpList = "PickUpList";

    }
    public struct GetBintagsUrl
    {
        public static string GetBintagList = "BinsList";
    }

    public struct GetPalletListUrl
    {
        public static string getpalletlist = "Pallet/GetPalletList";
        public static string getpalletTaglist = "Pallet/GetPalletTagList";
    }
    public struct WrReceivingLogProduct
    {
        public static string getcustomerlist = "WrReceivingLogProduct/UserCustomerList";
        public static string getvenderlist = "WrReceivingLogProduct/GetVendorList";
        public static string getproductlist = "WrReceivingLogProduct/GetProductNameList?keyword=";
        public static string getmaxlotno = "WrReceivingLogProduct/GetMaxLotNo";
        public static string GetPalletDetailByWrrecivingId = "WrReceivingLogProduct/GetPalletmaintenanceItemByWrReceivingId?WrReceivingId=";
    }

    public struct DamageStockUrl
    {
        public static string InsertDamageStock = "DamageStock";
        public static string DamageStockList = "DamageStock/GetDamageStockList";
        public static string damageproductByWRReceivingId = "DamageStock/GetDamageStockProductByWRReceivedProductIdList?wrreceivedproductId=";
    }

    public struct DeliveryListUrl
    {
        public static string DeliveryList = "WarehouseReceiveLog/GetDeleiveryList?Id=";
    }


}
