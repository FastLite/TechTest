using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class fish : MonoBehaviour
{
    public int index;

    private void FixedUpdate()
    {
        if (transform.position.x>30)
        {
            transform.DOMoveX(-40, 40);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            transform.DOMoveX(40, 40);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
