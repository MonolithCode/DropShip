using AmazonModule.AmazonService;
using System.Collections.Generic;

namespace AmazonModule
{
    public interface IAmazonServiceCaller
    {
        void BrowseNodeLoopup();
        Item GetProductFromUrl(string url);
        Item GetProductDetailsFromAsin(string asin);
        Item GetProductDetails(string asin);
        List<Item> Search(string searchPhrase, string searchCategory = null);
    }
}
