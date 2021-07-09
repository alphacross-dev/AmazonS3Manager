using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace S3put.Controllers
{
    public class S3Controller : ApiController
    {
        public void Get()
        {
            //アクセスキーID
            var accessKeyID = "(ここにアクセスキーID)";
            //シークレットアクセスキー
            var secretAccessKey = "(ここにシークレットアクセスキー)";
            //アクセスキーID、シークレットアクセスキー、リージョンを指定してAmazonS3Clientを作成
            var client = new Amazon.S3.AmazonS3Client(accessKeyID, secretAccessKey,
            Amazon.RegionEndpoint.APNortheast1);
            //GetObjectRequestを作成
            var getObjectRequest = new Amazon.S3.Model.GetObjectRequest
            {
                //バケット名
                BucketName = "バケット名",
                //キー名(≒ファイル名)
                Key = "sample/test.jpg"
            };
            //ダウンロードを実行
            var getObjectResponse = client.GetObject(getObjectRequest);

            //ローカルファイルに保存
            getObjectResponse.WriteResponseStreamToFile(@"(ここにファイルパスを指定)");
        }

        public void Post(string path)
        {
            //アクセスキーID
            var accessKeyID = "(ここにアクセスキーID)";
            //シークレットアクセスキー
            var secretAccessKey = "(ここにシークレットアクセスキー)";
            //アクセスキーID、シークレットアクセスキー、リージョンを指定してAmazonS3Clientを作成
            var amazonS3Client = new Amazon.S3.AmazonS3Client(accessKeyID, secretAccessKey,
            Amazon.RegionEndpoint.APNortheast1);
            //PutObjectRequestを作成
            var putObjectRequest = new Amazon.S3.Model.PutObjectRequest();
            //キー名(≒ファイル名)
            putObjectRequest.Key = "sample/test.jpg";
            //バケット名
            putObjectRequest.BucketName = "バケット名";
            //Content-Type
            putObjectRequest.ContentType = "image/jpeg";
            //①Streamを指定する場合
            //putObjectRequest.InputStream = (ここにStreamを指定);
            //②ローカルファイルをアップロードする場合
            putObjectRequest.FilePath = @"C:\test.jpg";
            //③ファイルがテキストの場合
            putObjectRequest.ContentBody = "(ここに指定した文字列がファイルの中身になります)";
            //アップロードの実行
            var putObjectResponse = amazonS3Client.PutObject(putObjectRequest);
            if (putObjectResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
            {
                //Status=200が返ってくればアップロード成功
            }
        }

        public void Delete()
        {
            //アクセスキーID
            var accessKeyID = "(ここにアクセスキーID)";
            //シークレットアクセスキー
            var secretAccessKey = "(ここにシークレットアクセスキー)";
            //アクセスキーID、シークレットアクセスキー、リージョンを指定してAmazonS3Clientを作成
            var client = new Amazon.S3.AmazonS3Client(accessKeyID, secretAccessKey,
            Amazon.RegionEndpoint.APNortheast1);
            //DeleteObjectRequestを作成
            var deleteObjectRequest = new Amazon.S3.Model.DeleteObjectRequest
            {
                //バケット名
                BucketName = "バケット名",
                //キー名(≒ファイル名)
                Key = "sample/test.jpg"
            };
            //削除実行
            var deleteObjectResponse = client.DeleteObject(deleteObjectRequest);
        }
    }
}
