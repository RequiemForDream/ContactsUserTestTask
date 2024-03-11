using System;
using UnityEngine;

namespace Contacts
{
    [Serializable]
    public struct ContactModel
    {
        [SerializeField] private Sprite _favoriteMarkerSprite;
        [SerializeField] private Sprite _unfavoriteMarkerSprite;
        [SerializeField] private Sprite _profileAvatar;
        [SerializeField] private Sprite _profileScreenAvatar;

        public Sprite FavoriteIcon => _favoriteMarkerSprite;
        public Sprite NonmarkedAsFavoriteIcon => _unfavoriteMarkerSprite;
        public Sprite ProfileAvatar => _profileAvatar;
        public Sprite ProfileScreenAvatar => _profileScreenAvatar;
    } 
}
