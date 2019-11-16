using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    [SerializeField] CharaBase CB;
    [SerializeField] VisualBase VB;
    [SerializeField] float attackDistance;//攻撃を開始する距離
    [SerializeField] Sprite attackSprite;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Vector2 attackMoveForce;
    [SerializeField] int attackPower;
    private GameObject player;
    private CharaBase playerCB;
    private bool attacking = false;
    private float delayTime = 0;
    [SerializeField] float maxDelayTime;//次の攻撃までの待ち時間
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCB = player.GetComponent<CharaBase>();
    }
    void Update()
    {
        if (NearPlayer() && !attacking && delayTime > maxDelayTime) StartAttacking();
        if (!attacking) delayTime += Time.deltaTime;
    }
    /// <summary>
    /// プレイヤーとの距離が指定した距離以下かを返す
    /// </summary>
    /// <returns>近ければtrue</returns>
    private bool NearPlayer()
    {
        var distance = Vector2.Distance(player.transform.position, transform.position);
        return distance < attackDistance;
    }

    private void StartAttacking()
    {
        attacking = true;
        VB.flag_AutoChangeWalkingImage = false;
        VB.SetCharaSprite(attackSprite);
        if(player.transform.position.x < transform.position.x)
        {
            //プレイヤーが左側にいるとき
            var force = new Vector2(-attackMoveForce.x, attackMoveForce.y);
            transform.eulerAngles=new Vector3(0, 0, 0);
            rb.AddForce(force);
        }
        else
        {
            //プレイヤーが右側にいるとき
            rb.AddForce(attackMoveForce);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        
    }
    //攻撃状態終了
    private void EndAttacking()
    {
        attacking = false;
        VB.flag_AutoChangeWalkingImage = true;
        delayTime = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && attacking)
        {
            //攻撃する
            playerCB.OnDamage(attackPower);

            EndAttacking();
        }
        if(collision.gameObject.tag == "Stage" && attacking)
        {
            //攻撃終了
            EndAttacking();
        }
    }

}
