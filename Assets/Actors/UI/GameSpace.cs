using Game.Core;
using Game.Sound;
using UnityEngine;

namespace Game.UI
{
    public class GameSpace : MonoBehaviour
    {
        [SerializeField] private GameObject space;

        IField field;

        public void MakeMove(Move move)
        {
            field.MakeMove(move);
        }

        public void CreateBigField((int, int) fieldsCount, (int, int) fieldsSize)
        {
            BigField bigField;
            bigField = Instantiate(GameAssets.Instance.bigField);
            bigField.transform.SetParent(space.transform, false);
            bigField.InitFields(fieldsCount, fieldsSize, new BigTicTacToeMove());

            ChangeChildScale(space.transform.GetComponent<RectTransform>(), bigField.GetComponent<RectTransform>());

            ApplicationController.Instance.CurrentGame.MoveIsDone += MoveIsDone;
            ApplicationController.Instance.CurrentGame.Win += () => SoundController.Instance.PlaySound(Sounds.win);

            void MoveIsDone()
            {
                bigField.ShowActiveFields((ApplicationController.Instance.CurrentGame as BigTicTacToeLogic).GetActiveFields());
            }

            field = bigField;
        }

        public void CreateClassicField((int, int) fieldsSize)
        {
            Field field;
            field = Instantiate(GameAssets.Instance.field);
            field.transform.SetParent(space.transform, false);
            field.InitCells(fieldsSize, new ClassicMove());

            ApplicationController.Instance.CurrentGame.Win += () => SoundController.Instance.PlaySound(Sounds.win);

            ChangeChildScale(space.transform.GetComponent<RectTransform>(), field.GetComponent<RectTransform>());

            this.field = field;
        }

        public void Clear()
        {
            for (int i = 0; i < space.transform.childCount; i++)
            {
                Destroy(space.transform.GetChild(i).gameObject);
            }
            space.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(1400, 1000);
        }

        void ChangeChildScale(RectTransform parant, RectTransform child)
        {
            Vector2 parantSize = parant.sizeDelta;
            Vector2 childSize = child.sizeDelta;

            float newScale;
            float scaleFromX = parantSize.x / childSize.x;
            float scaleFromY = parantSize.y / childSize.y;
            if (scaleFromX * childSize.y <= parantSize.y)
            {
                if ((scaleFromY * childSize.x <= parantSize.x))
                {
                    newScale = scaleFromX > scaleFromY ? scaleFromX : scaleFromY;
                }
                else
                {
                    newScale = scaleFromX;
                }
            }
            else newScale = scaleFromY;

            child.localScale = new Vector3(newScale, newScale, 1);
            parant.sizeDelta = new Vector2(childSize.x * newScale + 15, childSize.y * newScale + 15);
        }
    }
}
