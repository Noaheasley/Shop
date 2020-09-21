using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private int _coin;
        public Player _name;
        private Item[] _inventory;
        private Item _currentItem;

        public Player()
        {
            _inventory = new Item[3];
            _coin = 150;
        }
        public void InitalizePlayer()
        {
            _coin = 150;
        }

        public bool Buy(Item item, int itemIndex)
        {

            if (_coin >= item.cost)
            {
                _inventory[itemIndex] = item;
                return true;
            }
            return false;
        }

        public Item[] GetInventory()
        {
            return _inventory;
        }

        
        public void AddItem(Item item, int index)
        {
            _inventory[index] = item;
        }

        public void KeepItem(int itemIndex)
        {
            if (Contains(itemIndex))
            {
                _currentItem = _inventory[itemIndex];
            }
        }
        public bool Contains(int itemIndex)
        {
            if (itemIndex > 0 && itemIndex < _inventory.Length)
            {
                return true;
            }
            return false;
        }


    }
}
