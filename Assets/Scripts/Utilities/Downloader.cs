using UnityEngine;
using System.IO;
using System.Net;
using System;

namespace Utilities
{
    public class Downloader
    {
        private string _savePath;

        public void CheckFileExists(string path, string url)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            _savePath = Path.Combine(Application.persistentDataPath, path);
#else
            _savePath = Path.Combine(Application.dataPath, path);
#endif
            if (File.Exists(_savePath))
            {
                OnFileExists();
            }
            else
            {
                DownloadFile(url, path);
            }
        }

        public virtual void OnFileExists() { }

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
            
        }
    }
}
