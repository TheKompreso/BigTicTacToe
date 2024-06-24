using Game.Core;
using UnityEngine;

namespace Game.UI
{
    public class BigField : MonoBehaviour
    {
        [SerializeField] int column_length;
        [SerializeField] int row_length;
        [Space]
        [SerializeField] int column_fieldsize;
        [SerializeField] int row_fieldsize;

        Field[] m_Fields;

        private void Awake()
        {
            InitFields(new BigTicTacToeMove());
        }

        private void InitFields(BigTicTacToeMove moveTemplate)
        {
            m_Fields = new Field[column_length * row_length];
            for (int i = 0; i < m_Fields.Length; i++)
            {
                m_Fields[i] = Instantiate(GameAssets.Instance.field);
                m_Fields[i].transform.SetParent(this.transform, false);
                m_Fields[i].InitCells(moveTemplate.DeepClone().SetField((i % column_length, i / column_length)), (column_fieldsize, row_fieldsize));
            }
        }
    }
}
