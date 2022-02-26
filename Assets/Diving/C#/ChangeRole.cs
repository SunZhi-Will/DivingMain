using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRole : MonoBehaviour
{
    public GameObject[] g_RoleP1;
    public GameObject[] g_RoleP2;
    [SerializeField]
    [Header("P1角色")]
    public GameObject g_P1;
    [SerializeField]
    [Header("P2角色")]
    public GameObject g_P2;

    [SerializeField]
    [Header("獲勝畫面")]
    public GameObject m_Win_UI;

    void Start()
    {
        Change(g_RoleP1, true);
        Change(g_RoleP2, false);
    }
    public void Change(GameObject[] _Role, bool _boolP1){
        GameObject _P;
        if(_boolP1){
            _P = g_P1;
        }else{
            _P = g_P2;
        }
        foreach (var item in _Role)
        {
            GameObject _go = Instantiate(_P, item.transform.position, item.transform.rotation);
            _go.transform.parent = item.transform;
            _go.transform.localScale = item.transform.GetChild(0).gameObject.transform.localScale;
            if(_go.GetComponent<Animator>() == null){
                _go.AddComponent<Animator>() ;
            }
            _go.GetComponent<Animator>().runtimeAnimatorController = item.transform.GetChild(0).gameObject.GetComponent<Animator>().runtimeAnimatorController;
            _go.GetComponent<Animator>().avatar = item.transform.GetChild(0).gameObject.GetComponent<Animator>().avatar;
            

            Destroy(item.transform.GetChild(0).gameObject);
            
        }
    }
    
    public void Win(int _P1Win, int _P2Win){ //_P1Win P1獲勝分數 _P1Win P2獲勝分數
        Debug.Log("跳水結束遊戲");
        m_Win_UI.SetActive(true);
        if(_P1Win == _P2Win){
            Debug.Log("跳水平手");
        }else{
            m_Win_UI.GetComponent<WinningMethod>().Winner(_P1Win > _P2Win);
        }
        
    }
    
}
