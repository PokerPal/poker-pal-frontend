namespace Application.Models.Result
{
    /// <summary>
    /// Successful result of an attempt to create a new Tournament.
    /// </summary>
    public class CreateTournamentResultModel
    {
        /// <summary>
        /// The unique identifier of the created tournament.
        /// </summary>
        public int Id { get; set; }
    }
}