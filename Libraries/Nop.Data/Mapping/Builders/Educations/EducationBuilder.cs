using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Educations;

namespace Nop.Data.Mapping.Builders.Educations
{
    /// <summary>
    /// Represents a education entity builder
    /// </summary>
    public partial class EducationBuilder : NopEntityBuilder<Education>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Education.ApplicantId)).AsInt32().NotNullable()
                .WithColumn(nameof(Education.StandardId)).AsInt32().NotNullable()
                .WithColumn(nameof(Education.CourseName)).AsString(400).NotNullable()
                .WithColumn(nameof(Education.FieldOfStudy)).AsString(400).NotNullable()
                .WithColumn(nameof(Education.Institution)).AsString(400).NotNullable()
                .WithColumn(nameof(Education.University)).AsString(400).NotNullable()
                .WithColumn(nameof(Education.GraduationYear)).AsInt32().NotNullable()
                .WithColumn(nameof(Education.GPA)).AsDecimal().NotNullable();
        }

        #endregion
    }
}