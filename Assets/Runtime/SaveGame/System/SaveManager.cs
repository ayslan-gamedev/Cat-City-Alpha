using CatCity;
using UnityEngine;

public class SaveManager
{
    /// <summary>
    /// return the current saved data
    /// </summary>
    public Data CurrentData { get; private set; }

    /// <summary>
    /// Set current scriptable Obejct to save data
    /// </summary>
    public Save SaveObject { private get; set; }
    
    /// <summary>
    /// Save the game data
    /// </summary>
    public void Save(Data data)
    {
        if(data.SceneValues != null)
        {
            SaveObject.sceneValues = data.SceneValues;
        }

        if(data.PlayerData != null)
        {
            SaveObject.playerData = data.PlayerData;
        }

        //if(data.MenuValues != null)
        //{
        //    SaveObject.menuValues = data.MenuValues;
        //}
    }

    #region All Data
    /// <summary>
    /// Save scene values and player data
    /// </summary>
    public void Save(SceneValues sceneValues, PlayerData playerData)
    {
        Data tempData = new Data();
        
        tempData.SceneValues = sceneValues;
        tempData.PlayerData = playerData;
        
        Save(tempData);
    }

    ///// <summary>
    ///// Save scene values, player data and menu data
    ///// </summary>
    //public void Save(SceneValues sceneValues, PlayerData playerData /*,MenuValues menuData*/)
    //{
    //    Data tempData = new Data();

    //    tempData.SceneValues = sceneValues;
    //    tempData.PlayerData = playerData;
    //    //tempData.MenuValues = menuData;

    //    Save(tempData);
    //}
    #endregion

    #region Scene Data
    /// <summary>
    /// Save Scene Data
    /// </summary>
    public void Save(SceneValues sceneValues)
    {
        Data tempData = new Data();
        tempData.SceneValues = sceneValues;

        Save(tempData);
    }

    /// <summary>
    /// Creat a Scene values to save
    /// </summary>
    public void Save(string scene)
    {
        SceneValues sceneValues = new SceneValues();
        sceneValues.scene = scene;
        Save(sceneValues);
    }
    #endregion

    #region Player Data
    /// <summary>
    /// Save Player Data
    /// </summary>
    public void Save(PlayerData playerData)
    {
        Data tempData = new Data();
        tempData.PlayerData = playerData;

        Save(tempData);
    }

    /// <summary>
    /// Creat a Player data to save
    /// </summary>
    public void Save(Transform transform, PlayerInventory inventory)
    {
        PlayerData playerData = new PlayerData();

        playerData.playerTransform = transform;
        playerData.playerInventory = inventory;

        Save(playerData);
    }
    #endregion

    //#region Menu Data
    ///// <summary>
    ///// Save Menu Data
    ///// </summary>
    //public void Save(MenuValues menuData)
    //{
    //    Data tempData = new Data();
    //    tempData.MenuValues = menuData;
    //}

    ///// <summary>
    ///// Creat a Menu data to save ALL MENU SETTINGS
    ///// </summary>
    //public void Save(int resolution, int quality, bool fullscreen, float globalVolume, float musicVolume, float effectVolume)
    //{
    //    Save(resolution, quality, fullscreen);
    //    Save(globalVolume, musicVolume, effectVolume);
    //}

    ///// <summary>
    ///// Creat a Menu data to save SCREEN SETTINGS
    ///// </summary>
    //public void Save(int resolution, int quality, bool fullscreen)
    //{
    //    MenuValues menuValues = new MenuValues();
       
    //    menuValues.resolution = resolution;
    //    menuValues.quality = quality;
    //    menuValues.fullscreen = fullscreen;

    //    Save(menuValues);
    //}

    ///// <summary>
    ///// Creat a Menu data to save VOLUME SETTINGS
    ///// </summary>
    //public void Save(float globalVolume, float musicVolume, float effectVolume)
    //{
    //    MenuValues menuValues = new MenuValues();
        
    //    menuValues.globalVolume = globalVolume;
    //    menuValues.musicVolume = musicVolume;
    //    menuValues.effectVolume = effectVolume;

    //    Save(menuValues);
    //}
    //#endregion
}