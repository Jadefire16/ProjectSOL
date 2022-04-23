using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

namespace JadesToolkit.StateOfLife.Debugging
{
    public static partial class AsyncDebug
    {
        /// <summary>
        /// <inheritdoc cref="UnityEngine.Debug.Log(object)"/>
        /// </summary>
        /// <param name="message"><inheritdoc cref="UnityEngine.Debug.Log(object)"/></param>
        /// <param name="token"></param>
        /// <param name="configureAwait"></param>
        public async static void LogAsync(object message, CancellationToken token = default, bool configureAwait = true)
        {
            await Task.Run(() => Debug.Log(message), token == default ? CancellationToken.None : token).ConfigureAwait(configureAwait);
        }

        /// <summary>
        /// <inheritdoc cref="UnityEngine.Debug.Log(object)"/>
        /// </summary>
        /// <param name="message"><inheritdoc cref="UnityEngine.Debug.Log(object)"/></param>
        /// <param name="context"><inheritdoc cref="UnityEngine.Debug.Log(object)"/></param>
        /// <param name="token"></param>
        /// <param name="configureAwait"></param>
        public async static void LogAsync(object message, Object context, CancellationToken token = default, bool configureAwait = true)
        {
            await Task.Run(() => Debug.Log(message, context), token == default ? CancellationToken.None : token).ConfigureAwait(configureAwait);
        }

    }
}