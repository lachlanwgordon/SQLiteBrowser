using System.Diagnostics;
using SQLiteAppTools.Models;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SQLiteAppTools.ViewModels;

namespace SQLiteAppTools
{
    public class AltBrowserViewModel : BaseViewModel
    {
        public string Path { get; set; }
        private List<Table> tables;
        public List<Table> Tables
        {
            get => tables;
            set => SetProperty(ref tables, value);
        }

        private List<Models.Cell> allCells;
        public List<Models.Cell> AllCells
        {
            get => allCells;
            set => SetProperty(ref allCells, value);
        }

        Table selectedTable;
        public Table SelectedTable
        {
            get => selectedTable;
            set
            {
                SetProperty(ref selectedTable, value);
            }
        }

        public async Task LoadTableData(Table table)
        {
            await TableService.LoadData(table);

            AllCells = table.Rows.SelectMany(x => x.Cells).ToList();
        }

        public async Task LoadTables()
        {
            TableService.Init(Path);
            var tables = await TableService.GetAll();

            Tables = tables;
        }

        internal List<Cell> Search(string searchTerm, Table table)
        {
            var rows = table.Rows.Where(x => x.Matches(searchTerm));
            var cells = rows.SelectMany(x => x.Cells).ToList();
            return cells;
        }
    }
}