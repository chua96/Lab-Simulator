using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperToBottleAnimation : MonoBehaviour
{
    public PlayerMovement move;
    public GramStainingDropperAnimation DropperAnimation;

    public GameObject OrigDropper;
    public GameObject BottleDropper;
    public GameObject liquid;

    public Animator animator;

    void Update()
    {
        animator.SetBool("Animate", true);
    }

    private void EndSalineDropperAnimation()
    {
        move.DisableMovement = false;
        BottleDropper.transform.position = OrigDropper.transform.position;
        DropperAnimation.salinePicked = true;
        BottleDropper.SetActive(false);
        OrigDropper.SetActive(true);
    }

    private void EndSafraninDropperAnimation()
    {
        move.DisableMovement = false;
        BottleDropper.transform.position = OrigDropper.transform.position;
        DropperAnimation.safraninPicked = true;
        BottleDropper.SetActive(false);
        OrigDropper.SetActive(true);
    }

    private void EndVioletDropperAnimation()
    {
        move.DisableMovement = false;
        BottleDropper.transform.position = OrigDropper.transform.position;
        DropperAnimation.violetPicked = true;
        BottleDropper.SetActive(false);
        OrigDropper.SetActive(true);
    }

    private void EndIodineDropperAnimation()
    {
        move.DisableMovement = false;
        BottleDropper.transform.position = OrigDropper.transform.position;
        DropperAnimation.iodinePicked = true;
        BottleDropper.SetActive(false);
        OrigDropper.SetActive(true);
    }

    private void EndIodineAcetoneDropperAnimation()
    {
        move.DisableMovement = false;
        BottleDropper.transform.position = OrigDropper.transform.position;
        DropperAnimation.acetonePicked = true;
        BottleDropper.SetActive(false);
        OrigDropper.SetActive(true);
    }

    private void pickLiquid1()
    {
        liquid.transform.localScale = new Vector3(0.0321f, 0.5f, 0.0321f);
    }

    private void pickLiquid2()
    {
        liquid.transform.localScale = new Vector3(0.08092786f, 1.15f, 0.08092786f);
    }
}
