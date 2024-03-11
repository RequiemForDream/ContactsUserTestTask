using Contacts;
using Factories;
using UI;
using UnityEngine;
using Utilities;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private ContactConfiguration _contactConfiguration;
        [SerializeField] private EmployeeScreen _employeeScreen;
        [SerializeField] private FavoriteContactsScreen _favoriteContactsScreen;
        [SerializeField] private ProfileScreen _profileScreenView;

        private void Awake()
        {
            var contacts = GetJsonData();
            var favoriteContactFactory = BindFavoriteContactFactory();
            var contactFactory = BindContactFactory(favoriteContactFactory);
            var favoriteListGenerator = BindFavoriteListGenerator(contactFactory, contacts);
            favoriteListGenerator.Initilialize();
        }

        private ContactFactory BindContactFactory(FavoriteContactFactory favoriteContactFactory)
        {
            return new ContactFactory(_contactConfiguration, _employeeScreen.ContactsParent, _profileScreenView,
                favoriteContactFactory);
        }

        private FavoriteContactFactory BindFavoriteContactFactory()
        {
            return new FavoriteContactFactory(_favoriteContactsScreen.ContactsParent, _contactConfiguration);
        }

        private ContactListGenerator BindFavoriteListGenerator(ContactFactory contactFactory, ContactData[] contactData)
        {
            return new ContactListGenerator(contactFactory, contactData);
        }

        private ContactData[] GetJsonData()
        {
            JsonParser jsonParser = new JsonParser();
            var contacts = jsonParser.LoadFromJson();
            return contacts.data;
        }
    }
}

