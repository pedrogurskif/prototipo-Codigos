using UnityEngine;
using TMPro;

public class HudManager : MonoBehaviour
{
    [SerializeField] TMP_Text hpText;
    public void updateLives(int value)
    {
        hpText.text = value.ToString();
    }
}
