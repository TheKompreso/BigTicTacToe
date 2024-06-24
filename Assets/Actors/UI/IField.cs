using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public interface IField
    {
        public void SetGroupSize(GridLayoutGroup group, (int column, int row) cellsCount, (int column, int row) size)
        {
            group.cellSize = new Vector2(cellsCount.column * size.column, cellsCount.row * size.row);
        }
    }
}
