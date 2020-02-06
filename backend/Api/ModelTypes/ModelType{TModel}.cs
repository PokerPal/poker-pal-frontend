using Application.Models;

namespace Api.ModelTypes
{
    /// <summary>
    /// Model type.
    /// </summary>
    /// <typeparam name="TModel">The model type this class represents the external interface for.</typeparam>
    public abstract class ModelType<TModel>
        where TModel : IModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelType{TModel}"/> class.
        /// </summary>
        /// <param name="model"></param>
        public ModelType(TModel model)
        {
            this.Model = model;
        }

        /// <summary>
        /// The model.
        /// </summary>
        protected TModel Model { get; }
    }
}