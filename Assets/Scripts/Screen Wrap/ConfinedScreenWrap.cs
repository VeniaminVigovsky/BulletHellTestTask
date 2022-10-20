using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfinedScreenWrap : AbstractScreenWrap
{
    public override IScreenWrapBehaviour GetScreenWrapBehaviour()
    {
        return new DisableOffscreenScreenWrapBehaviour(gameObject);
    }
}
