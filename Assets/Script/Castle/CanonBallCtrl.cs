using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallCtrl : MonoBehaviour
{
  private void Start()
  {
    Invoke("Delete", 3);
  }
  private void Delete()
  {
    Destroy(gameObject);
  }
  private void OnCollisionEnter(Collision other)
  {
    if (other.gameObject.CompareTag("Limit"))
    {
      Destroy(gameObject);
    }
  }
}
