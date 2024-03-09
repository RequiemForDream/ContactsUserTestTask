using System;

namespace Contacts
{
    [Serializable]
    public struct ContactModel
    {
        public string ContactFirstName;
        public string ContactLastName;
        public string ContactGender;
        public int ID;
        public string ContactEmail;
        public string ContactIP;
        public bool IsFavorite;
    } 
}
