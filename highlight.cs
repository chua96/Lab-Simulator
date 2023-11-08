using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlight : MonoBehaviour
{
    public int objectMask;
    public int highlighMask;
    public GameObject _selection;
    [SerializeField] private GameObject previous_Selection;
    public PickUpManager pickUpManager;

    public bool switchLayer;
    // Start is called before the first frame update
    void Start()
    {
        objectMask = LayerMask.NameToLayer("Interactable");
        highlighMask = LayerMask.NameToLayer("Highlight");
    }

    // Update is called once per frame
    void Update()
    {
        if (pickUpManager.rayCastOn == true)
        {
            //raycast

            if (Camera.main == null)
            {
                return;
            }
            else
            {
                var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1f, LayerMask.GetMask("Interactable", "Highlight")))
                {
                    GameObject selection = hit.collider.gameObject;
                    if (_selection != selection)
                    {
                        switchLayer = true;
                        _selection = selection;
                        _selection.layer = highlighMask;
                    }
                }
                else if (_selection != null)
                {
                    switchLayer = false;
                    _selection.layer = objectMask;
                    previous_Selection = _selection;
                    SetLayerRecursively(_selection, objectMask);
                    _selection = null;
                }
                if (_selection == null)
                {
                    _selection = this.gameObject;
                    previous_Selection = _selection;
                }
                if (previous_Selection.name != _selection.name)
                {
                    SetLayerRecursively(previous_Selection, objectMask);
                    previous_Selection = _selection;
                }
            }
        }

        if (switchLayer)
        {
            SetLayerRecursively(_selection, highlighMask);
        }
        else
        {
            SetLayerRecursively(_selection, objectMask);
        }
    }

    public void SetLayerRecursively(GameObject obj, int newLayer)
    {
        if (obj == null)
        {
            return;
        }

        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (child == null)
            {
                continue;
            }
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
}
