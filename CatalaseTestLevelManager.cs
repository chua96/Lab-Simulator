using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CatalaseTestLevelManager : MonoBehaviour
{
    [Header("Skip Button")]
    [SerializeField] private string ButtonTag = "Button";
    public GameObject skip;
    public GameObject skipButton;
    public GameObject defaultDot;
    public GameObject buttonDot;

    public Transform _selection;

    [Header("Ui")]
    public GameObject[] ui;
    public GameObject videoPlayer;

    public AudioSource alert;
    public Light spotLight;
    public VideoPlayer video;

    [Header("Script")]
    public PlayerMovement movement;
    public CatalseTestDropperPlaceLiquid placeLiquid;
    public BurnLoopAnimation burnLoop;
    public PickBacteriaAnimation pickBacteria;
    public CatalaseTestLoopPlaceBacteria placeBacteria;


    [Header("Boolean")]
    public bool active1, active2, active3, active4, active5, active6;
    private bool is_playing;
    private bool is_skip;
    private bool canSkip;

    // Start is called before the first frame update
    void Start()
    {
        active1 = false;
        active2 = false;
        active3 = false;
        active4 = false;
        active5 = false;
        active6 = false;

        is_playing = true;
        is_skip = true;

        video.Stop();
        video.isLooping = false;
        movement.enabled = false;
        skip.SetActive(false);
        skipButton.SetActive(false);
        spotLight.enabled = true;
        StartCoroutine(skipTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (is_playing)
        {
            VideoTimer();
        }
        if (is_skip)
        {
            skipTimer();
            is_skip = false;
        }

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            defaultDot.SetActive(true);
            buttonDot.SetActive(false);
            _selection = null;
            canSkip = false;
        }


        //raycast

        if (Camera.main == null)
        {
            return;
        }
        else
        {
            var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 50f))
            {
                var selection = hit.transform;
                if (selection.CompareTag(ButtonTag))
                {
                    var selectionRenderer = selection.GetComponent<Renderer>();
                    if (selectionRenderer != null)
                    {
                        defaultDot.SetActive(false);
                        buttonDot.SetActive(true);
                        canSkip = true;

                        if (Input.GetMouseButtonDown(0))
                        {
                            if (canSkip)
                            {
                                if (selection.name == "SkipButton")
                                {
                                    skipVideo();
                                }
                            }
                        }
                    }

                    _selection = selection;
                }
            }
        }


        // dropper
        if (placeLiquid.liquid1_placed && placeLiquid.liquid2_placed && placeLiquid.liquid3_placed)
        {
            step2();
        }

        // burn loop
        if (burnLoop.loopHeated)
        {
            step3();
        }

        // loop pick bacteria
        if (pickBacteria.bacteria)
        {
            step4();
        }

        // loop place bacteria
        if (placeBacteria.P_placed || placeBacteria.E_placed || placeBacteria.S_placed)
        {
            step5();
        }

        // all bacteria placed
        if (placeBacteria.P_placed && placeBacteria.E_placed && placeBacteria.S_placed)
        {
            step6();
        }
    }


    private void VideoTimer()
    {
        videoPlayer.SetActive(true);
        if (Time.timeScale == 1)        // Pause video when timeScale is zero
        {
            video.Play();
        }
        else
        {
            video.Pause();
        }
        StartCoroutine(delay());
    }

    private IEnumerator skipTimer()
    {
        yield return new WaitForSeconds(5f);
        skip.SetActive(true);
        skipButton.SetActive(true);
    }

    private IEnumerator delay()
    {
        yield return new WaitForSeconds(43.3f);
        videoPlayer.SetActive(false);
        spotLight.enabled = false;
        is_playing = false;     // stop video from repeating after finish
        step1();
    }

    private void skipVideo()
    {
        video.Stop();
        buttonDot.SetActive(false);
        defaultDot.SetActive(true);
        videoPlayer.SetActive(false);
        StopCoroutine(delay());
        spotLight.enabled = false;
        is_playing = false;     // stop video from repeating after skip
        step1();
    }

    private void step1()
    {
        if (!active1)
        {
            movement.enabled = true;
            alert.Play();
            ui[0].SetActive(true);
            skip.SetActive(false);
            skipButton.SetActive(false);
            active1 = true;
        }
    }

    private void step2()
    {
        if (!active2 && active1)
        {
            ui[0].SetActive(false);
            ui[1].SetActive(true);
            alert.Play();
            active2 = true;
        }
    }

    private void step3()
    {
        if (!active3 && active2)
        {
            ui[1].SetActive(false);
            ui[2].SetActive(true);
            alert.Play();
            active3 = true;
        }
    }

    private void step4()
    {
        if (!active4 && active3)
        {
            ui[2].SetActive(false);
            ui[3].SetActive(true);
            alert.Play();
            active4 = true;
        }
    }

    private void step5()
    {
        if (!active5 && active4)
        {
            ui[3].SetActive(false);
            ui[4].SetActive(true);
            alert.Play();
            active5 = true;
        }
    }

    private void step6()
    {
        if (!active6 && active5)
        {
            ui[4].SetActive(false);
            ui[5].SetActive(true);
            alert.Play();
            active6 = true;
        }
    }
}

