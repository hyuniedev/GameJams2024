using UnityEngine;
using UnityEngine.UI;

namespace _Game.Scripts.GameSystem
{
    public class Scroller : MonoBehaviour
    {
        [SerializeField] private RawImage _img;
        [SerializeField] private float _x, _y;
        [SerializeField] private float speed;
        void Update()
        {
            _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x,_y) * Time.deltaTime * speed,_img.uvRect.size);               
        }
    }
    
}