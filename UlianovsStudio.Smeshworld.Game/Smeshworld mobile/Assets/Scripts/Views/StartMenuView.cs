using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UlianovsStudio.Smeshworld.Presenters;

namespace UlianovsStudio.Smeshworld.Views
{
    public class StartMenuView : MonoBehaviour
    {
        #region Unity serialized fields

        public GameObject PlayButton;
        public GameObject AchievementsButton;
        public GameObject SettingsButton;
        public GameObject ExitButton;

        public GameObject AchievementsPanel;
        public GameObject SettingPanel;

        public Image AchievementsBackground;
        public Image SettingsBackground;

        #endregion //Unity serialized fields

        #region Event handlers

        public event EventHandler<bool> PlayButtonClicked;
        public event EventHandler<bool> AchievementsButtonClicked;
        public event EventHandler<bool> SettingsButtonClicked;
        public event EventHandler<bool> ExitButtonClicked;

        #endregion //Event handlers

        #region Data members

        private bool _achievementsStatus;
        private bool _settingsStatus;
        private StartMenuPresenter _presenter;

        #endregion //Data members

        #region Unity methods

        public void Awake()
        {
            _achievementsStatus = false;
            _settingsStatus = false;
            _presenter = new StartMenuPresenter(this);
        }

        public void OnDestroy()
        {
            _presenter.Dispose();
        }

        #endregion //Unity methods

        #region Public methods

        public void OnPlayButtonClicked()
        {
            PlayButtonClicked?.Invoke(this, true);
        }

        public void OnAchievementsButtonClicked()
        {
            AchievementsButtonClicked?.Invoke(this, !_achievementsStatus);
            Debug.Log("Achiv " + _achievementsStatus);
        }

        public void OnSettingsButtonClicked()
        {
            SettingsButtonClicked?.Invoke(this, !_settingsStatus);
            Debug.Log("Settings " + _settingsStatus);
        }

        public void OnExitButtonClicked()
        {
            ExitButtonClicked?.Invoke(this, true);
        }

        public void ActivateAchievementsPanel()
        {
            DeactivateSettingsPanel();
            AchievementsBackground.color = new Color(255, 255, 255, (100.0f/255));
            AchievementsPanel.SetActive(true);
            _achievementsStatus = true;
        }

        public void ActivateSettingsPanel()
        {
            DeactivateAchievementsPanel();
            SettingsBackground.color = new Color(255, 255, 255, (100.0f/255));
            SettingPanel.SetActive(true);
            _settingsStatus = true;
        }

        public void DeactivateAchievementsPanel()
        {
            AchievementsBackground.color = new Color(255, 255, 255, (33.0f/255));
            AchievementsPanel.SetActive(false);
            _achievementsStatus = false;
        }

        public void DeactivateSettingsPanel()
        {
            SettingsBackground.color = new Color(255, 255, 255, (33.0f/255));
            SettingPanel.SetActive(false);
            _settingsStatus = false;
        }

        #endregion //Public methods
    }
}
