using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Utilities
{
    public static class SaveSystem
    {
        public static void SaveContactsData(ContactsId playerData)
        {
            string filePath = Application.persistentDataPath + "/playerData.fun";
            BinaryFormatter formatter = new BinaryFormatter();

            ContactsId savedPlayerData;

            if (File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    savedPlayerData = (ContactsId) formatter.Deserialize(fileStream);
                }
            }

            using (FileStream newFileStream = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(newFileStream, playerData);
            }
        }

        public static ContactsId LoadContactsData()
        {
            string filePath = Application.persistentDataPath + "/playerData.fun";

            if (File.Exists(filePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    return (ContactsId)formatter.Deserialize(fileStream);
                }
            }
            else
            {
                return null;
            }
        }
    }

    [Serializable]
    public class ContactsId
    {
        public List<int> FavoriteContactsId;

        public ContactsId(List<int> favoriteContactsId)
        {
            FavoriteContactsId = new List<int>();
            FavoriteContactsId = favoriteContactsId;
        }
    }
}
