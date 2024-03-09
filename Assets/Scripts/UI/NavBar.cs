using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class NavBar : MonoBehaviour
    {
        [Header("Screens for navigation")]
        [SerializeField] private EmployeeScreen _employeeScreen;
        [SerializeField] private FavoriteContactsScreen _favoriteContactsScreen;

        [Header("Buttons")]
        [SerializeField] private Button _openEmployeeScreenBtn;
        [SerializeField] private Button _openFavoriteContactsScreenBtn;

        [Header("BtnPictures")]
        [SerializeField] private Sprite _rightBtnSelectable;
        [SerializeField] private Sprite _leftBtnSelectable;

        private void Awake()
        {
            _openFavoriteContactsScreenBtn.onClick.AddListener(OpenFavoriteContactsScreen);
            _openEmployeeScreenBtn.onClick.AddListener(OpenEmployeeScreen);
        }

        private void OpenEmployeeScreen()
        {
            _employeeScreen.gameObject.SetActive(true);
            _favoriteContactsScreen.gameObject.SetActive(false);
        }

        private void OpenFavoriteContactsScreen()
        {
            _favoriteContactsScreen.gameObject.SetActive(true);
            _employeeScreen.gameObject.SetActive(false);
        }
    }
}
