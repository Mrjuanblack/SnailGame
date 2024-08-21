using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesMenuAnimation : MonoBehaviour
{
    private bool isOpen = false;

    [SerializeField]
    private Button button;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();

        this.button.onClick.AddListener(() =>
        {
            if(isOpen)
            {
                animator.SetTrigger("Close");
                isOpen = false;
            }
            else
            {
                animator.SetTrigger("Open");
                isOpen = true;
            }
        });
    }
}
