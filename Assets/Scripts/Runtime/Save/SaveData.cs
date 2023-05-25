using UnityEngine;

namespace CatCity
{
    [System.Serializable]
    public class SceneValues 
    {
        public string scene;
    }

    [System.Serializable]
    public class PlayerData 
    {
        public Transform playerTransform;
        public PlayerInventory playerInventory;
    }

    [System.Serializable]
    public class MenuValues
    {
        // Video
        public int resolution;
        public int quality;
        public bool fullscreen;

        // Audio
        public float globalVolume;
        public float musicVolume;
        public float effectVolume;
    }

    public class Data 
    {
        private SceneValues _sceneValues;

        public SceneValues SceneValues
        {
            get { return _sceneValues; }
            set { _sceneValues = value; }
        }

        private PlayerData _playerData;

        public PlayerData PlayerData
        {
            get { return _playerData; }
            set { _playerData = value; }
        }

        private MenuValues _menuValues;
        
        public MenuValues MenuValues
        {
            get { return _menuValues; }
            set { _menuValues = value; }
        }
    }
}