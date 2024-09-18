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
        private AsyncOperationHandle<IList<T>>? _handle;
        public IEnumerator Load(CallBackLoader callBack, string folder)
        {
            _handle = Addressables.LoadAssetsAsync<T>(folder, null);

            yield return _handle;

            if (_handle.Value.Status == AsyncOperationStatus.Succeeded)
            {
                callBack.Invoke(_handle.Value.Result);
            }
            else
            {
                Debug.LogError("Не удалось загрузить файлы");
            }
        }
        public void UnLoad()
        {
            if (_handle.HasValue)
            {
                Addressables.Release(_handle.Value);
            }
        }
    }
}
