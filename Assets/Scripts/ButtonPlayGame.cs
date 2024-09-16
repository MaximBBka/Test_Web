using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class ButtonPlayGame : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private LoadSprites _loadSprites;

        public void Click()
        {
            _animator.SetBool("anim", true);
            _loadSprites.StartLoad();
        }
    }
}
