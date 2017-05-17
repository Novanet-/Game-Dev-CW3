using UnityEngine;

namespace Entity
{
    public class EnemyController : MonoBehaviour
    {
        #region Public Fields

        public float speed = 10;
        public int ScoreValue = 10;

        #endregion Public Fields

        #region Protected Fields

        protected GameObject _player;

        #endregion Private Fields

        #region Protected Methods

        // Use this for initialization
        private void Start()
        {
            _player = GameObject.Find("Player");
        }

        // Update is called once per frame
        private void Update()
        {
            if (GetComponentInChildren<SpriteRenderer>() == null)
            {
                Destroy(gameObject);
            }
            if (_player != null && !_player.GetComponent<PlayerDeathController>().isDead())
            {
                //rotate to look at player
                transform.LookAt(_player.transform.position);
                transform.Rotate(new Vector3(0, -90, 0), Space.Self);

                //move towards player
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

                if (transform.eulerAngles.y < 90)
                    transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 0, transform.eulerAngles.z);
                else
                    transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 180, transform.eulerAngles.z);

                transform.Rotate(new Vector3(0, 0, -90));
            }
            else
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }

        #endregion Private Methods
    }
}