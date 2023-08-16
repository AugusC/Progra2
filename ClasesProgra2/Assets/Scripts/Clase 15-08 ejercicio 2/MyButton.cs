using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyButton : Button
{
    public TextMeshProUGUI label;
  
  
    public void SetLabel(string p_text)
    {
        label.text = p_text;
    }

}