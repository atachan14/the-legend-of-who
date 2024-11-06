using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

public class Player : MonoBehaviour
{

    float speed = 0.1f;
    bool moveUp;
    bool moveRight;
    bool moveLeft;
    bool moveDown;
    Vector3 direction = Vector3.down;

    public Sprite UpSprite; // 上向きのスプライト
    public Sprite DownSprite; // 下向きのスプライト
    public Sprite LeftSprite; // 左向きのスプライト
    public Sprite RightSprite; // 右向きのスプライト

    private SpriteRenderer spriteRenderer;

    public GameObject arrowPrefab;
    Arrow arrow;
    float arrowSpeed = 10f;


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
            direction = Vector3.up;
            spriteRenderer.sprite = UpSprite;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight = true;
            direction = Vector3.right;
            spriteRenderer.sprite = RightSprite;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft = true;
            direction = Vector3.left;
            spriteRenderer.sprite = LeftSprite;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDown = true;
            direction = Vector3.down;
            spriteRenderer.sprite = DownSprite;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ShootArrow();
        }

        if (Input.GetKeyUp(KeyCode.W)) moveUp = false;
        if (Input.GetKeyUp(KeyCode.D)) moveRight = false;
        if (Input.GetKeyUp(KeyCode.A)) moveLeft = false;
        if (Input.GetKeyUp(KeyCode.S)) moveDown = false;

        if (moveUp && CanMove(direction)) transform.position += Vector3.up * speed;
        if (moveRight && CanMove(direction)) transform.position += Vector3.right * speed;
        if (moveLeft && CanMove(direction)) transform.position += Vector3.left * speed;
        if (moveDown && CanMove(direction)) transform.position += Vector3.down * speed;
    }

    // 移動可能かチェックするメソッド
    private bool CanMove(Vector3 direction)
    {
        // 移動先の座標を計算
        Vector3 newPosition = transform.position + direction * speed;
        int layerMask = LayerMask.GetMask("noPass");
        Vector2 boxSize = new Vector2(0.32f, 0.32f); // ボックスのサイズ（幅と高さ）
        Collider2D hit = Physics2D.OverlapBox(newPosition, boxSize, 0f, layerMask);

        // hitがnullであれば、移動可能
        return hit == null;
    }

    void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.Euler(0f, 0f, GetAngle(direction)));
       Arrow arrowScript = arrow.GetComponent<Arrow>();
        arrowScript.Shoot(arrowSpeed, direction);
    }


    public float GetAngle(Vector3 direction)
    {
        if (direction == Vector3.up) return 0f;     // Up -> 0度
        if (direction == Vector3.right) return 90f;  // Right -> 90度
        if (direction == Vector3.down) return 180f;  // Down -> 180度
        if (direction == Vector3.left) return 270f;  // Left -> 270度
        return 0; // Default
    }


}


