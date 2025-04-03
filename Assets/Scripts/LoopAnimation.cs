using UnityEngine;

public class LoopAnimation : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime >= 1 && !anim.IsInTransition(0))
        {
            anim.Play(stateInfo.fullPathHash, 0, 0f);
        }
    }
}
