using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapController
{
    private IScreenWrapBehaviour _screenWrapBehaviour;    
    private static float _leftBorder, _rightBorder, _bottomBorder, _topBorder;
    private static float _offset = 0.03f;

    public ScreenWrapController(IScreenWrapBehaviour screenWrapBehaviour)
    {       
        var camera = Camera.main;
        var camDistance = -camera.transform.position.z;
        _leftBorder = camera.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, camDistance)).x;
        _rightBorder = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, camDistance)).x;
        _bottomBorder = camera.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, camDistance)).y;
        _topBorder = camera.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, camDistance)).y;
        _screenWrapBehaviour = screenWrapBehaviour;
    }

    public void Tick()
    {
        _screenWrapBehaviour?.CheckScreen();
    }

    public static Vector2 GetWrappedPosition(Vector2 currentPos)
    {
        if (currentPos.x > _rightBorder)
        {
            currentPos.x = _leftBorder + _offset;
        }
        else if(currentPos.x < _leftBorder)
        {
            currentPos.x = _rightBorder - _offset;
        }

        if (currentPos.y < _bottomBorder)
        {
            currentPos.y = _topBorder - _offset;
        }
        else if(currentPos.y > _topBorder)
        {
            currentPos.y = _bottomBorder + _offset;
        }

        return currentPos;
    }

    public static bool IsOffScreen(Vector2 position)
    {
        return position.x < _leftBorder || position.x > _rightBorder || 
            position.y > _topBorder || position.y < _bottomBorder;
    }


}
