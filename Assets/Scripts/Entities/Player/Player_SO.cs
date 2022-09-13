using UnityEngine;

[CreateAssetMenu(fileName = "new Player_SO", menuName = "Entities/Player")]
public class Player_SO : Entity_SO
{
    public InputComponent inputComponent;
    public Moveable moveable;
    public PositionLimitation moveLimit;
}