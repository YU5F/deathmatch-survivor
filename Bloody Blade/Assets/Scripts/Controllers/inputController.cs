using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class inputController : ScriptableObject
{
    public abstract float retrieveVerticalMoveInput();
    public abstract float retrieveHorizontalMoveInput();
    public abstract bool retrieveDashInput();
}
