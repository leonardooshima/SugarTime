using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
    
public class PlayerController : MonoBehaviour{
    
    public float speed;
    public float jumpForce;
    public float moveInput;
    public AudioClip somM;
    public AudioClip somE;

    
    private Rigidbody2D rb;
    
    private bool facingRight = true;
    
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadious;
    public LayerMask whatIsGround;
    
    public int life = 5;
    public Text lifeText;
    public int score = 0;
    public Text scoreText;
    
    private int extraJumps;
    public int extraJumpsValue;
    
    public Vector3 respawnPoint;
    
    
    void Start(){
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        MusicClass.Instance.gameObject.GetComponent<AudioSource>().Play();
    }
    
    public void FixedUpdate(){
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadious, whatIsGround);
        
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
        if(facingRight == false && moveInput > 0){
            Flip();
        } else if(facingRight == true && moveInput < 0){
            Flip();
        }
    }
    
    void Update(){
        if(isGrounded == true){
            extraJumps = extraJumpsValue;
        }
        
        if((Input.GetKeyDown(KeyCode.W) && extraJumps > 0)||(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)){
            rb.AddForce(new Vector2(0,jumpForce));
            extraJumps--;
        } else if((Input.GetKeyDown(KeyCode.UpArrow) && extraJumps==0 && isGrounded == true)||(Input.GetKeyDown(KeyCode.W) && extraJumps==0 && isGrounded == true)){
            rb.AddForce(new Vector2(0,jumpForce));
        }
    }
    
    void Flip(){
        
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    
    void OnCollisionEnter2D(Collision2D collision){  
        if(collision.gameObject.CompareTag("itens")){
            Destroy(collision.gameObject);
            score++;
            scoreText.text = score.ToString();
            AudioSource source1 = GetComponent<AudioSource> ();
            source1.clip = somM;
            source1.Play();
        }
        if(collision.gameObject.CompareTag("itens2")){
            Destroy(collision.gameObject);
            score+=5;
            scoreText.text = score.ToString();
            AudioSource source1 = GetComponent<AudioSource> ();
            source1.clip = somM;
            source1.Play();
        }
        if(collision.gameObject.CompareTag("itens3")){
            Destroy(collision.gameObject);
            score+=10;
            scoreText.text = score.ToString();
            AudioSource source1 = GetComponent<AudioSource> ();
            source1.clip = somM;
            source1.Play();
        }
        if(collision.gameObject.CompareTag("enemie")){
            life--;
            lifeText.text = life.ToString();
            scoreText.text = score.ToString();
            AudioSource source2 = GetComponent<AudioSource> ();
            source2.clip = somE;
            source2.Play();
            if(life == 0){
                perdeu();
            }
        }
        
    }
    
    void OnTriggerEnter2D(Collider2D other){  
        if(other.CompareTag("portal")){
            Debug.Log("Chegou ao portal");
            if(score==27){
                Debug.Log("50% concluida");
                SceneManager.LoadScene("leveltwo");
            }
            
            if(score==54){
                Debug.Log("100% concluida");
                SceneManager.LoadScene("win");
            }
            
            if(score<27){
                Debug.Log("Você precisa de mais açúcar");
            }
            
            if(score>27 && score<54){
                Debug.Log("Você precisa de mais açúcar para acionar o portal");
            }
        }
        
        if(other.CompareTag("caiu")){
            transform.position = respawnPoint;
            life--;
            lifeText.text = life.ToString();
            if(life == 0){
                perdeu();
            }
        }
        if(other.CompareTag("checkPoint")){
            Debug.Log("Caiu do mapa");
            respawnPoint = other.transform.position;
        }
    }
    
    void perdeu(){
        SceneManager.LoadScene("lose");
        Debug.Log("Você morreu");
    }
    
     
}