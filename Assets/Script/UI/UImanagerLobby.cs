using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanagerLobby : MonoBehaviour
{
    public Text MaxHP;
    public Text MaxMP;
    public Text NumGold;
    public Text NumDiamond;


    Player m_Player;
    UImanager m_UI;
    // Start is called before the first frame update
    void Start()
    {
        m_Player = FindObjectOfType<Player>();
        m_UI = FindObjectOfType<UImanager>();
    }

    // Update is called once per frame
    void Update()
    {
        MaxHP.text = m_Player.MaxHealth.ToString();
        MaxMP.text = m_Player.MaxMP.ToString();
    }
}
