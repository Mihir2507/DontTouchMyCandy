using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    private Animator anim;
    //[SerializeField] private Rigidbody player;
    [SerializeField] private FixedJoystick fj; 
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 currentPosition = new Vector3(player.velocity.x, player.velocity.y, player.velocity.z);
        float inputH = fj.Horizontal;
        float inputV = fj.Vertical;
        if(inputH > 0.01f || inputV > 0.01f || inputH < -0.01f || inputV < -0.01f)
            anim.SetBool("isWalking", true);
        else
            anim.SetBool("isWalking", false);
    }
}
