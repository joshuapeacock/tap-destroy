using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Peacock.IO
{
    public class Player : MonoBehaviour, System.IComparable<Player>
    {
        public bool isPlayer;

        public int CompareTo(Player other)
        {
            throw new System.NotImplementedException();
        }

        public int GetScore()
        {
            throw new System.NotImplementedException();
        }
    }
}
