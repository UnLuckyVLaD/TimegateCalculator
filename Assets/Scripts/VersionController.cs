using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VersionController : MonoBehaviour
{
    public TextMeshProUGUI VersionLabel;

    // Start is called before the first frame update
    void Start()
    {
        VersionLabel.text = "ver. " + Application.version;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
