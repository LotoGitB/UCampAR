using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Diagnostics;

public class ButtonPress : MonoBehaviour
{
  public LayerMask mask;
  public GameObject baseCanon;
  public GameObject canonObj;
  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    if (EnhancedTouch.Touch.activeTouches.Count > 0)
    {
      Ray line = Camera.main.ScreenPointToRay(EnhancedTouch.Touch.activeTouches[0].screenPosition);
      RaycastHit hit;
      Physics.Raycast(line, out hit, 10f, mask);

      if (hit.transform != null && hit.transform.gameObject.CompareTag("DirectionButton"))
      {
        //Debug.Log(hit.transform.gameObject.name);
        switch (hit.transform.gameObject.name)
        {
          case "Left":
            baseCanon.transform.Rotate(Vector3.down * 10 * Time.deltaTime);
            break;
          case "Right":
            baseCanon.transform.Rotate(Vector3.up * 10 * Time.deltaTime);
            break;
          case "Up":
            canonObj.transform.Rotate(Vector3.right * 10 * Time.deltaTime);
            break;
          case "Down":
            canonObj.transform.Rotate(Vector3.left * 10 * Time.deltaTime);
            break;
        }
      }
    }
  }
}
