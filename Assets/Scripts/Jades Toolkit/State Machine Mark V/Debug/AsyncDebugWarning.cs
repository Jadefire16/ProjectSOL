using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

namespace JadesToolkit.StateOfLife.Debugging
{
    public static partial class AsyncDebug
    {
        /// <summary>
        /// <inheritdoc cref="UnityEngine.Debug.LogWarning(object)"/>
        /// </summary>
        /// <param name="message"><inheritdoc cref="UnityEngine.Debug.LogWarning(object)"/></param>
        /// <param name="token"></param>
        /// <param name="configureAwait"></param>
        public static async void LogWarning(string message, CancellationToken token = default, bool configureAwait = true) => await Task.Run(() => Debug.LogWarning(message), token == default ? CancellationToken.None : token).ConfigureAwait(configureAwait);

        /// <summary>
        /// <inheritdoc cref="UnityEngine.Debug.LogWarning(object, Object)"/>
        /// </summary>
        /// <param name="message"><inheritdoc cref="UnityEngine.Debug.LogWarning(object, Object)"/></param>
        /// <param name="obj"><inheritdoc cref="UnityEngine.Debug.LogWarning(object, Object)"/></param>
        /// <param name="token"></param>
        /// <param name="configureAwait"></param>
        public static async void LogWarning(object message, Object obj, CancellationToken token = default, bool configureAwait = true) => await Task.Run(() => Debug.LogWarning(message, obj), token == default ? CancellationToken.None : token).ConfigureAwait(configureAwait);
    }
}