using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_Move : MonoBehaviour
{
    //1.xu li an diem
    int score = 0;
    int hp = 5;
    public Text txtScore;
    public Text txtHp;
    //-----

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
            hp--; //trừ điểm
            Destroy(collision.gameObject); //hủy coin
            txtHp.text = "HP: " + hp.ToString();
            if (hp <= 0)
            {
                Application.LoadLevel("Menu");
            }

        }

    }


 public void Start()
    {

        txtScore = GameObject.Find("txtDiem").GetComponent<Text>(); //ánh xạ
        txtHp = GameObject.Find("txtHp").GetComponent<Text>();

        // rigibody2d = this.gameObject.GetComponent<Rigibody2D>();
        // transform = this.gameObject.GetComponent<Transform>();
        animator = GetComponent<Animator>(); //findByViewID
        isGameOver = false;
        //thiet lap tham so trang thai
        animator.SetBool("diChay", false);
        animator.SetBool("diDung", true);

    }


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
            else{
                //thiet lap tham so trang thai
                animator.SetBool("diChay", false);
                animator.SetBool("diDung", true);

            }
        }
    }
}
