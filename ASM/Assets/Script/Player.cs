using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player_Move : MonoBehaviour
{
    //1.xu li an diem
    int score = 0;
    public Text txtScore;
    //-----

    int hp = 3;
    public  Text txtHP;

    public static bool isGameOver = false;
    public float speedX, speedY; //Tốc độ theo trục x, y
    private Animator animator;


    // Start is called before the first frame update
    //hàm xử lí va chạm
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            score++; //tăng điểm
            Destroy(collision.gameObject); //hủy coin
            txtScore.text = "Score: " + score.ToString();
        }

        if (collision.gameObject.tag == "Mushroom")
        {
            score--; //trừ điểm
            Destroy(collision.gameObject); //hủy coin
            txtScore.text = "Score: " + score.ToString();
            if (score <= 0)
            {
                Application.LoadLevel("Menu");
            }

        }
        if (collision.gameObject.tag == "CNV")
        {
            hp--; //trừ điểm
            Destroy(collision.gameObject); //hủy coin
            txtHP.text = "HP: " + hp.ToString();
            if (score <= 0)
            {
                Application.LoadLevel("Menu");
            }

        }

    }
    // qua màn chơi khác
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Va cham vao: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "nendat")
        {
            //isGrounded = true;
            // animator.SetBool("isGround", true);
            // animator.SetBool("isRun", false);
            animator.SetBool("diChay", false);
            animator.SetBool("diDung", true);
        }
        else if (collision.gameObject.tag == "door")
        {
            SceneManager.LoadScene("Level1");
        }
    }


    //hàm xử lí va chạm
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Coin") //neu va cham voi coin
    //     {
    //         score++; //tăng điểm
    //         Destroy(collision.gameObject); //hủy coin
    //         txtScore.text = "Score: " + score.ToString();
    //     }
    // }

    // Rigibody2D rigibody2d;
    // Transform transform;

    public void Start()
    {

        txtScore = GameObject.Find("txtDiem").GetComponent<Text>(); //ánh xạ
        txtHP = GameObject.Find("txtHP").GetComponent<Text>(); //ánh xạ

        // rigibody2d = this.gameObject.GetComponent<Rigibody2D>();
        // transform = this.gameObject.GetComponent<Transform>();
        animator = GetComponent<Animator>(); //findByViewID
        isGameOver = false;
        //thiet lap tham so trang thai
        animator.SetBool("diChay", false);
        animator.SetBool("diDung", true);

    }

    // float movePrefix = 6;
    public void Update()
    {
        if (!isGameOver)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) //khi an mui ten trai
            {
                //thiet lap tham so trang thai
                animator.SetBool("diChay", true);
                animator.SetBool("diDung", false);
                //di chuyen
                gameObject.transform.Translate(Vector2.left * speedX * Time.deltaTime);
                //quay dau neu nguoc chieu
                if (gameObject.transform.localScale.x > 0)
                {
                    gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                }
            }
            else if (Input.GetKey(KeyCode.RightArrow)) //khi an mui ten phai
            {
                //thiet lap tham so trang thai
                animator.SetBool("diChay", true);
                animator.SetBool("diDung", false);
                //di chuyen
                gameObject.transform.Translate(Vector2.right * speedX * Time.deltaTime);
                //quay dau neu nguoc chieu
                if (gameObject.transform.localScale.x < 0) //nguoc chieu
                {
                    gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                }
            }
            else if (Input.GetKey(KeyCode.Space)) //nhan dau cach
            {
                //thiet lap tham so trang thai
                animator.SetBool("diChay", true);
                animator.SetBool("diDung", false);
                //Jump 0 đk
                // if(gameObject.tag="matsan"){
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, speedY);
                // }
            }
            else
            {
                //thiet lap tham so trang thai
                animator.SetBool("diChay", false);
                animator.SetBool("diDung", true);

            }
        }


        // if (Input.GetKeyDown(KeyCode.Sapce))
        // {
        //     rigibody2d.AddFore(Vector2.up * movePrefix, ForeMode2D.Impulse);
        // }
        // else if (Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     rigibody2d.AddFore(Vector2.left * movePrefix, ForeMode2D.Impulse);
        //     transform.Rotate(Vector3.left);
        // }else if(Input.GetKeyDown(KeyCode.RightArrow)){
        //     rigibody2d.AddFore(Vector2.right * movePrefix, ForeMode2D.Impulse);
        //     transform.Rotate(Vector3.right);
        // }
    }

}