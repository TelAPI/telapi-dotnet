using System;

namespace TelAPI
{
    /// <summary>
    /// TelAPI Exception class
    /// </summary>
    public class TelAPIException : Exception
    {
        public TelAPIException(string message)
            : base(message)
        {
        }

        public TelAPIException(string message, Exception e)
            : base(message, e)
        {
        }
    }

    public class TelAPIBadRequestException : TelAPIException
    {
        public TelAPIBadRequestException(string message)
            : base(message)
        {
        }

        public TelAPIBadRequestException(string message, Exception e)
            : base(message, e)
        {
        }
    }

    public class TelAPIUnauthorizedException : TelAPIException
    {
        public TelAPIUnauthorizedException(string message)
            : base(message)
        {
        }

        public TelAPIUnauthorizedException(string message, Exception e)
            : base(message, e)
        {
        }
    }

    public class TelAPIForbiddenException : TelAPIException
    {
        public TelAPIForbiddenException(string message)
            : base(message)
        {
        }

        public TelAPIForbiddenException(string message, Exception e)
            : base(message, e)
        {
        }
    }

    public class TelAPINotFoundException : TelAPIException
    {
        public TelAPINotFoundException(string message)
            : base(message)
        {
        }

        public TelAPINotFoundException(string message, Exception e)
            : base(message, e)
        {
        }
    }

    public class TelAPIInternalErrorException : TelAPIException
    {
        public TelAPIInternalErrorException(string message)
            : base(message)
        {
        }

        public TelAPIInternalErrorException(string message, Exception e)
            : base(message, e)
        {
        }
    }
}
