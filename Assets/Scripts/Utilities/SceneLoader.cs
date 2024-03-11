using UnityEngine.SceneManagement;

namespace Utilities
{
    public struct SceneLoader
    {
        public static void LoadSceneBySceneIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
