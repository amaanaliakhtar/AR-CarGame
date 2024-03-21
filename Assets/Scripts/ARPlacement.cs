using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class ARPlacement : MonoBehaviour
{
    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    private GameObject spanewdObject;
    public Pose placementPose;
    private ARRaycastManager arRaycastManager;
    private bool placementPoseIsValid = false;

    // Start is called before the first frame update
    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
    if (spanewdObject == null && placementPoseIsValid && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            ARPlaceObject();
        }

        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    void UpdatePlacementIndicator()
    {
        if (spanewdObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);

            placementIndicator.transform.SetPositionAndRotation(placementPose.position,
            placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();

        arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);
        placementPoseIsValid = hits.Count > 0;

        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;
        }
    }

    void ARPlaceObject()
    {
        spanewdObject = Instantiate(arObjectToSpawn, placementPose.position, placementPose.rotation);
    }
}