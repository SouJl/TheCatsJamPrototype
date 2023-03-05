using Shooter.Player;
using Shooter.Tool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Shooter.UI
{
    internal class HealthBarController
    {
        private readonly string _viewPath = @"Prefabs/UI/Health/HealthBarView";

        private readonly IHealthBarView _view;

        public HealthBarController(Transform placeforUI, IPlayer player) 
        {
            _view = LoadView(placeforUI);
            _view.Init(player.HealthPoints);
        }

        private IHealthBarView LoadView(Transform placeforUI)
        {
            GameObject objectView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), placeforUI, false);         
            return objectView.GetComponent<HealthBarView>();
        }
    }
}
