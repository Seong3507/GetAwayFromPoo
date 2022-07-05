using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;       // 결제를 하기 위함
using UnityEngine.Events;

public class IAPTest : MonoBehaviour
{

    public IAPButton btnRemove;
    bool value;

    private void LoadData()
    {
        value = Convert.ToBoolean(PlayerPrefs.GetInt("Ad"));
        UIManager.Instance.AdRemove = value;
    }
    private void Start()
    {

        this.btnRemove.onPurchaseComplete.AddListener(new UnityAction<Product>((product) =>
        {
            value = UIManager.Instance.AdRemove = true;
            //UIManager.Instance.HideAd(value);
            PlayerPrefs.SetInt("Ad", 1);
            
            Debug.LogFormat("[광고 제거] 획득 : ", product.transactionID);
            StartCoroutine(UIManager.Instance.HideAd(value));
        }));

        this.btnRemove.onPurchaseFailed.AddListener(new UnityAction<Product, PurchaseFailureReason>((product, reason) =>
        {
            value = UIManager.Instance.AdRemove = false;
            //UIManager.Instance.HideAd(value);
            Debug.LogFormat("[광고 제거] 실패 : {0} , {1}", product.transactionID, reason);
        }));
    }

    private void OnEnable()
    {
        LoadData();

    }
}
