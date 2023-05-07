using System.Collections.Generic;
using UnityEngine;
using CatCity.Events;

[CreateAssetMenu(fileName = "GlobalVariables", menuName = "Data/GlobalVariables")]
public class GlobalVariables : ScriptableObject
{
    public List<Variable> globalVariables;
}