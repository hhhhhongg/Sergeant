using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPanel : MonoBehaviour
{

    public GameObject Winpanel;
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            Winpanel.SetActive(true);
            this.gameObject.SetActive(false);
        }
        
    }

    public void ChackEndAnim()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("EndAnim"))
        {
            Winpanel.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
