using System;
using System.Collections.Generic;
using AmazonModule.AmazonService;
using System.Text.RegularExpressions;
using System.Linq;
using AmazonModule.enums;

namespace AmazonModule
{
    public class AmazonServiceCaller : IAmazonServiceCaller
    {
        private AmazonAPI AmazonApi { get; set; }

        public AmazonServiceCaller(string accessKey, string secretKey, string associateTag)
        {
            AmazonApi = new AmazonAPI(accessKey, secretKey, associateTag);
            //AmazonApi = new AmazonAPI("AKIAIJIVM4Y5BFOT4OCA", "vZRZ/6iWQpeH5NRaa0v14b/llCBabKQFCmaCtQ3L", "aarongibson-21");
        }

        public void BrowseNodeLoopup()
        {
            IEnumerable<string> mOEnum = new List<string> { AmazonApi.BrowserNode[SearchIndex.Electronics] };
            IEnumerable<BrowserLookupResponseGroup> respGroup =
                new List<BrowserLookupResponseGroup> { BrowserLookupResponseGroup.TopSellers };
            var test = AmazonApi.BrowseNodeLookup(mOEnum, respGroup).BrowseNodes;
        }

        public Item GetProductDetails(string asin)
        {
            var list = new List<ResponseGroup> { ResponseGroup.ItemAttributes, ResponseGroup.OfferFull, ResponseGroup.Reviews, ResponseGroup.Large };
            var response =
                AmazonApi.ItemSearch(
                    SearchIndex.All, asin, 1, list);

            if (response.Items[0].Item == null)
                return response.Items[0].Item == null ? null : response.Items[0].Item[0];

            foreach (var item in GetSubStrings(response.Items[0].Item[0].EditorialReviews.First().Content, "<script", "</script>"))
            {
                response.Items[0].Item[0].EditorialReviews.First().Content =
                    response.Items[0].Item[0].EditorialReviews.First().Content.Replace(item, "");
            }
            // Remove links
            foreach (var item in GetSubStrings(response.Items[0].Item[0].EditorialReviews.First().Content, "<a", ">"))
            {
                response.Items[0].Item[0].EditorialReviews.First().Content =
                    response.Items[0].Item[0].EditorialReviews.First().Content.Replace(item, "");
            }

            return response.Items[0].Item == null ? null : response.Items[0].Item[0];
        }

        public Item GetProductDetailsFromAsin(string asin)
        {
            var response =
                    AmazonApi.ItemLookupCustom(asin);

            if (response.Items[0].Item == null)
                return response.Items[0].Item == null ? null : response.Items[0].Item[0];

            if (response.Items[0].Item[0].EditorialReviews != null)
            {
                foreach (var item in GetSubStrings(response.Items[0].Item[0].EditorialReviews.First().Content, "<script", "</script>"))
                {
                    response.Items[0].Item[0].EditorialReviews.First().Content =
                        response.Items[0].Item[0].EditorialReviews.First().Content.Replace(item, "");
                }
                // Remove links
                foreach (var item in GetSubStrings(response.Items[0].Item[0].EditorialReviews.First().Content, "<a", ">"))
                {
                    response.Items[0].Item[0].EditorialReviews.First().Content =
                        response.Items[0].Item[0].EditorialReviews.First().Content.Replace(item, "");
                }
            }

            return response.Items[0].Item == null ? null : response.Items[0].Item[0];
        }

        public Item GetProductFromUrl(string url)
        {
            var asin = Regex.Match(url, "/([a-zA-Z0-9]{10})(?:[/?]|$)").Value.Replace("/", "");
            return GetProductDetailsFromAsin(asin);
        }

        public List<Item> Search(string searchPhrase, string searchCategory = null)
        {
            var results = new List<Item>();
            var list = new List<ResponseGroup> { ResponseGroup.ItemAttributes, ResponseGroup.OfferFull };
            var response =
                AmazonApi.ItemSearch(
                    searchCategory == null
                        ? SearchIndex.All
                        : (SearchIndex)Enum.Parse(typeof(SearchIndex), searchCategory), searchPhrase, 1, list,
                    Merchants.Amazon);
            var value = int.Parse(response.Items[0].TotalPages) > 15 ? 15 : int.Parse(response.Items[0].TotalPages);
            for (var i = 0; i < value; i++)
            {
                if (i != 0)
                {
                    response = AmazonApi.ItemSearch(searchCategory == null ? SearchIndex.All : (SearchIndex)Enum.Parse(typeof(SearchIndex), searchCategory), searchPhrase, i + 1, list, Merchants.Amazon);
                }
                if (response.Items[0].Item != null)
                {
                    results.AddRange(response.Items[0].Item);
                }
                else
                {
                    break;
                }
            }

            return results;
        }

        protected string GetSubString(string input, string start, string end)
        {
            var r = new Regex(Regex.Escape(start) + "(.*?)" + Regex.Escape(end));
            var matches = r.Matches(input);
            foreach (Match match in matches)
                return match.Groups[1].Value;

            return "";
        }

        protected IEnumerable<string> GetSubStrings(string input, string start, string end)
        {
            var r = new Regex(Regex.Escape(start) + "(.*?)" + Regex.Escape(end));
            var matches = r.Matches(input);
            return from Match match in matches select match.Groups[1].Value;
        }
    }
}
