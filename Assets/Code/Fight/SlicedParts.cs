using UnityEngine;


namespace Code.Fight{
    internal class SlicedParts{
        private readonly GameObject _source;

        private GameObject _first;
        private GameObject _second;
        private GameObject _third;
        private GameObject _fourth;

        public SlicedParts(GameObject source){
            _source = source;

            Texture2D texture = _source.GetComponent<SpriteRenderer>().sprite.texture;

            var rect1 = new Rect(0, 0, texture.width / 2, texture.height / 2);
            var rect2 = new Rect(texture.width / 2, texture.width / 2, texture.width / 2, texture.height / 2);
            var rect3 = new Rect(0, texture.height / 2, texture.width / 2, texture.height / 2);
            var rect4 = new Rect(texture.width / 2, 0, texture.width / 2, texture.height / 2);

            _first = GameObject.Instantiate(_source, _source.transform, true);
            _second = GameObject.Instantiate(_first, _source.transform, true);
            _third = GameObject.Instantiate(_second, _source.transform, true);
            _fourth = GameObject.Instantiate(_third, _source.transform, true);

            _first.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, rect1, Vector2.one);
            _second.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, rect2, Vector2.zero);
            _third.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, rect3, Vector2.right);
            _fourth.GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, rect4, Vector2.up);
        
            _first.AddComponent<BoxCollider2D>();
            _second.AddComponent<BoxCollider2D>();
            _third.AddComponent<BoxCollider2D>();
            _fourth.AddComponent<BoxCollider2D>();
            
            _first.AddComponent<Rigidbody2D>();
            _second.AddComponent<Rigidbody2D>();
            _third.AddComponent<Rigidbody2D>();
            _fourth.AddComponent<Rigidbody2D>();

            _first.SetActive(false);
            _second.SetActive(false);
            _third.SetActive(false);
            _fourth.SetActive(false);
        }

        public void AddForceToParts(){
            _first.transform.SetParent(null);
            _second.transform.SetParent(null);
            _third.transform.SetParent(null);
            _fourth.transform.SetParent(null);

            _first.SetActive(true);
            _second.SetActive(true);
            _third.SetActive(true);
            _fourth.SetActive(true);

            _first.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
            _second.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 20, ForceMode2D.Impulse);
            _third.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 50, ForceMode2D.Impulse);
            _fourth.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 80, ForceMode2D.Impulse);
        }

        public void Destroy(){
            GameObject.Destroy(_first);
            GameObject.Destroy(_second);
            GameObject.Destroy(_third);
            GameObject.Destroy(_fourth);
        }
    }
}