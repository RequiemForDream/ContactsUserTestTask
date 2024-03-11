using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProfileScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _firstName;
        [SerializeField] private TMP_Text _lastName;
        [SerializeField] private TMP_Text _email;
        [SerializeField] private TMP_Text _ipAddress;
        [SerializeField] private TMP_Text _gender;
        [SerializeField] private Image _profileAvatar;
        [SerializeField] private Image _favoriteIcon;
        [SerializeField] private Button _closeProfileScreenBtn;
        [SerializeField] private FavoriteContactsScreen _favoriteContactsScreen;

        private void Awake()
        {
            _closeProfileScreenBtn.onClick.AddListener(CloseProfileScreen);
        }

        public void SetData(string lastName, string firstName, string iPAddress, string email, string gender, Sprite sprite)
        {
            _favoriteContactsScreen.gameObject.SetActive(false);
            _firstName.text = firstName;
            _lastName.text = lastName;
            _email.text = email;
            _ipAddress.text = iPAddress;
            _gender.text = gender;
            _profileAvatar.sprite = sprite;
        }

        public void SetFavoriteIcon(Sprite favoriteIcon)
        {
            _favoriteIcon.sprite = favoriteIcon;
        }

        private void CloseProfileScreen()
        {
            _favoriteContactsScreen.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
