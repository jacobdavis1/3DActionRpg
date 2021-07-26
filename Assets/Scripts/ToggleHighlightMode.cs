using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HighlightPlus;
using System;

public class ToggleHighlightMode : MonoBehaviour
{
    HighlightManager manager;
    public LayerMask InteractableMask, InventoryMask;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<HighlightManager>();

        InputComponent.OnMouseModeToggle += ToggleMode;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        InputComponent.OnToggleWeapons -= ToggleMode;
    }

    void ToggleMode(object source, EventArgs e)
    {
        bool cameraLocked = Camera.main.GetComponent<MouseLookCamera>().LockCameraPosition;

        if (cameraLocked)
            HighlightInventory();
        else
            HighlightInteractables();
    }

    void HighlightInteractables()
    {
        manager.layerMask = InteractableMask;
        manager.raycastSource = RayCastSource.CameraDirection;
    }

    void HighlightInventory()
    {
        manager.layerMask = InventoryMask;
        manager.raycastSource = RayCastSource.MousePosition;
    }
}
