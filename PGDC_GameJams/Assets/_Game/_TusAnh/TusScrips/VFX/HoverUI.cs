using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

    public class HoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Vector3 originalScale; 
        public float scaleValue;
        public float duration = 0.5f;

        public void Initialize(float scaleValue, float duration)
        {
            this.scaleValue = scaleValue;
            this.duration = duration;
        }

        private void Awake()
        {
            originalScale = transform.localScale;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(originalScale * (1 + scaleValue), duration);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(originalScale, duration);
        }

        public void ChangeValue(float scaleValue, float duration)
        {
            this.scaleValue = scaleValue;
            this.duration = duration;
        }
    }
