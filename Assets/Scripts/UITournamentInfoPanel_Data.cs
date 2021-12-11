using UnityEngine;
using UnityEngine.UI;

public class UITournamentInfoPanel_Data : MonoBehaviour, UITournametInfoPanel
{
    public Text typeTxt;
    public Text IDTxt;
    public Text attributesTxt;
    public void Populate(string ID, string type, string attributes)
    {
        typeTxt.text = type;
        IDTxt.text = ID;
        attributes = attributes.Replace('T', ' ');
        attributesTxt.text = attributes.Replace('Z', ' ');
    }
}
