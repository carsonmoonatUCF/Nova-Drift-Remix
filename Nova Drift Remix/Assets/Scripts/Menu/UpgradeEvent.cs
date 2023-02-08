using UnityEngine;
using UnityEngine.Events;

public class UpgradeEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent myTrigger;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            myTrigger.Invoke();
        }
    }
}
