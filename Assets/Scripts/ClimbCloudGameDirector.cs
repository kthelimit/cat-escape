using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClimbCloudGameDirector : MonoBehaviour
{
    [SerializeField] private Text velocityText;

    public void UpdateVelocityText(Vector2 velocity)
    {
        var velocityX = Mathf.Abs(velocity.x);
        this.velocityText.text = velocityX.ToString();
    }

    //public void UpdateIsJumpingText(Vector2 velocity)
    //{
    //   //벨로시티의 y값을 체크해서 0이고 아니고를 텍스트로 출력해줌.
    //    //bool isJumping = (Mathf.Abs(velocity.y))
    //}
}
