using ClosedXML.Excel;
namespace NashTechRookie.Utils
{
    public class FileHelper<T>
    {
        public static byte[] GenerateExcelFile(List<T> items)
        {
            if (items == null || !items.Any()) return Array.Empty<byte>();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add($"{typeof(T).Name}s");
            var properties = typeof(T).GetProperties();

            // Add header row
            var headerRow = worksheet.Row(1);
            properties.Select((prop, index) => worksheet.Cell(1, index + 1).SetValue(prop.Name)).ToList();

            // Add data rows
            for (int row = 0; row < items.Count; row++)
            {
                var item = items[row];
                for (int col = 0; col < properties.Length; col++)
                {
                    worksheet.Cell(row + 2, col + 1).SetValue(properties[col].GetValue(item)?.ToString() ?? "");
                }
            }

            // Style header row
            headerRow.Style.Font.Bold = true;
            headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Columns().AdjustToContents();

            // Save to memory stream
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }
    }
}
