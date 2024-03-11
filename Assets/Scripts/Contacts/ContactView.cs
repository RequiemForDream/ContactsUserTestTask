using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Contacts
{
    public class ContactView : MonoBehaviour
    {
        public event Action OnDestroyHandler;
        public event Action OnAddToFavoritesBtnClick;
        public event Action OnOpenProfileBtnClick;

        [SerializeField] private TMP_Text _lastName;
        [SerializeField] private TMP_Text _contactIPText;
        [SerializeField] private TMP_Text _contactEmailText;
        [SerializeField] private TMP_Text _firstName;
        [SerializeField] private Image _contactAvatar;
        [SerializeField] private Button _addToFavoritesBtn;
        [SerializeField] private Button _openProfileBtn;

        private void Awake()
        {
            _addToFavoritesBtn.onClick.AddListener(MarkAsFavorite);
            _openProfileBtn.onClick.AddListener(OpenProfileScreen);
        }

        public void SetData(string lastName, string firstName, string iPAddress, string email, Sprite sprite)
        {
            _lastName.text = lastName;  
            _firstName.text = firstName;
            _contactIPText.text = iPAddress;
            _contactEmailText.text = email;
            _contactAvatar.sprite = sprite;
        }

        public void SetFavoriteIcon(Sprite favoriteIcon)
        {
            _addToFavoritesBtn.image.sprite = favoriteIcon;
        }

        private void MarkAsFavorite()
        {
            OnAddToFavoritesBtnClick?.Invoke();
        }

        private void OpenProfileScreen()
        {
            OnOpenProfileBtnClick?.Invoke();
        }

        private void OnDestroy()
        {
            OnDestroyHandler?.Invoke();    
        }
    }
}
