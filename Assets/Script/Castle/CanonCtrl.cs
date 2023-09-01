using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonCtrl : MonoBehaviour
{
  public GameObject canonBall;
  public float burstForce;
  // Start is called before the first frame update
  void Start()
  {

  }

  public void FireBall()
  {
    GameObject b = Instantiate(canonBall, transform.position, Quaternion.identity, gameObject.transform.parent);
    b.GetComponent<Rigidbody>().AddForce(transform.up * burstForce, ForceMode.Force);
  }
}
