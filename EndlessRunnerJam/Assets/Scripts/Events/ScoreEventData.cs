using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Events
{
    [System.Serializable]
    internal class ScoreEventData
    {
        public ScoreEventData(double points, bool isCritical)
        {
            Points = points;
            IsCritical = isCritical;
        }
        public double Points;
        public bool IsCritical;

    }
}
