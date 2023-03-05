using UnityEngine;

namespace Shooter.UI
{
    internal interface IScoreConfig
    {
        int ScoreAmount { get; }
    }

    [CreateAssetMenu(fileName = nameof(ScoreConfig),
        menuName = "Configs/Score/" + nameof(ScoreConfig))]
    internal class ScoreConfig : ScriptableObject, IScoreConfig
    {
        [field: SerializeField] public int ScoreAmount { get; private set; }
    }
}
