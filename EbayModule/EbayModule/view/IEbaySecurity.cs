using System;

namespace EbayModule.view
{
    public interface IEbaySecurity
    {
        string FetchAccessToken(Guid secretKey);
        string AuthoriseAccountLink(Guid secretKey);
    }
}