using UnityEngine;

public class SimplePlayer : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _mouseSens = 1f;

    private float _xRotation = 0f;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 move = (transform.right * x + transform.forward * z).normalized;
            move = move * _speed * (Input.GetKeyDown(KeyCode.LeftShift) ? 2f : 1f) * Time.deltaTime;

            _characterController.Move(move);
        }
    }

    private void LateUpdate()
    {
        {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSens;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSens;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -80f, 70f);

            _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }
}
