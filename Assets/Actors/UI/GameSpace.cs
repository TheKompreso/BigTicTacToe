using Game.Core;
using System;
using UnityEngine;

namespace Game.UI
{
    public class GameSpace : MonoBehaviour
    {
        public static GameSpace Instance { get; private set; }

        Field[] fields;
        BigField[] bigFields;
        private void Awake()
        {
            Instance = this;
        }

        public void CreateBigField((int, int) fieldsCount, (int, int) fieldsSize)
        {
            bigFields = new BigField[1];
            bigFields[0] = Instantiate(GameAssets.Instance.bigField);
            bigFields[0].transform.SetParent(transform, false);
            bigFields[0].InitFields(fieldsCount, fieldsSize, new BigTicTacToeMove());

            Vector2 parantSize = transform.GetComponent<RectTransform>().sizeDelta;
            Vector2 childSize = bigFields[0].GetComponent<RectTransform>().sizeDelta;

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

            bigFields[0].GetComponent<RectTransform>().localScale = new Vector3(newScale, newScale, 1);
            this.GetComponent<RectTransform>().sizeDelta =
                new Vector2(childSize.x*newScale, childSize.y*newScale);

            ApplicationController.Instance.CurrentGame.MoveIsDone += MoveIsDone;

            void MoveIsDone()
            {
                bigFields[0].ShowActiveFields((ApplicationController.Instance.CurrentGame as BigTicTacToeLogic).GetActiveFields());
            }
        }

    }
}
