using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {
    #region Private Fields

    private Text _txtScore;
    private CanvasGroup _GameOverCanvas;
    private UI.UIController _uiController;

    #endregion Private Fields

    #region Public Methods

    public void Show() {
        _txtScore.text = _uiController.GetScore();

        _GameOverCanvas.alpha = 1;
        _GameOverCanvas.blocksRaycasts = true;
        var retryButton = GameObject.Find("btnRetry").GetComponent<Button>();
        retryButton.Select();
    }

    public void Restart() {
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void MainMenu() {
        SceneManager.LoadSceneAsync("StartScreen");
    }

    #endregion Public Methods

    #region Private Methods

    void Start() {
        _txtScore = GameObject.Find("txtFinalScore").GetComponent<Text>();
        _GameOverCanvas = GetComponent<CanvasGroup>();
        _uiController = GameObject.Find("UICanvas").GetComponent<UI.UIController>();

        _GameOverCanvas.alpha = 0;
        _GameOverCanvas.blocksRaycasts = false;
    }

    #endregion Private Methods
}
