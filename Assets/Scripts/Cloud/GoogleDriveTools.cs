using System.Threading.Tasks;
using UnityGoogleDrive;

namespace Cloud
{
    public static class GoogleDriveTools
    {
        public static async Task<UnityGoogleDrive.Data.File> DownloadFile(string fileId)
        {
            var file = await GoogleDriveFiles.Download(fileId).Send();
            return file;
        }
    }

    //// Listing files.
    //GoogleDriveFiles.List().Send().OnDone += fileList => ...;

    //// Uploading a file.
    //var file = new UnityGoogleDrive.Data.File { Name = "Image.png", Content = rawFileData };
    //GoogleDriveFiles.Create(file).Send();

    //// Downloading a file.
    //GoogleDriveFiles.Download(fileId).Send().OnDone += file => ...;

    //// All the requests are compatible with the .NET 4 asynchronous model.
    //var aboutData = await GoogleDriveAbout.Get().Send();
}

