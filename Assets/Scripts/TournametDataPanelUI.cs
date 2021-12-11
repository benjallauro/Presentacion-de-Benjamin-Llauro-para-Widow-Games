using System.Collections.Generic;
using UnityEngine;
using OVRSimpleJSON;
using System.Collections;

public class TournametDataPanelUI : MonoBehaviour
{
    [SerializeField] public GameObject userInfoDatPrefab;
    public GameObject tournamentsInfoPanelContainer;

    public List<GameObject> dataBlocks;

    #region Public methods
    public void Populate(JSONObject jsonData)
    {
        OrderData(jsonData);
    }

    public UITournametInfoPanel InstanciateDataBlock(GameObject prefab)
    {
        GameObject DataBlock = Instantiate(prefab, tournamentsInfoPanelContainer.transform);
        DataBlock.name = "DataBlock_" + prefab.name;
        dataBlocks.Add(DataBlock);
        return DataBlock.GetComponent<UITournametInfoPanel>();
    }

    public IEnumerator OrderScroll()
    {
        yield return (null);
    }

    public void ClearData()
    {
        dataBlocks.Clear();
        foreach (Transform child in tournamentsInfoPanelContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    #endregion

    #region Private methods
    private void OrderData(JSONObject jsonData)
    {
        int dataSize = jsonData[0].Count;
        for (int i = 0; i < dataSize; i++)
        {
            InstanciateDataBlock(userInfoDatPrefab.gameObject).Populate(
                    jsonData[0][i][1],   // ID
                    jsonData[0][i][0],   // type
                    jsonData[0][i][2][0]);  // attributes
        }
        StartCoroutine(OrderScroll());
    }
    #endregion
}