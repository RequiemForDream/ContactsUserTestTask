using UnityEngine;
using Utilities;

namespace Contacts
{
    public class Contact
    {
        public readonly ContactView ContactView;
        public readonly ContactModel ContactModel;

        private readonly Transform _employeeDataScreen;
        private readonly Transform _favoriteContactsScreen;
        private readonly ContactData _contactData;

        public Contact(ContactView contactView, ContactModel contactModel, Transform employeeDataScreen, ContactData contactData)
        {
            ContactView = contactView;
            ContactModel = contactModel;
            _employeeDataScreen = employeeDataScreen;
            _contactData = contactData;

            Initilialize();
        }

        private void Initilialize()
        {
            ContactView.ContactEmail = _contactData.email;
            ContactView.ContactIP = _contactData.ip_address;
            ContactView.FirstName = _contactData.first_name;
            ContactView.LastName = _contactData.last_name;
        }
    }
}
