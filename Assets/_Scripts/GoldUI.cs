using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    [SerializeField] EntityGold _gold;
    [SerializeField] TextMeshProUGUI _textMeshPro;
    void Start()
    {
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        GameObject player = GameObject.Find("Player");
        _gold = player.GetComponent<EntityGold>();

    }

    
    void Update()
    {
        _textMeshPro.text ="GOLD : " +_gold.Gold.ToString();
    }

    
}
