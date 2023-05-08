//using System;
//using Glosolalia.Common.Contracts;
//using static System.Runtime.InteropServices.JavaScript.JSType;


//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using Microsoft.Office.Interop.Excel;
//using parserExddcel;

//namespace Pars.Excell
//{
//	public class Parser
//	{
//		private Application _appExcel;
//		private Workbook _workbook;



//		//				// Otwarcie pliku Excela za pomocą interfejsu Excel.Application
//		//				Application excel = new Application();
//		//				Workbook workbook = excel.Workbooks.Open(excelFilePath);

//		//				// Pobranie arkusza o indeksie 1 (można też użyć nazwy)
//		//				Worksheet worksheet = (Worksheet)workbook.Worksheets.get_Item(1);

//		//				// Odczytanie wartości komórek w kolumnie 2, zaczynając od 5. wiersza
//		//				int row = 5;
//		//				while (true)
//		//				{
//		//					// Pobranie wartości komórki w drugiej kolumnie i aktualizacja zmiennej row
//		//					string value = GetCellValue(worksheet, 2, row++);
//		//					if (value == null)
//		//					{
//		//						break; // Koniec danych
//		//					}

//		//					// Dodanie słowa do listy
//		//					words.Add(value);
//		//				}

//		//				// Zamknięcie pliku Excela i interfejsu Excel.Application
//		//				workbook.Close();
//		//				excel.Quit();

//		//				// Wyświetlenie listy słów
//		//				foreach (string word in words)
//		//				{
//		//					Console.WriteLine(word);
//		//				}

//		//				Console.ReadLine();
//		//			}

//		//			// Funkcja pomocnicza do odczytywania wartości komórki o podanych współrzędnych
//		//			static string GetCellValue(Worksheet worksheet, int column, int row)
//		//			{
//		//				Range cell = worksheet.Cells[row, column];
//		//				if (cell.Value == null)
//		//				{
//		//					return null;
//		//				}
//		//				return cell.Value.ToString();
//		//			}
//		//		}
//		//	}


//		//}


//		public List<List<IParsableSlave>> GetseedEntityList(string filePath, List<ConfigInfo> configInfoSet)
//		{
//			this._appExcel = new Application();
//			this._workbook = _appExcel.Workbooks.Open(filePath);
//			throw new NotImplementedException();
//		}
//	}

//}

