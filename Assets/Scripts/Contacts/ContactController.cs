using Factories;
using System;
using UI;
using UnityEngine;
using Utilities;

namespace Contacts
{
    public class ContactController
    {
        public event Action<int> OnMarkedAsFavorite;
        public event Action<int> OnUnmarkedAsFavorite;

        private readonly ContactView _contactView;
        private readonly ProfileScreen _profileScreen;
        private readonly ContactModel _contactModel;
        private readonly FavoriteContactFactory _favoriteContactFactory;
        private ContactData _contactData;
        private ContactView _favoriteContactView;

        private bool _isFavorite;
        private Sprite _sprite;

        public ContactController(ContactView contactView, ProfileScreen profileScreen,
            ContactModel contactModel, FavoriteContactFactory favoriteContactFactory)
        {
            _contactView = contactView;
            _favoriteContactFactory = favoriteContactFactory;
            _contactModel = contactModel;
            _profileScreen = profileScreen;
        }

        public void Initialize(bool isFavorite, ContactData contactData, Sprite sprite)
        {
            _contactData = contactData;
            _sprite = sprite;
            _isFavorite = isFavorite;
            
            SetContactData(_contactView);
            SubscribeEvents(_contactView);
            
            if (!isFavorite)
            {
                _contactView.SetFavoriteIcon(_contactModel.NonmarkedAsFavoriteIcon);
            }
            else
            {
                CreateFavoriteContact();
                _contactView.SetFavoriteIcon(_contactModel.FavoriteIcon);
            }
        }

        private void SetContactData(ContactView contactView)
        {
            var avatar = GetSprite();
            contactView.SetData(_contactData.last_name, _contactData.first_name, _contactData.ip_address, _contactData.email,
                avatar);
        }

        private void SubscribeEvents(ContactView contact)
        {
            contact.OnAddToFavoritesBtnClick += ChangeFavoriteIcon;
            contact.OnOpenProfileBtnClick += ShowProfileData;
            contact.OnDestroyHandler += OnDestroy;
        }

        private void ShowProfileData()
        {
            _profileScreen.gameObject.SetActive(true);
            _profileScreen.transform.SetAsLastSibling();
            _profileScreen.SetData(_contactData.last_name, _contactData.first_name, _contactData.ip_address, _contactData.email,
                _contactData.gender);
            if (_isFavorite)
            {
                _profileScreen.SetFavoriteIcon(_contactModel.FavoriteIcon);
            }
            else
            {
                _profileScreen.SetFavoriteIcon(_contactModel.NonmarkedAsFavoriteIcon);
            }
        }

        private void UnsubscriveEvents(ContactView contact)
        {
            contact.OnAddToFavoritesBtnClick -= ChangeFavoriteIcon;
            contact.OnOpenProfileBtnClick -= ShowProfileData;
            contact.OnDestroyHandler -= OnDestroy;
        }

        private void ChangeFavoriteIcon()
        {
            _isFavorite = !_isFavorite;

            if (_isFavorite)
            {
                if (_favoriteContactView == null)
                {
                    CreateFavoriteContact();
                }
                else
                {
                    _favoriteContactView.gameObject.SetActive(true);
                    
                }

                _contactView.SetFavoriteIcon(_contactModel.FavoriteIcon);
                OnMarkedAsFavorite?.Invoke(_contactData.id);
            }
            else
            {
                _contactView.SetFavoriteIcon(_contactModel.NonmarkedAsFavoriteIcon);
                _favoriteContactView.SetFavoriteIcon(_contactModel.NonmarkedAsFavoriteIcon);
                _favoriteContactView.gameObject.SetActive(false);
                OnUnmarkedAsFavorite?.Invoke(_contactData.id);
            }
        }

        private Sprite GetSprite()
        {
            Sprite avatar = _sprite;
            if (_sprite == null)
            {
                avatar = _contactModel.ProfileAvatar;
            }
            return avatar;
        }

        private void CreateFavoriteContact()
        {
            _favoriteContactView = _favoriteContactFactory.Create();
            SetContactData(_favoriteContactView);
            _favoriteContactView.SetFavoriteIcon(_contactModel.FavoriteIcon);
            SubscribeEvents(_favoriteContactView);
        }

        private void OnDestroy()
        {
            UnsubscriveEvents(_contactView);
            if (_favoriteContactView == null)
            {
                return;
            }

            UnsubscriveEvents(_favoriteContactView);
        }
    }
}
