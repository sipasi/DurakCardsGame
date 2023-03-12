using UnityEngine;

namespace Framework.Shared.UI.SafeArea
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class SafeAreaAdapter : MonoBehaviour
    {
        [SerializeField] private RectTransform[] transforms;

        private Rect lastSaveArea;

        private void OnRectTransformDimensionsChange()
        {
            if (transforms == null || transforms.Length == 0)
            {
                return;
            }

            var area = Screen.safeArea;

            if (lastSaveArea.Equals(area))
            {
                return;
            }

            lastSaveArea = area;

            foreach (var transform in transforms)
            {
                SetAncors(transform, area);
            }
        }

        private static void SetAncors(RectTransform transform, Rect area)
        {
            Vector2 resolution = new(Screen.width, Screen.height);

            transform.anchorMin = new Vector2
            {
                x = area.xMin / resolution.x,
                y = area.yMin / resolution.y,
            };

            transform.anchorMax = new Vector2
            {
                x = area.xMax / resolution.x,
                y = area.yMax / resolution.y,
            };
        }
    }
}
