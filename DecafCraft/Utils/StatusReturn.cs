using System;

namespace DecafCraft.Utils
{
    public class StatusReturn<T>
    {
        private T _type;
        private string _reason;

        public T Getvalue() => _type;
        public string GetReason() => _reason;
        
        /// <summary>
        /// Returns a status type with a message for the return.
        /// </summary>
        /// <param name="type">Type of return value</param>
        /// <param name="reason">Message for reason of return value</param>
        public StatusReturn(T type, string reason = null)
        {
            if (type == null) return;
            if (string.IsNullOrEmpty(reason)) _reason = "No reason was given for the return value.";
            _type = type;
            _reason = reason;
        }
    }
}