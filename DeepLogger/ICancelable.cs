using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLogger
{
    /// <summary>
    /// A internal interface for cancelable event args
    /// <see cref="EventArgs"/>
    /// </summary>
    internal interface ICancelable
    {
        /// <summary>
        /// Value to decide to cancel the event
        /// </summary>
        bool Cancel { get; set; }
    }
}