using UnityEngine;

public sealed class PlayerMove : ShipMove
{
    protected override bool IsMove()
    {
        return Input.GetKey(KeyCode.W);  
    }
}
