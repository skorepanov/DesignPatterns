using Prototype;

#region Copy value cell
var valueCell = new ValueCell(value: "Значение поля 1", textColor: "Black");
valueCell.PrintInfo();

var valueCellClone = valueCell.Clone() as ValueCell;
valueCellClone.Value = "Значение поля 2";
valueCellClone.PrintInfo();
#endregion

#region Copy header cell
// var headerCell = new HeaderCell(value: "Значение поля 1", fontName: "Arial", fontSize: 16);
// headerCell.PrintInfo();
//
// var headerCellClone = headerCell.Clone() as HeaderCell;
// headerCellClone.Value = "Значение поля 2";
// headerCellClone.PrintInfo();
//
// Console.WriteLine();
//
// headerCell.Font.Size = 5;
// headerCell.PrintInfo();
// headerCellClone.PrintInfo();
#endregion

#region Cell registry
// var cellRegistry = new CellRegistry();
//
// var valueCell = new ValueCell(value: "Значение поля 1", textColor: "Black");
// cellRegistry["valueCell"] = valueCell;
//
// var headerCell = new HeaderCell(value: "Значение поля 1", fontName: "Arial", fontSize: 16);
// cellRegistry["headerCell"] = headerCell;
//
// var valueCellClone = cellRegistry["valueCell"].Clone();
// var headerCellClone = cellRegistry["headerCell"].Clone();
//
// valueCell.PrintInfo();
// valueCellClone.PrintInfo();
// Console.WriteLine();
// headerCell.PrintInfo();
// headerCellClone.PrintInfo();
#endregion