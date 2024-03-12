using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utilities;

namespace Core
{
    public class BootSceneBootstrap : MonoBehaviour
    {
        [SerializeField] private TMP_Text _internetConnectionText;
        [SerializeField] private TMP_Text _loadingText;
        
        private int _downalodImagesCount;

        private void Awake()
        {
            if (CheckInternetConnection() == true)
            {
                for (int i = 0; i < DataClass.PICTURE_URLS.Length; i++)
                {
                    var url = DataClass.PICTURE_URLS[i];
                    var path = DataClass.PICTURE_PATHS[i];
                    var avatarDownloader = new Downloader();
                    avatarDownloader.OnDownloadComplete += AddToList;
                    avatarDownloader.CheckFileExists(path, url);
                }
            }
        }

        private bool CheckInternetConnection()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                _internetConnectionText.text = "Not Reachable.";
                return false;
            }
            else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
            {
                _internetConnectionText.text = "Reachable via carrier data network.";
                return true;
            }
            else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                _internetConnectionText.text = "Reachable via Local Area Network.";
                return true;
            }

            return false;
        }
        private void AddToList()
        {
            _downalodImagesCount++;
            if (_downalodImagesCount == DataClass.PICTURE_URLS.Length)
            {
                Debug.Log("sdas");
                DownloadJsonData();
            }
        }

        private void DownloadJsonData()
        {
            var url = DataClass.JSON_URL_DOWNLOAD;
            var path = DataClass.JSON_FILE_NAME;
            var downloader = new JsonDownloader();
            downloader.OnDownloadComplete += LoadScene;
            downloader.CheckFileExists(path, url);
        }

        private void LoadScene()
        {
            SceneLoader.LoadSceneBySceneIndex(DataClass.SAMPLE_SCENE);
        }
    }
}
