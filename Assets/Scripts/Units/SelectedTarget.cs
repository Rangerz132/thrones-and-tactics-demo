using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedTarget : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void PlaySelectAnimation()
    {
        animator.SetTrigger("Select");
    }

    public void PlayUnselectAnimation()
    {
        animator.SetTrigger("Unselect");
    }
}
