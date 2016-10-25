using UnityEngine;
using System.Collections;

public class CaptionManager : MonoSingleton<CaptionManager>
{
    public string       Title;
    public string       Subtitle;
    public float        TitleDisplaySecond = 3f;
    public float        SubtitleDisplaySecond = 3f;
    public GameObject   TitleObj;
    public GameObject   SubtitleObj;

    private Object obj1;
    private Object obj2;

    public void ShowTitle(string title = null, float displaySecond = 0.001f)
    {
        if (obj1 != null)
        {
            Destroy(obj1);
            obj1 = null;
        }
        if (displaySecond < 0.1f)
            displaySecond = TitleDisplaySecond;
        if (title == null || title.Length == 0)
            title = Title;
        GUIText text = TitleObj.GetComponent<GUIText>();
        text.text = title;
        obj1 = Instantiate(TitleObj, new Vector3(0.5f, 0.7f), Quaternion.identity);
        Destroy(obj1, displaySecond);
    }

    public void ShowSubtitle(string subtitle = null, float displaySecond = 0.001f)
    {
        if (obj2 != null)
        {
            Destroy(obj2);
            obj2 = null;
        }
        if (displaySecond < 0.1f)
            displaySecond = TitleDisplaySecond;
        if (subtitle == null || subtitle.Length == 0)
            subtitle = Subtitle;
        GUIText text = SubtitleObj.GetComponent<GUIText>();
        text.text = subtitle;
        obj2 = Instantiate(SubtitleObj, new Vector3(0.5f, 0.5f), Quaternion.identity);
        Destroy(obj2, displaySecond);
    }
}
