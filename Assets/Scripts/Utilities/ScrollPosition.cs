using Contacts;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class ScrollPosition : MonoBehaviour
    {
        [SerializeField] private List<ContactView> _contacts = new List<ContactView>();
        [SerializeField] private RectTransform _content;

        private float _yPos;
        private int _currentItemsOnScreen;

        private void Start()
        {
            _currentItemsOnScreen = Mathf.FloorToInt((Screen.height * 2) / 360);

            for (int i = 0; i < _content.childCount; i++)
            {
                var child = _content.GetChild(i).GetComponent<ContactView>();
                _contacts.Add(child);
            }
        }

        private void Update()
        {
            _yPos = _content.anchoredPosition.y;

            int u = Mathf.FloorToInt(_yPos / 360);

            for (int i = 0; i < _contacts.Count; i++)
            {
                if (i + 1 <= u)
                {
                    _contacts[i]._contact.gameObject.SetActive(false);
                }
                else if (i + 1 > u + _currentItemsOnScreen)
                {
                    _contacts[i]._contact.gameObject.SetActive(false);
                }
                else
                {

                    _contacts[i]._contact.gameObject.SetActive(true);
                }
            }
        }
    }
}
