using Misc;
using UnityEngine;

namespace Entity
{
    public class EnemyControllerSuppress : EnemyController
    {
        #region Protected Internal Fields

        protected internal bool isDeployed;

        #endregion Protected Internal Fields

        #region Private Fields

        [SerializeField] private GameObject _leftBalcony;
        private Transform _leftBalconyTransform;
        [SerializeField] private GameObject _rightBalcony;
        private Transform _rightBalconyTransform;

        private Transform _targetBalcony;
        private Vector3 _targetPosition;

        #endregion Private Fields

        #region Private Methods

        private void ShipMovement()
        {
            //rotate to look at player
            transform.LookAt(_targetPosition);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);

            //move towards player
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

            if (transform.eulerAngles.y < 90)
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 0, transform.eulerAngles.z);
            else
                transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 180, transform.eulerAngles.z);

            transform.Rotate(new Vector3(0, 0, -90));
        }

        private void Start()
        {
            _leftBalcony = GameObject.Find("leftBalcony");
            _rightBalcony = GameObject.Find("rightBalcony");
            _leftBalconyTransform = _leftBalcony.transform;
            _rightBalconyTransform = _rightBalcony.transform;

            float leftDistance = Vector3.Distance(transform.position, _leftBalconyTransform.position);
            float rightDistance = Vector3.Distance(transform.position, _rightBalconyTransform.position);
            _targetBalcony = leftDistance < rightDistance ? _leftBalconyTransform : _rightBalconyTransform;

//            var mesh = _targetBalcony.GetComponent<MeshFilter>().mesh;
//            _targetPosition = GetARandomTreePos(mesh, _targetBalcony.transform);
            var collider = _targetBalcony.GetComponent<BoxCollider>();
            _targetPosition = collider.GetPointInCollider();
        }

        // Update is called once per frame
        private void Update()
        {
            if (!isDeployed)
            {
//                Debug.Log("MovingShip");
//                Debug.Log(string.Format("Target position  = {0}", _targetPosition));

                ShipMovement();
                float distanceTillDeploy = (_targetPosition - transform.position).magnitude;
                if (distanceTillDeploy < 0.1)
                {
                    isDeployed = true;
                    Debug.Log("Ship deployed");
                }
            }
        }

        #endregion Private Methods

        public Vector3 GetARandomTreePos(Mesh mesh, Transform transform)
        {
            Bounds bounds = mesh.bounds;

            float minX = transform.position.x - transform.localScale.x * bounds.size.x * 0.5f;
            float minY = transform.position.y - transform.localScale.y * bounds.size.y * 0.5f;

            return new Vector3(
                Random.Range(minX, -minX),
                Random.Range(minY, -minY),
                transform.position.z
            );
        }
    }
}