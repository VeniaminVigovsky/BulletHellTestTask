using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOffscreenScreenWrapBehaviour : IScreenWrapBehaviour
{
    private GameObject _self;

    public DisableOffscreenScreenWrapBehaviour(GameObject self)
    {
        _self = self;
    }

    public void CheckScreen()
    {
        if (_self == null) return;

        if (ScreenWrapController.IsOffScreen(_self.transform.position))
        {
            _self.SetActive(false);
        }
    }
}
