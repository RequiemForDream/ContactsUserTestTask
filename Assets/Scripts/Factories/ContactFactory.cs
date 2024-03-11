using Contacts;
using Factories.Interfaces;
using UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factories
{
    public class ContactFactory : IFactory<ContactController>
    {
        private readonly ContactConfiguration _contactConfiguration;
        private readonly Transform _employyeListParent;
        private readonly ProfileScreen _profileScreen;
        private readonly FavoriteContactFactory _favoriteContactFactory;

        public ContactFactory(ContactConfiguration contactConfiguration, Transform employeeList, ProfileScreen profileScreen,
            FavoriteContactFactory favoriteContactFactory)
        {
            _contactConfiguration = contactConfiguration;
            _favoriteContactFactory = favoriteContactFactory;
            _employyeListParent = employeeList;
            _profileScreen = profileScreen;
        }

        public ContactController Create()
        {            
            var contactView = Object.Instantiate(_contactConfiguration.ContactView, _employyeListParent, false);

            var contact = new ContactController(contactView, _profileScreen, _contactConfiguration.ContactModel,
                _favoriteContactFactory);

            return contact;
        }
    }
}
