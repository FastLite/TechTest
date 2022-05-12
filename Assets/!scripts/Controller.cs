using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Controller : MonoBehaviour
{
    [Header("Player")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private SpriteRenderer shark;
    private int targetIndex;
    private int score;
    [SerializeField]
    private AudioSource src;
     

    private float moveHorizontal, moveVertical;
    private Vector2 movement;
    private Rigidbody2D r2d;
    
    [Header("UI")]
    [SerializeField]
    private List<Sprite> allFish;
    [SerializeField]
    private Image targetFish;
    [SerializeField]
    private TextMeshProUGUI scoreTxt;
    [Header("Other")]
    [SerializeField]
    private List<AudioClip> sfx;

 
    private void Start()
    {
        NewTargetFish();
        r2d = gameObject.GetComponent<Rigidbody2D>();
        scoreTxt.text = "Score: " + score;
    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal")*speed;
        shark.flipX = (moveHorizontal>0);
        moveVertical = Input.GetAxis("Vertical")*speed;
        movement = new Vector2(moveHorizontal, moveVertical);
        r2d.velocity = movement * speed;
    }

        private void NewTargetFish()
        {
            targetIndex = Random.Range(0, allFish.Count);
            targetFish.sprite = allFish[targetIndex];
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("fish"))
            {
                if (col.gameObject.GetComponent<fish>().index == targetIndex)
                {
                    scoreTxt.text = "Score: " + (score+1).ToString();
                    src.PlayOneShot(sfx[0]);
                    NewTargetFish();
                }
                else
                {
                    scoreTxt.text = "Score: " + (score-1).ToString();
                    src.PlayOneShot(sfx[1]);
                }
            }
        }
}