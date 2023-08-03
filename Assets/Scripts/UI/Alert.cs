using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface IAlert : IDependency<IAlert>
{
}

public class Alert : MonoBehaviour, IAlert
{
    [SerializeField] private RectTransform rootPanel;
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private Button button;
}