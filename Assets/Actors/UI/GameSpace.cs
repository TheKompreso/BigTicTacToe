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
            float parantMinSide = parantSize.x > parantSize.y ? parantSize.y : parantSize.x;
            Vector2 childSize = bigFields[0].GetComponent<RectTransform>().sizeDelta;
            float childMinSide = childSize.x > childSize.y ? childSize.y : childSize.x;

            float newScale = parantMinSide / childMinSide;
            bigFields[0].GetComponent<RectTransform>().localScale = new Vector3(newScale, newScale, 1);


        }
    }
}
