using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public KeyCode A= KeyCode.A;
    public KeyCode D = KeyCode.D;
    public KeyCode W = KeyCode.W;
    public KeyCode S = KeyCode.S;

    public Rigidbody2D _rigid;
    public float speed=5;
    private Vector2 direction= Vector2.zero;

    public AnimaSprite _Up; 
    public AnimaSprite _Down;
    public AnimaSprite _Left;
    public AnimaSprite _Right;
    private AnimaSprite _Idle;
    public AnimaSprite _Die;

    // Start is called before the first frame update
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _Idle = _Down;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey(A))
       { SetDirection(Vector2.left,_Left); }
      else if (Input.GetKey(D))
       { SetDirection(Vector2.right,_Right); }
      else if (Input.GetKey(W))
       { SetDirection(Vector2.up,_Up); }
      else if (Input.GetKey(S))
       { SetDirection(Vector2.down,_Down); }
      else 
       { SetDirection(Vector2.zero,_Idle); }

    }
    private void FixedUpdate()
    {
        Vector2 position = this.transform.position;
        Vector2 translate = direction * speed * Time.fixedDeltaTime;
        _rigid.MovePosition(position + translate);
    }
    private void SetDirection(Vector2 newdirection, AnimaSprite _Animation)
    {
        direction = newdirection;
        _Up.enabled = _Animation == _Up;//Bật tắt SpriteRender, Script ở các gameobject
        _Down.enabled = _Animation == _Down;
        _Left.enabled = _Animation == _Left;
        _Right.enabled = _Animation == _Right;
        _Animation.idle = direction == Vector2.zero;
        _Die.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Explotion"))
        {
            Dead();
            Debug.Log("Trig");
        }
    }
    private void Dead() 
    {
        Debug.Log("123");
        // _Die.enabled = true;
        enabled = false;
        GetComponent<BoomController>().enabled = false;

        _Up.enabled = false;
        _Down.enabled = false;
        _Left.enabled = false;
        _Right.enabled = false;

        _Die.enabled = true;


        Invoke(nameof(AfterDead), 1f);
    }
    void AfterDead()
    {
        gameObject.SetActive(false);
        GameObject.Find("Gamemanager").GetComponent<GameMAnager>().CheckWin();
    }
}
