using Leopotam.EcsLite;
using TMPro;
using UnityEngine;
using Zenject;

public class EnemyScoreUI : MonoBehaviour
{
    private EcsWorld _world;
    private TextMeshProUGUI _textMeshPro;

    [Inject]
    public void Construct(EcsWorld ecsWorld)
    {
        _world = ecsWorld;
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        EcsFilter filter = _world.Filter<EnemyMarker>().Inc<Scoreable>().End();

        foreach (int entity in filter)
        {
            ref Scoreable scoreable = ref _world.Get<Scoreable>(entity);

            _textMeshPro.text = scoreable.Score.ToString();
        }
    }
}