using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


//[System.Serializable]
//public class MyAssetReference : AssetReferenceT<GameObject>
//{
//    public MyAssetReference(string guid) : base(guid)
//    {
//    }
//}
public class Addressable_Manager : MonoBehaviour
{
    [SerializeField] AssetReferenceT<GameObject> m_Cube;
    [SerializeField] AssetReferenceT<AudioClip> m_Clip;
    [SerializeField] AssetReferenceT<Mesh> m_mesh;
    
    GameObject m_loadedCube;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadAsset();
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            UnloadAsset();
        }
    }

    private void LoadAsset()
    {
        m_Cube.LoadAssetAsync().Completed += OnAssetLoaded;
        //Addressables.LoadAssetAsync()
        //Addressables.LoadAssetsAsync()
    }
    private void UnloadAsset()
    {
        Destroy(m_loadedCube);
        m_Cube.ReleaseAsset();
    }

    private void OnAssetLoaded(AsyncOperationHandle<GameObject> a_operation)
    {
        if(a_operation.Status == AsyncOperationStatus.Succeeded)
        {
            m_loadedCube = Instantiate(a_operation.Result);
        }
        else
        {
            Debug.LogError("Could not load Asset cube");
        }
    }
}
