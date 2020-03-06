// <copyright file="CreateBadgeInputType.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

#pragma warning disable 8618
namespace Api.ModelTypes.Input
{
    /// <summary>
    /// Details required to make a new badge
    /// </summary>
    public class CreateBadgeInputType
    {
        /// <summary>
        /// The badge's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The badge's Description
        /// </summary>
        public string Description { get; set; }
    }
}