using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Pancake;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "ItemConfig", menuName = "ScriptableObject/ItemConfig")]
public class ItemConfig : ScriptableObject
{
    public List<BallData> ballDataList;
    public List<PinData> pinDataList;
    public List<ThemeData> themeDataList;
    public List<TrailData> trailDataList;
    public List<ItemData> avatarDataList;

    public Dictionary<int, ItemData> AvatarDict { get; private set; }

    public void Initialize()
    {
        //UnlockAllDefaultSkins();
        InitializeAvatarData();
        // if (IAPManager.Instance.IsPurchased(Constant.IAP_UNLOCK_ALL_SKINS) ||
        //     IAPManager.Instance.IsPurchased(Constant.IAP_VIP)) UnlockAllSkins();
    }
    private void InitializeAvatarData()
    {
        AvatarDict = new Dictionary<int, ItemData>();

        foreach (var avatarData in avatarDataList)
        {
            AvatarDict[avatarData.Id] = avatarData;
        }
    }

    //#region UnlockAll

    //public void UnlockAllAvatar()
    //{
    //    avatarDataList.ForEach(item => item.IsUnlocked = true);
    //}

    //public void UnlockAllTrail()
    //{
    //    trailDataList.ForEach(item => item.IsUnlocked = true);
    //}

    //public void UnlockAllBall()
    //{
    //    ballDataList.ForEach(item => item.IsUnlocked = true);
    //}

    //public void UnlockAllPin()
    //{
    //    pinDataList.ForEach(item => item.IsUnlocked = true);
    //}

    //public void UnlockAllTheme()
    //{
    //    themeDataList.ForEach(item => item.IsUnlocked = true);
    //}

    //public void UnlockAllSkins()
    //{
    //    ballDataList.ForEach(item => item.IsUnlocked = true);
    //    pinDataList.ForEach(item => item.IsUnlocked = true);
    //    themeDataList.ForEach(item => item.IsUnlocked = true);
    //    trailDataList.ForEach(item => item.IsUnlocked = true);
    //    avatarDataList.ForEach(item => item.IsUnlocked = true);
    //    //EventController.OnUnlockAllSkins?.Invoke();
    //}

    //#endregion


    public ItemData GetRandomAvatar()
    {
        return avatarDataList[Random.Range(0, avatarDataList.Count)];
    }


    //public ItemData GetRandomItem()
    //{
    //    var itemList = new List<ItemData>(ballDataList
    //        .Where(ball => !ball.IsUnlocked && ball.PurchaseType != TypePurchase.Event).ToList());

    //    itemList.AddRange(pinDataList.Where(pin => !pin.IsUnlocked && pin.PurchaseType != TypePurchase.Event));
    //    itemList.Shuffle();

    //    return itemList.Count == 0 ? null : itemList[Random.Range(0, itemList.Count)];
    //}

    public Material GetMaterialByThemeId(int id)
    {
        return themeDataList.Find(item => item.Id == id).wallMaterial;
    }
    public ItemData GetItemData(TypeItem typeItem, int id)
    {
        return typeItem switch
        {
            TypeItem.Ball => ballDataList.Find(item => item.Id == id),
            TypeItem.Pin => pinDataList.Find(item => item.Id == id),
            TypeItem.Theme => themeDataList.Find(item => item.Id == id),
            _ => null
        };
    }

    //public void SetAllSkinUnlockedData(string dataDictStr)
    //{
    //    var dataDict = JsonConvert.DeserializeObject<Dictionary<string, bool>>(dataDictStr);

    //    foreach (var ballData in ballDataList) ballData.IsUnlocked = dataDict[ballData.ItemId];
    //    foreach (var pinData in pinDataList) pinData.IsUnlocked = dataDict[pinData.ItemId];
    //    foreach (var themeData in themeDataList) themeData.IsUnlocked = dataDict[themeData.ItemId];
    //    foreach (var trailData in trailDataList) trailData.IsUnlocked = dataDict[trailData.ItemId];
    //    foreach (var avatarData in avatarDataList) avatarData.IsUnlocked = dataDict[avatarData.ItemId];
    //}
}

public enum TypePurchase
{
    Default,
    Coin,
    Ads,
    UnlockLevel,
    Event,
    CardCollection,
    LeaderboardEvent,
}

public enum TypeItem
{
    Ball,
    Pin,
    Theme,
    Trail,
    Avatar,
    None
}

[Serializable]
public class ItemData
{
    public TypeItem TypeItem;
    public int Id;
    public Sprite ImageBg;
    public Sprite ImageIcon;
    public TypePurchase PurchaseType;

    [ShowIf("PurchaseType", TypePurchase.Coin)]
    public int coin;

    [ShowIf("PurchaseType", TypePurchase.UnlockLevel)]
    public int LevelUnlock;

    [ShowIf("PurchaseType", TypePurchase.Event)]
    public GameEventType EventType;

    [ShowIf("PurchaseType", TypePurchase.Event)]
    public int CollectNumber;

    [HideIf("PurchaseType", TypePurchase.Event)]
    public GameObject itemModel;


    public string ItemId => $"{TypeItem}_{Id}";

    //public bool IsUnlocked
    //{
    //    get
    //    {
    //        Data.IdSkinCheckUnlocked = ItemId;
    //        return Data.IsSkinUnlocked;
    //    }

    //    set
    //    {

    //        switch (TypeItem)
    //        {
    //            case TypeItem.Pin:
    //                Data.PinSkinCount++;
    //                break;
    //            case TypeItem.Theme:
    //                Data.ThemeSkinCount++;
    //                break;
    //            case TypeItem.Ball:
    //                Data.BallSkinCount++;
    //                break;
    //            case TypeItem.Trail:
    //                Data.TrailSkinCount++;
    //                break;
    //            case TypeItem.Avatar:
    //                Data.AvatarSkinCount++;
    //                break;
    //        }
    //    }
    //}

    public bool IsUnlockLevel()
    {
        return Data.CurrentLevel >= LevelUnlock && PurchaseType == TypePurchase.UnlockLevel;
    }
}

[Serializable]
public class BallData : ItemData
{
    public BallSkin ballSkin;
}

[Serializable]
public class PinData : ItemData
{
    public PinSkin pinSkin;
}

[Serializable]
public class ThemeData : ItemData
{
    public BackgroundSkin backgroundSkin;
    public Material wallMaterial;
}

[Serializable]
public class TrailData : ItemData
{
    public GameObject trailPrefab;
    public float trailSize;
}