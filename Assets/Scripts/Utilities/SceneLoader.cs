using UnityEngine.SceneManagement;

namespace Utilities
{
    public class SceneLoader
    {
        public static void LoadSceneBySceneIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
