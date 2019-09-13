using BLL.Interface.Interfaces;
using System;

namespace BLL.Interface.Entities.Helper
{
    /// <summary>
    /// Generate account ID.
    /// </summary>
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        /// <summary>
        /// Generate account ID.
        /// </summary>
        /// <param name="str">The identification of the account.</param>
        /// <returns>Account ID.</returns>
        public string GenerateId(string str)
        { 
            return String.Format($"{DateTime.Now.Millisecond+str+str.Length.GetHashCode()}"); 
        }
    }
}
