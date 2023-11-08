using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperAnimation : MonoBehaviour
{
    public PlayerMovement move;
    public PickUpManager pickUp;
    //public DropperAndSlideAnimationTrigger _DropperAndSlideAnimTrigger;
    public HydronPeroxideBottleAnimation hydronPeroxideBottle;

    [Header("GameObject")]
    public GameObject OrigDropper;
    public GameObject bottleDropper;
    public GameObject liquid;

    [Header("Selection")]
    public GameObject _selection;
    public GameObject previous_selection;

    public bool liquidPicked;
    public bool trigger;
    public bool hydronPeroxidePicked;
    public bool dropper_isTrigger = false;


    private int objectMask;
    private int highlightMask;
    // Start is called before the first frame update
    private void Start()
    {
        objectMask = LayerMask.NameToLayer("Interactable");
        highlightMask = LayerMask.NameToLayer("Highlight");

        liquidPicked = false;

        trigger = false;

        hydronPeroxidePicked = false;

        bottleDropper.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (pickUp.pickedUp)
        {
            if (pickUp._selection.name == "Dropper")
            {
                dropper_isTrigger = true;
            }
            else
            {
                dropper_isTrigger = false;
            }
        }
        else
        {
            dropper_isTrigger = false;
        }

        if (dropper_isTrigger)
        {
            if (_selection != null)
            {
                pickUp.defaultDot.SetActive(true);
                pickUp.selectedDot.SetActive(false);

                trigger = false;;

                _selection.gameObject.layer = objectMask;

                _selection = null;
            }

            var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 3f, LayerMask.GetMask("Interactable", "Highlight")))
            {
                var selection = hit.collider;
                if (selection.name == "Hydron Peroxide")
                {
                    trigger = true;
                    _selection = selection.gameObject;
                    previous_selection = _selection;
                    _selection.gameObject.layer = highlightMask;
                }
            }

            if (_selection != previous_selection)
            {
                _selection = null;
                previous_selection = null;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!liquidPicked)
            {
                if (trigger && pickUp.pickedUp)
                {
                    if (hydronPeroxideBottle.PeroxideBottleOpened)
                    {
                        animateHydronPeroxideBottle();
                    }
                }
            }
        }

        if (liquidPicked)
        {
            trigger = false;
        }


        if (hydronPeroxidePicked)
        {
            liquid.transform.localScale = new Vector3(0.0321f, 0.5f, 0.0321f);
        }
        else
        {
            liquid.transform.localScale = new Vector3(0.0321f, 0f, 0.0321f);
        }
    }


    private void animateHydronPeroxideBottle()
    {
        move.DisableMovement = true;
        liquidPicked = true;
        bottleDropper.SetActive(true);
        OrigDropper.SetActive(false);
    }
}
