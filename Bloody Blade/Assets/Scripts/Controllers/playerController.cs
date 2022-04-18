using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="playerController", menuName ="inputController/playerController")]
public class playerController : inputController
{
    public override float retrieveHorizontalMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public override float retrieveVerticalMoveInput()
    {
        return Input.GetAxisRaw("Vertical");
    }
}
