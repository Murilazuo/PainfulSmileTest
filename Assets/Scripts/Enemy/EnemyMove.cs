using UnityEngine;

public sealed class EnemyMove : Move
{
    protected override bool isMove()
    {
        return Input.GetKey(KeyCode.W);
    }
}
