using UnityEngine;

namespace Shooter.UI
{
    internal interface IScoreConfig
    {
        int ScoreAmount { get; }
        
        float ScoreResetTime { get; }
    }

    [CreateAssetMenu(fileName = nameof(ScoreConfig),
        menuName = "Configs/Score/" + nameof(ScoreConfig))]
    internal class ScoreConfig : ScriptableObject, IScoreConfig
    {
        [field: SerializeField] public int ScoreAmount { get; private set; }

        [field: Header("Score Multiply Settings")]
        [field: SerializeField] public float ScoreResetTime { get; private set; } = 1f;
    }
}
