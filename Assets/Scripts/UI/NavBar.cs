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
        [SerializeField] private Sprite _unselectableBtn;

        private void Awake()
        {
            _openFavoriteContactsScreenBtn.onClick.AddListener(OpenFavoriteContactsScreen);
            _openEmployeeScreenBtn.onClick.AddListener(OpenEmployeeScreen);
        }

        private void OpenEmployeeScreen()
        {
            _openEmployeeScreenBtn.GetComponent<Image>().sprite = _leftBtnSelectable;
            _openFavoriteContactsScreenBtn.GetComponent<Image>().sprite = _unselectableBtn;
            _favoriteContactsScreen.gameObject.SetActive(false);
        }

        private void OpenFavoriteContactsScreen()
        {
            _openEmployeeScreenBtn.GetComponent<Image>().sprite = _unselectableBtn;
            _openFavoriteContactsScreenBtn.GetComponent<Image>().sprite = _rightBtnSelectable;
            _favoriteContactsScreen.gameObject.SetActive(true);
        }
    }
}
