using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Arrow : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(float arrowSpeed, Vector3 direction)
    {
        // �������Ɍ����Ĉړ������鏈��
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * arrowSpeed;
    }


}
