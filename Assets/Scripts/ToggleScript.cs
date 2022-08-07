using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public Sprite offToggleImage;
    public Sprite onToggleImage;

    Toggle Toggle;
    Image Image;

    private void Awake()
    {
        Toggle = GetComponent<Toggle>();
        Image = GetComponent<Image>();
        Toggle.onValueChanged.AddListener(ChangeToggle);
        if (Toggle.isOn)
            ChangeToggle(true);
    }

    public void ChangeToggle(bool on)
    {
            Image.sprite = on ? onToggleImage : offToggleImage;
    }
}
