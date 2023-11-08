using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperToSlideAnimation : MonoBehaviour
{
    public GameObject DropperSlide;

    public CatalseTestDropperPlaceLiquid placeLiquid;
    public Animator animator;

    [SerializeField] private ParticleSystem droplet;
    [SerializeField] private GameObject _WaterSphere;

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Animate", true);
        animator.SetBool("Animate", true);
        animator.SetBool("Animate", true);
    }
    private void endAnimation1()
    {
        placeLiquid.liquid1_placed = true;
        DropperSlide.SetActive(false);
    }
    private void endAnimation2()
    {
        placeLiquid.liquid2_placed = true;
        DropperSlide.SetActive(false);
    }
    private void endAnimation3()
    {
        placeLiquid.liquid3_placed = true;
        DropperSlide.SetActive(false);
    }
    private void Droplet()
    {
        droplet.Play();
    }
    private void WaterSphere()
    {
        _WaterSphere.SetActive(true);
    }
}   
