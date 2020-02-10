// <copyright file="Result.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

using System;

namespace Utility
{
    /// <summary>
    /// Represents the result of an operation that could fail.
    /// </summary>
    /// <typeparam name="T">The type of the value returned by a successful operation.</typeparam>
    /// <typeparam name="E">The type of the error occurring if the operation fails.</typeparam>
    public class Result<T, E>
        where T : class
        where E : class
    {
        /// <summary>
        /// Gets whether the operation completed successfully.
        /// </summary>
        public bool IsSuccess { get; private set; }

        /// <summary>
        /// The successful result value, if <c>IsSuccess == true</c>.
        /// </summary>
        public T? Value { get; private set; }

        /// <summary>
        /// The error value, if <c>IsSuccess == false</c>.
        /// </summary>
        public E? Error { get; private set; }

        /// <summary>
        /// Implicitly converts a value of type <c>T</c> to a <c>Result{T,E}</c> representing a success.
        /// </summary>
        /// <param name="successValue">The value to wrap inside the successful result.</param>
        /// <returns>The created result wrapping <c>successValue</c>.</returns>
        public static implicit operator Result<T, E>(T successValue) => Success(successValue);

        /// <summary>
        /// Implicitly converts a value of type <c>E</c> to a <c>Result{T,E}</c> representing a failure.
        /// </summary>
        /// <param name="errorValue">The value to wrap inside the failed result.</param>
        /// <returns>The created result wrapping <c>errorValue</c>.</returns>
        public static implicit operator Result<T, E>(E errorValue) => Fail(errorValue);

        /// <summary>
        /// Creates an instance of <see cref="Result{T,E}"/> representing a successful operation.
        /// </summary>
        /// <param name="value">The success value.</param>
        /// <returns>The successful result.</returns>
        public static Result<T, E> Success(T value)
        {
            return new Result<T, E>
            {
                IsSuccess = true,
                Value = value,
                Error = null,
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="Result{T,E}"/> representing a failed operation.
        /// </summary>
        /// <param name="error">The error value representing the failure.</param>
        /// <returns>The failed result.</returns>
        public static Result<T, E> Fail(E error)
        {
            return new Result<T, E>
            {
                IsSuccess = false,
                Value = null,
                Error = error,
            };
        }

        /// <summary>
        /// Converts a result of type <c>Result{T,E}</c> to a result of new type <c>Result{U,E}</c>.
        ///
        /// This works by converting the wrapped <c>T</c> value to a <c>U</c> using the provided function
        /// <c>mapping()</c>, if this result is a success. If this result is a failure, the error is copied to the new
        /// result.
        /// </summary>
        /// <param name="mapping">The conversion function from a <c>T</c> to a <c>U</c>.</param>
        /// <typeparam name="U">The success type of the new result.</typeparam>
        /// <returns>The new result.</returns>
        public Result<U, E> Map<U>(Func<T, U> mapping)
            where U : class
        {
            if (!this.IsSuccess)
            {
                return new Result<U, E>
                {
                    IsSuccess = false,
                    Value = null,
                    Error = this.Error,
                };
            }

            return Result<U, E>.Success(mapping(this.Value!));
        }

        /// <summary>
        /// Unwraps a <see cref="Result{T,E}"/> to produce a value of type <c>T</c>, by providing a default to be used
        /// if the result is unsuccessful.
        ///
        /// If the default value is expensive to compute, the alternative function <see cref="Result{T,E}.OrElse"/>
        /// should be used instead.
        /// </summary>
        /// <param name="other">The default value, to be used if this result is unsuccessful.</param>
        /// <returns>The wrapped <c>T</c> value, or the default provided if there is none.</returns>
        public T Or(T other)
        {
            return this.IsSuccess ? this.Value! : other;
        }

        /// <summary>
        /// Unwraps a <see cref="Result{T,E}"/> to produce a value of type <c>T</c>, by computing a default to be used
        /// if the result is unsuccessful.
        ///
        /// This function, as opposed to <see cref="Result{T,E}.Or"/>, is useful when the default value is expensive
        /// to compute; the function <c>other</c> is only called in the case where this result is unsuccessful.
        /// </summary>
        /// <param name="other">A function that computes the default value, to be used if this result is
        /// unsuccessful.</param>
        /// <returns>The wrapped <c>T</c> value, or the default computed if there is none.</returns>
        public T OrElse(Func<T> other)
        {
            return this.IsSuccess ? this.Value! : other();
        }
    }
}