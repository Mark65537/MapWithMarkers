using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace MapWithMarkers
{
    public partial class MainForm : Form
    {
        GMapOverlay overlay = new GMapOverlay("my");// создание именованного слоя
        GMapMarker selectedMarker;
        SqlConnection connection;
        //ServerConnection sc;
        SqlCommand command=new SqlCommand();
        string sqlConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        string databaseName = "GMapDB";
        public MainForm()
        {
            InitializeComponent();
        }
        private void gMapCtrl_Load(object sender, EventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache; //выбор подгрузки карты – онлайн или из ресурсов
            gMapCtrl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance; //какой провайдер карт используется (в нашем случае гугл) 
            gMapCtrl.MinZoom = 2; //минимальный зум
            gMapCtrl.MaxZoom = 20; //максимальный зум
            gMapCtrl.Zoom = 10; // какой используется зум при открытии
            gMapCtrl.Position = new PointLatLng(56.0043, 92.9);// точка в центре карты при открытии (центр Красноярска)
            gMapCtrl.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter; // как приближает (просто в центр карты или по положению мыши)
            gMapCtrl.CanDragMap = true; // перетаскивание карты мышью
            gMapCtrl.DragButton = MouseButtons.Left; // какой кнопкой осуществляется перетаскивание(по умолчанию правой)
            gMapCtrl.ShowCenter = false; //показывать или скрывать красный крестик в центре
            gMapCtrl.ShowTileGridLines = false; //показывать или скрывать тайлы
            gMapCtrl.Overlays.Add(overlay);            
        }

        private bool ConnectServer()
        {
            try
            {
                //sc = new ServerConnection(new Microsoft.Data.SqlClient.SqlConnection(sqlConnectionString));//если не писать полностью, то тогда не видет
                connection = new SqlConnection(sqlConnectionString);
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CheckDatabaseExists()
        {
            try
            {
                command.Connection = connection;
                command.CommandText = $"SELECT db_id('{databaseName}')";
                return command.ExecuteScalar() != DBNull.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
        }

        private void CreateDB()
        {                        
            string script = File.ReadAllText(@"..\..\..\CreateDataBase.sql");
            foreach (string s in script.Split(new string[] { "GO" }, StringSplitOptions.None))//так как SqlCommand не может выполнять несколько команд, нужно их разделять
            {
                command.CommandText = s;
                command.ExecuteNonQuery();
            }
            command.CommandText = $"USE {databaseName}";
            command.ExecuteNonQuery();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MinimumSize = Size;
            if (ConnectServer())
            {
                if(!CheckDatabaseExists())
                    CreateDB();
                else
                    ReadDB();
            }
                
        }

        private void ReadDB()
        {
            command.CommandText = "SELECT latitude, longitude FROM [GMapDB].[dbo].[MarkersTable]";
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read()) // построчно считываем данные
                {
                    var lat = (string)reader.GetValue(0);
                    var lng = (string)reader.GetValue(1);

                    GMarkerGoogle marker = new GMarkerGoogle(
                            new PointLatLng(double.Parse(lat), double.Parse(lng)),
                            GMarkerGoogleType.red);

                    overlay.Markers.Add(marker);
                }
            }
            reader.Close();
        }

        private void gMapCtrl_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Right == e.Button)
            {
                GMarkerGoogle marker = new GMarkerGoogle(
                    new PointLatLng(gMapCtrl.Position.Lat, gMapCtrl.Position.Lng),
                    GMarkerGoogleType.red);

                marker.Position = gMapCtrl.FromLocalToLatLng(e.X, e.Y);                   

                overlay.Markers.Add(marker);
            }
            else if (MouseButtons.Left == e.Button)
            {
                //находим тот маркер над которым нажали клавишу мыши
                selectedMarker = gMapCtrl.Overlays
                    .SelectMany(o => o.Markers)
                    .FirstOrDefault(m => m.IsMouseOver == true);
            }
        }

        private void gMapCtrl_MouseUp(object sender, MouseEventArgs e)
        {
            if (selectedMarker is null)
                return;

            //переводим координаты курсора мыши в долготу и широту на карте
            var latlng = gMapCtrl.FromLocalToLatLng(e.X, e.Y);
            //присваиваем новую позицию для маркера
            selectedMarker.Position = latlng;

            selectedMarker = null;
        }

        private void b_saveInDB_Click(object sender, EventArgs e)
        {
            command.CommandText = $"USE {databaseName}";
            command.ExecuteNonQuery();
            command.CommandText = "DELETE FROM [dbo].[MarkersTable]";
            command.ExecuteNonQuery();
            try
            {
                if (overlay.Markers.Count > 0)
                {
                    foreach (var marker in overlay.Markers)
                    {
                        command.CommandText = $"INSERT [GMapDB].[dbo].[MarkersTable] VALUES(\'{marker.Position.Lat}\', \'{marker.Position.Lng}\')";
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Изменения сохранены в базу", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Close();
        }
    }
}
