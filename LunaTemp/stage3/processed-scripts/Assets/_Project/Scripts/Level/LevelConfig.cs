using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Level config")]
public class LevelConfig : ScriptableObject
{
    [Header("Normal level")] 
    public List<Level> listLevels;
    
    [Header("Multiple level")]
    public List<Level> listMultipleLevels;
    
    [Header("Challenge level")]
    public List<Level> listChallengeLevels;

    public Level GetLevelByIndex(int index)
    {
        try
        {
            return listLevels[index - 1];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return listLevels[0];
        }
    }
}
