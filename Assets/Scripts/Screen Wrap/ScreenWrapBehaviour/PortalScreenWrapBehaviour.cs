using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScreenWrapBehaviour : IScreenWrapBehaviour
{
    private Transform _selfT;

    public PortalScreenWrapBehaviour(Transform selfT)
    {
        _selfT = selfT;
    }

    public void CheckScreen()
    {
        if (_selfT == null) return;
        if (!ScreenWrapController.IsOffScreen(_selfT.position)) return;

        _selfT.position = ScreenWrapController.GetWrappedPosition(_selfT.position);
    }
}
