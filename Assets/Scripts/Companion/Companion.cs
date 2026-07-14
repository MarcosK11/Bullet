using UnityEngine;

public class Companion : MonoBehaviour
{
    protected Transform player;

    public virtual void Initialize(Transform player)
    {
        this.player = player;
    }
}