using System.Runtime.CompilerServices;
using UnityEngine;

namespace CatCity
{
    [CreateAssetMenu(fileName = "Game Settings", menuName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        public VideoSettings videoSettings;
        public AudioSettings audioSettings;
        public Language language;
    }

    [System.Serializable]
    public class AudioSettings
    {
        public bool EnableSound;
        [Range(0, 1)] public float MainVolume;
        [Range(0, 1)] public float MusicVolume;
        [Range(0, 1)] public float SoundEffectVolume;
    }

    [System.Serializable]
    public class VideoSettings
    {
        public bool EnabledFullScreen;
        public bool EnabledPosprocessing;
        public bool EnabledParticles;
        public ScreenResolution resolution;
        public int Quality;
    }

    public struct ScreenResolution
    {
        public int w;
        public int h;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ScreenResolution(int w, int h)
        {
            this.w = w;
            this.h = h;
        }
    }

    public enum AudioType
    {
        Default = 0,
        Music = 1,
        SoundEffect = 3
    }
}