using CatCity;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Languages", menuName = "Dilaogue/Languages")]
public class Languages : ScriptableObject
{
    public List<Language> languages = new List<Language>();
}