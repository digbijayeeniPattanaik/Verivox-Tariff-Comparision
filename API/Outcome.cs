using System;

namespace API
{
    public class Outcome<T>
    {
        private const string _defaultMessage = "An error occurred";

        private string _errorMessage = _defaultMessage;

        private T _result;

        public Outcome()
        {
        }

        public Outcome(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }

            set { _errorMessage = value; }
        }

        public bool Successful { get { return string.IsNullOrWhiteSpace(_errorMessage); } }

        public T Result
        {
            get { return _result; }
            set
            {
                _result = value;
                if (value != null && !string.IsNullOrWhiteSpace(_errorMessage) && _errorMessage.Equals(_defaultMessage, StringComparison.InvariantCultureIgnoreCase)) _errorMessage = string.Empty;
            }
        }
    }
}
