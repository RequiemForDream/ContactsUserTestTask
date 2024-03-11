using System.Net;
using System;
using UnityEngine;
using System.IO;

namespace Utilities
{
    public class JsonDownloader
    {
        private string _savePath;

        public void CheckFileExists()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            _savePath = Path.Combine(Application.persistentDataPath, DataClass.JSON_FILE_NAME);
#else
            _savePath = Path.Combine(Application.dataPath, DataClass.JSON_FILE_NAME);
#endif

            if (File.Exists(_savePath))
            {
                Debug.Log("Downloaded");
                SceneLoader.LoadSceneBySceneIndex(DataClass.SAMPLE_SCENE);
            }
            else
            {
                DownloadFile();
            }
        }

        private void DownloadFile()
        {
            string url = DataClass.JSON_URL_DOWNLOAD;
            string fileName = DataClass.JSON_FILE_NAME;

            WebClient webClient = new WebClient();

            webClient.DownloadFileCompleted += DownloadComplete;

#if UNITY_ANDROID && !UNITY_EDITOR
            webClient.DownloadFileAsync(new Uri(url), Application.persistentDataPath + $"/{fileName}");
#else
            webClient.DownloadFileAsync(new Uri(url), Application.dataPath + $"/{fileName}"); 
            
#endif
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
                SceneLoader.LoadSceneBySceneIndex(DataClass.SAMPLE_SCENE);
            }
            else
            {
                Debug.Log($"Error: {e.Error}");
            }
        }
    }
}
