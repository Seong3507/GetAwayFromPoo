using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing.Extension;
using UnityEngine;
using UnityEngine.Purchasing;
using System.Collections.ObjectModel;

public class MyStore : IStore
{
    private IStoreCallback callback;
    public void Initialize(IStoreCallback callback)
    {
        // 스토어가 Unity IAP에 비동기적으로 통신하는 데
        // 사용하는 IStoreCallback 메서드를 통해 Unity IAP에 의해 호출
        this.callback = callback;
    }

    public void FinishTransaction(ProductDefinition product, string transactionId)
    {
        // 구매가 끝났을 때
    }

    public void Purchase(ProductDefinition product, string developerPayload)
    {
        // 구매를 시작하고 콜백한다.
        // 구매 성공 또는 실패를 콜백하게 된다.

    }

    public void RetrieveProducts(ReadOnlyCollection<ProductDefinition> products)
    {
        // 제품을 검색해서 정보를 가져오고 콜백을 호출함
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
