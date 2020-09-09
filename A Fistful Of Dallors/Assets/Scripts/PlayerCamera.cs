using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCamera : MonoBehaviour
{
    public float rotateSpeed = 1f;
    public float scrollSpeed = 200f;
    public float smoothRotate = 5f;
    public float smoothScale = 10f;
    public Transform pivot;

    private Vector3 targetPos;
    [System.Serializable]
    public class SphericalCoordinates
    {
        public float _radius, _azimuth, _elevation;

        public float radius
        {
            get { return _radius; }
            private set
            {
                _radius = Mathf.Clamp(value, _minRadius, _maxRadius);
            }
        }

        public float azimuth
        {
            get { return _azimuth; }
            private set
            {
                _azimuth = Mathf.Repeat(value, _maxAzimuth - _minAzimuth);
            }
        }

        public float elevation
        {
            get { return _elevation; }
            private set
            {
                _elevation = Mathf.Clamp(value, _minElevation, _maxElevation);
            }
        }

        public float _minRadius = .5f;
        public float _maxRadius = 3f;

        public float minAzimuth = 0f;
        private float _minAzimuth;

        public float maxAzimuth = 360f;
        private float _maxAzimuth;

        public float minElevation = -35f;
        private float _minElevation;

        public float maxElevation = 85f;
        private float _maxElevation;

        public SphericalCoordinates() { }

        public SphericalCoordinates(Vector3 cartesianCoordinate)
        {
            _minAzimuth = Mathf.Deg2Rad * minAzimuth;
            _maxAzimuth = Mathf.Deg2Rad * maxAzimuth;

            _minElevation = Mathf.Deg2Rad * minElevation;
            _maxElevation = Mathf.Deg2Rad * maxElevation;

            radius = cartesianCoordinate.magnitude;
            azimuth = Mathf.Atan2(cartesianCoordinate.z, cartesianCoordinate.x);
            elevation = Mathf.Asin(cartesianCoordinate.y / radius);
        }

        public Vector3 toCartesian
        {
            get
            {
                float t = radius * Mathf.Cos(elevation);
                return new Vector3(
                    t * Mathf.Cos(azimuth), 
                    radius * Mathf.Sin(elevation), 
                    t * Mathf.Sin(azimuth));
            }
        }

        public SphericalCoordinates Rotate(float newAzimuth, float newElevation, float x)
        {
            azimuth += newAzimuth;
            elevation += newElevation;
            radius += x;
            
            return this;
        }

        public SphericalCoordinates TranslateRadius(float x)
        {
            radius += x;
            return this;
        }
      
    }

    public SphericalCoordinates sphericalCoordinates;


    void Start()
    {
        sphericalCoordinates = new SphericalCoordinates(transform.position);
        transform.position = sphericalCoordinates.toCartesian + pivot.position;
        targetPos = transform.position;
    }

    void Update()
    {
        float kh, kv, mh, mv, h, v;
        //kh kv는 이후 조이스틱으로 변경할 예정 일단 마우스 값만 이용
       // kh = Input.GetAxis("Horizontal");
       // kv = Input.GetAxis("Vertical");

        //bool anyMouseButton = Input.GetMouseButton(0) | Input.GetMouseButton(1) | Input.GetMouseButton(2);
        // mh = anyMouseButton ? Input.GetAxis("Mouse X") : 0f;
        // mv = anyMouseButton ? Input.GetAxis("Mouse Y") : 0f;
        h = Input.GetAxis("Mouse X");
        v = Input.GetAxis("Mouse Y");
        // h = kh * kh > mh * mh ? kh : mh;
        // v = kv * kv > mv * mv ? kv : mv;
        //if (h * h > Mathf.Epsilon || v * v > Mathf.Epsilon)
        //{



        //}

        RaycastHit hit;
        float rad_val = 0f;
        //Debug.DrawRay(transform.position, transform.forward * sphericalCoordinates.radius, Color.red);
        //Debug.DrawRay(transform.position, transform.forward * -.5f, Color.blue);
        if (Physics.Raycast(transform.position, transform.forward, out hit, sphericalCoordinates.radius))
        {
            float dis = Vector3.Distance(transform.position, hit.point);
            rad_val = -(dis + 0.5f);
        }
        else if (!Physics.Raycast(transform.position, transform.forward * -1f, out hit, .5f))
        {
            var targetPos = sphericalCoordinates.TranslateRadius(0.01f * scrollSpeed * Time.deltaTime).toCartesian + pivot.position;
            rad_val = 0.01f * scrollSpeed * Time.deltaTime;
        }
        targetPos = sphericalCoordinates.Rotate(
            h * rotateSpeed * Time.deltaTime * -1,
            v * rotateSpeed * Time.deltaTime * -1,
            rad_val).toCartesian + pivot.position;
       
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothRotate * Time.deltaTime);

        


        float sw = -Input.GetAxis("Mouse ScrollWheel");
        if (sw * sw > Mathf.Epsilon)
        {
            transform.position = sphericalCoordinates.TranslateRadius(sw * Time.deltaTime * scrollSpeed).toCartesian + pivot.position;
        }
        transform.LookAt(pivot.position);
    }

  
}


