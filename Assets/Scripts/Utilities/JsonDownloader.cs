using System;

namespace Utilities
{
    public class JsonDownloader : Downloader
    {
        public event Action OnDownloadComplete;

        public override void OnFileExists()
        {
            OnDownloadComplete?.Invoke();
        }

        public override void DownloadComplete(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            OnDownloadComplete?.Invoke();
        }
    }
}
