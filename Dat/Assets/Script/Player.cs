using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int hp = 3;

    public int GetHp()
    {
        return hp;
    }
    public void SetHP(int hp)
    {
        this.hp = hp;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp > 0)
        {
            float posx = Input.GetAxis("Horizontal");
            float posy = Input.GetAxis("Vertical");

            //float posx=0, posy=0;
            //if (Input.GetKey(KeyCode.A))
            //{
            //    posx -=1;
            //}
            //if (Input.GetKey(KeyCode.D))
            //{
            //    posx += 1;
            //}
            //if (Input.GetKey(KeyCode.W))
            //{
            //    posy += 1;
            //}
            //if (Input.GetKey(KeyCode.S))
            //{
            //    posy -= 1;
            //}
            Vector3 pos = gameObject.transform.position;
            pos.x += posx * Time.deltaTime * 10;
            pos.y += posy * Time.deltaTime * 10;
            if (pos.x > 7.9f)
            {
                pos.x = 7.9f;
            }
            else if (pos.x < -7.9)
            {
                pos.x = -7.9f;
            }
            if (pos.y > 4.47)
            {
                pos.y = 4.47f;
            }
            else if (pos.y < -4.47)
            {
                pos.y = -4.47f;
            }
            gameObject.transform.position = pos;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            hp--;
            print(hp);
        }
    }
}
