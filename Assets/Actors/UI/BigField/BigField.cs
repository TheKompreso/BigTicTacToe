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

        public void MakeMove(Move move)
        {
            BigTicTacToeMove bigMove = move as BigTicTacToeMove;
            m_Fields[bigMove.field.column, bigMove.field.row].MakeMove(bigMove);
        }

        public void InitFields((int column, int row) fieldsCount, (int column, int row) fieldsSize, BigTicTacToeMove moveTemplate)
        {
            (this as IField).SetGroupSize(GetComponent<GridLayoutGroup>(), fieldsSize, (70, 70));
            this.GetComponent<RectTransform>().sizeDelta =
                new Vector2(
                    fieldsCount.column * fieldsSize.column * 70 + fieldsCount.column * 10 + 20,
                    fieldsCount.row * fieldsSize.row * 70 + fieldsCount.row * 10 + 20);

            size = fieldsCount;
            m_Fields = new Field[fieldsCount.column, fieldsCount.row];
            for (int j = 0; j < fieldsCount.row; j++)
            {
                for (int i = 0; i < fieldsCount.column; i++)
                {
                    m_Fields[i, j] = Instantiate(GameAssets.Instance.field);
                    m_Fields[i, j].transform.SetParent(this.transform, false);
                    m_Fields[i, j].InitCells((fieldsSize.column, fieldsSize.row), moveTemplate.DeepClone().SetField((i, j)));
                }
            }
        }

        public void ShowActiveFields(((int column, int row)[] fields, bool active) space)
        {
            for (int j = 0; j < size.row; j++)
            {
                for (int i = 0; i < size.column; i++)
                {
                    m_Fields[i, j].SetActive(!space.active);
                }
            }
            for (int f = 0; f < space.fields.Length; f++)
            {
                m_Fields[space.fields[f].column, space.fields[f].row].SetActive(space.active);
            }
        }
    }
}
