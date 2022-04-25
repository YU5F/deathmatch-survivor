using UnityEngine;

[CreateAssetMenu(fileName = "AIController", menuName = "inputController/AIController")]
public class AIController : inputController
{
    public override bool retrieveDashInput()
    {
        return true;
    }

    public override float retrieveHorizontalMoveInput()
    {
        return 1f;
    }

    public override Vector3 retrieveMousePos()
    {
        return Vector3.zero;
    }

    public override float retrieveVerticalMoveInput()
    {
        return 1f;
    }
}
