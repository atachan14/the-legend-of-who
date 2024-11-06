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

    public Sprite UpSprite; // ������̃X�v���C�g
    public Sprite DownSprite; // �������̃X�v���C�g
    public Sprite LeftSprite; // �������̃X�v���C�g
    public Sprite RightSprite; // �E�����̃X�v���C�g

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

    // �ړ��\���`�F�b�N���郁�\�b�h
    private bool CanMove(Vector3 direction)
    {
        // �ړ���̍��W���v�Z
        Vector3 newPosition = transform.position + direction * speed;
        int layerMask = LayerMask.GetMask("noPass");
        Vector2 boxSize = new Vector2(0.32f, 0.32f); // �{�b�N�X�̃T�C�Y�i���ƍ����j
        Collider2D hit = Physics2D.OverlapBox(newPosition, boxSize, 0f, layerMask);

        // hit��null�ł���΁A�ړ��\
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
        if (direction == Vector3.up) return 0f;     // Up -> 0�x
        if (direction == Vector3.right) return 90f;  // Right -> 90�x
        if (direction == Vector3.down) return 180f;  // Down -> 180�x
        if (direction == Vector3.left) return 270f;  // Left -> 270�x
        return 0; // Default
    }


}


