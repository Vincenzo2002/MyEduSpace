using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WhiteboardMarker : MonoBehaviour
{
    [SerializeField] private Transform _tip;
    [SerializeField] private int _penSize = 5;

    private Renderer _renderer;
    private Color[] _colors;
    private float _tipHeight;

    private RaycastHit _touch;
    private Whiteboard _whiteboard;
    private Vector2 _touchPos, _lastTouchPos;
    private bool _touchedLastFrame;
    private Quaternion _lastTouchRot;

    // colore corrente usato sia dal tip che dal pennello
    private Color _currentColor;

    void Start()
    {
        _renderer = _tip.GetComponent<Renderer>();

        _currentColor = _renderer.material.color;
        UpdateColorArray(_currentColor);

        _tipHeight = _tip.localScale.y;
    }

    void Update()
    {
        // se qualcuno ha cambiato il materiale / colore del tip, aggiorna l'array
        if (_renderer.material.color != _currentColor)
        {
            _currentColor = _renderer.material.color;
            UpdateColorArray(_currentColor);
        }

        Draw();
    }

    // aggiorna l’array di colori usato per disegnare
    void UpdateColorArray(Color c)
    {
        _colors = Enumerable.Repeat(c, _penSize * _penSize).ToArray();
    }

    public void SetInkColor(Color c)
    {
        _currentColor = c;
        _renderer.material.color = c;
        UpdateColorArray(c);
    }

    private void Draw()
    {
        if (Physics.Raycast(_tip.position, transform.up, out _touch, _tipHeight))
        {
            if (_touch.transform.CompareTag("Whiteboard"))
            {
                var hitBoard = _touch.transform.GetComponent<Whiteboard>();
                if (_whiteboard != hitBoard)
                {
                    _whiteboard = hitBoard;
                    _touchedLastFrame = false;
                }

                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);

                var x = (int)(_touchPos.x * _whiteboard.textureSize.x - (_penSize / 2));
                var y = (int)(_touchPos.y * _whiteboard.textureSize.y - (_penSize / 2));

                if (y < 0 || y > _whiteboard.textureSize.y || x < 0 || x > _whiteboard.textureSize.x)
                    return;

                if (_touchedLastFrame)
                {
                    _whiteboard.texture.SetPixels(x, y, _penSize, _penSize, _colors);

                    for (float f = 0.01f; f < 1.00f; f += 0.01f)
                    {
                        var lerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var lerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        _whiteboard.texture.SetPixels(lerpX, lerpY, _penSize, _penSize, _colors);
                    }

                    transform.rotation = _lastTouchRot;
                    _whiteboard.texture.Apply();
                }

                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                _touchedLastFrame = true;
                return;
            }
        }

        _whiteboard = null;
        _touchedLastFrame = false;
    }
}
