
namespace Nop.Services.Common
{
    public static class EntityCompletionHelper
    {
        public static double GetCompletionPercentage<T>(T entity)
        {
            if (entity == null)
                return 0;

            var properties = typeof(T).GetProperties();
            int totalCount = 0;
            int filledCount = 0;

            foreach (var prop in properties)
            {
                // Skip Id field if you want
                if (prop.Name == "Id" || prop.Name == "StandardEnum" || prop.Name == "EmploymentStatusEnum" || prop.Name == "RecordTypeEnum" || prop.Name == "AssetTypeEnum" || prop.Name == "RelevantConditionEnum")
                    continue;

                totalCount++;

                var value = prop.GetValue(entity);

                if (value != null)
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        var str = value as string;
                        if (!string.IsNullOrWhiteSpace(str))
                            filledCount++;
                    }
                    else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
                    {
                        int intValue = Convert.ToInt32(value);
                        if (intValue > 0)
                            filledCount++;
                    }
                    else if (prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(decimal?))
                    {
                        decimal decimalValue = Convert.ToDecimal(value);
                        if (decimalValue > 0)
                            filledCount++;
                    }
                    else if (prop.PropertyType == typeof(DateTime?) || prop.PropertyType == typeof(DateTime))
                    {
                        if (value is DateTime dt && dt != default(DateTime))
                            filledCount++;
                    }
                    else
                        filledCount++;
                }
            }

            return totalCount == 0 ? 0 : (filledCount * 100.0 / totalCount);
        }
    }
}