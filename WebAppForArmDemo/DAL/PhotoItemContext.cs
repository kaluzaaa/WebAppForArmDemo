using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using WebAppForArmDemo.Models;
using System.IO;

namespace WebAppForArmDemo.DAL
{
    public class PhotoItemContext
    {
        CloudStorageAccount storageAccount;
        CloudBlobClient blobClinet;
        CloudBlobContainer blobContainer;
        public PhotoItemContext()
        {
            storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);
            blobClinet = storageAccount.CreateCloudBlobClient();
            blobContainer = blobClinet.GetContainerReference(ConfigurationManager.AppSettings["blobContainer"].ToString());
            if(blobContainer.CreateIfNotExists())
            {
                blobContainer.SetPermissions(new BlobContainerPermissions() { PublicAccess = BlobContainerPublicAccessType.Blob });
            }
        }

        public List<PhotoItem> Get()
        {
            List<PhotoItem> list = new List<PhotoItem>();
            foreach(var blobItem in blobContainer.ListBlobs())
            {
                list.Add(new PhotoItem()
                {
                    FileName = blobItem.Uri.Segments.Last(),
                    Url = blobItem.Uri.ToString()
                });
            }
            return list;
        }

        public PhotoItem Get(string FileName)
        {
            CloudBlob blob = blobContainer.GetBlobReference(FileName);
            if(blob == null)
            {
                return null;
            }
            else
            {
                return new PhotoItem()
                {
                    FileName = blob.Uri.Segments.Last(),
                    Url = blob.Uri.ToString()
                };
            }
        }

        public void Upload(HttpPostedFileBase photo)
        {
            CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(Path.GetFileName(photo.FileName));
            blockBlob.Properties.ContentType = photo.ContentType;
            blockBlob.UploadFromStream(photo.InputStream);
        }

        public void Delete(string FileName)
        {
            CloudBlob blob = blobContainer.GetBlobReference(FileName);
            blob.Delete();
        }
    }
}