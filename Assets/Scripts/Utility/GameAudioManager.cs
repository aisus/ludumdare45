using System;
using System.Linq;
using UnityEngine;
using System.Linq;

namespace Utility
{
    public class GameAudioManager : MonoBehaviour
    {
        public enum SoundType
        {
            EnemyShot, 
            PlayerShot, 
            EnemyDead, 
            PlayerHit, 
            PlayerDead,
            WeaponPicked, 
            Explosion, 
            LevelCompleted, 
            GameOver, 
            Respawn, 
            PausePress
        }
        
        [Serializable]
        private class SoundAndType
        {
            public SoundType Type;
            public AudioClip Clip;
        }

        [SerializeField] private SoundAndType[] _sounds;

        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(SoundType type)
        {
            SoundAndType sound = null;
            try
            {
                sound = _sounds.First(x => x.Type == type);
            }
            catch (Exception e) {
                return;
            }
            if (sound != null)
            {
                if (sound.Clip != null)
                {
                    _audioSource.PlayOneShot(sound.Clip);
                }
            }
        }
    }
}