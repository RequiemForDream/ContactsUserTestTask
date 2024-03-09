using UnityEngine;

namespace UI
{
    public class EmployeeScreen : Screen
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
