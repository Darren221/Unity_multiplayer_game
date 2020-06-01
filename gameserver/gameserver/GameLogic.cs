using System;
using System.Collections.Generic;
using System.Text;

namespace gameserver
{
    class GameLogic
    {
        public static void Update(int _id = 99)
        {
            if (_id != 99){
            foreach (Client _client in Server.clients.Values)
            {
                if (_client.player != null)
                {
                    
                    _client.player.Update();
                }
            }

            ThreadManager.UpdateMain();
            }
        }
    }
}
