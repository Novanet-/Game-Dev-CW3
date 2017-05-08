using UnityEngine;

public class DeathController : MonoBehaviour
{
    #region Public Fields

    public bool CanFall;
    public bool IsPlayer;

    #endregion Public Fields

    #region Public Methods

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Die(GameObject self)
    {
        Destroy(self);
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Bullet"))
        {
            if (coll.GetComponent<EnemyLaserController>() && IsPlayer || coll.GetComponent<LaserController>() && !IsPlayer)
            {
                if (IsPlayer)
                    Die();
                else
                {
                    Die(GetComponentInParent<EnemyMovementController>().gameObject);
                }

                Die(coll.gameObject);
            }
        }
        else if (CanFall && coll.CompareTag("Hole"))
        {
            Die(GameObject.Find("Player"));
        }
        else if (IsPlayer && coll.CompareTag("Enemy"))
        {
            Die(GameObject.Find("Player"));
            Die(coll.GetComponentInParent<EnemyMovementController>().gameObject);
        }
    }

    #endregion Public Methods
}