using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Works;

namespace Nop.Data.Mapping.Builders.Works
{
    /// <summary>
    /// Represents a work entity builder
    /// </summary>
    public partial class WorkBuilder : NopEntityBuilder<Work>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Work.ApplicantId)).AsInt32().NotNullable()
                .WithColumn(nameof(Work.EmploymentStatusId)).AsInt32().NotNullable()
                .WithColumn(nameof(Work.JobTitle)).AsString(400).NotNullable()
                .WithColumn(nameof(Work.EmployerOrBusiness)).AsString(400).NotNullable();
        }

        #endregion
    }
}