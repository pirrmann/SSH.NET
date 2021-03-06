﻿using System;
using System.Linq;
using Renci.SshNet.Common;

namespace Renci.SshNet
{
    /// <summary>
    /// Provides connection information when keyboard interactive authentication method is used
    /// </summary>
    /// <example>
    ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\KeyboardInteractiveConnectionInfoTest.cs" region="Example KeyboardInteractiveConnectionInfo AuthenticationPrompt" language="C#" title="Connect using interactive method" />
    /// </example>
    public class KeyboardInteractiveConnectionInfo : ConnectionInfo, IDisposable
    {
        /// <summary>
        /// Occurs when server prompts for more authentication information.
        /// </summary>
        /// <example>
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\KeyboardInteractiveConnectionInfoTest.cs" region="Example KeyboardInteractiveConnectionInfo AuthenticationPrompt" language="C#" title="Connect using interactive method" />
        /// </example>
        public event EventHandler<AuthenticationPromptEventArgs> AuthenticationPrompt;

        //  TODO: DOCS Add exception documentation for this class.

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInteractiveConnectionInfo"/> class.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="username">The username.</param>
        public KeyboardInteractiveConnectionInfo(string host, string username)
            : this(host, DefaultPort, username, ProxyTypes.None, string.Empty, 0, string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInteractiveConnectionInfo"/> class.
        /// </summary>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="username">The username.</param>
        public KeyboardInteractiveConnectionInfo(string host, int port, string username)
            : this(host, port, username, ProxyTypes.None, string.Empty, 0, string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInteractiveConnectionInfo"/> class.
        /// </summary>
        /// <param name="host">Connection host.</param>
        /// <param name="port">Connection port.</param>
        /// <param name="username">Connection username.</param>
        /// <param name="proxyType">Type of the proxy.</param>
        /// <param name="proxyHost">The proxy host.</param>
        /// <param name="proxyPort">The proxy port.</param>
        public KeyboardInteractiveConnectionInfo(string host, int port, string username, ProxyTypes proxyType, string proxyHost, int proxyPort)
            : this(host, port, username, proxyType, proxyHost, proxyPort, string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInteractiveConnectionInfo"/> class.
        /// </summary>
        /// <param name="host">Connection host.</param>
        /// <param name="port">Connection port.</param>
        /// <param name="username">Connection username.</param>
        /// <param name="proxyType">Type of the proxy.</param>
        /// <param name="proxyHost">The proxy host.</param>
        /// <param name="proxyPort">The proxy port.</param>
        /// <param name="hostResolutionMode">The host name resolution method when using the proxy.</param>
        public KeyboardInteractiveConnectionInfo(string host, int port, string username, ProxyTypes proxyType, string proxyHost, int proxyPort, HostResolutionMode hostResolutionMode)
            : this(host, port, username, proxyType, proxyHost, proxyPort, string.Empty, string.Empty, hostResolutionMode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInteractiveConnectionInfo"/> class.
        /// </summary>
        /// <param name="host">Connection host.</param>
        /// <param name="port">Connection port.</param>
        /// <param name="username">Connection username.</param>
        /// <param name="proxyType">Type of the proxy.</param>
        /// <param name="proxyHost">The proxy host.</param>
        /// <param name="proxyPort">The proxy port.</param>
        /// <param name="proxyUsername">The proxy username.</param>
        public KeyboardInteractiveConnectionInfo(string host, int port, string username, ProxyTypes proxyType, string proxyHost, int proxyPort, string proxyUsername)
            : this(host, port, username, proxyType, proxyHost, proxyPort, proxyUsername, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInteractiveConnectionInfo"/> class.
        /// </summary>
        /// <param name="host">Connection host.</param>
        /// <param name="port">Connection port.</param>
        /// <param name="username">Connection username.</param>
        /// <param name="proxyType">Type of the proxy.</param>
        /// <param name="proxyHost">The proxy host.</param>
        /// <param name="proxyPort">The proxy port.</param>
        /// <param name="proxyUsername">The proxy username.</param>
        /// <param name="hostResolutionMode">The host name resolution method when using the proxy.</param>
        public KeyboardInteractiveConnectionInfo(string host, int port, string username, ProxyTypes proxyType, string proxyHost, int proxyPort, string proxyUsername, HostResolutionMode hostResolutionMode)
            : this(host, port, username, proxyType, proxyHost, proxyPort, proxyUsername, string.Empty, hostResolutionMode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInteractiveConnectionInfo"/> class.
        /// </summary>
        /// <param name="host">Connection host.</param>
        /// <param name="username">Connection username.</param>
        /// <param name="proxyType">Type of the proxy.</param>
        /// <param name="proxyHost">The proxy host.</param>
        /// <param name="proxyPort">The proxy port.</param>
        public KeyboardInteractiveConnectionInfo(string host, string username, ProxyTypes proxyType, string proxyHost, int proxyPort)
            : this(host, DefaultPort, username, proxyType, proxyHost, proxyPort, string.Empty, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInteractiveConnectionInfo"/> class.
        /// </summary>
        /// <param name="host">Connection host.</param>
        /// <param name="username">Connection username.</param>
        /// <param name="proxyType">Type of the proxy.</param>
        /// <param name="proxyHost">The proxy host.</param>
        /// <param name="proxyPort">The proxy port.</param>
        /// <param name="hostResolutionMode">The host name resolution method when using the proxy.</param>
        public KeyboardInteractiveConnectionInfo(string host, string username, ProxyTypes proxyType, string proxyHost, int proxyPort, HostResolutionMode hostResolutionMode)
            : this(host, DefaultPort, username, proxyType, proxyHost, proxyPort, string.Empty, string.Empty, hostResolutionMode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInteractiveConnectionInfo"/> class.
        /// </summary>
        /// <param name="host">Connection host.</param>
        /// <param name="username">Connection username.</param>
        /// <param name="proxyType">Type of the proxy.</param>
        /// <param name="proxyHost">The proxy host.</param>
        /// <param name="proxyPort">The proxy port.</param>
        /// <param name="proxyUsername">The proxy username.</param>
        public KeyboardInteractiveConnectionInfo(string host, string username, ProxyTypes proxyType, string proxyHost, int proxyPort, string proxyUsername)
            : this(host, DefaultPort, username, proxyType, proxyHost, proxyPort, proxyUsername, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInteractiveConnectionInfo"/> class.
        /// </summary>
        /// <param name="host">Connection host.</param>
        /// <param name="username">Connection username.</param>
        /// <param name="proxyType">Type of the proxy.</param>
        /// <param name="proxyHost">The proxy host.</param>
        /// <param name="proxyPort">The proxy port.</param>
        /// <param name="proxyUsername">The proxy username.</param>
        /// <param name="hostResolutionMode">The host name resolution method when using the proxy.</param>
        public KeyboardInteractiveConnectionInfo(string host, string username, ProxyTypes proxyType, string proxyHost, int proxyPort, string proxyUsername, HostResolutionMode hostResolutionMode)
            : this(host, DefaultPort, username, proxyType, proxyHost, proxyPort, proxyUsername, string.Empty, hostResolutionMode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInteractiveConnectionInfo"/> class.
        /// </summary>
        /// <param name="host">Connection host.</param>
        /// <param name="username">Connection username.</param>
        /// <param name="proxyType">Type of the proxy.</param>
        /// <param name="proxyHost">The proxy host.</param>
        /// <param name="proxyPort">The proxy port.</param>
        /// <param name="proxyUsername">The proxy username.</param>
        /// <param name="proxyPassword">The proxy password.</param>
        public KeyboardInteractiveConnectionInfo(string host, string username, ProxyTypes proxyType, string proxyHost, int proxyPort, string proxyUsername, string proxyPassword)
            : this(host, DefaultPort, username, proxyType, proxyHost, proxyPort, proxyUsername, proxyPassword)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInteractiveConnectionInfo"/> class.
        /// </summary>
        /// <param name="host">Connection host.</param>
        /// <param name="username">Connection username.</param>
        /// <param name="proxyType">Type of the proxy.</param>
        /// <param name="proxyHost">The proxy host.</param>
        /// <param name="proxyPort">The proxy port.</param>
        /// <param name="proxyUsername">The proxy username.</param>
        /// <param name="proxyPassword">The proxy password.</param>
        /// <param name="hostResolutionMode">The host name resolution method when using the proxy.</param>
        public KeyboardInteractiveConnectionInfo(string host, string username, ProxyTypes proxyType, string proxyHost, int proxyPort, string proxyUsername, string proxyPassword, HostResolutionMode hostResolutionMode)
            : this(host, DefaultPort, username, proxyType, proxyHost, proxyPort, proxyUsername, proxyPassword, hostResolutionMode)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInteractiveConnectionInfo"/> class.
        /// </summary>
        /// <param name="host">Connection host.</param>
        /// <param name="port">Connection port.</param>
        /// <param name="username">Connection username.</param>
        /// <param name="proxyType">Type of the proxy.</param>
        /// <param name="proxyHost">The proxy host.</param>
        /// <param name="proxyPort">The proxy port.</param>
        /// <param name="proxyUsername">The proxy username.</param>
        /// <param name="proxyPassword">The proxy password.</param>
        public KeyboardInteractiveConnectionInfo(string host, int port, string username, ProxyTypes proxyType, string proxyHost, int proxyPort, string proxyUsername, string proxyPassword)
            : base(host, port, username, proxyType, proxyHost, proxyPort, proxyUsername, proxyPassword, new KeyboardInteractiveAuthenticationMethod(username))
        {
            foreach (var authenticationMethod in AuthenticationMethods.OfType<KeyboardInteractiveAuthenticationMethod>())
            {
                authenticationMethod.AuthenticationPrompt += AuthenticationMethod_AuthenticationPrompt;
            }

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardInteractiveConnectionInfo"/> class.
        /// </summary>
        /// <param name="host">Connection host.</param>
        /// <param name="port">Connection port.</param>
        /// <param name="username">Connection username.</param>
        /// <param name="proxyType">Type of the proxy.</param>
        /// <param name="proxyHost">The proxy host.</param>
        /// <param name="proxyPort">The proxy port.</param>
        /// <param name="proxyUsername">The proxy username.</param>
        /// <param name="proxyPassword">The proxy password.</param>
        /// <param name="hostResolutionMode">The host name resolution method when using the proxy.</param>
        public KeyboardInteractiveConnectionInfo(string host, int port, string username, ProxyTypes proxyType, string proxyHost, int proxyPort, string proxyUsername, string proxyPassword, HostResolutionMode hostResolutionMode)
            : base(host, port, username, proxyType, proxyHost, proxyPort, proxyUsername, proxyPassword, hostResolutionMode, new KeyboardInteractiveAuthenticationMethod(username))
        {
            foreach (var authenticationMethod in AuthenticationMethods.OfType<KeyboardInteractiveAuthenticationMethod>())
            {
                authenticationMethod.AuthenticationPrompt += AuthenticationMethod_AuthenticationPrompt;
            }

        }

        private void AuthenticationMethod_AuthenticationPrompt(object sender, AuthenticationPromptEventArgs e)
        {
            if (AuthenticationPrompt != null)
            {
                AuthenticationPrompt(sender, e);
            }
        }


        #region IDisposable Members

        private bool _isDisposed;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
            {
                if (AuthenticationMethods != null)
                {
                    foreach (var authenticationMethods in AuthenticationMethods.OfType<IDisposable>())
                    {
                        authenticationMethods.Dispose();
                    }
                }

                _isDisposed = true;
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="KeyboardInteractiveConnectionInfo"/> is reclaimed by garbage collection.
        /// </summary>
        ~KeyboardInteractiveConnectionInfo()
        {
            Dispose(false);
        }

        #endregion
    }
}
