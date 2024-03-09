using UnityEngine;

namespace Contacts
{
    [CreateAssetMenu(fileName = "Contact Configuration", menuName = "Contact Configuration / New Contact Configuration")]
    public class ContactConfiguration : ScriptableObject
    {
        [SerializeField] private ContactView _contactView;
        [SerializeField] private ContactModel _contactModel;

        public ContactView ContactView => _contactView;
        public ContactModel ContactModel => _contactModel;
    }
}
