using UnityEngine;

namespace Game
{
    public class ButtonPlayGame : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private SetupSprites _setupSprites;
        [SerializeField] private SetupAudio _setupAudio;

        private void Start()
        {
            #if UNITY_WEBGL
            Application.ExternalEval($"console.log('{(Application.isMobilePlatform ? "Mobile" : "Desktop")}');");
            #endif
        }
        public void Click()
        {
            _animator.SetBool("anim", true);
            _setupSprites.StartLoad();
            _setupAudio.StartLoad();
        }
    }
}
