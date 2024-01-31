using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject panelEndGame;
    public GameObject panelWinGame;

    private Animator animator;
    public float speedX, speedY;
    public static bool isGameOver = false;

    int score = 0;
    private Text txtScore;
    int hp = 3;
    public  Text txtHP;

    //
    //

    public GameObject banana;
    //public GameObject weapon;
    public AudioClip jump;
    public AudioClip collectFruit;
    private AudioSource audioSource;
    public float moveSpeed = 12f;
     
    public SpriteRenderer spriteRenderer;


    void Start()
    {
         //rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Instantiate(weapon, gameObject.transform);

        audioSource = GetComponent<AudioSource>();

        //Instantiate(effectPartical, gameObject.transform);
        //
        //

        
        txtScore = GameObject.Find("txtDiem").GetComponent<Text>(); //ánh xạ
        txtHP = GameObject.Find("txtHP").GetComponent<Text>(); //ánh xạ

        animator = GetComponent<Animator>(); //findByViewID
        isGameOver = false;
        //thiet lap tham so trang thai
        animator.SetBool("diChay", false);
        animator.SetBool("diDung", true);
    }



    

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "obstacles")
        {
            //
            hp--; //trừ điểm
            txtHP.text = "HP: " + hp.ToString();
            if (hp <= 0)
            {
                // Application.LoadLevel("Menu");
                panelEndGame.SetActive(true);
            }
            // Time.timeScale = 0;
            
        }
        if (other.gameObject.tag == "checkpoint")
        {
            SceneManager.LoadScene("Map 2");
        }
        if (other.gameObject.tag == "checkwin")
        {
            panelWinGame.SetActive(true);
            //Time.timeScale = 0;
            
        }
    }

    



    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "fruits")
        {
            audioSource.PlayOneShot(collectFruit);
            score++; //tăng điểm
            Destroy(collider.gameObject); //hủy 
            txtScore.text = "Score: " + score.ToString();
            

            //Instantiate(effectPartical, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

        // Update is called once per frame
        void Update()
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
    }
}
