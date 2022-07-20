using System.Collections.Generic;
using UnityEngine;

public static class DataPlayer
{
    private const string ALL_DATA = "all_data";
    private static AllData allData;
    static DataPlayer()
    {
        // chuy?n ??i d? li?u t? json sang alldata
        allData = JsonUtility.FromJson<AllData>(PlayerPrefs.GetString(ALL_DATA));

        if (allData == null)
        {
            allData = new AllData
            {

                HP = 200,
                MaxHP = 200,

                MP = 200,
                MaxMP = 200,

                XP = 0,
                MaxXP = 1000,

                coin = 300,
                diamond = 300,

                Level = 1,
                WeponList = new List<int> { },
            };
            SaveData();
        }
    }
    private static void SaveData()
    {
        var data = JsonUtility.ToJson(allData);
        PlayerPrefs.SetString(ALL_DATA, data);
    }
    public static bool IsOwnWeponWithId(int id)
    {
        return allData.IsOwnWeponWithId(id);
    }
    public static void AddWepon(int id)
    {
        allData.AddWepon(id);

        SaveData();
    }

    public static int GetHP()
    {
        return allData.GetHP();
    }
    public static int GetMaxHP()
    {
        return allData.GetMaxHP();
    }
    public static void SetMaxHP(int value)
    {
        allData.SetMaxHP(value);
    }
    public static void SetHP(int value)
    {
        allData.SetHP(value);
        SaveData();
    }
    public  static void TakeHP(int value)
    {
        allData.TakeHP(value);
    }
    public static void AddMaxHP(int value)
    {
        allData.AddMaxHP(value);
        SaveData();
    }
    public static int GetMP()
    {
        return allData.GetMP();
    }
    public static int GetMaxMP()
    {
        return allData.GetMaxMP();
    }
    public static void SetMaxMP(int value)
    {
        allData.SetMaxMP(value);
        SaveData();
    }
    public static void SetMP(int value)
    {
        allData.SetMP(value);
        SaveData();
    }
    public static void TakeMP(int value)
    {
        allData.TakeMP(value);
    }
    public static int GetMaxXP()
    {
        return allData.GetMaxXP();
    }
    public static void SetXP(int value)
    {
        allData.SetXP(value);
        SaveData();
    }
    public static int GetXP()
    {
        return allData.GetXP();
    }
    public static void AddXP(int value)
    {
        allData.AddXP(value);
        SaveData();
    }
    public static void SetMaxXP(int Level)
    {
        allData.SetMaxXP(Level);
        SaveData();
    }
    public static int GetCoin()
    {
        return allData.GetCoin();
    }
    public static void AddCoin(int value)
    {
        allData.AddCoin(value);
        SaveData();
    }

    public static void Addlevel(int value)
    {
        allData.AddLevel(value);
        SaveData();
    }
    public static int GetLevel()
    {
        return allData.GetLevel();
    }

    public static int GetDiamond()
    {
        return allData.GetDiamon();
    }
    public static void AddDiamond(int value)
    {
        allData.AddDiamond(value);
        SaveData();
    }
  
}
public class AllData
{
    public List<int> WeponList;


    public int XP;
    public int MaxXP;

    public int HP;
    public int MaxHP;

    public int MP;
    public int MaxMP;


    public int coin;
    public int diamond;

    public int Level;
    public bool IsOwnWeponWithId(int id)
    {
        return WeponList.Contains(id);
    }
    public void AddWepon(int id)
    {
        if (IsOwnWeponWithId(id)) return;

        WeponList.Add(id);
    }


    public int GetXP()
    {
        return XP;
    }
    public void SetXP(int value)
    {
        XP = value;
    }
    public void AddXP(int value)
    {
        XP += value;
    }
    public int GetMaxXP()
    {
        return MaxXP;
    }
    public void SetMaxXP(int Level)
    {
        MaxXP = (Level*Level) * 1000;
    }

    public int GetHP()
    {
        return HP;
    }
    public int GetMaxHP()
    {
        return MaxHP;
    }
    public void SetMaxHP(int value)
    {
        MaxHP = value;
    }
    public void SetHP(int value)
    {
        HP = value;
    }
    public void TakeHP(int value)
    {
        HP -= value;
    }
    public void AddMaxHP(int value)
    {
        MaxHP += value;
    }

    public int GetMP()
    {
        return MP;
    }
    public int GetMaxMP()
    {
        return MaxMP;
    }
    public void SetMaxMP(int value)
    {
        MaxMP = value;
    }
    public void SetMP(int value)
    {
        MP = value;
    }
    public void TakeMP(int value)
    {
        MP -= value;
    }
    public int GetDiamon()
    {
        return diamond;
    }
    public void AddDiamond(int value)
    {
        diamond += value;
    }

    public int GetCoin()
    {
        return coin;
    }
    public void AddCoin(int value)
    {
        coin += value;
    }

    public int GetLevel()
    {
        return Level;
    }
    public void AddLevel(int value)
    {
        Level += value;
    }
}
