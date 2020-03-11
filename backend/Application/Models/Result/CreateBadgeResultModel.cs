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