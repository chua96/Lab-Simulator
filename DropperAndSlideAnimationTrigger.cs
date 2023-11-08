using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperAndSlideAnimationTrigger : MonoBehaviour
{
    public bool DropperOnSlideAnim1 = false;
    public bool DropperOnSlideAnim2 = false;
    public bool DropperOnSlideAnim3 = false;
    public DropperAnimation dropperAnim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DropperOnSlideAnim1 == true)
        {

        }
        if (DropperOnSlideAnim2 == true)
        {
           // dropperAnim.animateSlide2();
        }
        if (DropperOnSlideAnim3 == true)
        {
           // dropperAnim.animateSlide3();
        }
    }
}
