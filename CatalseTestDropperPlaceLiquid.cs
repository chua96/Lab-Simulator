using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalseTestDropperPlaceLiquid : MonoBehaviour
{
    [Header("Script")]
    public PickUpManager pickUp;
    public DropperAnimation dropper;
    public CatalaseTestCameraManager cameraManager;

    [Header("Guide")]
    public GameObject[] guide;

    [Header("Dropper")]
    public GameObject[] animateDropper;

    [Header("Bool")]
    private bool trigger1;
    public bool liquid1_placed, liquid2_placed, liquid3_placed;
    // Start is called before the first frame update
    void Start()
    {
        trigger1 = true;
        liquid1_placed = false;
        liquid2_placed = false;
        liquid3_placed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger1 == true)
        {
            if (dropper.liquidPicked)
            {
                guide[0].SetActive(true);
                guide[1].SetActive(true);
                guide[2].SetActive(true);
                trigger1 = false;
            }
        }


        if (pickUp._selection.name == "Dropper")
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (cameraManager.Alt_Selection == null)
                {
                    return;
                }

                else
                {
                    string altSelectionName = cameraManager.Alt_Selection.name;

                    switch (altSelectionName)
                    {
                        case "TriggerBac1":
                            ActivateDropper(0);
                            break;
                        case "TriggerBac2":
                            ActivateDropper(1);
                            break;
                        case "TriggerBac3":
                            ActivateDropper(2);
                            break;
                    }
                }
            }
        }
    }

    void ActivateDropper(int index)
    {
        animateDropper[index].SetActive(true);
        guide[index].SetActive(false);
    }
}
