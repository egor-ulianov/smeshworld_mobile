using System.Collections;
using System.Collections.Generic;
using UlianovsStudio.Smeshworld.Views;

namespace UlianovsStudio.Smeshworld.Presenters
{
    public class StartMenuPresenter
    {
        #region Data members

        private StartMenuView _view;

        #endregion //Data members

        #region Constructors

        public StartMenuPresenter(StartMenuView startMenuView)
        {
            _view = startMenuView;
            AssignEvents();
        }

        #endregion //Constructors

        #region Public methods

        public void Dispose()
        {
            UnassignEvents();
        }

        #endregion //Public methods

        #region Private methods

        private void AssignEvents()
        {
            _view.AchievementsButtonClicked += OnAchievementsButtonClicked;
            _view.SettingsButtonClicked += OnSettingsButtonClicked;
        }

        private void UnassignEvents()
        {
            _view.AchievementsButtonClicked -= OnAchievementsButtonClicked;
            _view.SettingsButtonClicked -= OnSettingsButtonClicked;
        }

        private void OnAchievementsButtonClicked(object sender, bool e)
        {
            if (e)
            {
                _view.ActivateAchievementsPanel();
            }
            else
            {
                _view.DeactivateAchievementsPanel();
            }
        }

        private void OnSettingsButtonClicked(object sender, bool e)
        {
            if (e)
            {
                _view.ActivateSettingsPanel();
            }
            else
            {
                _view.DeactivateSettingsPanel();
            }
        }

        #endregion //Private methods
    }
}
