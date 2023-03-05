using Shooter.Controllers;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] float _speed;

    Camera _camera;
    Vector2 _newCharacterPosition;
    bool _needMoveTowards;
    PauseController _pauseController;

    public void Init(PauseController pauseController)
    {
        _camera = Camera.main;
        _pauseController = pauseController;
    }

    void Update()
    {
        if (_pauseController.isPaused)
            return;

        _newCharacterPosition = transform.position;

        float verticalAxis = Input.GetAxis("Vertical");
        bool needChangeVerticalPosition = verticalAxis != 0 && IsVertical();
        if (needChangeVerticalPosition)
            _newCharacterPosition += Vector2.up * verticalAxis;

        float horizontalAxis = Input.GetAxis("Horizontal");
        bool needChangeHorizontalPosition = horizontalAxis != 0 && IsHorizontal();
        if (needChangeHorizontalPosition)
            _newCharacterPosition += Vector2.right * horizontalAxis;

        if (needChangeVerticalPosition || needChangeHorizontalPosition)
        {
            Vector2 position = transform.position;
            position = Vector2.MoveTowards(position, _newCharacterPosition, _speed * Time.deltaTime);
            transform.position = GetClampedByScreenPosition(position);
        }

        Vector3 diff = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation - 90);
    }

    Vector2 GetClampedByScreenPosition(Vector2 position)
    {
        Vector2 minScreenBounds = _camera.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 maxScreenBounds = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        return new Vector2(
            Mathf.Clamp(position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1),
            Mathf.Clamp(position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1));
    }

    bool IsHorizontal()
    {
        return Input.GetKey(KeyCode.D) ||
               Input.GetKey(KeyCode.RightArrow) ||
               Input.GetKey(KeyCode.A) ||
               Input.GetKey(KeyCode.LeftArrow);
    }

    bool IsVertical()
    {
        return Input.GetKey(KeyCode.W) ||
               Input.GetKey(KeyCode.UpArrow) ||
               Input.GetKey(KeyCode.S) ||
               Input.GetKey(KeyCode.DownArrow);
    }
}
