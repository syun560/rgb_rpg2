/*
 * 製作者:土川(AE19051)
 * 製作日:2019/11/02
 * Playerの動きを処理
 */
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] KeyInput keyInput;
    [SerializeField] Rigidbody2D rb;
    private bool isTouchingTheGround = false;
    public float charaSpeed;
    public float jumpSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        keyInputMove();
    }
    private void keyInputMove()
    {
        if (keyInput.input_RightMove)
        {
            transform.eulerAngles = new Vector3(0, 180, transform.eulerAngles.z);
            rb.velocity = new Vector2(charaSpeed, rb.velocity.y);
        }
        if (keyInput.input_LeftMove)
        {
            transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
            rb.velocity = new Vector2(-charaSpeed, rb.velocity.y);
        }
        if (keyInput.input_Jump&&isTouchingTheGround)
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Stage") isTouchingTheGround = true;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stage") isTouchingTheGround = false;
    }

}
