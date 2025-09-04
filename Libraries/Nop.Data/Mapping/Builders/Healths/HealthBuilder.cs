using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Healths;

namespace Nop.Data.Mapping.Builders.Healths
{
    /// <summary>
    /// Represents a health entity builder
    /// </summary>
    public partial class HealthBuilder : NopEntityBuilder<Health>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Health.ApplicantId)).AsInt32().NotNullable()
                .WithColumn(nameof(Health.RelevantConditionId)).AsInt32().NotNullable()
                .WithColumn(nameof(Health.Notes)).AsString(400).NotNullable();
        }

        #endregion
    }
}