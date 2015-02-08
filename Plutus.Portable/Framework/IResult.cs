using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plutus.Portable.Framework {
    /// <summary>
    /// TODO
    /// </summary>
    public interface IResult {
        /// <summary>
        /// TODO
        /// </summary>
        string Message { get; }
        /// <summary>
        /// TODO
        /// </summary>
        bool Success { get; }
    }
    /// <summary>
    /// TODO
    /// </summary>
    public class SuccessResult : IResult {
        /// <summary>
        /// TODO
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// TODO
        /// </summary>
        public bool Success { get; private set; }


        /// <summary>
        /// TODO
        /// </summary>
        public SuccessResult() { Message = "Success!"; Success = true; }
    }
}
