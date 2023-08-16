using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Store : MonoBehaviour
{
  public Dictionary<string, string> m_items = new Dictionary<string, string>();

  [SerializeField] private TextMeshProUGUI previewText;
  [SerializeField] private Transform contentParent;
    
  [SerializeField] private MyButton m_buttonPrefab;
  
  public void Awake()
  {
    m_items.Add("Coca-Cola", "10");
    m_items.Add("Pepsi", "25");
    m_items.Add("Fanta", "12");
    m_items.Add("Mirinda", "15");
    m_items.Add("Galletitas", "20");

    previewText.text = string.Empty;
    
    foreach (var l_item in m_items)
    {
      var l_button = Instantiate(m_buttonPrefab, contentParent);
      l_button.SetLabel(l_item.Key);
      l_button.onClick.AddListener(() =>
      {
        previewText.text = "el precio de: " + l_item.Key + " es de: " + l_item.Value + " usd";
      });
    }
  }
  
  
  
}
