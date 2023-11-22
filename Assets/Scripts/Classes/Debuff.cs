using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    public class Debuff : MonoBehaviour
    {
        public alignmentName Name;
        public typeOfAlignment AlignmentType;
        public object Picture;
        public object Duration;
        public bool Disspellable;
    }
}
