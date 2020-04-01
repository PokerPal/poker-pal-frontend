using System;

namespace Api.ModelTypes.Input
{
    /// <summary>
    /// Details required to make a new league.
    /// </summary>
    public class CreateLeagueInputType
    {
        /// <summary>
        /// The league's name.
        /// </summary>
        public string Name { get; set; }
    }
}
