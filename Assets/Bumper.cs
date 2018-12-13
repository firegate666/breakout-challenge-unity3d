using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float Speed = 5.0f;
    public float MinX = -5.0f;
    public float MaxX = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float y = 0.0f;// Input.GetAxis("Vertical");

        transform.Translate(x, y, 0.0f);

        var ot = transform.position;
        transform.position = new Vector3(Mathf.Clamp(ot.x, MinX, MaxX), ot.y, ot.z);
    }
}
