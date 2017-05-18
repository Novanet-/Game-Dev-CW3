using System.Collections;
using Sound;
using UnityEngine;

namespace Entity
{
    public class PlayerDeathController : DeathController
    {
        #region Public Fields

        public float respawnDelay = 1;
        public int lives = 3;

        #endregion Public Fields

        #region Private Fields

        private Collider2D _coll;
        private PlayerMovementController _movement;
        private PlayerFireController _firing;
        private SpriteRenderer _sprite;
        private Level.BackgroundManager _backgroundManager;
        private UI.UIController _uiController;
        private GameOverUI _gameOverUI;
        private bool _gameOver = false;

        #endregion Private Fields

        #region Public Methods

        public override void Die(GameObject self)
        {
            if (Dead) return;

            if (self.tag == "Bullet") {
                Destroy(self.gameObject);
                return;
            }

            Dead = true;
            RemoveLife();

            SoundController.Instance.PlaySingle(Sounds.Instance.PlayerDeath, 0.5f);
            Animator explosion = Instantiate(deathAnim, self.transform);
            explosion.transform.localPosition = new Vector3(0, 0, 0);

            Destroy(explosion.gameObject, explosionTime);

            _movement.SetCanMove(false);
            _firing.SetCanShoot(false);
            _sprite.enabled = false;
            _coll.enabled = false;

            StartCoroutine(Respawn());
        }

        public override void Fall(GameObject self)
        {
            _backgroundManager.playerFall();
            SoundController.Instance.PlaySingle(Sounds.Instance.PlayerFall, 0.15f);

            base.Fall(self);
        }

        internal bool isDead()
        {
            return Dead;
        }

        public void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            _coll = GetComponent<Collider2D>();
            _movement = GetComponent<PlayerMovementController>();
            _firing = GetComponent<PlayerFireController>();
            _backgroundManager = GameObject.Find("RowManager").GetComponent<Level.BackgroundManager>();
            _uiController = GameObject.Find("UICanvas").GetComponent<UI.UIController>();
            _gameOverUI = GameObject.Find("GameOverCanvas").GetComponent<GameOverUI>();

            health = healthStart;
            _uiController.UpdateHealth(health);

            if (GameObject.Find("StateProperties").GetComponent<Misc.StateProperties>().isTimeAttack) {
                lives = -1;
            }
            _uiController.UpdateLives(lives);
        }

        public override void Hit() {
            base.Hit();

            _uiController.UpdateHealth(health);
        }

        public void AddLife() {
            lives++;

            StartCoroutine(_uiController.DisplayTextForTime("Life gained", _uiController._lblPowerupGained, _uiController._powerupGainDisplayTime));
            _uiController.UpdateLives(lives);
        }

        public void RemoveLife() {
            lives--;

            _uiController.UpdateLives(lives);

            if (lives == 0) {
                GameOver();
            }
        }

        public void GameOver() {
            _gameOver = true;

            _movement.SetCanMove(false);
            _firing.SetCanShoot(false);
            _sprite.enabled = false;
            _coll.enabled = false;

            Dead = true;

            _gameOverUI.Show();
        }

        #endregion Public Methods

        #region Private Methods

        private IEnumerator Respawn()
        {
            yield return new WaitForSeconds(respawnDelay);

            if (!_gameOver) {

                transform.position = new Vector3(0, -6, 0);
                transform.localPosition = new Vector3(0, -6, 0);

                health = healthStart;
                _uiController.UpdateHealth(health);

                _movement.SetCanMove(true);
                _firing.SetCanShoot(true);

                for (int i = 0; i < 6; i++) {
                    _sprite.enabled = true;
                    yield return new WaitForSeconds(0.1f);
                    _sprite.enabled = false;
                    yield return new WaitForSeconds(0.1f);
                }

                _sprite.enabled = true;
                _coll.enabled = true;

                Dead = false;
            }
        }

        #endregion Private Methods
    }
}