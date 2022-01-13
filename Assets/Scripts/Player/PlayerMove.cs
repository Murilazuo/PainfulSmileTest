using UnityEngine;

public sealed class PlayerMove : Move
{
    override protected bool IsMove()
    {
        return Input.GetKey(KeyCode.W);  
    }
}
