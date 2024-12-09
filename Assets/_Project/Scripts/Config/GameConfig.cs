using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObject/GameConfig")]
public class GameConfig : ScriptableObject
{
    public float durationPopup = .5f;
    public int maxLevel = 2;
    public int startLoopLevel = 1;
    public int coinWin = 100;
    public int currencyWatchAds = 500;
    public int percentWinGiftPerLevel = 10;
    public int receiveCoinWinFullItem = 5000;
}