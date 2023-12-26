//------------------------------------------[Задание]-----------------------------------------------
// Вывести на консоль, например, три стобцаTime, Hbar, Vpr.


// Применяем GetData для чтения и c помощью .ToArray представляем данные в виде массива
// (переименовал в data.csv для удобства, старое название слишком длинное).
// var data = Data.GetData("flight-data.csv").ToArray();


// // Цикл для вывода столбца Time в консоль.
// for (int i = 0; i < data.Length; i++)
// {
//     Console.WriteLine($"{data[i].Time} \t");
// }


// //------------------------------------------[Семинар]------------------------------------------------

// struct Data
// {
//     // Шаг 0. Задаем структуру данных, то есть имена столбцов, пока без значений.
//     public double Time { get;set; }  // Time / Время
//     public double Hbar { get;set; }  // Pressure altitude / Барометрическая высота
//     public double Hr { get;set; }  // Height according to radio altimeter / Показания радиовысотомера
//     public double Vpr { get;set; }  // Travel speed / Путевая скорость
//     public double Vy { get;set; }  // Vertical speed / Вертикальная скорость
//     public double nx { get;set; }  // Acceleration along x
//     public double ny { get;set; }  // Acceleration along y
//     public double nz { get;set; }  // Acceleration along z
//     public bool Gear { set;get; }  // Landing gear compression / обжатие шасси
//     public double Latitude { set;get; }  // Latitude / Широта 
//     public double Longitude { set;get; }  // Longitude / Долгота
//     public double Hbar_m => Hbar*0.3; // Converting feet to meters
//     public double Hr_m => Hr*0.3;  // Converting feet to meters
    
    
//     // Шаг 1. Пустая таблчика есть, теперь заполним ее данными из файла .csv
//     public static IEnumerable<Data> GetData(IEnumerable<string> strs)
//     {
//         // Проход по всем строкам
//         foreach (var str in strs)
//         {
//             // В файле все значения в столбцах разделены символом ;
//             // поэтому пропишем разделитель
//             var items = str.Split(';');
//             var data = new Data
//             {
//                 // items[i], где i соотвествует номеру столбца (отсчет идет с 0).
//                 Time = double.Parse(items[0]),
//                 Hbar = double.Parse(items[2]),
//                 Hr = double.Parse(items[3]),
//                 Vpr = double.Parse(items[4]),
//                 Vy = double.Parse(items[5]),
//                 nx = double.Parse(items[6]),
//                 ny = double.Parse(items[7]),
//                 nz = double.Parse(items[8]),
//             };
//             yield return data;
//         }
//     }
    
    
//     // Шаг 2. Создаем функцию для чтения строк.
//     public static IEnumerable<string> GetLines(string FileName)
//     {
//         using var file = File.OpenText(FileName);  // открыть файл
//         while(!file.EndOfStream)  // читать, пока не закончатся строки
//             yield return file.ReadLine()!;
//     }
    
    
//     // Шаг 3. Создаем функцию для чтения И пропуска двух первых строчек с текстом.
//     public static IEnumerable<Data> GetData(string FileName)
//     {
//         return GetData(GetLines(FileName).Skip(2));
//     }   
// }