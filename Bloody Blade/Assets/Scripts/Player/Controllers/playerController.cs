using UnityEngine;

[CreateAssetMenu(fileName ="playerController", menuName ="inputController/playerController")]
public class playerController : inputController
{
    public override bool retrieveDashInput()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public override float retrieveHorizontalMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public override float retrieveVerticalMoveInput()
    {
        return Input.GetAxisRaw("Vertical");
    }

    public override Vector3 retrieveMousePos()
    {
        return Input.mousePosition;
    }

    public override bool retrieveFireInput()
    {
        return Input.GetMouseButtonDown(0);
    }
}
