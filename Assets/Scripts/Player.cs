using TMPro;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _interactable;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _mouseSens = 1f;

    [Header("UI")]
    [SerializeField] private TMP_Text _interactText;

    private float _xRotation = 0f;
    private RaycastHit _hitInfo;
    private CharacterController _characterController;
    private GameManager _gameManager;

    private GameObject _currentPickup = null;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (_gameManager.isPlaying)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 move = (transform.right * x + transform.forward * z).normalized;
            move = move * _speed * (Input.GetKeyDown(KeyCode.LeftShift) ? 2f : 1f) * Time.deltaTime;

            _characterController.Move(move);

            if (Input.GetMouseButtonUp(0) && _currentPickup)
            {
                _currentPickup.GetComponent<Objective>().OnPickup();
            }
        }
    }

    private void LateUpdate()
    {
        if (_gameManager.isPlaying)
        {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSens;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSens;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -80f, 70f);

            _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out _hitInfo, 7.0f, _interactable))
        {
            Debug.DrawRay(_camera.transform.position, _camera.transform.forward * 7.0f, Color.red, 5f, true);
            if (_hitInfo.transform.gameObject.tag == "Coin")
            {
                _interactText.text = "Press Left Click to pickup coin";
                _currentPickup = _hitInfo.transform.gameObject;
            }
        }
        else
        {
            _interactText.text = "";
            _currentPickup = null;
        }
    }
}
