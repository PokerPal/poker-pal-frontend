// <copyright file="SuccessfulResult.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

namespace Utility.ResultModel
{
    /// <summary>
    /// Represents a <see cref="Result{T,E}"/> that signifies a successful operation.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the success value wrapped inside the <see cref="Result{T,E}"/>.
    /// </typeparam>
    public sealed class SuccessfulResult<T>
    {
        internal SuccessfulResult(T value)
        {
            this.Value = value;
        }

        internal T Value { get; }
    }
}
