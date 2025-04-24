using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LemonInc.Core.Utilities.Ui
{
    /*public class UiFeedbacks : MonoBehaviour, 
        IPointerEnterHandler, 
        IPointerExitHandler, 
        IPointerDownHandler, 
        IPointerUpHandler
    {
        [Title("Hover")]
        [SerializeField] private TweenParams<Vector3> _scaleOnHover = new(Vector3.one, Vector3.one * 1.1f, 0.1f);
        [SerializeField] private TweenParams<Color> _colorOnHover = new(Color.white, new Color(.9f, .9f, .9f), 0.1f);
        
        [Title("Click")]
        [SerializeField] private TweenParams<Vector3> _scaleOnClick = new(Vector3.one, Vector3.one * .9f, 0.1f);
        [SerializeField] private TweenParams<Color> _colorOnClick = new(Color.white, new Color(.8f, .8f, .8f), 0.1f);
        
        private Graphic _graphics;

        protected void Awake()
        {
            _graphics = GetComponent<Graphic>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _scaleOnHover.Play(transform, Tween.Scale);
            _colorOnHover.Play(_graphics, Tween.Color);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _scaleOnHover.Reverse(transform, Tween.Scale);
            _colorOnHover.Reverse(_graphics, Tween.Color);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _scaleOnClick.Play(transform, Tween.Scale);
            _colorOnClick.Play(_graphics, Tween.Color);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _scaleOnClick.Reverse(transform, Tween.Scale);
            _colorOnClick.Reverse(_graphics, Tween.Color);
        }
    }*/
}