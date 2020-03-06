// <copyright file="CreateBadgeResultModel.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

namespace Application.Models.Result
{
    /// <summary>
    /// Successful result of an attempt to create a new Badge.
    /// </summary>
    public class CreateBadgeResultModel
    {
        /// <summary>
        /// The unique identifier of the created Badge.
        /// </summary>
        public int Id { get; set; }
    }
}