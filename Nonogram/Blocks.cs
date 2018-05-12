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

        public Blocks()
        {
            //empty list
        }

        public void AddBlock(BlockData blockInfo)
        {
            _blockList.Add(new Block(blockInfo));    
        }

        public void AddBlock(Block block)
        {
            _blockList.Add(block);
        }

        public Block GetBlock(int index)
        {
            if (index >= 0 && index < _blockList.Count)
            {
                return _blockList[index];
            }
            return null;
          
        }

        public Block RemoveBlock(int index)
        {
            if (index >= 0 && index < _blockList.Count)
            {
                Block selected = GetBlock(index);
                _blockList.RemoveAt(index);
                return selected;
            }
            return null;
            
        }

        public void RemoveAll()
        {
            _blockList.Clear();
        }

        public int GetBlockCount()
        {
            return _blockList.Count;
        }

        public int GetBlockLength()
        {
            if (_blockList.Count == 0) { return 0; }
            return (_blockList[_blockList.Count - 1].BlockStart + _blockList[_blockList.Count-1].BlockLength-(_blockList[0].BlockStart ));
        }

        private List<Block> _blockList = new List<Block>();
    }
}
