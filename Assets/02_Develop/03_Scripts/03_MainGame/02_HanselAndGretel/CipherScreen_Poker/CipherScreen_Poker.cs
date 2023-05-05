using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameManager;
using CommonlyUsed;
using DesignPattern;
using UnityEngine.EventSystems;
using NJsonLoader;
using UnityEngine.UI;

public class CipherScreen_Poker : MonoBehaviour, IUpdateManager
{
    private enum TileNumber
    {
        Tile1,
        Tile2,
        Tile3,
        Tile4,
    }

    [SerializeField]
    RectTransform[] tilePos;

    [SerializeField]
    GameObject[] tiles;

    [SerializeField]
    RayCastScriipt_HanselAndGretel hansel;

    [SerializeField]
    Text[] texts;

    [SerializeField]
    Image item4;

    Vector2 startPos,pressPos;

    TileNumber TILES = TileNumber.Tile1;

    bool check = true;
    bool checkClear = false;
    bool justOnce = true;
    Vector2[] initialValues;

    void Start() 
    {
        UpdateManager.Instance.Bind(this, FrameControl.ON);

        initialValues = new Vector2[tiles.Length];

        texts[0].enabled = true;
        texts[1].enabled = false;
        texts[2].enabled = false;

        for (int i = 0; i < tilePos.Length; i++)
        {
            initialValues[i] = tilePos[i].anchoredPosition;
        }
    }

    public void OnUpdate(double deltaTime)
    {
        if (!this.gameObject.activeInHierarchy) return;

        if (checkClear) return;

        State(TILES);

        Decipher();
    }

    
    public void TileClick1()
    {
        TILES = TileNumber.Tile1;   
    }

    public void TileClick2()
    {
        TILES = TileNumber.Tile2;
    }

    public void TileClick3()
    {
        TILES = TileNumber.Tile3;
    }

    public void TileClick4()
    {
        TILES = TileNumber.Tile4;
    }

    private void Decipher()
    {
        //クッキーの画像が中心にそろったら
        if (tilePos[0].anchoredPosition.x != -125f || tilePos[0].anchoredPosition.y != -90f) return;
        if (tilePos[1].anchoredPosition.x !=  175f || tilePos[1].anchoredPosition.y != 210f) return; 
        if (tilePos[2].anchoredPosition.x !=  175f || tilePos[2].anchoredPosition.y != -90f) return;
        if (tilePos[3].anchoredPosition.x != -125f || tilePos[3].anchoredPosition.y != 210f) return;

        //暗号が解読された
        if(justOnce)
        {
            justOnce = false;
            checkClear = true;

            StartCoroutine(Scenario());
        }

    }

    private IEnumerator Scenario()
    {
        texts[0].enabled = false;
        texts[1].enabled = false;
        texts[2].enabled = true;

        yield return new WaitForSeconds(1f);

        hansel.ScenarioItemGet(ScenarioSceneHansel.pokerGet,item4, "Assets/LoadingDatas/ScenarioDatas/HanselAndGretel/Black.png");
    }
    private bool WhereIsTile(TileNumber tile)
    {
        bool tile1 = false;
        bool tile2 = false;
        bool tile3 = false;
        bool tile4 = false;

        tile1 = tilePos[(int)tile].anchoredPosition.x < 20f && tilePos[(int)tile].anchoredPosition.y > 70f;
              
        tile2 = tilePos[(int)tile].anchoredPosition.x > 40f && tilePos[(int)tile].anchoredPosition.y > 175f;
              
        tile3 = tilePos[(int)tile].anchoredPosition.x < 20f && tilePos[(int)tile].anchoredPosition.y < 50f;
               
        tile4 = tilePos[(int)tile].anchoredPosition.x > 55f && tilePos[(int)tile].anchoredPosition.y < 50f;

        if (tile1)
        {
            tilePos[(int)tile].anchoredPosition = initialValues[0];

            return true;
        }

        if (tile2)
        {
            tilePos[(int)tile].anchoredPosition = initialValues[1];

            return true;
        }

        if (tile3)
        {
            tilePos[(int)tile].anchoredPosition = initialValues[2];
            return true;
        }

        if (tile4)
        {
/*            Debug.Log("Tile4");
            Debug.Log(tile4Index);
            Vector2 temp = tilePos[tile4Index].anchoredPosition;
            tilePos[tile4Index].anchoredPosition = initialValues[tile4Index];
            tilePos[(int)tile].anchoredPosition = temp;
            tile4Index = (int)tile;
*/
            tilePos[(int)tile].anchoredPosition = initialValues[3];
            return true;
        }

        return false;
    }

    private void State(TileNumber tile)
    {

        if (MobileInput.InputState(TouchPhase.Ended))
        {
            if(WhereIsTile(tile))
            {

            }
            else
            {
                tilePos[(int)tile].anchoredPosition = startPos;
            }

            tiles[(int)tile].transform.SetSiblingIndex(2+(int)tile);
            check = true;

            texts[0].enabled = false;
            texts[1].enabled = true;
            texts[2].enabled = false;

        }

        if (MobileInput.InputState(TouchPhase.Began))
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch.position);

            pressPos = touch.position;
            startPos = tilePos[(int)tile].anchoredPosition;
        }

        if (MobileInput.InputState(TouchPhase.Moved))
        {
            Debug.Log("通ってる");

            Touch touch = Input.GetTouch(0);

            Vector2 pos = touch.position - pressPos;

            tiles[(int)tile].transform.SetAsLastSibling();
            tilePos[(int)tile].anchoredPosition = FrameGuard(startPos + pos);

        }
    }

    private Vector2 FrameGuard(Vector2 pos)
    {
        if(pos.x < -125f)
        {
            pos.x = -125f;
        }

        if(pos.x > 175f)
        {
            pos.x = 175f;
        }

        if(pos.y > 210f)
        {
            pos.y = 210f;
        }

        if(pos.y < -90f)
        {
            pos.y = -90f;
        }

        return pos;
    }

    private void TilesChange(TileNumber tile)
    {
        if(tile == TileNumber.Tile1)
        {
            
        }
    }
}
    