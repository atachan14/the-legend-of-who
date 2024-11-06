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

    public Sprite UpSprite; // ������̃X�v���C�g
    public Sprite DownSprite; // �������̃X�v���C�g
    public Sprite LeftSprite; // �������̃X�v���C�g
    public Sprite RightSprite; // �E�����̃X�v���C�g

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

        // �ړ�����
        if (moveUp && CanMove(Vector3.up)) transform.position += Vector3.up * speed;
        if (moveRight && CanMove(Vector3.right)) transform.position += Vector3.right * speed;
        if (moveLeft && CanMove(Vector3.left)) transform.position += Vector3.left * speed;
        if (moveDown && CanMove(Vector3.down)) transform.position += Vector3.down * speed;
    }

    // �ړ��\���`�F�b�N���郁�\�b�h
    private bool CanMove(Vector3 direction)
    {
        // �ړ���̍��W���v�Z
        Vector3 newPosition = transform.position + direction * speed;
        int layerMask = LayerMask.GetMask("noPass");
        Vector2 boxSize = new Vector2(0.125f, 0.125f); // �{�b�N�X�̃T�C�Y�i���ƍ����j
        Collider2D hit = Physics2D.OverlapBox(newPosition, boxSize, 0f, layerMask);

        // hit��null�ł���΁A�ړ��\
        return hit == null;
    }



}


