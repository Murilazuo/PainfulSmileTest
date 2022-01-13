using UnityEngine;

public sealed class PlayerMove : Move
{
    protected override bool isMove()
    {
        return Input.GetKey(KeyCode.W);  
    }
}
