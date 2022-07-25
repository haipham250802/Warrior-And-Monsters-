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
                IsPlusDamage1 = false,
                IsPlusDamage2 = false,

                HP = 200,
                MaxHP = 200,

                MP = 200,
                MaxMP = 200,

                XP = 0,
                MaxXP = 1000,

                coin = 300,
                diamond = 300,

                Level = 1,

                damage1 = 11,
                damage2 = 41,

                volumeSound = 1f,
                WeponList = new List<int> { },
                LevelList = new List<int> { 1 },
            };
            SaveData();
        }
    }
    private static void SaveData()
    {
        var data = JsonUtility.ToJson(allData);
        PlayerPrefs.SetString(ALL_DATA, data);
    }
    #region Wepon
    public static bool IsOwnWeponWithId(int id)
    {
        return allData.IsOwnWeponWithId(id);
    }
    public static void AddWepon(int id)
    {
        allData.AddWepon(id);

        SaveData();
    }
    #endregion
    #region HP
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
        SaveData();
    }
    public static void SetHP(int value)
    {
        allData.SetHP(value);
        SaveData();
    }
    public static void TakeHP(int value)
    {
        allData.TakeHP(value);
    }
    public static void AddMaxHP(int value)
    {
        allData.AddMaxHP(value);
    }
    #endregion
    #region MP
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
    public static void AddMaxMP(int value)
    {
        allData.AddMaxMP(value);
        SaveData();
    }
    #endregion
    #region XP
    public static void AddXP(int value)
    {
        allData.AddXP(value);
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
    }
    public static int GetXP()
    {
        return allData.GetXP();
    }

    public static void SetMaxXP(int Level)
    {
        allData.SetMaxXP(Level);
        SaveData();
    }
    #endregion
    #region Money & LV
    public static int GetCoin()
    {
        return allData.GetCoin();
    }
    public static void AddCoin(int value)
    {
        allData.AddCoin(value);
    }
    public static void SubCoin(int value)
    {
        allData.SubCoin(value);
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
    }
    public static bool CheckEnoughtCoin(int value)
    {
        return allData.CheckEnoughtCoin(value);
    }
    public static void SubDiamond(int value)
    {
        allData.SubDiamond(value);
    }
    #endregion
    #region Damage
    public static int GetDamage1()
    {
        return allData.GetDamage1();
    }
    public static void SetDamage1(int value)
    {
        allData.SetDamage1(value);
        SaveData();
    }
    public static void AddDamage1(int CurDamage, int Level)
    {
        allData.AddDamage1(CurDamage, Level);
        SaveData();
    }

    public static int GetDamage2()
    {
        return allData.GetDamage2();
    }
    public static void SetDamage2(int value)
    {
        allData.SetDamage2(value);
        SaveData();
    }
    public static void AddDamage2(int CurDamage, int Level)
    {
        allData.AddDamage2(CurDamage, Level);
        SaveData();
    }


    public static bool GetIsPlusDamage1()
    {
        return allData.GetIsPlusDamage1();
    }
    public static void SetIplusDamage1(bool value)
    {
        allData.SetIplusDamage1(value);
        SaveData();
    }

    public static bool GetIsPlusDamage2()
    {
        return allData.GetIsPlusDamage2();
    }

    public static void ReceiveBuffDamage1ToSkill(int value)
    {
        allData.ReceiveBuffDamage1ToSkill(value);
    }
    public static void ReceiveBuffDamage2ToSkill(int value)
    {
        allData.ReceiveBuffDamage2ToSkill(value);
    }
    public static void SetIplusDamage2(bool value)
    {
        allData.SetIplusDamage2(value);
        SaveData();
    }

    #endregion
    public static bool IsOwnLvWithId(int id)
    {
        return allData.IsOwnLvWithId(id);
    }
    public static void AddLvWithId(int id)
    {
        allData.AddLvWithId(id);
        SaveData();
    }

    public static void SetVolume(float value)
    {
        allData.SetVolume(value);
        SaveData();
    }
    public static float GetVolume()
    {
        return allData.GetVolume();
    }
    public static void ResetData()
    {
        allData.ResetData();
        SaveData();
    }

}
public class AllData
{
    public List<int> WeponList;
    public List<int> LevelList;

    public bool IsPlusDamage1;
    public bool IsPlusDamage2;

    public int damage1;
    public int damage2;

    public int XP;
    public int MaxXP;

    public int HP;
    public int MaxHP;

    public int MP;
    public int MaxMP;


    public int coin;
    public int diamond;

    public int Level;

    public float volumeSound;

    public bool IsOwnLvWithId(int id)
    {
        return LevelList.Contains(id);
    }
    public void AddLvWithId(int id)
    {
        if (IsOwnLvWithId(id)) return;
        LevelList.Add(id);
    }
    public void SetVolume(float value)
    {
        volumeSound = value;
    }
    public float GetVolume()
    {
        return volumeSound;
    }

    public void ResetData()
    {
        IsPlusDamage1 = false;
        IsPlusDamage2 = false;

        HP = 200;
        MaxHP = 200;

        MP = 200;
        MaxMP = 200;

        XP = 0;
        MaxXP = 1000;

        coin = 300;
        diamond = 300;

        Level = 1;

        damage1 = 11;
        damage2 = 41;

        volumeSound = 1f;
        WeponList = new List<int> { };
        LevelList = new List<int> { 1 };
    }
    #region Wepon
    public bool IsOwnWeponWithId(int id)
    {
        return WeponList.Contains(id);
    }
    public void AddWepon(int id)
    {
        if (IsOwnWeponWithId(id)) return;

        WeponList.Add(id);
    }
    #endregion
    #region Damage
    public bool GetIsPlusDamage1()
    {
        return IsPlusDamage1;
    }
    public void SetIplusDamage1(bool value)
    {
        IsPlusDamage1 = value;
    }

    public bool GetIsPlusDamage2()
    {
        return IsPlusDamage2;
    }
    public void SetIplusDamage2(bool value)
    {
        IsPlusDamage2 = value;
    }

    public int GetDamage1()
    {
        return damage1;
    }
    public void SetDamage1(int value)
    {
        damage1 = value;
    }
    public void AddDamage1(int curDamage, int level)
    {
        damage1 = curDamage + (level * level * level);
    }


    public int GetDamage2()
    {
        return damage2;
    }
    public void SetDamage2(int value)
    {
        damage2 = value;
    }
    public void AddDamage2(int CurDamage, int level)
    {
        damage2 = CurDamage + (level * level * level);
    }

    public void ReceiveBuffDamage1ToSkill(int value)
    {
        damage1 = value;
    }
    public void ReceiveBuffDamage2ToSkill(int value)
    {
        damage2 = value;
    }
    #endregion
    #region XP
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
    public void AddMaxMP(int value)
    {
        MaxMP += value;
    }
    public int GetMaxXP()
    {
        return MaxXP;
    }
    public void SetMaxXP(int Level)
    {
        MaxXP = (Level * Level) * 1000;
    }
    #endregion
    #region HP
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
        if (HP <= 0)
        {
            HP = 0;
        }
    }
    public void AddMaxHP(int value)
    {
        MaxHP += value;
    }
    #endregion
    #region MP
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
    #endregion
    #region Money & LV
    public int GetDiamon()
    {
        return diamond;
    }
    public void AddDiamond(int value)
    {
        diamond += value;
    }
    public void SubDiamond(int value)
    {
        diamond -= value;
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


    public void SubCoin(int value)
    {
        coin -= value;
    }
    public bool CheckEnoughtCoin(int value)
    {
        return coin > value;
    }
    #endregion
}
