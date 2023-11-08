using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperPickLiquid : MonoBehaviour
{
    [Header("Script")]
    public PlayerMovement move;
    public PickUpManager PickUp;
    public HydronPeroxideBottleAnimation hydronPeroxideBottle;
    public SalineBottleAnimation salineBottle;
    public VioletBottleAnimation violetBottle;
    public IodineAcetoneBottleAnimation iodineAcetoneBottle;
    public IodineBottleAnimation iodineBottle;
    public SafraninBottleAnimation safraninBottle;


    [Header("Game Object")]
    public GameObject origDropper;
    public GameObject BottleDropper;

    [Header("Boolean")]
    public bool liquidPicked;
    private bool isTrigger;

    [SerializeField] private string TriggerName;

    // Start is called before the first frame update
    void Start()
    {
        liquidPicked = false;
        BottleDropper.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PickUp.pickedUp == false)
        {
            isTrigger = false;
        }

        if (isTrigger)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!liquidPicked)
                {
                    if (hydronPeroxideBottle.PeroxideBottleOpened)
                    {
                        animatePeroxideBottle();
                    }
                    else if (salineBottle.SalineBottleOpened)
                    {
                        animateSalineBottle();
                    }
                    else if (violetBottle.VioletBottleOpened)
                    {
                        animateVioletBottle();
                    }
                    else if (iodineBottle.IodineBottleOpened)
                    {
                        animateIodineBottle();
                    }
                    else if (safraninBottle.SafraninBottleOpened)
                    {
                        animateSafraninBottle();
                    }
                    else if (iodineAcetoneBottle.AcetoneBottleOpened)
                    {
                        animateAcetoneBottle();
                    }
                    else
                    {
                        Debug.Log("Please Open the bottle.");
                    }
                }
                else
                {
                    Debug.Log("Dropper if full.");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == TriggerName)
        {
            isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == TriggerName)
        {
            isTrigger = false;
        }
    }


    private void animatePeroxideBottle()
    {
        move.DisableMovement = true;
        liquidPicked = true;
        BottleDropper.SetActive(true);
        origDropper.SetActive(false);
    }

    private void animateSalineBottle()
    {
        move.DisableMovement = true;
        liquidPicked = true;
        origDropper.SetActive(false);
    }

    private void animateIodineBottle()
    {
        move.DisableMovement = true;
        liquidPicked = true;
        origDropper.SetActive(false);
    }

    private void animateAcetoneBottle()
    {
        move.DisableMovement = true;
        liquidPicked = true;
        origDropper.SetActive(false);
    }

    private void animateVioletBottle()
    {
        move.DisableMovement = true;
        liquidPicked = true;
        origDropper.SetActive(false);
    }

    private void animateSafraninBottle()
    {
        move.DisableMovement = true;
        liquidPicked = true;
        origDropper.SetActive(false);
    }
}
