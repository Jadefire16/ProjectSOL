using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

namespace JadesToolkit.StateOfLife.Debugging
{
    public static partial class AsyncDebug
    {
        /// <summary>
        /// <inheritdoc cref="UnityEngine.Debug.LogError(object)"/>
        /// </summary>
        /// <param name="message"><inheritdoc cref="UnityEngine.Debug.LogError(object)"/></param>
        /// <param name="configureAwait"></param>
        /// <param name="token"></param>
        public static async void LogError(object message, CancellationToken token = default, bool configureAwait = true) => await Task.Run(() => Debug.LogError(message), token == default ? CancellationToken.None : token).ConfigureAwait(configureAwait);

        /// <summary>
        /// <inheritdoc cref="UnityEngine.Debug.LogError(object, Object)"/>
        /// </summary>
        /// <param name="message"><inheritdoc cref="UnityEngine.Debug.LogError(object, Object)"/></param>
        /// <param name="obj"><inheritdoc cref="UnityEngine.Debug.LogError(object, Object)"/></param>
        /// <param name="configureAwait"></param>
        /// <param name="token"></param>D
        public static async void LogError(object message, Object obj, CancellationToken token = default, bool configureAwait = true) => await Task.Run(() => Debug.LogError(message, obj), token == default ? CancellationToken.None : token).ConfigureAwait(configureAwait);
    }
}