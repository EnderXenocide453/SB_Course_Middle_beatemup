using UnityEngine;

public partial class CharacterMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;

    private Vector2 _direction;

    public void MoveToDirection(Vector3 direction, float speedMultiplier = 1)
    {
        _direction = direction;

        Vector3 newPosition = transform.position + new Vector3(_direction.x, 0, _direction.y) * speed * speedMultiplier;

        transform.LookAt(newPosition);
        transform.position = newPosition;
    }
}
