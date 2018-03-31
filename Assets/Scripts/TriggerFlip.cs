using UnityEngine;
using System.Collections;

public class TriggerFlip : MonoBehaviour {

    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void sendAutoTriggerFlip()
    {
        ani.SetTrigger("Flip1");
    }

}
