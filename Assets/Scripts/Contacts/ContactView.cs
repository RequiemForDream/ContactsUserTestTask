using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Contacts
{
    public class ContactView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _lastName;
        public string LastName
        {
            get
            {
                return _lastName.text;
            }
            set
            {
                _lastName.text = value;
            }
        }

        [SerializeField] private TMP_Text _firstName;
        public string FirstName
        {
            get
            {
                return _firstName.text;
            }
            set
            {
                _firstName.text = value;
            }
        }

        [SerializeField] private TMP_Text _contactEmailText;
        public string ContactEmail
        {
            get
            {
                return _contactEmailText.text;
            }
            set 
            { 
                _contactEmailText.text = value;
            }
        }

        [SerializeField] private TMP_Text _contactIPText;
        public string ContactIP
        {
            get
            {
                return _contactIPText.text;
            }
            set
            {
                _contactIPText.text = value;
            }
        }

        [SerializeField] private Image _contactAvatar;
        public Sprite ContactAvatar
        {
            get
            {
                return _contactAvatar.sprite;
            }
            set
            {
                _contactAvatar.sprite = value;
            }
        }
    }
}
