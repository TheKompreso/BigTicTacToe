using Game.Core;
using System;
using UnityEngine;

namespace Game.UI
{
    public class GameSpace : MonoBehaviour
    {
        [SerializeField] private GameObject space;

        Field fields;
        BigField bigFields;

        public void CreateBigField((int, int) fieldsCount, (int, int) fieldsSize)
        {
            bigFields = Instantiate(GameAssets.Instance.bigField);
            bigFields.transform.SetParent(transform, false);
            bigFields.InitFields(fieldsCount, fieldsSize, new BigTicTacToeMove());

            ChangeChildScale(space.transform.GetComponent<RectTransform>(), bigFields.GetComponent<RectTransform>());

            ApplicationController.Instance.CurrentGame.MoveIsDone += MoveIsDone;

            void MoveIsDone()
            {
                bigFields.ShowActiveFields((ApplicationController.Instance.CurrentGame as BigTicTacToeLogic).GetActiveFields());
            }
        }

        public void CreateClassicField((int, int) fieldsSize)
        {
            fields = Instantiate(GameAssets.Instance.field);
            fields.transform.SetParent(space.transform, false);
            fields.InitCells(fieldsSize, new ClassicMove());

            ChangeChildScale(space.transform.GetComponent<RectTransform>(), fields.GetComponent<RectTransform>());
        }

        public void Clear()
        {
            for (int i = 0; i < space.transform.childCount; i++)
            {
                Destroy(space.transform.GetChild(i).gameObject);
            }
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
            parant.sizeDelta = new Vector2(childSize.x * newScale, childSize.y * newScale);
        }
    }
}
