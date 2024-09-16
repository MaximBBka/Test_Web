using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace Game
{
    public class SetupSprites : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] _spriteRenderer;
        [SerializeField] private string _folder;
        private ResourceLoader<SpriteAtlas> loader = new ResourceLoader<SpriteAtlas>();

        public void StartLoad()
        {
            StartCoroutine(loader.Load(Setup, _folder));
        }
        private void Setup(IList<SpriteAtlas> atlas)
        {
            Sprite[] sprites = new Sprite[atlas[0].spriteCount];
            atlas[0].GetSprites(sprites);
            for (int i = 0; i < _spriteRenderer.Length; i++)
            {
                _spriteRenderer[i].sprite = sprites[i];
            }
        }
    }
}
