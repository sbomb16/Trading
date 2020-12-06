using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TradeItem : MonoBehaviour
{
    public string itemName;

    public int value;

    public TextMeshProUGUI displayText;

    void UpdateDisplayText()
    {
        displayText.text = string.Format("{0} ({1})", itemName, value);
    }

    public void OnAddItemButton()
    {
        value++;
        UpdateDisplayText();
    }

    public void OnRemoveItemButton()
    {
        if (value > 0)
            value--;
        UpdateDisplayText();
    }

    public void ResetValue()
    {
        value = 0;
        UpdateDisplayText();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
