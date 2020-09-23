using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Shop
    {
        private int _coin;
        private Item[] inventory;

        public Shop()
        {
            inventory = new Item[3];
            _coin = 150;
        }

        public Shop(int coin, int inventorySize)
        {
            inventory = new Item[inventorySize];
            _coin = coin;
        }
        

        public bool Sell(Player player, int shopIndex, int playerIndex)
        {
            return player.Buy(inventory[shopIndex], playerIndex);
            
        }

    }
}
