using UnityEngine;
using System.IO;
using System.Net;
using System;

namespace Utilities
{
    public class AvatarDownloader
    {
        private string _savePath;

        public void CheckFileExists(string picturePath, string pictureUrl)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            _savePath = Path.Combine(Application.persistentDataPath, picturePath);
#else
            _savePath = Path.Combine(Application.dataPath, picturePath);
#endif
            if (File.Exists(_savePath))
            {
                Debug.Log("Downloaded");
            }
            else
            {
                DownloadFile(pictureUrl, picturePath);
            }
        }

        private void DownloadFile(string url, string fileName)
        {
            WebClient webClient = new WebClient();

            webClient.DownloadFileCompleted += DownloadComplete;

#if UNITY_ANDROID && !UNITY_EDITOR
            webClient.DownloadFileAsync(new Uri(url), Application.persistentDataPath + $"/{fileName}");
#else
            webClient.DownloadFileAsync(new Uri(url), Application.dataPath + $"/{fileName}");
#endif 
        }

        public virtual void DownloadComplete(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
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
