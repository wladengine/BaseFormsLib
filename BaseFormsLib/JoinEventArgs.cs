using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseFormsLib
{
    /// <summary>
    /// delegate for events with Joints
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="jea"></param>
    public delegate void JoinEventHandler(object sender, JoinEventArgs jea);

    /// <summary>
    /// EventArgs with JointPair property for JoinEventDelegate
    /// </summary>
    public class JoinEventArgs : EventArgs
    {
        public JointPair Pair { get; private set; }

        public JoinEventArgs(JointPair jp)
        {
            Pair = jp;
        }
    }
}
