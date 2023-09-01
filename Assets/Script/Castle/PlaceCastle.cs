using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class PlaceCastle : MonoBehaviour
{
  public GameObject arObject; //Prefab Original
  private GameObject playground; //Instancia del Prefab ya en juego
  private ARRaycastManager arRaycastManager;
  private ARPlaneManager aRPlaneManager;
  // Start is called before the first frame update
  void Start()
  {
    arRaycastManager = GameObject.FindObjectOfType<ARRaycastManager>();
    aRPlaneManager = GameObject.FindObjectOfType<ARPlaneManager>();
  }

  private void OnEnable()
  {
    EnhancedTouch.EnhancedTouchSupport.Enable();
    EnhancedTouch.TouchSimulation.Enable();

    EnhancedTouch.Touch.onFingerDown += PlaceObjectInPlane;
    EnhancedTouch.Touch.onFingerMove += PlaceObjectInPlane;
  }

  private void OnDisable()
  {
    EnhancedTouch.EnhancedTouchSupport.Disable();
    EnhancedTouch.TouchSimulation.Disable();

    EnhancedTouch.Touch.onFingerDown -= PlaceObjectInPlane;
    EnhancedTouch.Touch.onFingerMove -= PlaceObjectInPlane;
  }

  private void PlaceObjectInPlane(EnhancedTouch.Finger finger)
  {
    //Debug.Log("Fire");
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    arRaycastManager.Raycast(finger.screenPosition, hits, TrackableType.PlaneWithinPolygon);

    if (playground == null && hits.Count > 0)
    {
      gameObject.AddComponent<ARAnchor>();
      // playground = Instantiate(arObject, hits[0].pose.position, Quaternion.identity, gameObject.transform);
      playground = arObject;
      playground.transform.position = hits[0].pose.position;
      playground.transform.rotation = quaternion.identity;
      playground.transform.SetParent(gameObject.transform);
      playground.SetActive(true);
      foreach (var plane in aRPlaneManager.trackables)
      {
        plane.gameObject.SetActive(false);
      }
      aRPlaneManager.enabled = false;
      // Vector3 lookPos = Camera.main.transform.position - playground.transform.position;
      // lookPos.x = 0;
      // playground.transform.LookAt(lookPos);
    }
    // else if (hits.Count > 0)
    // {
    //   playground.transform.position = hits[0].pose.position;
    //   // Vector3 lookPos = Camera.main.transform.position - playground.transform.position;
    //   // lookPos.x = 0;
    //   // playground.transform.LookAt(lookPos);
    // }
  }
}
