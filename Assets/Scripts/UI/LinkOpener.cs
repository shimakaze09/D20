#region

using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#endregion

[RequireComponent(typeof(TMP_Text))]
public class LinkOpener : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent<string> onClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        var text = GetComponent<TMP_Text>();
        var linkIndex = TMP_TextUtilities.FindIntersectingLink(text, eventData.position, null);
        if (linkIndex != -1)
        {
            var linkInfo = text.textInfo.linkInfo[linkIndex];
            onClick.Invoke(linkInfo.GetLinkID());
        }
    }
}