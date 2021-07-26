using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetupDamageText : MonoBehaviour
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
        EquipmentComponent equipmentInfo = GetComponentInParent<EquipmentComponent>();
        GetComponent<TextMeshProUGUI>().text = equipmentInfo.BaseMinDamage + " - " + equipmentInfo.BaseMaxDamage;
    }
}
