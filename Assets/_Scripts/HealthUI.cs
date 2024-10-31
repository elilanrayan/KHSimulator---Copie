using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] EntityHealth _playerHealth;

    private void Start()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
        GameObject player = GameObject.Find("Player");
        _playerHealth = player.GetComponent<EntityHealth>();
    }
    ///int CachedMaxHealth { get; set; }
    private void Update()
    {
        UpdateSlider();
    }
    void UpdateSlider()
    {
        _slider.value = _playerHealth.CurrentHealth;
        _text.text = $"{_playerHealth.CurrentHealth} / {_playerHealth.MaxHealth}";
    }

   
}
