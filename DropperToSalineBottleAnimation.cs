using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperToSalineBottleAnimation : MonoBehaviour
{
    public PlayerMovement move;

    public GameObject origDropper;
    public GameObject SalineDropper;

    public Animator anim;

    public bool SalinePicked;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Animate", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void endAnimation()
    {
        move.DisableMovement = false;
        SalinePicked = true;
        origDropper.SetActive(true);
        SalineDropper.SetActive(false);
    }
}
