using System;
using System.IO;
using UnityEngine;

namespace Utilities
{
    public class JsonParser
    {
        public Response LoadFromJson()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            var _filePath = Path.Combine(Application.persistentDataPath, _fileName);
#else
            var _filePath = Path.Combine(Application.dataPath, DataClass.JSON_FILE_NAME);
#endif
            var json = File.ReadAllText(_filePath);

            var contacts = JsonUtility.FromJson<Response>(json);

            return contacts;
        }
    }

    [Serializable]
    public struct Response
    {
        public ContactData[] data;
    }

    [Serializable]
    public struct ContactData
    {
        public int id;
        public string first_name;
        public string last_name;
        public string email;
        public string gender;
        public string ip_address;
    }
}
