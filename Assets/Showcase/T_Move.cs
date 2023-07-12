using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Move : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float sideMove = Input.GetAxis("Horizontal");
        float forwardMove = Input.GetAxis("Vertical");

        Vector3 newOffset = new Vector3(sideMove, 0, forwardMove);

        transform.Translate(newOffset * speed * Time.deltaTime);

    }
}
