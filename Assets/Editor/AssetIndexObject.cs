using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Editor
{
    [Serializable]
    class AssetIndexObject : ScriptableObject
    {
        public Dictionary<string, string> AssetToPathIndex; 
    }
}
