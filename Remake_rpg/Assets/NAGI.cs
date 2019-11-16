using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAGI : MonoBehaviour
{
    float time = 0;
    bool flag_draw = false;
    [SerializeField] Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(!flag_draw&&GameObject.FindGameObjectsWithTag("Figure").Length > 0)
        {
            flag_draw = true;
            time = 0;
        }
        if (flag_draw && time > 5)
        {
            rb.AddForce(new Vector2(800, 700));
            time = 0;
        }
    }
}
