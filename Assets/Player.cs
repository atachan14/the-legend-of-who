using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    float speed = 0.1f;
    bool moveUp;
    bool moveRight;
    bool moveLeft;
    bool moveDown;

    public Sprite UpSprite; // 上向きのスプライト
    public Sprite DownSprite; // 下向きのスプライト
    public Sprite LeftSprite; // 左向きのスプライト
    public Sprite RightSprite; // 右向きのスプライト

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveUp = true;
            spriteRenderer.sprite = UpSprite;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight = true;
            spriteRenderer.sprite = RightSprite;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft = true;
            spriteRenderer.sprite = LeftSprite;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDown = true;
            spriteRenderer.sprite = DownSprite;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            moveUp = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveRight = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveLeft = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            moveDown = false;
        }

        // 移動処理
        if (moveUp && CanMove(Vector3.up)) transform.position += Vector3.up * speed;
        if (moveRight && CanMove(Vector3.right)) transform.position += Vector3.right * speed;
        if (moveLeft && CanMove(Vector3.left)) transform.position += Vector3.left * speed;
        if (moveDown && CanMove(Vector3.down)) transform.position += Vector3.down * speed;
    }

    // 移動可能かチェックするメソッド
    private bool CanMove(Vector3 direction)
    {
        // 移動先の座標を計算
        Vector3 newPosition = transform.position + direction * speed;
        int layerMask = LayerMask.GetMask("noPass");
        Vector2 boxSize = new Vector2(0.125f, 0.125f); // ボックスのサイズ（幅と高さ）
        Collider2D hit = Physics2D.OverlapBox(newPosition, boxSize, 0f, layerMask);

        // hitがnullであれば、移動可能
        return hit == null;
    }



}


