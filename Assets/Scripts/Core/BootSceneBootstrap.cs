using System.Collections;
using TMPro;
using UnityEngine;
using Utilities;

namespace Core
{
    public class BootSceneBootstrap : MonoBehaviour
    {
        [SerializeField] private TMP_Text _internetConnectionText;
        [SerializeField] private TMP_Text _loadingText;

        private void Awake()
        {
            if (CheckInternetConnection() == true)
            {
                //var jsonDownloader = new JsonDownloader();
                //jsonDownloader.CheckFileExists();
                StartCoroutine(DownloadRoutine());
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

        private IEnumerator DownloadRoutine()
        {
            for (int i = 0; i < DataClass.PICTURE_URLS.Length; i++)
            {
                var url = DataClass.PICTURE_URLS[i];
                var path = DataClass.PICTURE_PATHS[i];
                var avatarDownloader = new AvatarDownloader();
                avatarDownloader.CheckFileExists(path, url);
            }

            yield return new WaitForSeconds(2.5f);
            DownloadJsonData();
        }

        private void DownloadJsonData()
        {
            var downloader = new JsonDownloader();
            downloader.CheckFileExists();
        }
    }
}
