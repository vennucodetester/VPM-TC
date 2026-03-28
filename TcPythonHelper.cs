// Minimal helper for pythonnet: implements Teamcenter .NET interfaces
// that can't be subclassed from Python.
//
// Compile:
//   csc /target:library /out:TcPythonHelper.dll /reference:TcSoaClient.dll /reference:TcSoaCommon.dll TcPythonHelper.cs

using System;
using System.Collections.Generic;
using Teamcenter.Schemas.Soa._2006_03.Exceptions;
using Teamcenter.Soa.Client;
using Teamcenter.Soa.Exceptions;

namespace TcPythonHelper
{
    /// <summary>
    /// Simple CredentialManager that stores credentials set from Python.
    /// </summary>
    public class SimpleCredentialManager : CredentialManager
    {
        private string _user = "";
        private string _password = "";
        private string _group = "";
        private string _role = "";
        private string _discriminator = "SoaAppX";

        public int CredentialType { get { return 0; } }

        public void SetCredentials(string user, string password)
        {
            _user = user;
            _password = password;
        }

        public void SetDiscriminator(string discriminator)
        {
            _discriminator = discriminator;
        }

        /// <summary>Returns [user, password, group, role, "", discriminator] for Login call.</summary>
        public string[] GetLoginArgs()
        {
            return new string[] { _user, _password, _group, _role, "", _discriminator };
        }

        // --- CredentialManager interface ---

        public string[] GetCredentials(InvalidCredentialsException e)
        {
            return new string[0]; // Empty = don't retry
        }

        public string[] GetCredentials(InvalidUserException e)
        {
            return new string[0];
        }

        public void SetGroupRole(string group, string role)
        {
            _group = group;
            _role = role;
        }

        public void SetUserPassword(string user, string password, string discriminator)
        {
            _user = user;
            _password = password;
            _discriminator = discriminator;
        }
    }

    /// <summary>
    /// No-op ExceptionHandler — just like the checksheet app.
    /// </summary>
    public class SimpleExceptionHandler : ExceptionHandler
    {
        public string LastError { get; private set; }

        public void HandleException(InternalServerException ise)
        {
            LastError = ise != null ? ise.Message : "InternalServerException";
        }

        public void HandleException(CanceledOperationException coe)
        {
            LastError = coe != null ? coe.Message : "CanceledOperationException";
        }
    }
}
