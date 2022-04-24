using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

namespace JadesToolkit.StateOfLife.Debugging
{
    public static partial class AsyncDebug
    {
        /// <summary>
        /// <inheritdoc cref="UnityEngine.Debug.Assert(bool)"/>
        /// </summary>
        /// <param name="condition"><inheritdoc cref="UnityEngine.Debug.Assert(bool)"/></param>
        /// <param name="message"><inheritdoc cref="UnityEngine.Debug.Assert(bool)"/></param>
        /// <param name="context"><inheritdoc cref="UnityEngine.Debug.Assert(bool)"/></param>
        /// <param name="token"></param>
        /// <param name="configureAwait"></param>
        public static async void Assert(bool condition, CancellationToken token = default, bool configureAwait = true)
        {
            await Task.Run(() => Debug.Assert(condition), token == default ? CancellationToken.None : token).ConfigureAwait(configureAwait);
        }

        /// <summary>
        /// <inheritdoc cref="UnityEngine.Debug.Assert(bool, object)"/>
        /// </summary>
        /// <param name="condition"><inheritdoc cref="UnityEngine.Debug.Assert(bool, object)"/></param>
        /// <param name="message"><inheritdoc cref="UnityEngine.Debug.Assert(bool, object)"/></param>
        /// <param name="context"><inheritdoc cref="UnityEngine.Debug.Assert(bool, object)"/></param>
        /// <param name="token"></param>
        /// <param name="configureAwait"></param>
        public static async void Assert(bool condition, object message, CancellationToken token = default, bool configureAwait = true)
        {
            await Task.Run(() => Debug.Assert(condition, message), token == default ? CancellationToken.None : token).ConfigureAwait(configureAwait);
        }

        /// <summary>
        /// <inheritdoc cref="UnityEngine.Debug.Assert(bool, Object)"/>
        /// </summary>
        /// <param name="condition"><inheritdoc cref="UnityEngine.Debug.Assert(bool, Object)"/></param>
        /// <param name="message"><inheritdoc cref="UnityEngine.Debug.Assert(bool, Object)"/></param>
        /// <param name="context"><inheritdoc cref="UnityEngine.Debug.Assert(bool, Object)"/></param>
        /// <param name="token"></param>
        /// <param name="configureAwait"></param>
        public static async void Assert(bool condition, Object context, CancellationToken token = default, bool configureAwait = true)
        {
            await Task.Run(() => Debug.Assert(condition, context), token == default ? CancellationToken.None : token).ConfigureAwait(configureAwait);
        }

        /// <summary>
        /// <inheritdoc cref="UnityEngine.Debug.Assert(bool, string)"/>
        /// </summary>
        /// <param name="condition"><inheritdoc cref="UnityEngine.Debug.Assert(bool, string)"/></param>
        /// <param name="message"><inheritdoc cref="UnityEngine.Debug.Assert(bool, string)"/></param>
        /// <param name="context"><inheritdoc cref="UnityEngine.Debug.Assert(bool, string)"/></param>
        /// <param name="token"></param>
        /// <param name="configureAwait"></param>
        public static async void Assert(bool condition, string message, CancellationToken token = default, bool configureAwait = true)
        {
            await Task.Run(() => Debug.Assert(condition, message), token == default ? CancellationToken.None : token).ConfigureAwait(configureAwait);
        }

        /// <summary>
        /// <inheritdoc cref="UnityEngine.Debug.Assert(bool, object, Object)"/>
        /// </summary>
        /// <param name="condition"><inheritdoc cref="UnityEngine.Debug.Assert(bool, object, Object)"/></param>
        /// <param name="message"><inheritdoc cref="UnityEngine.Debug.Assert(bool, object, Object)"/></param>
        /// <param name="context"><inheritdoc cref="UnityEngine.Debug.Assert(bool, object, Object)"/></param>
        /// <param name="token"></param>
        /// <param name="configureAwait"></param>
        public static async void Assert(bool condition, object message, Object context, CancellationToken token = default, bool configureAwait = true)
        {
            await Task.Run(() => Debug.Assert(condition, message, context), token == default ? CancellationToken.None : token).ConfigureAwait(configureAwait);
        }

        /// <summary>
        /// <inheritdoc cref="UnityEngine.Debug.Assert(bool, string, Object)"/>
        /// </summary>
        /// <param name="condition"><inheritdoc cref="UnityEngine.Debug.Assert(bool, string, Object)"/></param>
        /// <param name="message"><inheritdoc cref="UnityEngine.Debug.Assert(bool, string, Object)"/></param>
        /// <param name="context"><inheritdoc cref="UnityEngine.Debug.Assert(bool, string, Object)"/></param>
        /// <param name="token"></param>
        /// <param name="configureAwait"></param>
        public static async void Assert(bool condition, string message, Object context, CancellationToken token = default, bool configureAwait = true)
        {
            await Task.Run(() => Debug.Assert(condition, message, context), token == default ? CancellationToken.None : token).ConfigureAwait(configureAwait);
        }
    }
}