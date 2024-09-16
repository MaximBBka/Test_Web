using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D;

namespace Game
{
    public class LoadSprites : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] _spriteRenderer;
        [SerializeField] private string _folder;

        public void StartLoad()
        {
            StartCoroutine(LoadSprite());
        }

        private IEnumerator LoadSprite()
        {
            AsyncOperationHandle<SpriteAtlas> handle = Addressables.LoadAssetAsync<SpriteAtlas>(_folder);

            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Sprite[] sprites = new Sprite[handle.Result.spriteCount];
                handle.Result.GetSprites(sprites);
                for (int i = 0; i < _spriteRenderer.Length; i++)
                {
                    _spriteRenderer[i].sprite = sprites[i];
                }
            }
            else
            {
                Debug.LogError("Не удалось загрузить спрайты");
            }

            // Освобождаем ресурсы, если больше не нужны
            Addressables.Release(handle);
        }
    }
}
