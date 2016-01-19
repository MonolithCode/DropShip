using System;
using System.Windows.Forms;
using EbayModule;
using EbayModule.eBaySvc;
using EbayModule.enums;
using EbayModule.Extensions;
using EbayModule.view;

namespace ApplicationTest
{
    public partial class Form1 : Form
    {
        public IEbayService Service;

        public Form1(IEbayService service)
        {
            InitializeComponent();
            Service = service;
        }

        //private void AddItem()
        //{
        //    AddFixedPriceItemRequestType req = new AddFixedPriceItemRequestType();
        //    ItemType item = new ItemType
        //    {
        //        ConditionID = 1000,
        //        Country = CountryCodeType.AU,
        //        Currency = CurrencyCodeType.AUD,
        //        InventoryTrackingMethod = InventoryTrackingMethodCodeType.SKU,
        //        SKU = "PROD1234",
        //        Description = "test - do not bid or buy",
        //        Title = "test - do not bid or buy",
        //        SubTitle = "Test Item",
        //        ListingDuration = "Days_7",
        //        PaymentMethods = new BuyerPaymentMethodCodeType[1]
        //    };
        //    //set the item condition depending on the value from GetCategoryFeatures
        //    //new

        //    //Basic properties of a listing

        //    //Track item by SKU


        //    item.PaymentMethods.Add(BuyerPaymentMethodCodeType.PayPal);
        //    item.PayPalEmailAddress = "test@test.com";
        //    item.PostalCode = "2001";

        //    //Specify Shipping Services
        //    item.DispatchTimeMax = 3;
        //    item.ShippingDetails = new ShippingDetailsType();
        //    item.ShippingDetails.ShippingServiceOptions = new ShippingServiceOptionsTypeCollection();

        //    ShippingServiceOptionsType shipservice1 = new ShippingServiceOptionsType();
        //    shipservice1.ShippingService = "AU_Regular";
        //    shipservice1.ShippingServicePriority = 1;
        //    shipservice1.ShippingServiceCost = new AmountType();
        //    shipservice1.ShippingServiceCost.currencyID = CurrencyCodeType.AUD;
        //    shipservice1.ShippingServiceCost.Value = 1.0;

        //    shipservice1.ShippingServiceAdditionalCost = new AmountType();
        //    shipservice1.ShippingServiceAdditionalCost.currencyID = CurrencyCodeType.AUD;
        //    shipservice1.ShippingServiceAdditionalCost.Value = 1.0;

        //    item.ShippingDetails.ShippingServiceOptions.Add(shipservice1);

        //    ShippingServiceOptionsType shipservice2 = new ShippingServiceOptionsType();
        //    shipservice2.ShippingService = "AU_Express";
        //    shipservice2.ShippingServicePriority = 2;
        //    shipservice2.ShippingServiceCost = new AmountType();
        //    shipservice2.ShippingServiceCost.currencyID = CurrencyCodeType.AUD;
        //    shipservice2.ShippingServiceCost.Value = 4.0;

        //    shipservice2.ShippingServiceAdditionalCost = new AmountType();
        //    shipservice2.ShippingServiceAdditionalCost.currencyID = CurrencyCodeType.AUD;
        //    shipservice2.ShippingServiceAdditionalCost.Value = 1.0;

        //    item.ShippingDetails.ShippingServiceOptions.Add(shipservice2);

        //    //Specify Return Policy
        //    item.ReturnPolicy = new ReturnPolicyType();
        //    item.ReturnPolicy.ReturnsAcceptedOption = "ReturnsAccepted";

        //    item.Quantity = 10;
        //    item.StartPrice = new AmountType();
        //    item.StartPrice.currencyID = CurrencyCodeType.AUD;
        //    item.StartPrice.Value = 10;

        //    item.PrimaryCategory = new CategoryType();
        //    item.PrimaryCategory.CategoryID = "156955";

        //    item.ProductListingDetails = new ProductListingDetailsType();

        //    //Specifying UPC as the product identifier. Other applicable product identifiers
        //    //include ISBN, EAN, Brand-MPN.

        //    item.ProductListingDetails.UPC = UPC;

        //    //If multiple product identifiers are specified, eBay uses the first one that
        //    //matches a product in eBay's catalog system.
        //    item.ProductListingDetails.BrandMPN = new BrandMPNType();
        //    item.ProductListingDetails.BrandMPN.Brand = Brand;
        //    item.ProductListingDetails.BrandMPN.MPN = MPN;

        //    //For listing to be pre-filled with product information from the catalog
        //    item.ProductListingDetails.IncludePrefilledItemInformation = true;

        //    //Include the eBay stock photo with the listing if available and use it as the gallery picture
        //    item.ProductListingDetails.IncludeStockPhotoURL = true;
        //    item.ProductListingDetails.UseStockPhotoURLAsGallery = true;
        //    item.ProductListingDetails.UseStockPhotoURLAsGallerySpecified = true;

        //    //If multiple prod matches found, list the item with the 1st product's information
        //    item.ProductListingDetails.UseFirstProduct = true;
        //    // List the item even if no product match found
        //    item.ProductListingDetails.ListIfNoProduct = true;

        //    //Add pictures
        //    item.PictureDetails = new PictureDetailsType();

        //    //Specify GalleryType
        //    item.PictureDetails.GalleryType = GalleryTypeCodeType.None;
        //    item.PictureDetails.GalleryTypeSpecified = true;
        //}

        private void button1_Click(object sender, EventArgs e)
        {
           
            string[] mews = new string[1];
            mews[0] = @"C:\git\img.jpg";
            var moo = Service.Sales.ProductManagement.ImageManager.UpLoadPictureFiles(PhotoDisplayCodeType.CustomCode, mews);
            //var mopo = Service.Sales.GetMyEbayListings(OrderStatusFilterCodeType.All);
            //var mso = Service.Sales.ProductManagement.ImageManager.UpLoadPictureFile(
            //        PhotoDisplayCodeType.CustomCode, @"C:\pic\original.jpg");
            var req = new EbayListingUpdateRequest("110151755098");
            req.MarkAsShipped();
            var data = Service.Sales.ProductManagement.UpdateListing(req);
            
            //var up = Service.Sales.ProductManagement.UpdateListing(req);
            //var mo = Service.Sales.GetSales()
            var mo = "";
        }
    }
}
