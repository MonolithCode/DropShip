using System;
using System.Windows.Forms;
using EbayModule.eBaySvc;
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
            //var properties = new EbayProperties("Lunchbox-ba44-4393-a8b7-4d3e3e15af5b", "dc4ad018-7461-4a1b-bf30-aeeb02472561", "617cc402-f344-4014-a371-a38b35a2af39","AgAAAA**AQAAAA**aAAAAA**7iQxVA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wFk4GhCZSEoQydj6x9nY+seQ**y+sBAA**AAMAAA**UWXWs911deeY+IEdv4CAIoibqS+dhtEQsp8s7vLI3mX0w7Jn3aVT8fp3puozeGIfUz9BHk2h02sfqsTq7JBRVyQDjB5hKiHB55JlE0I9nk448KB+NByG9o0jChcqTrcFx3v+klrWgNZTRkdD0H/XRXpNP7IfAI20EmjRiNs7Cp0ldJtKnSAXW0Q5VoQOTMjJipLggMeQ/5ZfXRR80IQmPy76wcgZazVzhQtehFA5WE5lU/2xslaKFIAzc2L57U5h9gIDuqPdMY946Vu4cHBAnmdJSDk6qJDctf+07AISHlltQ67eYqsV8AB00ZGZPSKbB2qlbWNKLsBcpATCXD8cBVy0C2Oqk9HjiIuTMsLfkXbnZGwfpqVpHIO1hwwKwndfOf8y9NRUgPuKnyRiAlp+xakL2G6zDX/ytfFzJklwUVlF6YwOofxnWJauOf9Jz0wircIJdh+Wjj7/uPRpyN9zsi3UhxRuqPaD5/31VFAtZ2PTkCHUoFVXI4xNX9HKVi+/1Plj6k2o0tXDOsFaVs157rDyX/EH3GSUU6BQ2ZNlF4PLT85BS/ZvWpqMRMqvEyuqlBAQiwhAgH1NVqvs3SE1UjhxVE3bJFE3cjpxJIuf6/8udkwb42J16A2OLNEZDaGkgZgkVr67k39+M7FmqZ61MaisKoUyHeBVOqL76idsN4jyZ0kcAOhIB5ljmT32Uoya08iWJF5gi92z0eR0pRGjEmANaR112BxewTcWg2TO1BpjIecT5O/o+ZX83+c2N74y",
            //    "Lunchboxcode-Lunchbox-ba44-4-bsyng", "AgAAAA**AQAAAA**aAAAAA**7iQxVA**nY+sHZ2PrBmdj6wVnY+sEZ2PrA2dj6wFk4GhCZSEoQydj6x9nY+seQ**y+sBAA**AAMAAA**UWXWs911deeY+IEdv4CAIoibqS+dhtEQsp8s7vLI3mX0w7Jn3aVT8fp3puozeGIfUz9BHk2h02sfqsTq7JBRVyQDjB5hKiHB55JlE0I9nk448KB+NByG9o0jChcqTrcFx3v+klrWgNZTRkdD0H/XRXpNP7IfAI20EmjRiNs7Cp0ldJtKnSAXW0Q5VoQOTMjJipLggMeQ/5ZfXRR80IQmPy76wcgZazVzhQtehFA5WE5lU/2xslaKFIAzc2L57U5h9gIDuqPdMY946Vu4cHBAnmdJSDk6qJDctf+07AISHlltQ67eYqsV8AB00ZGZPSKbB2qlbWNKLsBcpATCXD8cBVy0C2Oqk9HjiIuTMsLfkXbnZGwfpqVpHIO1hwwKwndfOf8y9NRUgPuKnyRiAlp+xakL2G6zDX/ytfFzJklwUVlF6YwOofxnWJauOf9Jz0wircIJdh+Wjj7/uPRpyN9zsi3UhxRuqPaD5/31VFAtZ2PTkCHUoFVXI4xNX9HKVi+/1Plj6k2o0tXDOsFaVs157rDyX/EH3GSUU6BQ2ZNlF4PLT85BS/ZvWpqMRMqvEyuqlBAQiwhAgH1NVqvs3SE1UjhxVE3bJFE3cjpxJIuf6/8udkwb42J16A2OLNEZDaGkgZgkVr67k39+M7FmqZ61MaisKoUyHeBVOqL76idsN4jyZ0kcAOhIB5ljmT32Uoya08iWJF5gi92z0eR0pRGjEmANaR112BxewTcWg2TO1BpjIecT5O/o+ZX83+c2N74y", Modes.Sandbox, SiteCodeType.UK);
            //Service = new EbayService(properties);
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
            mews[0] = @"C:\pic\original.jpg";
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
