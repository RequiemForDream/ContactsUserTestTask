using System.Net;
using System;
using UnityEngine;

namespace Utilities
{
    public class JsonDownloader
    {
        public void DownloadFile()
        {
            string url = DataClass.JSON_URL_DOWNLOAD;
            string fileName = DataClass.JSON_FILE_NAME;

            WebClient webClient = new WebClient();

            webClient.DownloadProgressChanged += DownloadProgressChanged;
            webClient.DownloadFileCompleted += DownloadComplete;

            webClient.DownloadFileAsync(new Uri(url), Application.dataPath + $"/{fileName}.json");
        }



        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Debug.Log("Download Progress = " + e.ProgressPercentage + "%");
        }

        private void DownloadComplete(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Debug.Log("Download completed");
            }
            else
            {
                Debug.Log($"Error: {e.Error}");
            }
        }
    }
}
