using System;
using System.Collections;
using System.Collections.Generic;

namespace Nonogram
{
    public class Blocks : IEnumerable
    {
        public IEnumerator GetEnumerator() => _blockList.GetEnumerator();

        public Blocks(List<BlockData> options)
        {
            foreach (BlockData item in options)
            {
                _blockList.Add(new Block(item));
            }

        }

        public void addBlock(BlockData blockInfo)
        {
            _blockList.Add(new Block(blockInfo));    
        }


        public Block getBlock(int index)
        {
            if (index >= 0 && index < _blockList.Count)
            {
                return _blockList[index];
            }
            else
            {
                return null;
            }

        }

        public int getBlockCount()
        {
            return _blockList.Count;
        }

        private List<Block> _blockList = new List<Block>();
    }
}
