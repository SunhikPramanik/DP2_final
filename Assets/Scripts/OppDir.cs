using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppDir : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(0, 0, -5 * rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(0, 0, 5 * rotateSpeed * Time.deltaTime);
        }
    }
}
