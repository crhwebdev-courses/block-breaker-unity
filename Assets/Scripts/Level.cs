using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int breakableBlocks; // Serialized for debugging purposes

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
   
}
