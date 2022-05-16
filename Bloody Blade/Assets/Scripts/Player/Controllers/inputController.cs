using UnityEngine;

public abstract class inputController : ScriptableObject
{
    public abstract float retrieveVerticalMoveInput();
    public abstract float retrieveHorizontalMoveInput();
    public abstract bool retrieveDashInput();
    public abstract Vector3 retrieveMousePos();
    public abstract bool retrieveFireInput();
}
