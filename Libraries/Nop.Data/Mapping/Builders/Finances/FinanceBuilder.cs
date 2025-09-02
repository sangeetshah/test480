using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Finances;

namespace Nop.Data.Mapping.Builders.Finances
{
    /// <summary>
    /// Represents a finance entity builder
    /// </summary>
    public partial class FinanceBuilder : NopEntityBuilder<Finance>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Finance.ApplicantId)).AsInt32().NotNullable()
                .WithColumn(nameof(Finance.RecordTypeId)).AsInt32().NotNullable()
                .WithColumn(nameof(Finance.BankName)).AsString(400).NotNullable()
                .WithColumn(nameof(Finance.AccountMask)).AsString(400).NotNullable()
                .WithColumn(nameof(Finance.Currency)).AsDecimal().NotNullable()
                .WithColumn(nameof(Finance.AssetTypeId)).AsInt32().NotNullable()
                .WithColumn(nameof(Finance.Amount)).AsDecimal().NotNullable();
        }

        #endregion
    }
}