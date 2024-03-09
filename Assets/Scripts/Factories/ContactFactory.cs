using Contacts;
using Factories.Interfaces;
using UnityEngine;
using Utilities;
using Object = UnityEngine.Object;

namespace Factories
{
    public class ContactFactory : IFactory<Contact>
    {
        private readonly ContactConfiguration _contactConfiguration;
        private readonly Transform _contactParent;

        private readonly ContactData[] _contacts;
        private int _contactCount = 0;

        public ContactFactory(ContactConfiguration contactConfiguration, Transform contactParent, ContactData[] contacts)
        {
            _contactConfiguration = contactConfiguration;
            _contactParent = contactParent;
            _contacts = contacts;
        }

        public Contact Create()
        {
            //if (_contactCount == _contacts.Length)
            //{
            //    return null;
            //}
            

            var contactView = Object.Instantiate(_contactConfiguration.ContactView, _contactParent, false);
            var contact = new Contact(contactView, _contactConfiguration.ContactModel, _contactParent.transform,
                _contacts[_contactCount]);

            _contactCount++;

            return contact;
        }
    }
}
