using Contacts;
using Factories.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factories
{
    public class FavoriteContactFactory : IFactory<ContactView>
    {
        private readonly Transform _favoriteListParent;
        private readonly ContactConfiguration _contactConfiguration;

        public FavoriteContactFactory(Transform favoriteListParent, ContactConfiguration contactConfiguration)
        {
            _favoriteListParent = favoriteListParent;
            _contactConfiguration = contactConfiguration;
        }

        public ContactView Create()
        {
            var favoriteContact = Object.Instantiate(_contactConfiguration.ContactView, _favoriteListParent);

            return favoriteContact;
        }
    }
}
