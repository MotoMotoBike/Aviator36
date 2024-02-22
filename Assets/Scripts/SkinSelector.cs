using UnityEngine;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{
    [SerializeField] private byte totalSkinsCount;
    [SerializeField] private byte selectedSinLocal = 1;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Image imgRenderer;
    [SerializeField] private string basePath;
    void Start()
    {
        selectedSinLocal = (byte)GameData.SkinID;
        VisualizeSkin();
    }
    public void NextSkin()
    {
        selectedSinLocal++;
        if (selectedSinLocal > totalSkinsCount)
        {
            selectedSinLocal = 1;
        }
        VisualizeSkin();
    }
    public void BuySkin(int cost)
    {
        if (GameData.TotalStars < cost)
            return;
        GameData.TotalStars -= cost;
        GameData.SkinID = selectedSinLocal;
    }
    public void PrevSkin()
    {
        selectedSinLocal--;
        if (selectedSinLocal == 0)
        {
            selectedSinLocal = totalSkinsCount;
        }
        VisualizeSkin();
    }
    public void VisualizeSkin()
    {
        if(spriteRenderer != null) spriteRenderer.sprite = Resources.Load<Sprite>(basePath + selectedSinLocal);
        if(imgRenderer != null) imgRenderer.sprite = Resources.Load<Sprite>(basePath + selectedSinLocal);
    }
    
}
