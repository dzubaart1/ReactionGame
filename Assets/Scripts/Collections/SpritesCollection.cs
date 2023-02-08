using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Collections
{
    public class SpritesCollection
    {
        private List<Sprite> _sprites;
        public SpritesCollection()
        {
            UpdateList();
        }

        public IReadOnlyCollection<Sprite> Sprites => _sprites;

        public Sprite FindSpriteByName(string name)
        {
            return _sprites.Find(sprite => sprite.name.Equals(name));
        }

        public void UpdateList()
        {
            _sprites = Resources.LoadAll<Sprite>("Sprites/").ToList();
        }
    }
}