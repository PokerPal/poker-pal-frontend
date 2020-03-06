namespace Utility.ResultModel
{
    /// <summary>
    /// Represents a <see cref="Result{T,E}"/> that signifies a failed operation.
    /// </summary>
    /// <typeparam name="E">
    /// The type of the error wrapped inside the <see cref="Result{T,E}"/>.
    /// </typeparam>
    public sealed class FailedResult<E>
    {
        internal FailedResult(E error)
        {
            this.Error = error;
        }

        internal E Error { get; }
    }
}
