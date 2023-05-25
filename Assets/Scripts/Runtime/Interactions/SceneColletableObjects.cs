using System.Collections.Generic;
using UnityEngine;

namespace CatCity
{
    [CreateAssetMenu(fileName = "Save Scene Object", menuName = "Save/Save Scene Objects")]
    public class SceneColletableObjects : ScriptableObject 
    {
        public List<ColletableObject> sceneObjects;
    }

    public class ColletableObject
    {
        public GameObject @object;
        public bool colletable;
    }
}