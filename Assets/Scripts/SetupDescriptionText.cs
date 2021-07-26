using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetupDescriptionText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().text = GetComponentInParent<EquipmentComponent>().Description;
    }
}
