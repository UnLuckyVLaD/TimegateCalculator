using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ReserveSetter : MonoBehaviour
{
    public TMP_Dropdown ReserveDropDown;
    public GameObject TimePanel;
    public GameObject StaminaPanel;

    // Start is called before the first frame update
    void Start()
    {
        StaminaPanel.SetActive(false);
        DropdownItemSelected(ReserveDropDown);
        ReserveDropDown.onValueChanged.AddListener(delegate { DropdownItemSelected(ReserveDropDown); });
    }

    void DropdownItemSelected(TMP_Dropdown dropdown)
    {
        if (dropdown.value == 0)
        {
            TimePanel.SetActive(true);
            StaminaPanel.SetActive(false);
        }    
        else
        {
            TimePanel.SetActive(false);
            StaminaPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
