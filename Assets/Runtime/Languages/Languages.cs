using System.Collections.Generic;
using UnityEngine;

namespace CatCity
{
    [CreateAssetMenu(fileName = "Languages", menuName = "Dilaogue/Languages")]
    public class Languages : ScriptableObject
    {
        public List<Language> languages = new List<Language>();
    }

    [System.Serializable]
    public class Language
    {
        public string name;
        public int index;
    }
}