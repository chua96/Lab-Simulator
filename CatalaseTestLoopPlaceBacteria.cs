using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalaseTestLoopPlaceBacteria : MonoBehaviour
{
    [Header("Script")]
    [SerializeField] private PickUpManager pickUp;
    [SerializeField] private PickBacteriaAnimation pickBacteria;
    [SerializeField] private CatalaseTestCameraManager cameraManager;
    [SerializeField] private CatalseTestDropperPlaceLiquid placeLiquid;

    [Header("Guide")]
    public GameObject[] guide;

    [Header("Loop")]
    public GameObject[] animateLoop;

    [Header("Bool")]
    private bool trigger1, trigger2, trigger3;
    public bool P_placed, E_placed, S_placed;
    // Start is called before the first frame update
    void Start()
    {
        trigger1 = true;
        trigger2 = true;
        trigger3 = true;

        P_placed = false;
        E_placed = false;
        S_placed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (placeLiquid.liquid1_placed && placeLiquid.liquid2_placed && placeLiquid.liquid3_placed)
        {
            if (trigger1 == true)
            {
                if (pickBacteria.P_isPick)
                {
                    guide[0].SetActive(true);
                }
                else
                {
                    guide[0].SetActive(false);
                }
            }
            if (trigger2 == true)
            {
                if (pickBacteria.E_isPick)
                {
                    guide[1].SetActive(true);
                }
                else
                {
                    guide[1].SetActive(false);
                }
            }
            if (trigger3 == true)
            {
                if (pickBacteria.S_isPick)
                {
                    guide[2].SetActive(true);
                }
                else
                {
                    guide[2].SetActive(false);
                }
            }
        }

        if (pickUp._selection.name == "Loop")
        {
            if (placeLiquid.liquid1_placed && placeLiquid.liquid2_placed && placeLiquid.liquid3_placed)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    if (cameraManager.Alt_Selection.name == "TriggerBac1")
                    {
                        trigger1 = false;
                        animateLoop[0].SetActive(true);
                        guide[0].SetActive(false);
                    }
                    else if (cameraManager.Alt_Selection.name == "TriggerBac2")
                    {
                        trigger2 = false;
                        animateLoop[1].SetActive(true);
                        guide[1].SetActive(false);
                    }
                    else if (cameraManager.Alt_Selection.name == "TriggerBac3")
                    {
                        trigger3 = false;
                        animateLoop[2].SetActive(true);
                        guide[2].SetActive(false);
                    }
                }
            }
        }
    }
}
