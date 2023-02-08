using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Collections
{
    public class SoundCollection
    {
        private List<AudioClip> _sounds;
        public SoundCollection()
        {
            UpdateList();
        }

        public IReadOnlyCollection<AudioClip> Sounds => _sounds;

        public AudioClip FindSoundByName(string name)
        {
            return _sounds.Find(sound => sound.name.Equals(name));
        }

        public void UpdateList()
        {
            _sounds = Resources.LoadAll<AudioClip>("Sounds/").ToList();
        }
    }
}