using UnityEngine;

namespace UI
{
    public class FavoriteContactsScreen : MonoBehaviour
    {
        [SerializeField] private Transform _contactsData;

        public Transform ContactsParent
        {
            get
            {
                return _contactsData;
            }
        }
    }
}
