using Leopotam.EcsLite;
using TMPro;
using UnityEngine;
using Zenject;

public abstract class EntityScoreUI : MonoBehaviour
{
    protected EcsWorld _world;
    protected TextMeshProUGUI _textMeshPro;

    [Inject]
    public void Construct(EcsWorld ecsWorld)
    {
        _world = ecsWorld;
        _textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        EcsFilter filter = GetFilter();

        foreach (int entity in filter)
        {
            ref Scoreable scoreable = ref _world.Get<Scoreable>(entity);

            _textMeshPro.text = scoreable.Score.ToString();
        }
    }

    protected abstract EcsFilter GetFilter();
}