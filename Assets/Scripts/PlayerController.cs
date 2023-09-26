using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    int life = 2;
    bool isJumping = false;
    SpriteRenderer renderer;
    // BoxCollider2D bc2d;
    // bool isHit;
    // Animator animator;
    // float angle;
    // bool isDead;

    // public float maxHeight;
    public float jumpVelocity;
    // public float relativeVelocityX;
    // public GameObject sprite;

    // public bool IsDead(){
    // return isDead;
    // }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //    animator = sprite.GetComponent<Animator>();
    }

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        // bc2d = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isJumping && !(rb2d.velocity.y < -0.5f))
        {
            Jump();
        }
        // ApplyAngle();
        // animator.SetBool("flap", angle >= 0.0f && !isDead);
    }

    public void Jump()
    {
        // if (isDead) return;
        isJumping = true;
        // if (rb2d.isKinematic) return;
        rb2d.velocity = new Vector2(0.0f, jumpVelocity);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Enemyとぶつかった時にコルーチンを実行
        if (col.gameObject.tag == "Enemy")
        {
            StartCoroutine("Damage");
        }
    }

    IEnumerator Damage()
    {
        //レイヤーをPlayerDamageに変更
        gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
        //while文を10回ループ
        int count = 10;
        while (count > 0)
        {
            //透明にする
            renderer.material.color = new Color(1, 1, 1, 0);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            renderer.material.color = new Color(1, 1, 1, 1);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            count--;
        }
        //レイヤーをPlayerに戻す
        gameObject.layer = LayerMask.NameToLayer("Player");
    }

    // void ApplyAngle(){
    // float targetAngle;

    // if (isDead){
    // targetAngle = 180.0f;
    // } else{
    // targetAngle = Mathf.Atan2(rb2d.velocity.y, relativeVelocityX) * Mathf.Rad2Deg;
    // }

    // angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * 10.0f);
    // sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    // }

    // void OnCollisionEnter2D(Collision2D collision){
    // if (isDead) return;
    // Camera.main.SendMessage("Clash");
    // isDead = true;
    // }

    // public void SetSteerActive(bool active){
    // rb2d.isKinematic = !active;
    // }
}