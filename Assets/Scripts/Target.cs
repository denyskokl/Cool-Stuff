using UnityEngine;


public class Target : MonoBehaviour
{
    private Vector3 _currentPosition;
    private Vector3 _previousLocation;
    private Vector3 _currentLocation;
    private Rigidbody _rigidbody;
    private Vector3 _difference;
    public float topSpeed = 10;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void OnMouseDown()
    {
        _currentPosition = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        _previousLocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _currentPosition.z);
    }
   
    void OnMouseDrag()
    {
        _currentLocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _currentPosition.z);
        _difference = _currentLocation - _previousLocation;
        _previousLocation = _currentLocation;
    }

    public void OnMouseUp()
    {
        if (_rigidbody.velocity.magnitude > topSpeed)
            _difference = _rigidbody.velocity.normalized * topSpeed;
    }

    public void FixedUpdate()
    {
        //або 
        //_rigidbody.velocity = _difference;
        _rigidbody.AddForce(_difference);
    }
}
