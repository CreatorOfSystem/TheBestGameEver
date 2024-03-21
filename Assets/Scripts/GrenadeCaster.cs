using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public float force;
    public Transform grenadeSourceTransform;
    public Rigidbody GrenadePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var grenade = Instantiate(GrenadePrefab);

            grenade.transform.position = grenadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(grenadeSourceTransform.forward*force);
        }
    }
}
