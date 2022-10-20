using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScreenWrap : AbstractScreenWrap
{
    public override IScreenWrapBehaviour GetScreenWrapBehaviour()
    {
        return new PortalScreenWrapBehaviour(transform);
    }
}
