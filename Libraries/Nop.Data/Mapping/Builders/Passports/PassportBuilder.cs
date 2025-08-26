using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Passports;

namespace Nop.Data.Mapping.Builders.Passports
{
    /// <summary>
    /// Represents a passport entity builder
    /// </summary>
    public partial class PassportBuilder : NopEntityBuilder<Passport>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Passport.ApplicantId)).AsInt32().NotNullable()
                .WithColumn(nameof(Passport.PassportNumber)).AsString(400).NotNullable()
                .WithColumn(nameof(Passport.IssuingCountry)).AsString(400).NotNullable()
                .WithColumn(nameof(Passport.IssueDate)).AsDateTime2().NotNullable()
                .WithColumn(nameof(Passport.ExpiryDate)).AsDateTime2().NotNullable()
                .WithColumn(nameof(Passport.PlaceOfIssue)).AsString(400).NotNullable();
        }

        #endregion
    }
}