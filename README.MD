![image](https://github.com/Mark65537/MapWithMarkers/blob/master/images/image1.png)
# Описание задачи
На языке C#(.NET Framework 4.8) разработано приложение Windows Forms, 
которое на главной форме содержит карту из библиотеки GMap.NET, 
загружает из базы данных Microsoft SQL Server географические координаты маркеров
и отображает их на карте.
Так же реализовано перемещение маркеров с помощью мыши
(Drag&Drop, то есть нажать на маркер и перенести в другую точку карты) 
и сохранение новых координат в базу данных. После перезапуска приложения 
маркеры остаются расположены так же, как и до закрытия приложения.</p>
Полное создание Базы Данных, Таблицы и начальных данных происходит в файле
CreateDataBase.sql
# Описание работы программы
   Маркер на карте ставиться с помощью правой кнопки мыши. Можно при желании переместить
маркер нажав на него левой кнопкой мыши, потом перетащить его на нужное место и 
отпустить кнопку.
Чтобы сохранить маркеры в базу данных, нужно нажать кнопку 'запись в базу'. Это сделано
на тот случай если вы переместили маркер не куда нужно. Если все 
прошло хорошо появиться окно в котором будет сказанно что данные успешно записанны, если
сохранить не удалось, программа оповестит об этом, и данные не будут сохранены.
# Используемые библиотеки:

1.	Azure.Core
2.	Azure.Identity
3.	Microsoft.Bcl.AsyncInterfaces
4.	Microsoft.Data.SqlClient
5.	Microsoft.IdentityModel.JsonWebTokens
6.	Microsoft.IdentityModel.Logging
7.	Microsoft.IdentityModel.Protocols
8.	Microsoft.IdentityModel.Protocols.OpenIdConnect
9.	Microsoft.IdentityModel.Tokens
10.	System.ServiceProcess
11.	System.Text.Encodings.Web
12.	System.Text.Json
13.	System.Threading.Tasks.Extensions
14.	System.Transactions
15.	System.ValueTuple
16.	System.Xml.Linq
17.	System.Data.DataSetExtensions
18.	System.Data
19.	System.Deployment
20.	System.Drawing
21.	System.Net.Http
22.	System.Xml

# Используемые фреймворки:

1.	GMap.NET.WindowsForms
2.	System.Windows.Forms
3.	WindowsBase

