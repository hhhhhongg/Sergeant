using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPanel : MonoBehaviour
{

    public GameObject Winpanel;
    public Animator animator;
    public Shild shild;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        shild.Collider.enabled = true;
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {         
            Winpanel.SetActive(true);
            Time.timeScale = 0f;
            this.gameObject.SetActive(false);
        }
        
    }   
}
