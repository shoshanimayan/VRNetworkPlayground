using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private IEnumerator kill() {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);


    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hit");
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
      //  StartCoroutine(kill());
    }
}
