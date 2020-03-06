// <copyright file="Result.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

namespace Utility.ResultModel
{
    /// <summary>
    /// Convenience counterpart to <see cref="Result{T,E}" />, allowing some methods to be called
    /// without specifying full type parameters.
    /// </summary>
    public static class Result
    {
        /// <summary>
        /// Construct a <see cref="SuccessfulResult{T}"/>, representing a <see cref="Result{T,E}"/>
        /// that signifies a successful result.
        /// </summary>
        /// <param name="value">The success value to wrap inside.</param>
        /// <typeparam name="T">The type of the success value.</typeparam>
        /// <returns>The created <see cref="SuccessfulResult{T}"/>.</returns>
        public static SuccessfulResult<T> Success<T>(T value)
        {
            return new SuccessfulResult<T>(value);
        }

        /// <summary>
        /// Construct a <see cref="FailedResult{E}"/>, representing a <see cref="Result{T,E}"/>
        /// that signifies a failed result.
        /// </summary>
        /// <param name="error">The error value to wrap inside.</param>
        /// <typeparam name="E">The type of the error value.</typeparam>
        /// <returns>The created <see cref="FailedResult{E}"/>.</returns>
        public static FailedResult<E> Fail<E>(E error)
        {
            return new FailedResult<E>(error);
        }

        /// <summary>
        /// Specialised convenience implementation of <see cref="Success{T}" /> for when the wrapped
        /// success value is an <see cref="Empty" />.
        /// </summary>
        /// <returns>An empty successful result.</returns>
        public static SuccessfulResult<Empty> Success()
        {
            return Success(new Empty());
        }

        /// <summary>
        /// Specialised convenience implementation of <see cref="Fail{E}" /> for when the wrapped error
        /// value is an <see cref="Empty" />.
        /// </summary>
        /// <returns>An empty failed result.</returns>
        public static FailedResult<Empty> Fail()
        {
            return Fail(new Empty());
        }
    }
}
