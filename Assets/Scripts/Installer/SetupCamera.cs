using UnityEngine;

namespace Game
{
    public class SetupCamera : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private Vector2 size;

        private void Start()
        {
            float targetAspect = size.x / size.y;
            float windowAspect = (float)Screen.width / (float)Screen.height;
            float scaleHeight = windowAspect / targetAspect;

            Rect rect = cam.rect;

            if (scaleHeight < 1.0f)
            {
                rect.width = 1.0f;
                rect.height = scaleHeight;
                rect.x = 0;
                rect.y = (1.0f - scaleHeight) / 2.0f;
            }
            else
            {
                float scaleWidth = 2.0f / scaleHeight;
                rect.width = scaleWidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scaleWidth) / 2.0f;
                rect.y = 0;
            }
            cam.rect = rect;
        }
    }
}
