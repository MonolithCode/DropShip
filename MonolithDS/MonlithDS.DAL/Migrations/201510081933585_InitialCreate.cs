namespace MonlithDS.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessProfile",
                c => new
                    {
                        AccessProfileID = c.Guid(nullable: false),
                        AdminPanel = c.Boolean(nullable: false),
                        EbayListingsCreation = c.Boolean(nullable: false),
                        EbayItemSubmission = c.Boolean(nullable: false),
                        ProfileDisplayName = c.String(nullable: false, maxLength: 80),
                        DashBoard = c.Boolean(nullable: false),
                        AdminUsers = c.Boolean(nullable: false),
                        AdminProfiles = c.Boolean(nullable: false),
                        AdminService = c.Boolean(nullable: false),
                        AdminEbay = c.Boolean(nullable: false),
                        AdminPaypal = c.Boolean(nullable: false),
                        AdminAttributes = c.Boolean(nullable: false),
                        AdminRestrictions = c.Boolean(nullable: false),
                        AdminTemplates = c.Boolean(nullable: false),
                        ProductAdd = c.Boolean(nullable: false),
                        ProductItems = c.Boolean(nullable: false),
                        ProductInProgress = c.Boolean(nullable: false),
                        ProductForReview = c.Boolean(nullable: false),
                        ProductFinalStage = c.Boolean(nullable: false),
                        ProductLiveListings = c.Boolean(nullable: false),
                        AmazonAccounts = c.Boolean(nullable: false),
                        Cards = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccessProfileID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeID = c.Guid(nullable: false),
                        DisplayEmployeeID = c.Int(nullable: false, identity: true),
                        Forename = c.String(maxLength: 50),
                        Surname = c.String(maxLength: 50),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 200),
                        DateOfBirth = c.DateTime(),
                        AccessProfileID = c.Guid(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.AccessProfile", t => t.AccessProfileID)
                .Index(t => t.AccessProfileID);
            
            CreateTable(
                "dbo.EbayListing",
                c => new
                    {
                        EbayListingID = c.Guid(nullable: false),
                        EbayAccountID = c.Guid(),
                        AmazonItemID = c.Guid(),
                        EbayItemID = c.String(maxLength: 400),
                        Status = c.String(maxLength: 50),
                        DescriptionHtml = c.String(),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Sold = c.Boolean(nullable: false),
                        SoldDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Retracted = c.Boolean(nullable: false),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Postage = c.Decimal(precision: 18, scale: 2),
                        Currency = c.String(maxLength: 5),
                        Title = c.String(nullable: false, maxLength: 80),
                        SubTitle = c.String(maxLength: 55),
                        CategoryID = c.Int(nullable: false),
                        PaypalID = c.Int(),
                        PriceFixed = c.Boolean(nullable: false),
                        ConditionID = c.Guid(nullable: false),
                        Quantity = c.Int(nullable: false),
                        DescriptionHeader = c.String(maxLength: 200),
                        DescriptionSubHeader = c.String(maxLength: 200),
                        DescriptionContent = c.String(),
                        DescriptionPayment = c.String(maxLength: 2000),
                        DescriptionShipping = c.Guid(),
                        DescriptionReturnPolicy = c.Guid(),
                        DescriptionFeedback = c.Guid(),
                        DescriptionTaxes = c.Guid(),
                        InProgress = c.Boolean(nullable: false),
                        EmployeeID = c.Guid(),
                        ListingDurationID = c.Guid(),
                        ReadyToSubmit = c.Boolean(nullable: false),
                        Online = c.Boolean(nullable: false),
                        ReadyForEbayList = c.Boolean(nullable: false),
                        ListingUrl = c.String(maxLength: 400),
                        ChangesToApply = c.Boolean(nullable: false),
                        NewPrice = c.Decimal(precision: 18, scale: 2),
                        AcceptNewPrice = c.Boolean(nullable: false),
                        RejectNewPrice = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EbayListingID)
                .ForeignKey("dbo.AmazonItem", t => t.AmazonItemID)
                .ForeignKey("dbo.EbayAccount", t => t.EbayAccountID)
                .ForeignKey("dbo.EbayCategories", t => t.CategoryID)
                .ForeignKey("dbo.EbayFeedback", t => t.DescriptionFeedback)
                .ForeignKey("dbo.EbayListingCondition", t => t.ConditionID)
                .ForeignKey("dbo.EbayListingDuration", t => t.ListingDurationID)
                .ForeignKey("dbo.EbayReturnPolicy", t => t.DescriptionReturnPolicy)
                .ForeignKey("dbo.EbayShipping", t => t.DescriptionShipping)
                .ForeignKey("dbo.EbayTaxes", t => t.DescriptionTaxes)
                .ForeignKey("dbo.Employee", t => t.EmployeeID)
                .Index(t => t.EbayAccountID)
                .Index(t => t.AmazonItemID)
                .Index(t => t.CategoryID)
                .Index(t => t.ConditionID)
                .Index(t => t.DescriptionShipping)
                .Index(t => t.DescriptionReturnPolicy)
                .Index(t => t.DescriptionFeedback)
                .Index(t => t.DescriptionTaxes)
                .Index(t => t.EmployeeID)
                .Index(t => t.ListingDurationID);
            
            CreateTable(
                "dbo.AmazonItem",
                c => new
                    {
                        AmazonItemID = c.Guid(nullable: false),
                        ASIN = c.String(nullable: false, maxLength: 20),
                        SKU = c.String(maxLength: 50),
                        Title = c.String(maxLength: 200),
                        Description = c.String(),
                        Status = c.String(maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdatedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Price = c.Decimal(precision: 18, scale: 2),
                        LastCheckedDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Rating = c.Decimal(precision: 18, scale: 2),
                        UPC = c.String(maxLength: 50),
                        ISBN = c.String(maxLength: 50),
                        Model = c.String(maxLength: 50),
                        MPN = c.String(maxLength: 50),
                        Brand = c.String(maxLength: 50),
                        Url = c.String(maxLength: 300),
                        OfferListingID = c.String(),
                        OffersUrl = c.String(maxLength: 250),
                        OutOfStock = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AmazonItemID);
            
            CreateTable(
                "dbo.AmazonItemFeatures",
                c => new
                    {
                        AmazonItemFeatureID = c.Guid(nullable: false),
                        Description = c.String(nullable: false),
                        AmazonItemID = c.Guid(nullable: false),
                        Order = c.Int(),
                    })
                .PrimaryKey(t => t.AmazonItemFeatureID)
                .ForeignKey("dbo.AmazonItem", t => t.AmazonItemID)
                .Index(t => t.AmazonItemID);
            
            CreateTable(
                "dbo.AmazonItemImages",
                c => new
                    {
                        AmazonImagesID = c.Int(nullable: false, identity: true),
                        AmazonItemID = c.Guid(nullable: false),
                        Image = c.Binary(nullable: false, storeType: "image"),
                        Order = c.Int(),
                    })
                .PrimaryKey(t => t.AmazonImagesID)
                .ForeignKey("dbo.AmazonItem", t => t.AmazonItemID)
                .Index(t => t.AmazonItemID);
            
            CreateTable(
                "dbo.EbayAccount",
                c => new
                    {
                        EbayAccountID = c.Guid(nullable: false),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        AccessToken = c.String(),
                        Authorised = c.Boolean(nullable: false),
                        EbayApiID = c.Guid(),
                        PayPalID = c.Guid(),
                        SecretKey = c.Guid(nullable: false),
                        TemplateID = c.Guid(),
                        AmazonAccountID = c.Guid(),
                        LocationPostalCode = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.EbayAccountID)
                .ForeignKey("dbo.AmazonAccount", t => t.AmazonAccountID)
                .ForeignKey("dbo.EbayAPI", t => t.EbayApiID)
                .ForeignKey("dbo.PayPal", t => t.PayPalID)
                .ForeignKey("dbo.Template", t => t.TemplateID)
                .Index(t => t.EbayApiID)
                .Index(t => t.PayPalID)
                .Index(t => t.TemplateID)
                .Index(t => t.AmazonAccountID);
            
            CreateTable(
                "dbo.AmazonAccount",
                c => new
                    {
                        AmazonAccountID = c.Guid(nullable: false),
                        DisplayName = c.String(nullable: false, maxLength: 100),
                        Username = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 200),
                        CardID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AmazonAccountID)
                .ForeignKey("dbo.Card", t => t.CardID)
                .Index(t => t.CardID);
            
            CreateTable(
                "dbo.Card",
                c => new
                    {
                        CardID = c.Guid(nullable: false),
                        DisplayName = c.String(nullable: false, maxLength: 100),
                        CardNumber = c.String(nullable: false, maxLength: 100),
                        NameOnCard = c.String(nullable: false, maxLength: 150),
                        StartDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SecurityCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardID);
            
            CreateTable(
                "dbo.EbayAccountFeeDates",
                c => new
                    {
                        FeeRemovalID = c.Guid(nullable: false),
                        DisplayName = c.String(nullable: false, maxLength: 100),
                        Date = c.DateTime(nullable: false),
                        EbayAccountID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FeeRemovalID)
                .ForeignKey("dbo.EbayAccount", t => t.EbayAccountID)
                .Index(t => t.EbayAccountID);
            
            CreateTable(
                "dbo.EbayAPI",
                c => new
                    {
                        EbayApiID = c.Guid(nullable: false),
                        AppID = c.String(nullable: false, maxLength: 80),
                        DevID = c.String(nullable: false, maxLength: 80),
                        AuthCert = c.String(nullable: false, maxLength: 80),
                        Token = c.String(),
                        Runame = c.String(maxLength: 80),
                        SandBoxToken = c.String(),
                    })
                .PrimaryKey(t => t.EbayApiID);
            
            CreateTable(
                "dbo.PayPal",
                c => new
                    {
                        PaypalID = c.Guid(nullable: false),
                        ApiUsername = c.String(nullable: false, maxLength: 100),
                        ApiPassword = c.String(nullable: false, maxLength: 100),
                        ApiSignature = c.String(nullable: false, maxLength: 150),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        EmailAddress = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.PaypalID);
            
            CreateTable(
                "dbo.Template",
                c => new
                    {
                        TemplateID = c.Guid(nullable: false),
                        TemplateName = c.String(nullable: false, maxLength: 50),
                        Html = c.String(),
                    })
                .PrimaryKey(t => t.TemplateID);
            
            CreateTable(
                "dbo.EbayCategories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false),
                        CategoryLevel = c.Int(nullable: false),
                        CategoryName = c.String(nullable: false, maxLength: 80),
                        ParentID = c.Int(nullable: false),
                        AutoPayEnabled = c.Boolean(nullable: false),
                        BestOfferEnabled = c.Boolean(nullable: false),
                        FullName = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.EbayFeedback",
                c => new
                    {
                        FeedbackID = c.Guid(nullable: false),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FeedbackID);
            
            CreateTable(
                "dbo.EbayListingCondition",
                c => new
                    {
                        ConditionID = c.Guid(nullable: false),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConditionID);
            
            CreateTable(
                "dbo.EbayListingDuration",
                c => new
                    {
                        EbayListingDurationID = c.Guid(nullable: false),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        Value = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EbayListingDurationID);
            
            CreateTable(
                "dbo.EbayListingErrors",
                c => new
                    {
                        ErrorID = c.Guid(nullable: false),
                        EbayListingID = c.Guid(nullable: false),
                        Message = c.String(),
                        CreateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ErrorID)
                .ForeignKey("dbo.EbayListing", t => t.EbayListingID)
                .Index(t => t.EbayListingID);
            
            CreateTable(
                "dbo.EbayListingFeatures",
                c => new
                    {
                        EbayListingFeatureID = c.Guid(nullable: false),
                        Description = c.String(nullable: false),
                        Order = c.Int(),
                        EbayListingID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EbayListingFeatureID)
                .ForeignKey("dbo.EbayListing", t => t.EbayListingID)
                .Index(t => t.EbayListingID);
            
            CreateTable(
                "dbo.EbayListingImages",
                c => new
                    {
                        EbayListingImageID = c.Guid(nullable: false),
                        EbayListingID = c.Guid(nullable: false),
                        Image = c.Binary(nullable: false, storeType: "image"),
                        Order = c.Int(),
                        Link = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.EbayListingImageID)
                .ForeignKey("dbo.EbayListing", t => t.EbayListingID)
                .Index(t => t.EbayListingID);
            
            CreateTable(
                "dbo.EbayReturnPolicy",
                c => new
                    {
                        ReturnPolicyID = c.Guid(nullable: false),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ReturnPolicyID);
            
            CreateTable(
                "dbo.EbayShipping",
                c => new
                    {
                        ShippingID = c.Guid(nullable: false),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ShippingID);
            
            CreateTable(
                "dbo.EbayTaxes",
                c => new
                    {
                        TaxesID = c.Guid(nullable: false),
                        DisplayName = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TaxesID);
            
            CreateTable(
                "dbo.ListingFees",
                c => new
                    {
                        FeedID = c.Guid(nullable: false),
                        AuctionLengthFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BoldFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BuyItNowFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryFeaturedFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FeaturedFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GalleryPlusFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FeaturedGalleryFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FixedPriceDurationFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GalleryFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GiftIconFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HighLightFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InsertionFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InternationalInsertionFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ListingDesignerFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ListingFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PhotoDisplayFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PhotoFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReserveFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SchedulingFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubtitleFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BorderFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProPackBundleFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BasicUpgradePackBundleFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValuePackBundleFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrivateListingFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProPackPlusBundleFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MotorsGermanySearchFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EbayListingID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.FeedID)
                .ForeignKey("dbo.EbayListing", t => t.EbayListingID)
                .Index(t => t.EbayListingID);
            
            CreateTable(
                "dbo.AmazonItemSearch",
                c => new
                    {
                        AmazonItemSearchID = c.Guid(nullable: false),
                        ASIN = c.String(nullable: false, maxLength: 20),
                        Title = c.String(maxLength: 100),
                        Description = c.String(),
                        Status = c.String(maxLength: 20),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        LastCheckedDate = c.DateTime(),
                        RUID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AmazonItemSearchID);
            
            CreateTable(
                "dbo.EbayOrderChanges",
                c => new
                    {
                        OrderChangeID = c.Guid(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        MarkAsShipped = c.Boolean(nullable: false),
                        AddTrackingNumber = c.Boolean(nullable: false),
                        LeaveFeedback = c.Boolean(nullable: false),
                        Negative = c.Boolean(nullable: false),
                        Message = c.String(maxLength: 50),
                        EBayOrderID = c.String(nullable: false, maxLength: 150),
                        TrackingNumber = c.String(maxLength: 200),
                        OrderID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OrderChangeID)
                .ForeignKey("dbo.EbayOrders", t => t.OrderID)
                .Index(t => t.OrderID);
            
            CreateTable(
                "dbo.EbayOrders",
                c => new
                    {
                        OrderID = c.Guid(nullable: false),
                        EbayOrderID = c.String(nullable: false, maxLength: 150),
                        AmountPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        eBayPaymentStatus = c.String(maxLength: 100),
                        PaymentMethod = c.String(maxLength: 100),
                        ShippingName = c.String(maxLength: 100),
                        ShippingStreet1 = c.String(maxLength: 100),
                        ShippingStreet2 = c.String(maxLength: 100),
                        ShippingCityName = c.String(maxLength: 100),
                        ShippingStateOrProvince = c.String(maxLength: 100),
                        ShippingCountry = c.String(maxLength: 100),
                        AddressCountryName = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 100),
                        PostalCode = c.String(maxLength: 50),
                        EbayItemID = c.String(nullable: false, maxLength: 400),
                        QuantityPurchased = c.Int(nullable: false),
                        PaymentStatus = c.String(nullable: false, maxLength: 150),
                        PaymentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionID = c.String(nullable: false, maxLength: 200),
                        Shipped = c.Boolean(nullable: false),
                        ShippedTime = c.DateTime(precision: 7, storeType: "datetime2"),
                        TrackingNumber = c.String(maxLength: 150),
                        TrackingNumberAdded = c.Boolean(nullable: false),
                        Username = c.String(maxLength: 100),
                        CreatedDate = c.String(maxLength: 50),
                        CreatedDateReadable = c.DateTime(),
                        OrderedOnAmazon = c.Boolean(nullable: false),
                        StockUpdated = c.Boolean(nullable: false),
                        AmazonOrderRef = c.String(maxLength: 50),
                        LastUpdated = c.DateTime(nullable: false),
                        AmazonShipmentID = c.String(maxLength: 150),
                        AmazonOrderStatus = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.OrderID);
            
            CreateTable(
                "dbo.EventLog",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        Event = c.String(nullable: false, maxLength: 50),
                        Message = c.String(nullable: false),
                        Employee = c.Guid(),
                        IPAddress = c.String(nullable: false, maxLength: 50),
                        EbayListingID = c.Guid(),
                        OrderID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FeeCalculationValues",
                c => new
                    {
                        FeeCalcID = c.Guid(nullable: false),
                        PaypalPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaypalFixedAdditionalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaypalInternationalFeePercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EbayInsertionFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EbayFVFeePercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FeeCalcID);
            
            CreateTable(
                "dbo.PriceRanges",
                c => new
                    {
                        RangeID = c.Guid(nullable: false),
                        Min = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Max = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Profit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency = c.String(nullable: false, maxLength: 50),
                        DisplayName = c.String(maxLength: 197),
                    })
                .PrimaryKey(t => t.RangeID);
            
            CreateTable(
                "dbo.ProductRestrictions",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        MinRating = c.Int(nullable: false),
                        UseRating = c.Boolean(nullable: false),
                        AllowAdultProducts = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ServiceSettings",
                c => new
                    {
                        ServiceSettingsID = c.Guid(nullable: false),
                        CheckEvery = c.Int(nullable: false),
                        Disabled = c.Boolean(nullable: false),
                        EmailFailures = c.Boolean(nullable: false),
                        Emails = c.String(maxLength: 400),
                        RunOnStart = c.Boolean(nullable: false),
                        UseFixedPriceAddition = c.Boolean(nullable: false),
                        FixedPriceValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PercentageValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoundUpTo99 = c.Boolean(nullable: false),
                        ReducePriceIfLowers = c.Boolean(nullable: false),
                        LastAmazonOrderScrape = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceSettingsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EbayOrderChanges", "OrderID", "dbo.EbayOrders");
            DropForeignKey("dbo.ListingFees", "EbayListingID", "dbo.EbayListing");
            DropForeignKey("dbo.EbayListing", "EmployeeID", "dbo.Employee");
            DropForeignKey("dbo.EbayListing", "DescriptionTaxes", "dbo.EbayTaxes");
            DropForeignKey("dbo.EbayListing", "DescriptionShipping", "dbo.EbayShipping");
            DropForeignKey("dbo.EbayListing", "DescriptionReturnPolicy", "dbo.EbayReturnPolicy");
            DropForeignKey("dbo.EbayListingImages", "EbayListingID", "dbo.EbayListing");
            DropForeignKey("dbo.EbayListingFeatures", "EbayListingID", "dbo.EbayListing");
            DropForeignKey("dbo.EbayListingErrors", "EbayListingID", "dbo.EbayListing");
            DropForeignKey("dbo.EbayListing", "ListingDurationID", "dbo.EbayListingDuration");
            DropForeignKey("dbo.EbayListing", "ConditionID", "dbo.EbayListingCondition");
            DropForeignKey("dbo.EbayListing", "DescriptionFeedback", "dbo.EbayFeedback");
            DropForeignKey("dbo.EbayListing", "CategoryID", "dbo.EbayCategories");
            DropForeignKey("dbo.EbayAccount", "TemplateID", "dbo.Template");
            DropForeignKey("dbo.EbayAccount", "PayPalID", "dbo.PayPal");
            DropForeignKey("dbo.EbayListing", "EbayAccountID", "dbo.EbayAccount");
            DropForeignKey("dbo.EbayAccount", "EbayApiID", "dbo.EbayAPI");
            DropForeignKey("dbo.EbayAccountFeeDates", "EbayAccountID", "dbo.EbayAccount");
            DropForeignKey("dbo.EbayAccount", "AmazonAccountID", "dbo.AmazonAccount");
            DropForeignKey("dbo.AmazonAccount", "CardID", "dbo.Card");
            DropForeignKey("dbo.EbayListing", "AmazonItemID", "dbo.AmazonItem");
            DropForeignKey("dbo.AmazonItemImages", "AmazonItemID", "dbo.AmazonItem");
            DropForeignKey("dbo.AmazonItemFeatures", "AmazonItemID", "dbo.AmazonItem");
            DropForeignKey("dbo.Employee", "AccessProfileID", "dbo.AccessProfile");
            DropIndex("dbo.EbayOrderChanges", new[] { "OrderID" });
            DropIndex("dbo.ListingFees", new[] { "EbayListingID" });
            DropIndex("dbo.EbayListingImages", new[] { "EbayListingID" });
            DropIndex("dbo.EbayListingFeatures", new[] { "EbayListingID" });
            DropIndex("dbo.EbayListingErrors", new[] { "EbayListingID" });
            DropIndex("dbo.EbayAccountFeeDates", new[] { "EbayAccountID" });
            DropIndex("dbo.AmazonAccount", new[] { "CardID" });
            DropIndex("dbo.EbayAccount", new[] { "AmazonAccountID" });
            DropIndex("dbo.EbayAccount", new[] { "TemplateID" });
            DropIndex("dbo.EbayAccount", new[] { "PayPalID" });
            DropIndex("dbo.EbayAccount", new[] { "EbayApiID" });
            DropIndex("dbo.AmazonItemImages", new[] { "AmazonItemID" });
            DropIndex("dbo.AmazonItemFeatures", new[] { "AmazonItemID" });
            DropIndex("dbo.EbayListing", new[] { "ListingDurationID" });
            DropIndex("dbo.EbayListing", new[] { "EmployeeID" });
            DropIndex("dbo.EbayListing", new[] { "DescriptionTaxes" });
            DropIndex("dbo.EbayListing", new[] { "DescriptionFeedback" });
            DropIndex("dbo.EbayListing", new[] { "DescriptionReturnPolicy" });
            DropIndex("dbo.EbayListing", new[] { "DescriptionShipping" });
            DropIndex("dbo.EbayListing", new[] { "ConditionID" });
            DropIndex("dbo.EbayListing", new[] { "CategoryID" });
            DropIndex("dbo.EbayListing", new[] { "AmazonItemID" });
            DropIndex("dbo.EbayListing", new[] { "EbayAccountID" });
            DropIndex("dbo.Employee", new[] { "AccessProfileID" });
            DropTable("dbo.ServiceSettings");
            DropTable("dbo.ProductRestrictions");
            DropTable("dbo.PriceRanges");
            DropTable("dbo.FeeCalculationValues");
            DropTable("dbo.EventLog");
            DropTable("dbo.EbayOrders");
            DropTable("dbo.EbayOrderChanges");
            DropTable("dbo.AmazonItemSearch");
            DropTable("dbo.ListingFees");
            DropTable("dbo.EbayTaxes");
            DropTable("dbo.EbayShipping");
            DropTable("dbo.EbayReturnPolicy");
            DropTable("dbo.EbayListingImages");
            DropTable("dbo.EbayListingFeatures");
            DropTable("dbo.EbayListingErrors");
            DropTable("dbo.EbayListingDuration");
            DropTable("dbo.EbayListingCondition");
            DropTable("dbo.EbayFeedback");
            DropTable("dbo.EbayCategories");
            DropTable("dbo.Template");
            DropTable("dbo.PayPal");
            DropTable("dbo.EbayAPI");
            DropTable("dbo.EbayAccountFeeDates");
            DropTable("dbo.Card");
            DropTable("dbo.AmazonAccount");
            DropTable("dbo.EbayAccount");
            DropTable("dbo.AmazonItemImages");
            DropTable("dbo.AmazonItemFeatures");
            DropTable("dbo.AmazonItem");
            DropTable("dbo.EbayListing");
            DropTable("dbo.Employee");
            DropTable("dbo.AccessProfile");
        }
    }
}
