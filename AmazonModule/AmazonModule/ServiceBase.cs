using AmazonModule.AmazonService;
using AmazonModule.enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;

namespace AmazonModule
{
    public abstract class ServiceBase
    {
        private AWSECommerceServicePortTypeClient client;
        private string AccessKey;
        private string AssociateTag;

        public Merchants Merchant;
        public Dictionary<SearchIndex, string> BrowserNode;

        protected ServiceBase(string accessKey, string secretKey, string associateTag)
        {
            AccessKey = accessKey;
            AssociateTag = associateTag;

            var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport) { MaxReceivedMessageSize = int.MaxValue };
            client = new AWSECommerceServicePortTypeClient(
                binding,
                new EndpointAddress("https://webservices.amazon.com/onca/soap?Service=AWSECommerceService"));

            client.ChannelFactory.Endpoint.Behaviors.Add(
                new AmazonSigningEndpointBehavior(accessKey, secretKey));
            Merchant = Merchants.All;
            SetupUSBrowserNodes();

        }

        private void SetupUSBrowserNodes()
        {
            BrowserNode = new Dictionary<SearchIndex, string>
            {
                {SearchIndex.Apparel, "1036592"},
                {SearchIndex.Appliances, "2619525011"},
                {SearchIndex.ArtsAndCrafts, "2617941011"},
                {SearchIndex.Automotive, "15690151"},
                {SearchIndex.Baby, "165796011"},
                {SearchIndex.Beauty, "11055981"},
                {SearchIndex.Books, "1000"},
                {SearchIndex.Classical, "301668"},
                {SearchIndex.Collectibles, "4991425011"},
                {SearchIndex.DigitalMusic, "195208011"},
                {SearchIndex.Grocery, "16310101"},
                {SearchIndex.DVD, "2625373011"},
                {SearchIndex.Electronics, "493964"},
                {SearchIndex.HealthPersonalCare, "3760931"},
                {SearchIndex.HomeGarden, "285080"},
                {SearchIndex.Industrial, "228239"},
                {SearchIndex.Jewelry, "3880591"},
                {SearchIndex.KindleStore, "133141011"},
                {SearchIndex.Kitchen, "1063498"},
                {SearchIndex.LawnGarden, "2972638011"},
                {SearchIndex.Magazines, "599872"},
                {SearchIndex.Miscellaneous, "10304191"},
                {SearchIndex.MobileApps, "2350149011"},
                {SearchIndex.MP3Downloads, "195211011"},
                {SearchIndex.Music, "301668"},
                {SearchIndex.MusicalInstruments, "11091801"},
                {SearchIndex.OfficeProducts, "1084128"},
                {SearchIndex.OutdoorLiving, "1063498"},
                {SearchIndex.PCHardware, "493964"},
                {SearchIndex.PetSupplies, "1063498"},
                {SearchIndex.Photo, "493964"},
                {SearchIndex.Software, "409488"},
                {SearchIndex.SportingGoods, "3375251"},
                {SearchIndex.Tools, "468240"},
                {SearchIndex.Toys, "493964"},
                {SearchIndex.VHS, "404272"},
                {SearchIndex.Video, "130"},
                {SearchIndex.VideoGames, "493964"},
                {SearchIndex.Watches, "377110011"},
                {SearchIndex.Wireless, "508494"},
                {SearchIndex.WirelessAccessories, "13900851"}
            };
        }

        private ItemSearchRequest RequestBuilder(SearchIndex index, string keywords, int page, IEnumerable<ResponseGroup> responseGroups,
            Merchants merchant, int? maximumPrice, int? minimumPrice, int? percentageOff)
        {
            var request = new ItemSearchRequest
            {
                SearchIndex = index.ToString(),
                Keywords = keywords,
                MaximumPrice = maximumPrice != null ? maximumPrice.ToString() : null,
                MinimumPrice = minimumPrice != null ? minimumPrice.ToString() : null,
                MerchantId = merchant.ToString(),
                MinPercentageOff = percentageOff != null ? percentageOff.ToString() : null,
                ItemPage = page.ToString(CultureInfo.InvariantCulture),
                ResponseGroup = new[] { String.Join(",", responseGroups.Select(i => i.ToString()).ToArray()), }
            };

            return request;

        }

        public BrowseNodeLookupResponse BrowseNodeLookup(IEnumerable<string> browserNode, IEnumerable<BrowserLookupResponseGroup> responseGroup)
        {
            var request = new BrowseNodeLookupRequest
            {
                BrowseNodeId = new[] { String.Join(",", browserNode.Select(i => i.ToString(CultureInfo.InvariantCulture)).ToArray()) },
                ResponseGroup = new[] { String.Join(",", responseGroup.Select(i => i.ToString()).ToArray()) }
            };

            var itemSearch = SearchRequest(request);
            var response = client.BrowseNodeLookup(itemSearch);

            return response;
        }

        private ItemSearch SearchRequest(ItemSearchRequest request)
        {
            var itemSearch = new ItemSearch
            {
                Request = new[] { request },
                AWSAccessKeyId = AccessKey,
                AssociateTag = AssociateTag
            };

            return itemSearch;
        }

        public ItemLookupResponse ItemLookupCustom(string asin)
        {
            var lookup = new ItemLookup();
            var request = new ItemLookupRequest
            {
                IdType = ItemLookupRequestIdType.ASIN,
                IdTypeSpecified = true,
                ItemId = new[] { asin },
                ResponseGroup = new[] { "ItemAttributes", "OfferFull", "Reviews", "Large" }
            };

            //request.SearchIndex = "All";
            lookup.AWSAccessKeyId = AccessKey;
            lookup.AssociateTag = AssociateTag;
            lookup.Request = new[] { request };

            return client.ItemLookup(lookup);
        }


        private BrowseNodeLookup SearchRequest(BrowseNodeLookupRequest request)
        {
            var itemSearch = new BrowseNodeLookup
            {
                Request = new[] { request },
                AWSAccessKeyId = AccessKey,
                AssociateTag = AssociateTag
            };

            return itemSearch;
        }

        public ItemSearchResponse ItemSearch(string keywords, int page)
        {
            var list = new List<ResponseGroup> { ResponseGroup.ItemAttributes, ResponseGroup.OfferFull };
            return ItemSearch(SearchIndex.All, keywords, page, list, Merchant, null, null, null);
        }

        public ItemSearchResponse ItemSearch(SearchIndex index, string keywords, int page)
        {
            var list = new List<ResponseGroup> { ResponseGroup.ItemAttributes, ResponseGroup.OfferFull };
            return ItemSearch(index, keywords, page, list, Merchant, null, null, null);
        }

        public ItemSearchResponse ItemSearch(SearchIndex index, string keywords, int page, List<ResponseGroup> responseGroups)
        {
            return ItemSearch(index, keywords, page, responseGroups, Merchant, null, null, null);
        }

        public ItemSearchResponse ItemSearch(SearchIndex index, string keywords, int page, List<ResponseGroup> responseGroups,
            Merchants merchant)
        {
            return ItemSearch(index, keywords, page, responseGroups, merchant, null, null, null);
        }

        public ItemSearchResponse ItemSearch(SearchIndex index, string keywords, int page, List<ResponseGroup> responseGroups,
            Merchants merchant, int maxPrice, int minPrice)
        {
            return ItemSearch(index, keywords, page, responseGroups, merchant, maxPrice, minPrice, null);
        }

        public ItemSearchResponse ItemSearch(SearchIndex index, string keywords, int page, List<ResponseGroup> responseGroups,
            Merchants merchant, int? maxPrice, int? minPrice, int? minPercentageOff)
        {
            var request = RequestBuilder(index, keywords, page, responseGroups, merchant, maxPrice, minPrice, minPercentageOff);
            var itemSearch = SearchRequest(request);

            var response = client.ItemSearch(itemSearch);

            return response;
        }

        public ItemLookupResponse ItemLookupRequest(string asin)
        {
            var requests = new ItemLookupRequest[1];
            var request = new ItemLookupRequest
            {
                ItemId = new[] { asin },
                IdType = ItemLookupRequestIdType.ASIN,
                IdTypeSpecified = true,
                SearchIndex = "All"
            };
            requests[0] = request;

            var resp = client.ItemLookup(new ItemLookup
            {
                AWSAccessKeyId = AccessKey,
                AssociateTag = AssociateTag,
                Request = requests
            });

            return resp;
        }
    }
}
