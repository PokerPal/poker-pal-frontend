namespace Api.ModelTypes.Input
{
    /// <summary>
    /// Details required to make a new badge.
    /// </summary>
    public class CreateBadgeInputType
    {
        /// <summary>
        /// The badge's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The badge's Description.
        /// </summary>
        public string Description { get; set; }
    }
}