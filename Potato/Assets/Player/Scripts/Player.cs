using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public enum State
{
    normal,
    jump,
    longJump,
}

public class Player : MonoBehaviour
{
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool canMove = false;
    [HideInInspector] new public Rigidbody2D rigidbody2D;
    [HideInInspector] public State currentState;
    [HideInInspector] public bool lockMovement = false;
    Vector2 atkSpeed = new Vector2(0,0);
    Vector2 knockbackSpeed = new Vector2(0,0);


    public bool spawnAtStart;

    [Space]
    public float sideSpeed;
    public float upSpeed;
    public float jumpSpeed;
    public float longJumpSideSpeed;
    public float startLongJumpTimer;
    [HideInInspector] public float longJumpTimer;

    [Space]
    public GameObject atkPrefab;
    public float startAtkCD;
    float atkCD;
    public float sideAtkUpSpeed;
    public float sideAtkSideSpeed;
    public float upAtkUpSpeed;
    public float upAtkSideSpeed;
    public float downAtkSpeed;

    [Space]
    public int maxHealth;
    [HideInInspector] public int health;
    public float startIFrameTimer;
    float iFrameTimer;
    public float upKnockback;
    public float sideKnockback;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject takeDamagePrefab;

    [Space]
    public bool hasDash;
    CircleCollider2D circleCollider2D;
    public float startDashCD;
    float dashCD = 0;
    public float dashSpeed;
    public float dashTime;
    bool isDashing;
    Vector2 dashVector = new Vector2();
    public float dashRotation;
    Vector3 rotationVector = new Vector3();
    [Space]
    public bool hasFly;
    Vector2 flyVector = new Vector2();
    public float flySpeed;

    [Space]
    public bool hasSuperDash;
    public float superDashSpeed;
    public float startSuperDashCD;
    float superDashCD = 0;
    public float superDashIFrameTime;
    Vector2 superDashVector = new Vector2();
    bool isSuperDashing;
    public float superDashTime;

    // Start is called before the first frame update
    void Start()
    {
        if(spawnAtStart)
        {
            transform.position = new Vector3(-7.5f, 29);
        }

        rigidbody2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDashing || !isSuperDashing)
        {
            if (!hasFly)
            {
                CheckForJump();
                CheckForMove();
            }

            if (!lockMovement)
            {
                CheckForTurn();
            }
        }

        if (!lockMovement)
        {
            CheckForAtk();
        }

        CallTimer();

        CheckForHealth();

        if (!isSuperDashing && !lockMovement)
        {
            CheckForFly();
        }

        if (!hasFly)
        {
            CheckForDash();
        }

        if (!lockMovement)
        {
            CheckForSuperDash();
        }
    }

    void CheckForSuperDash()
    {
        if(hasSuperDash)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(superDashCD <= 0)
                {
                    if (!IsFacingRight())
                    {
                        superDashVector.x = -1;
                    }
                    else
                    {
                        superDashVector.x = 1;
                    }
                   

                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        superDashVector.y = 1;
                    }
                    else if (Input.GetKey(KeyCode.DownArrow))
                    {
                        superDashVector.y = -1;
                    }
                    else
                    {
                        superDashVector.y = 0.3f;
                    }

                    if (iFrameTimer < superDashIFrameTime)
                    {
                        iFrameTimer = superDashIFrameTime;
                    }

                    superDashCD = startSuperDashCD;
                    isSuperDashing = true;
                    rigidbody2D.AddForce(superDashVector * superDashSpeed);

                    IEnumerator coroutine = FinishSuperDash(superDashTime);
                    StartCoroutine(coroutine);
                }
            }

            if(superDashCD >= 0)
            {
                superDashCD -= Time.deltaTime;
            }
        }
    }

    IEnumerator FinishSuperDash(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        isSuperDashing = false;
    }

    void CheckForFly()
    {
        if(hasFly)
        {
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                flyVector.x = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                flyVector.x = 1;
            }
            else
            {
                flyVector.x = 0;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                flyVector.y = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                flyVector.y = -1;
            }
            else
            {
                flyVector.y = 0;
            }

            rigidbody2D.velocity = flyVector * flySpeed;
        }
    }

    void CheckForDash()
    {
        if (hasDash)
        {
            if (dashCD > 0)
            {
                dashCD -= Time.deltaTime;
            }
            else
            {
                if (Input.GetKey(KeyCode.Z) && isGrounded && canMove)
                {
                    isDashing = true;
                    circleCollider2D.radius = 0.01f;
                    rotationVector.Set(0, 0, -dashRotation);

                    if (IsFacingRight())
                    {
                        dashVector.Set(dashSpeed, 0);
                        IEnumerator coroutine = FinishDash(dashTime, true);
                        StartCoroutine(coroutine);
                    }
                    else
                    {
                        dashVector.Set(-dashSpeed, 0);
                        IEnumerator coroutine = FinishDash(dashTime, false);
                        StartCoroutine(coroutine);
                    }
                }
            }
        }

        if(isDashing)
        {
            transform.Rotate(rotationVector * Time.deltaTime);
            rigidbody2D.velocity = dashVector;
        }
    }

    IEnumerator FinishDash(float seconds, bool isFacingRight)
    {
        yield return new WaitForSeconds(seconds);
        circleCollider2D.radius = 0.09f;
        isDashing = false;
        dashCD = startDashCD;

        if(isFacingRight)
        {
            FaceRight();
        }
        else
        {
            FaceLeft();
        }
    }

    void CheckForHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
          
        }
    }

    void CallTimer()
    {
        if(iFrameTimer > 0)
        {
            iFrameTimer -= Time.deltaTime;
        }
    }    

    void CheckForAtk()
    {
        if (atkCD > 0)
        {
            atkCD -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.X))
            {
                GameObject atk = Instantiate(atkPrefab, transform.position, transform.rotation);
                atkCD = startAtkCD;

                if(Input.GetKey(KeyCode.UpArrow))
                {
                    if(IsFacingRight())
                    {
                        atkSpeed.Set(upAtkSideSpeed, upAtkUpSpeed);
                    }
                    else
                    {
                        atkSpeed.Set(-upAtkSideSpeed, upAtkUpSpeed);
                    }
                }
                else if (Input.GetKey(KeyCode.DownArrow) && !isGrounded)
                {
                    atkSpeed.Set(0, -downAtkSpeed);
                }
                else
                {
                    if (IsFacingRight())
                    {
                        atkSpeed.Set(sideAtkSideSpeed, sideAtkUpSpeed);
                    }
                    else
                    {
                        atkSpeed.Set(-sideAtkSideSpeed, sideAtkUpSpeed);
                    }
                }

                atk.GetComponent<Rigidbody2D>().AddForce(atkSpeed);
            }
        }       
    }


    void FaceLeft()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    void FaceRight()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    bool IsFacingRight()
    {
        if(transform.rotation.y == 0)
        {
            return true;
        }
        else
        {
            return false;
        }    
    }

    void CheckForTurn()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            FaceLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            FaceRight();
        }
    }

    void CheckForJump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentState = State.jump;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            currentState = State.longJump;
        }
        else
        {
            currentState = State.normal;
        }
    }

    void CheckForMove()
    {
        if (isGrounded && canMove)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveCharacter(-1, currentState);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveCharacter(1, currentState);
            }
        }
    }

    void MoveCharacter(int dir, State state)
    {
        if (state == State.longJump)
        {
            rigidbody2D.AddForce(new Vector2(dir * longJumpSideSpeed, upSpeed));
        }
        else if(state == State.jump)
        {
            rigidbody2D.AddForce(new Vector2(dir * sideSpeed, jumpSpeed));
        }
        else
        {
            rigidbody2D.AddForce(new Vector2(dir * sideSpeed, upSpeed));
        }

        canMove = false;
      
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Skill"))
        {
            if(iFrameTimer <= 0)
            {
                health -= 1;
                iFrameTimer = startIFrameTimer;
                Instantiate(takeDamagePrefab, transform.position, transform.rotation);

                canMove = false;

                rigidbody2D.velocity = Vector2.zero;

                if(collision.transform.position.x > transform.position.x)
                {
                    knockbackSpeed.Set(-sideKnockback, upKnockback);
                    FaceRight();
                }
                else
                {
                    knockbackSpeed.Set(sideKnockback, upKnockback);
                    FaceLeft();
                }

                rigidbody2D.AddForce(knockbackSpeed);

                if (health <= 0)
                {
                    Die();
                }
            }
        }
    }

    void Die()
    {
        SceneManager.LoadScene(3);
    }
}
