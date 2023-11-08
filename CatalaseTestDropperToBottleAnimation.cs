using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalaseTestDropperToBottleAnimation : MonoBehaviour
{
    public PlayerMovement move;
    public DropperAnimation DropperAnimation;

    public GameObject OrigDropper;
    public GameObject BottleDropper;
    public GameObject liquid;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Animate", true);
    }
    private void EndSafraninDropperAnimation()
    {
        move.DisableMovement = false;
        BottleDropper.transform.position = OrigDropper.transform.position;
        DropperAnimation.hydronPeroxidePicked = true;
        BottleDropper.SetActive(false);
        OrigDropper.SetActive(true);
    }
}
