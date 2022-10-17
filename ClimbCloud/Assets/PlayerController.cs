using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float JumpForce = 680.0f;
    float walkForce = 20.0f;
    float maxWalkSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //�����Ѵ�.
        if (Input.GetKeyDown(KeyCode.Space)&&this.rigid2D.velocity.y==0) {
            this.rigid2D.AddForce(transform.up * this.JumpForce*this.JumpForce);
                }

        //�¿� �̵�
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //�÷��̾� �ӵ�
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //���ǵ� ����
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);

        }
        //�����̴� ���ῡ ���� ����
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }


        //�÷��̾� �ӵ��� ���� �ִϸ޼� �ӵ� ����
        this.animator.speed = speedx / 2.0f;

        //�÷��̾ ȭ�� ������ �����ٸ� ó������
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
                }
    }

    //�� ����
    private void OnTriggerEnter2D(Collider2D orher)
    {
        Debug.Log("��");
        SceneManager.LoadScene("ClearScene");
    }
}
