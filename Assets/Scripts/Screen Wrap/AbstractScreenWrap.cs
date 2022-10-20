using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractScreenWrap : MonoBehaviour
{
    protected ScreenWrapController _screenWrapController;
    protected bool _isInit;

    public virtual void Awake()
    {
        Init();
    }

    public virtual void Init()
    {
        if (_isInit) return;
        var screenWrapBehaviour = GetScreenWrapBehaviour();
        _screenWrapController = new ScreenWrapController(screenWrapBehaviour);
        _isInit = true;
    }

    public virtual void Update()
    {
        if (!_isInit) Init();

        _screenWrapController?.Tick();
    }

    public abstract IScreenWrapBehaviour GetScreenWrapBehaviour();
}
