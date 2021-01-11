using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Custom Data / GameData")]
public class GameData : ScriptableObject
{
    public int currentLevel;
    public int maxLevelCount;
    public int unLockedLevels;

}
