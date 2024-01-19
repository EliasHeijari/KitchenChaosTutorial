using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    [SerializeField] private ContainerCounter containerCounter;
    private const string animTriggerName = "OpenClose";
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        containerCounter.OnCounterObjectGrabbed += ContainerCounter_OnCounterObjectGrabbed;
    }

    private void ContainerCounter_OnCounterObjectGrabbed(object sender, System.EventArgs e)
    {
        animator.SetTrigger(animTriggerName);
    }
}
