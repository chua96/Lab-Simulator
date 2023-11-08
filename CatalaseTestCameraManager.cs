using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalaseTestCameraManager : MonoBehaviour
{
    [Header("Script")]
    public PlayerMovement move;
    public MouseLook mouse;
    public PickUpManager pickUp;
    public highlight highlight;

    [Header("Camera")]
    public Camera mainCamera;
    public Camera sideCamera;

    [Header("Selection")]
    public GameObject _selection;
    public GameObject previous_selection;
    public GameObject Alt_Selection;
    public GameObject previous_Alt_Selection;

    [Header("Boolean")]
    public bool PanelCamera;
    public bool CameraChanged;
    public bool canChange;
    public bool dropper;
    public bool loop;

    // Start is called before the first frame update
    void Start()
    {
        PanelCamera = false;
        CameraChanged = false;

        dropper = false;
        loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUp.pickedUp == false)
        {
            PanelCamera = false;
        }
        else if (pickUp.pickedUp == true && pickUp._selection.name == "Loop" || pickUp._selection.name == "Dropper")
        {
            PanelCamera = true;
        }

        if (PanelCamera)
        {
            if (mainCamera.enabled == true)
            {
                if (_selection != null)
                {
                    canChange = false;
                    pickUp.defaultDot.SetActive(true);
                    pickUp.selectedDot.SetActive(false);

                    highlight.SetLayerRecursively(_selection, highlight.objectMask);
                    _selection = null;
                }

                var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 3f, LayerMask.GetMask("Interactable", "Highlight")))
                {
                    var selection = hit.collider;
                    if (selection.name == "Slide")
                    {
                        canChange = true;

                        pickUp.defaultDot.SetActive(false);
                        pickUp.selectedDot.SetActive(true);

                        _selection = selection.gameObject;
                        previous_selection = _selection;

                        highlight.SetLayerRecursively(_selection, highlight.highlighMask);
                    }
                }
                if (previous_selection != _selection)
                {
                    _selection = null;
                    previous_selection = null;
                }
            }
        }


        if (!CameraChanged)
        {
            if (canChange)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    Cam1();
                }
            }
        }
        else if (CameraChanged)
        {
            if (Input.GetMouseButtonUp(1))
            {
                mainCam();
            }
        }

        if (CameraChanged)
        {
            if (Alt_Selection != null)
            {
                pickUp.defaultDot.SetActive(true);
                pickUp.selectedDot.SetActive(false);

                highlight.SetLayerRecursively(Alt_Selection, highlight.objectMask);
                Alt_Selection = null;
            }

            var ray = sideCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 3f, LayerMask.GetMask("Highlight", "Interactable")))
            {
                var selection = hit.collider;
                if (selection.tag == "Guide")
                {
                    Alt_Selection = selection.gameObject;
                    previous_Alt_Selection = Alt_Selection;

                    highlight.SetLayerRecursively(Alt_Selection, highlight.highlighMask);
                }
            }
            else if (Alt_Selection != null && !Alt_Selection.CompareTag("Guide"))
            {
                Alt_Selection = null;
                previous_Alt_Selection = null;
            }

            if (Alt_Selection == null)
            {
                Alt_Selection = this.gameObject;
                previous_Alt_Selection = Alt_Selection;
            }
        }
    }

    private void Cam1()
    {
        CameraChanged = true;

        move.DisableMovement = true;
        mouse.canLock = false;

        Cursor.lockState = CursorLockMode.None;

        pickUp._selection.gameObject.SetActive(false);
        pickUp.canPutDown = false;
        pickUp.defaultDot.SetActive(false);
        pickUp.selectedDot.SetActive(false);

        highlight.SetLayerRecursively(_selection, highlight.objectMask);

        sideCamera.enabled = true;
        mainCamera.enabled = false;
    }

    private void mainCam()
    {
        CameraChanged = false;

        move.DisableMovement = false;
        mouse.canLock = true;

        Cursor.lockState = CursorLockMode.Locked;

        pickUp.canPutDown = true;
        pickUp._selection.gameObject.SetActive(true);

        pickUp.defaultDot.SetActive(true);

        sideCamera.enabled = false;
        mainCamera.enabled = true;
    }
}
