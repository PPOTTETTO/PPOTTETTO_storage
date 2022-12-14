using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StickmanController : MonoBehaviour
{
    
    public enum Player { Pink, Blue, dum }
    public Player playerType;

    public _Muscle[] muscles;

    public float JumpPower;
    public int MaxHp = 100;
    public int Hp;

    public HpBar healthBar;

    public float positionRadius;

    public LayerMask G;
    public Transform PlayerPos;

    public bool BlueLive;
    public bool PinkLive;
    public bool Right;
    public bool Left;
    private bool isOnGround;

    public Rigidbody2D rbUP;
    public Rigidbody2D rbRIGHT;
    public Rigidbody2D rbLEFT;

    public Vector2 WalkRightVector;
    public Vector2 WalkLeftVector;

    private float MoveDelayPointer;
    public float MoveDelay;

    void Start()
    {
        Hp = MaxHp;
        healthBar.SetMaxHealth(MaxHp);
        BlueLive = true;
        PinkLive = true;
    }

    void TakeDamage(int damage)
    {
        Hp -= damage;

        healthBar.SetHealth(Hp);
    }

    void Heal(int heal)
    {
        Hp += heal;

        healthBar.SetHealth(Hp);
    }

    private void Update()
    {
        switch (playerType)
        {
            case Player.Pink:
                if(Hp > 0)
                {
                    foreach (_Muscle muscle in muscles)
                    {
                        muscle.ActivateMuscle();
                        PinkLive = true;
                    }
                }
                else if (Hp <= 0)
                {
                    foreach (_Muscle muscle in muscles)
                    {
                        muscle.DieMuscle();
                        PinkLive = false;
                    }
                }
                break;
            case Player.Blue:
                if(Hp> 0)
                {
                    foreach (_Muscle muscle in muscles)
                    {
                        muscle.ActivateMuscle();
                        BlueLive = true;
                    }
                }
                else if (Hp <= 0)
                {
                    foreach (_Muscle muscle in muscles)
                    {
                        muscle.DieMuscle();
                        BlueLive = false;
                    }
                }
                break;
            case Player.dum:
                if (Hp > 0)
                {
                    foreach (_Muscle muscle in muscles)
                    {
                        muscle.ActivateMuscle();
                        BlueLive = true;
                    }
                }
                else if (Hp <= 0)
                {
                    foreach (_Muscle muscle in muscles)
                    {
                        muscle.DieMuscle();
                        BlueLive = false;
                    }
                }
                break;
        }
            foreach (_Muscle muscle in muscles)
            {
                 muscle.Update();
            }

        switch (playerType)
        {
            case Player.Pink:
               if (PinkLive == true)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        Right = true;
                    }

                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        Left = true;
                    }

                    if (Input.GetKeyUp(KeyCode.RightArrow))
                    {
                        Right = false;
                    }

                    if (Input.GetKeyUp(KeyCode.LeftArrow))
                    {
                        Left = false;
                    }
                }
                break;
            case Player.Blue:
                if (BlueLive == true)
                {
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        Right = true;
                    }

                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        Left = true;
                    }

                    if (Input.GetKeyUp(KeyCode.D))
                    {
                        Right = false;
                    }

                    if (Input.GetKeyUp(KeyCode.A))
                    {
                        Left = false;
                    }
                }
                break;

        }

        isOnGround = Physics2D.OverlapCircle(PlayerPos.position, positionRadius, G);

        switch (playerType)
        {
            case Player.Pink:
                if (PinkLive == true)
                {
                    if (isOnGround == true && Input.GetKey(KeyCode.UpArrow))
                    {
                        rbUP.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                    }

                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        rbUP.AddForce(Vector2.down * 4, ForceMode2D.Impulse);
                    }
                }
                break;
            case Player.Blue:
                if (BlueLive == true)
                {
                    if (isOnGround == true && Input.GetKey(KeyCode.W))
                    {
                        rbUP.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                    }

                    if (Input.GetKey(KeyCode.S))
                    {
                        rbUP.AddForce(Vector2.down * 4, ForceMode2D.Impulse);
                    }
                }
                break;
        }

        switch (playerType)
        {
            case Player.Pink:
                if (Input.GetKeyDown(KeyCode.B))
                {
                    TakeDamage(100);
                }
                break;
            case Player.Blue:
                if (Input.GetKeyDown(KeyCode.C))
                {
                    TakeDamage(100);
                }
                break;
            case Player.dum:
                if (Input.GetKeyDown(KeyCode.X))
                {
                    TakeDamage(100);
                }
                break;
        }

        switch (playerType)
        {
            case Player.Pink:
                if (Input.GetKeyDown(KeyCode.N))
                {
                    Heal(100);
                }
                break;
            case Player.Blue:
                if (Input.GetKeyDown(KeyCode.V))
                {
                    Heal(100);
                }
                break;
            case Player.dum:
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Heal(100);
                }
                break;
        }



        while (Right == true && Left == false && Time.time > MoveDelayPointer)
        {
            Invoke("Step1Right", 0f);
            Invoke("Step2Right", 0.085f);
            Invoke("R", 0f);
            Invoke("R", 0.085f);
            MoveDelayPointer = Time.time + MoveDelay;
        }

        while (Left == true && Right == false && Time.time > MoveDelayPointer)
        {
            Invoke("Step1Left", 0f);
            Invoke("Step2Left", 0.085f);
            Invoke("L", 0f);
            Invoke("L", 0.085f);
            MoveDelayPointer = Time.time + MoveDelay;
        }

     }


                              



    public void Step1Right()
    {
        rbRIGHT.AddForce(WalkRightVector, ForceMode2D.Impulse);
        rbLEFT.AddForce(WalkRightVector * -0.5f, ForceMode2D.Impulse);
    }

    public void Step2Right()
    {
        rbLEFT.AddForce(WalkRightVector, ForceMode2D.Impulse);
        rbRIGHT.AddForce(WalkRightVector * -0.5f, ForceMode2D.Impulse);
    }

    public void Step1Left()
    {
        rbRIGHT.AddForce(WalkLeftVector, ForceMode2D.Impulse);
        rbLEFT.AddForce(WalkRightVector * -0.5f, ForceMode2D.Impulse);
    }

    public void Step2Left()
    {
        rbLEFT.AddForce(WalkLeftVector, ForceMode2D.Impulse);
        rbRIGHT.AddForce(WalkLeftVector * -0.5f, ForceMode2D.Impulse);
    }



}

[System.Serializable]
public class _Muscle
{

    public Rigidbody2D bone;
    public float restRotation;
    public float force;
    public bool R;

    public void Update()
    {
        if (R == true)
        {
            bone.MoveRotation(Mathf.LerpAngle(bone.rotation, restRotation, force * Time.deltaTime));
        }
    }
    
    public void DieMuscle()
    {
        R = false;
    }
    public void ActivateMuscle()
    {
        R = true;
    }
}


