using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game
{
    public class ResourceLoader<T>
    {
        public delegate void CallBackLoader(IList<T> resource);
        public IEnumerator Load(CallBackLoader callBack, string folder)
        {
            AsyncOperationHandle<IList<T>> handle = Addressables.LoadAssetsAsync<T>(folder, null);

            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                callBack.Invoke(handle.Result);
            }
            else
            {
                Debug.LogError("Не удалось загрузить файлы");
            }

            Addressables.Release(handle);
        }
    }
}
