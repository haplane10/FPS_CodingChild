using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float power;
    //Coroutine co_Destroy;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.AddForce(transform.forward * power);
        //co_Destroy = StartCoroutine(DestroyObject(10));

        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 3f);
        rigidbody.Sleep();
        //StartCoroutine(DestroyObject(3));
    }

    //IEnumerator DestroyObject(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    Destroy(gameObject);
    //}
}
