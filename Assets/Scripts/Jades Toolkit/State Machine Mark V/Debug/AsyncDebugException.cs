using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

namespace JadesToolkit.StateOfLife.Debugging
{
    public static partial class AsyncDebug
    {
        /// <summary>
        /// <inheritdoc cref="UnityEngine.Debug.LogException(System.Exception)"/>
        /// </summary>
        /// <param name="exception"><inheritdoc cref="UnityEngine.Debug.LogException(System.Exception)"/></param>
        /// <param name="token"></param>
        /// <param name="configureAwait"></param>
        public static async void LogException(System.Exception exception, CancellationToken token = default, bool configureAwait = true) => await Task.Run(() => Debug.LogException(exception), token == default ? CancellationToken.None : token).ConfigureAwait(configureAwait);

        /// <summary>
        /// <inheritdoc cref="UnityEngine.Debug.LogException(System.Exception, Object)"/>
        /// </summary>
        /// <param name="exception"><inheritdoc cref="UnityEngine.Debug.LogException(System.Exception, Object)"/></param>
        /// <param name="context"><inheritdoc cref="UnityEngine.Debug.LogException(System.Exception, Object)"/></param>
        /// <param name="token"></param>
        /// <param name="configureAwait"></param>
        public static async void LogException(System.Exception exception, Object context, CancellationToken token = default, bool configureAwait = true) => await Task.Run(() => Debug.LogException(exception, context), token == default ? CancellationToken.None : token).ConfigureAwait(configureAwait);
    }
}