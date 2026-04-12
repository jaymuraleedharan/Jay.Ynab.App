using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YnabApp.BL.ListCategories;
using YnabApp.BL.ListTransactions;
using YnabApp.BL.Reflect;
using YnabApp.BL.BudgetSettings;
using ClosedXML.Excel;
using System.IO;
using System.Data;
using System.Drawing;

namespace YnabApp.BL.Export
{
    public class ReflectExport
    {
        CategoryGroupData[] CategoryDatas;
        TransactionData[] TransactionDatas;
        bool IsYearly;
        DateTime StartDate;
        PersonSetting Person;
        bool IsHideZeroCategories;

        private int CurrentRowNum { get; set; } = 0;
        private int CurrentCellNum { get; set; } = 0;

        private IXLWorksheet CurrentWorksheet { get; set; }

        List<ReflectSummaryData> _summaryResults;
        List<ReflectIncomeData> _incomeResults;
        List<ReflectCategoryGroupData> _categoryGroupResults;
        List<ReflectCategoryData> _categoryResults; 

        public ReflectExport(bool isYearly, PersonSetting person, DateTime startDate, List<ReflectSummaryData> summaryResults, List<ReflectIncomeData> incomeResults, List<ReflectCategoryGroupData> categoryGroupResults, List<ReflectCategoryData> categoryResults)
        {
            IsYearly = isYearly;
            Person = person;
            StartDate = startDate;
            _summaryResults = summaryResults;
            _incomeResults = incomeResults;
            _categoryGroupResults = categoryGroupResults;
            _categoryResults = categoryResults;
        }

        private string ExportFileName
        {
            get
            {
                var personName = (Person == null) ? "All" : Person.Name;
                if (IsYearly)
                    return $"ReflectViewReport-Yearly-{personName}-{StartDate:yyyy}.xlsx";
                else
                    return $"ReflectViewReport-Monthly-{personName}-{StartDate:yyyy-MM}.xlsx";
            }
        }

        private string ExportFilePath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), ExportFileName);
            }
        }

        public string GenerateReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Reflection Report");

                CurrentWorksheet = workSheet;

                ExportSummary();
                ExportIncome();
                ExportCategoryGroup();
                ExportCategory();

                workSheet.Columns().AdjustToContents();

                workBook.SaveAs(ExportFilePath);

                CurrentWorksheet = null;

                return ExportFilePath;
            }
        }

        private void NextRow()
        {
            CurrentRowNum++;
            CurrentCellNum = 1;
        }

        private void NextCell()
        {
            CurrentCellNum++;
        }

        private void FormatCell(int formatNum, XLAlignmentHorizontalValues alignment, Color backColor, Color fontColor, bool isBold = false)
        {
            CurrentWorksheet.Cell(CurrentRowNum, CurrentCellNum).Style.NumberFormat.NumberFormatId = formatNum;
            CurrentWorksheet.Cell(CurrentRowNum, CurrentCellNum).Style.Alignment.Horizontal = alignment;
            CurrentWorksheet.Cell(CurrentRowNum, CurrentCellNum).Style.Fill.BackgroundColor = XLColor.FromColor(backColor);
            CurrentWorksheet.Cell(CurrentRowNum, CurrentCellNum).Style.Font.FontColor = XLColor.FromColor(fontColor);
            CurrentWorksheet.Cell(CurrentRowNum, CurrentCellNum).Style.Font.SetBold(isBold);
        }

        private void SetCellValue(string value)
        {
            CurrentWorksheet.Cell(CurrentRowNum, CurrentCellNum).Value = value;
        }

        private void SetCellValue(decimal value)
        {
            CurrentWorksheet.Cell(CurrentRowNum, CurrentCellNum).Value = value;
        }

        private void ExportSummary()
        {
            NextRow();

            //HEADER ROW
            FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Left, Color.Transparent, Color.Black, true);
            SetCellValue("Summary");

            NextCell();
            FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Right, Color.Transparent, Color.Black, true);
            SetCellValue("Amount");

            NextCell();
            FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Right, Color.Transparent, Color.Black, true);
            SetCellValue("% of Income");

            if (IsYearly)
            {
                NextCell();
                FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Right, Color.Transparent, Color.Black, true);
                SetCellValue("Monthly");
            }

            //DATA ROWS
            foreach (var result in _summaryResults)
            {
                NextRow();

                Color backColor = ExportColorizer.GetSummaryBackColor(result.SummaryName);
                Color fontColor = ExportColorizer.GetSummaryFontColor(result.SummaryName);
                if (result.SummaryName == "Net Change")
                {
                    backColor = ExportColorizer.GetNetChangeBackColor(result.Amount);
                    fontColor = ExportColorizer.GetNetChangeFontColor(result.Amount);
                }

                FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Left, backColor, fontColor);
                SetCellValue(result.SummaryName);

                NextCell();
                FormatCell((int)XLPredefinedFormat.Number.Precision2WithSeparator, XLAlignmentHorizontalValues.Right, backColor, fontColor);
                SetCellValue(result.Amount);

                NextCell();
                FormatCell((int)XLPredefinedFormat.Number.Precision2WithSeparator, XLAlignmentHorizontalValues.Right, backColor, fontColor);
                SetCellValue(result.Percentage);

                if (IsYearly)
                {
                    NextCell();
                    FormatCell((int)XLPredefinedFormat.Number.Precision2WithSeparator, XLAlignmentHorizontalValues.Right, backColor, fontColor);
                    SetCellValue(result.MonthlyAmountAccurate(StartDate));
                }
            }

            NextRow();
        }

        private void ExportIncome()
        {
            NextRow();

            //HEADER ROW
            FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Left, Color.Transparent, Color.Black, true);
            SetCellValue("Income");

            NextCell();
            FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Right, Color.Transparent, Color.Black, true);
            SetCellValue("Amount");

            NextCell();
            FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Right, Color.Transparent, Color.Black, true);
            SetCellValue("% of Income");

            if (IsYearly)
            {
                NextCell();
                FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Right, Color.Transparent, Color.Black, true);
                SetCellValue("Monthly");
            }

            //DATA ROWS
            foreach (var result in _incomeResults)
            {
                NextRow();

                Color backColor = Color.Transparent;
                Color fontColor = Color.Black;

                FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Left, backColor, fontColor);
                SetCellValue(result.FullName);

                NextCell();
                FormatCell((int)XLPredefinedFormat.Number.Precision2WithSeparator, XLAlignmentHorizontalValues.Right, backColor, fontColor);
                SetCellValue(result.Amount);

                NextCell();
                FormatCell((int)XLPredefinedFormat.Number.Precision2WithSeparator, XLAlignmentHorizontalValues.Right, backColor, fontColor);
                SetCellValue(result.Percentage);

                if (IsYearly)
                {
                    NextCell();
                    FormatCell((int)XLPredefinedFormat.Number.Precision2WithSeparator, XLAlignmentHorizontalValues.Right, backColor, fontColor);
                    SetCellValue(result.MonthlyAmountAccurate(StartDate));
                }
            }

            NextRow();
        }

        private void ExportCategoryGroup()
        {
            NextRow();

            //HEADER ROW
            FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Left, Color.Transparent, Color.Black, true);
            SetCellValue("Category Group");

            NextCell();
            FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Right, Color.Transparent, Color.Black, true);
            SetCellValue("Amount");

            NextCell();
            FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Right, Color.Transparent, Color.Black, true);
            SetCellValue("% of Income");

            if (IsYearly)
            {
                NextCell();
                FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Right, Color.Transparent, Color.Black, true);
                SetCellValue("Monthly");
            }

            //DATA ROWS
            foreach (var result in _categoryGroupResults)
            {
                NextRow();

                Color backColor = ExportColorizer.GetBackColor(result.CategoryGroupName);
                Color fontColor = ExportColorizer.GetFontColor(result.CategoryGroupName);

                FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Left, backColor, fontColor);
                SetCellValue(result.CategoryGroupName);

                NextCell();
                FormatCell((int)XLPredefinedFormat.Number.Precision2WithSeparator, XLAlignmentHorizontalValues.Right, backColor, fontColor);
                SetCellValue(result.Amount);

                NextCell();
                FormatCell((int)XLPredefinedFormat.Number.Precision2WithSeparator, XLAlignmentHorizontalValues.Right, backColor, fontColor);
                SetCellValue(result.Percentage);

                if (IsYearly)
                {
                    NextCell();
                    FormatCell((int)XLPredefinedFormat.Number.Precision2WithSeparator, XLAlignmentHorizontalValues.Right, backColor, fontColor);
                    SetCellValue(result.MonthlyAmountAccurate(StartDate));
                }
            }

            NextRow();
        }

        private void ExportCategory()
        {
            NextRow();

            //HEADER ROW
            FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Left, Color.Transparent, Color.Black, true);
            SetCellValue("Category");

            NextCell();
            FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Right, Color.Transparent, Color.Black, true);
            SetCellValue("Amount");

            NextCell();
            FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Right, Color.Transparent, Color.Black, true);
            SetCellValue("% of Income");

            if (IsYearly)
            {
                NextCell();
                FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Right, Color.Transparent, Color.Black, true);
                SetCellValue("Monthly");
            }

            //DATA ROWS
            foreach (var result in _categoryResults)
            {
                NextRow();

                Color backColor = ExportColorizer.GetBackColor(result.CategoryGroupName);
                Color fontColor = ExportColorizer.GetFontColor(result.CategoryGroupName);

                FormatCell(XLPredefinedFormat.General, XLAlignmentHorizontalValues.Left, backColor, fontColor);
                SetCellValue(result.FullCategoryName);

                NextCell();
                FormatCell((int)XLPredefinedFormat.Number.Precision2WithSeparator, XLAlignmentHorizontalValues.Right, backColor, fontColor);
                SetCellValue(result.Amount);

                NextCell();
                FormatCell((int)XLPredefinedFormat.Number.Precision2WithSeparator, XLAlignmentHorizontalValues.Right, backColor, fontColor);
                SetCellValue(result.Percentage);

                if (IsYearly)
                {
                    NextCell();
                    FormatCell((int)XLPredefinedFormat.Number.Precision2WithSeparator, XLAlignmentHorizontalValues.Right, backColor, fontColor);
                    SetCellValue(result.MonthlyAmountAccurate(StartDate));
                }
            }

            NextRow();
        }
    }
}
