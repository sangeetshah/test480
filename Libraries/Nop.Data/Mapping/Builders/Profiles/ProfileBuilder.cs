using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Profiles;

namespace Nop.Data.Mapping.Builders.Profiles;

/// <summary>
/// Represents a profile entity builder
/// </summary>
public partial class ProfileBuilder : NopEntityBuilder<Profile>
{
    #region Methods

    /// <summary>
    /// Apply entity configuration
    /// </summary>
    /// <param name="table">Create table expression builder</param>
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table
            .WithColumn(nameof(Profile.ApplicantId)).AsString(400).NotNullable()
            .WithColumn(nameof(Profile.Email)).AsString(400).NotNullable();
    }

    #endregion
}