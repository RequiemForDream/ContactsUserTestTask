using Contacts;
using Factories;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Core
{
    public class FavoriteListGenerator
    {
        private readonly ContactFactory _contactFactory;
        private readonly ContactData[] _contactsData;
        private List<int> _contactIds = new List<int>();

        public FavoriteListGenerator(ContactFactory contactFactory, ContactData[] contactData)
        {
            _contactFactory = contactFactory;
            _contactsData = contactData;
        }

        public void Initilialize()
        {
            LoadData();

            ContactController contact;
            for (int i = 0; i < 50; i++)
            {
                bool isFavorite;

                if (!_contactIds.Contains(_contactsData[i].id))
                {
                    isFavorite = false;
                }
                else
                {
                    isFavorite = true;
                }

                FindImage(i, out Sprite sprite);
                contact = _contactFactory.Create();
                contact.OnMarkedAsFavorite += AddToFavorites;
                contact.OnUnmarkedAsFavorite += RemoveFromFavorites;
                contact.Initialize(isFavorite, _contactsData[i], sprite);
            }
        }

        private void FindImage(int i, out Sprite sprite)
        {
            int x = i % 5;
            switch (x)
            {
                case 0:
                    sprite = Resources.Load<Sprite>("LoadedPictures/picture" + $"{x}");
                    break;
                case 1:
                    sprite = Resources.Load<Sprite>("LoadedPictures/picture" + $"{x}");
                    break;
                case 2:
                    sprite = Resources.Load<Sprite>("LoadedPictures/picture" + $"{x}");
                    break;
                case 3:
                    sprite = Resources.Load<Sprite>("LoadedPictures/picture" + $"{x}");
                    break;
                case 4:
                    sprite = Resources.Load<Sprite>("LoadedPictures/picture" + $"{x}");
                    break;
                default:
                    sprite = null;
                    break;
            }
        }

        private void LoadData()
        {
            var data = SaveSystem.LoadContactsData();
            if (data == null)
            {
                return;
            }
            _contactIds = data.FavoriteContactsId;
        }

        private void AddToFavorites(int id)
        {
            _contactIds.Add(id);
            var data = new ContactsId(_contactIds);
            SaveSystem.SaveContactsData(data);
        }

        private void RemoveFromFavorites(int id)
        {
            _contactIds.Remove(id);
            var data = new ContactsId(_contactIds);
            SaveSystem.SaveContactsData(data);
        }
    }
}

