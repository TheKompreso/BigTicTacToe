using Game.Core;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class BigField : MonoBehaviour, IField
    {
        Field[,] m_Fields;
        (int column, int row) size;

        public void InitFields((int column, int row) fieldsCount, (int column, int row) fieldsSize, BigTicTacToeMove moveTemplate)
        {
            (this as IField).SetGroupSize(GetComponent<GridLayoutGroup>(), fieldsSize, (70, 70));
            this.GetComponent<RectTransform>().sizeDelta = 
                new Vector2(
                    fieldsCount.column * fieldsSize.column * 80 + 30, 
                    fieldsCount.row * fieldsSize.row* 80 + 30);

            size = fieldsCount;
            m_Fields = new Field[fieldsCount.column, fieldsCount.row];
            for (int i = 0; i < fieldsCount.column; i++)
            {
                for (int j = 0; j < fieldsCount.row; j++)
                {
                    m_Fields[i, j] = Instantiate(GameAssets.Instance.field);
                    m_Fields[i, j].transform.SetParent(this.transform, false);
                    m_Fields[i, j].InitCells(moveTemplate.DeepClone().SetField((i, j)), (fieldsSize.column, fieldsSize.row));
                }
            }
        }

        private void ShowActiveFields((int column, int row)[] fields, bool active)
        {
            for (int i = 0; i < size.column; i++)
            {
                for (int j = 0; j < size.row; j++)
                {
                    m_Fields[i, j].SetActive(!active);
                }
            }
            for (int f = 0; f < fields.Length; f++)
            {
                m_Fields[fields[f].column, fields[f].row].SetActive(active);
            }
        }
    }
}
