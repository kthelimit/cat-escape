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
    //   //���ν�Ƽ�� y���� üũ�ؼ� 0�̰� �ƴϰ� �ؽ�Ʈ�� �������.
    //    //bool isJumping = (Mathf.Abs(velocity.y))
    //}
}
