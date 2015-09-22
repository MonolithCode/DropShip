using EbayModule.eBaySvc;
        
namespace EbayModule.view
{
    public interface IEbayImageManagement
    {
        string[] UploadSelfHostedImages(PhotoDisplayCodeType photoDisplay, string[] pictureFileList);
        string[] UpLoadPictureFiles(PhotoDisplayCodeType photoDisplay, string[] pictureFileList);
        string UpLoadPictureFile(PhotoDisplayCodeType photoDisplay, string pictureFile);
    }
}