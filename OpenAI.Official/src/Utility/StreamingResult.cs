using System.ClientModel;
using System.ClientModel.Primitives.Pipeline;
using System.ClientModel.Primitives;
using System.Threading;
using System.Collections.Generic;
using System;

namespace OpenAI.Official;

/// <summary>
/// Represents an operation response with streaming content that can be deserialized and enumerated while the response
/// is still being received.
/// </summary>
/// <typeparam name="T"> The data type representative of distinct, streamable items. </typeparam>
public class StreamingResult<T>
    : Result
    , IDisposable
    , IAsyncEnumerable<T>
{
    private Result _rawResult { get; }
    private IAsyncEnumerable<T> _asyncEnumerableSource { get; }
    private bool _disposedValue { get; set; }

    private StreamingResult() { }

    private StreamingResult(
        Result rawResult,
        Func<Result, IAsyncEnumerable<T>> asyncEnumerableProcessor)
    {
        _rawResult = rawResult;
        _asyncEnumerableSource = asyncEnumerableProcessor.Invoke(rawResult);
    }

    /// <summary>
    /// Creates a new instance of <see cref="StreamingResult{T}"/> using the provided underlying HTTP response. The
    /// provided function will be used to resolve the response into an asynchronous enumeration of streamed response
    /// items.
    /// </summary>
    /// <param name="result">The HTTP response.</param>
    /// <param name="asyncEnumerableProcessor">
    /// The function that will resolve the provided response into an IAsyncEnumerable.
    /// </param>
    /// <returns>
    /// A new instance of <see cref="StreamingResult{T}"/> that will be capable of asynchronous enumeration of
    /// <typeparamref name="T"/> items from the HTTP response.
    /// </returns>
    public static StreamingResult<T> CreateFromResponse(
        Result result,
        Func<Result, IAsyncEnumerable<T>> asyncEnumerableProcessor)
    {
        return new(result, asyncEnumerableProcessor);
    }

    /// <summary>
    /// Gets the underlying <see cref="PipelineResponse"/> instance that this <see cref="StreamingResult{T}"/> may enumerate
    /// over.
    /// </summary>
    /// <returns> The <see cref="PipelineResponse"/> instance attached to this <see cref="StreamingResult{T}"/>. </returns>
    public override PipelineResponse GetRawResponse() => _rawResult.GetRawResponse();

    /// <summary>
    /// Gets the asynchronously enumerable collection of distinct, streamable items in the response.
    /// </summary>
    /// <remarks>
    /// <para> The return value of this method may be used with the "await foreach" statement. </para>
    /// <para>
    /// As <see cref="StreamingResult{T}"/> explicitly implements <see cref="IAsyncEnumerable{T}"/>, callers may
    /// enumerate a <see cref="StreamingResult{T}"/> instance directly instead of calling this method.
    /// </para>
    /// </remarks>
    /// <returns></returns>
    public IAsyncEnumerable<T> EnumerateValues() => this;

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc/>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _rawResult?.GetRawResponse()?.Dispose();
            }
            _disposedValue = true;
        }
    }

    IAsyncEnumerator<T> IAsyncEnumerable<T>.GetAsyncEnumerator(CancellationToken cancellationToken)
        => _asyncEnumerableSource.GetAsyncEnumerator(cancellationToken);
}