using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Classes
{
    public class BaseAlignment
    {
        public alignmentName Name;
        public typeOfAlignment AlignmentType;
        public object Picture;
        public object Duration;
        public bool Disspellable;
    }

    public enum typeOfAlignment : int
    {
       Buff = 0,
       Debuff = 1,
    }

    public enum alignmentName : int
    {
        Healing = 0,
        Poision = 1,
    }
}
