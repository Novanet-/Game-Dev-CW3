using com.kleberswf.lib.core;
using UnityEngine;

namespace Level
{
    public class DifficultyController : Singleton<DifficultyController>
    {
        #region Public Fields

        public float DifficultyLevel;

        #endregion Public Fields

        #region Private Fields

        private float _difficultyAdjusmentInc;
        [SerializeField] private float _interval;
        private float _timer;

        #endregion Private Fields

        #region Public Methods

        public void UpdateDifficulty(int enemiesKilledSinceLastInc, int secondsSinceLastHit, int gameSecondsElapsed)
        {
            _difficultyAdjusmentInc = CalculateDifficultyAdjusmentInc(enemiesKilledSinceLastInc, secondsSinceLastHit, gameSecondsElapsed);
        }

        #endregion Public Methods

        #region Private Methods

        private float CalculateDifficultyAdjusmentInc(int enemiesKilledSinceLastInc, int secondsSinceLastHit, int gameSecondsElapsed)
        {
            //TODO: Replace with an actual heuristic
            return enemiesKilledSinceLastInc + secondsSinceLastHit + gameSecondsElapsed;
        }

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer < _interval) return;

            _timer -= _interval;
            DifficultyLevel += _difficultyAdjusmentInc;
            Debug.Log("Memes in the difficulty controller");
        }

        #endregion Private Methods
    }
}