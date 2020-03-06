// <copyright file="BadgeOutputModel.cs" company="IP Group 2">
// Copyright (c) IP Group 2. All rights reserved.
// </copyright>

using System;
using Type = Persistence.Entities.Type;

namespace Application.Models.Output
{
    /// <summary>
    /// Represents details about a badge.
    /// </summary>
    public class BadgeOutputModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadgeOutputModel"/> class.
        /// </summary>
        /// <param name="id">The badge's unique identifier.</param>
        /// <param name="name">The badge's Name.</param>
        /// <param name="description">The badge's Description.</param>
        /// <param name="type">The badge's type.</param>
        public BadgeOutputModel(Guid id, string name, string description, Type type)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Type = type;
        }

        /// <summary>
        /// The badge's unique identifier.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// The badge's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Description of the badge.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// The badge type.
        /// </summary>
        public Type Type { get; }
    }
}