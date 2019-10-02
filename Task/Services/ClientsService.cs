using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Task.Interfaces.Data;

namespace Task.Services
{
    public class ClientsService
    {
        private const string xlsTemplateName = "example.xlsx";
        private readonly IClientRepository _clientRepo;

        public ClientsService(IClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }

        private string GetXlsTemplatePath()
        {
            string xlsTemplateDirectory = DirectoriesService.GetXlsTemplateDirectoryPath();
            return Path.Combine(xlsTemplateDirectory, xlsTemplateName);
        }

        public void WriteClientDataToXls(string socialNumber)
        {
            var client = _clientRepo.GetBySocialNumber(socialNumber);

            using (var excel = new ExcelPackage(new FileInfo(GetXlsTemplatePath())))
            {
                var workbook = excel.Workbook;
                var worksheet = workbook.Worksheets.First();
                worksheet.Cells[1, 2].Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                UpdateCellsValue(
                    worksheet,
                    GetCellsIndexesByValue(worksheet, "[ID]"),
                    client.ID.ToString());

                UpdateCellsValue(
                    worksheet,
                    GetCellsIndexesByValue(worksheet, "[Name]"),
                    client.Name);

                UpdateCellsValue(
                    worksheet,
                    GetCellsIndexesByValue(worksheet, "[BirthDate]"),
                    client.BirhtDate.ToString("dd.MM.yyyy"));

                UpdateCellsValue(
                    worksheet,
                    GetCellsIndexesByValue(worksheet, "[PhoneNumber]"),
                    client.PhoneNumber);

                UpdateCellsValue(
                    worksheet,
                    GetCellsIndexesByValue(worksheet, "[Address]"),
                    client.Address);

                UpdateCellsValue(
                    worksheet,
                    GetCellsIndexesByValue(worksheet, "[SocialNumber]"),
                    client.SocialNumber);

                var outputXlsFileName = $"{client.SocialNumber}-{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}.xlsx";
                var outputXlsFilePath = Path.Combine(DirectoriesService.GetResultDirectoryPath(), outputXlsFileName);
                excel.SaveAs(new FileInfo(outputXlsFilePath));
            }
        }

        private IEnumerable<string> GetCellsIndexesByValue(ExcelWorksheet worksheet, string value)
        {
            return worksheet.Cells["A1:I8"]
                .Where(cell => cell.Value != null ? cell.Value.ToString() == value : false)
                .Select(cell => cell.Address);
        }

        private void UpdateCellsValue(ExcelWorksheet worksheet, IEnumerable<string> cellIndexes, string value)
        {
            foreach(string index in cellIndexes)
            {
                worksheet.Cells[index].Value = value;
                worksheet.Cells[index].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            }
        }
    }
}
