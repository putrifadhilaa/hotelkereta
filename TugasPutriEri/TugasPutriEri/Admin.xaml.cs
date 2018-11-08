using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TugasPutriEri.BaseContext;
using TugasPutriEri.Model;

namespace TugasPutriEri
{
    /// <summary>
    /// Interaction logic for Hotel.xaml
    /// </summary>
    public partial class Admin : Window
    {
        MyContext context = new MyContext();
        Province province = new Province();
        District district = new District();
        Regency regency = new Regency();
        Village village = new Village();
        Hotel hotel = new Hotel();
        Room room = new Room();
        Facility facility = new Facility();
        DetailRoom detailroom = new DetailRoom();

        public Admin()
        {
            InitializeComponent();
            LoadData();
        }

        private void AddProvinsi_Click(object sender, RoutedEventArgs e)
        {
            province.Name = TextProvinsi.Text;
            context.Provinces.Add(province);
            context.SaveChanges();
        }

        private void DataProvinsi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = DataProvinsi.SelectedItem;
            TextProvinsi.Text = (DataProvinsi.SelectedCells[0].Column.GetCellContent(cell) as TextBlock).Text;
        }


        #region Load

        public void LoadData()
        {
            var GetDataProvinsi = context.Provinces.Where(x => x.IsDelete == false).ToList();
            DataProvinsi.ItemsSource = GetDataProvinsi;
            var GetDataKota = context.Districts.Where(x => x.IsDelete == false).ToList();
            DataKota.ItemsSource = GetDataKota;
            var getProvinsi = context.Provinces.Where(x => x.IsDelete == false).ToList();
            provinsi_kota.ItemsSource = getProvinsi;
            var GetDataKecamatan = context.Regencies.Where(x => x.IsDelete == false).ToList();
            DataKecamatan.ItemsSource = GetDataKecamatan;
            var getProvinsiKecamatan = context.Provinces.Where(x => x.IsDelete == false).ToList();
            provinsi_kecamatan.ItemsSource = getProvinsiKecamatan;
            var getProvinsiKelurahan = context.Provinces.Where(x => x.IsDelete == false).ToList();
            provinsi_kelurahan.ItemsSource = getProvinsiKelurahan;
            var GetDataKelurahan = context.Villages.Where(x => x.IsDelete == false).ToList();
            DataKelurahan.ItemsSource = GetDataKelurahan;
            var getprovinsihotel = context.Provinces.Where(x => x.IsDelete == false).ToList();
            ProvinsiHotel.ItemsSource = getprovinsihotel;
            var GetDataKamar = context.Rooms.Where(x => x.IsDelete == false).ToList();
            DataKamar.ItemsSource = GetDataKamar;
            var gethotelroom = context.Hotels.Where(x => x.IsDelete == false).ToList();
            hotelroom.ItemsSource = gethotelroom;
            var gethoteldetail = context.Hotels.Where(x => x.IsDelete == false).ToList();
            hoteldetailroom.ItemsSource = gethoteldetail;
        }

        #endregion Load

        private void AddKota_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt16(provinsi_kota.SelectedValue);
            var getProvinsi = context.Provinces.Find(id);
            district.Name = TextKota.Text;
            district.Provinces = getProvinsi;
            context.Districts.Add(district);
            context.SaveChanges();

        }

        private void DataKota_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = DataKota.SelectedItem;
            if (district != null)
            {
                TextKota.Text = (DataKota.SelectedCells[0].Column.GetCellContent(cell) as TextBlock).Text;
                provinsi_kota.Text = (DataKota.SelectedCells[1].Column.GetCellContent(cell) as TextBlock).Text;
            }
            else
            {
                TextKota.Text = "";
                provinsi_kota.Text = "";
            }
        }

        private void AddKecamatan_Click(object sender, RoutedEventArgs e)
        {
            int idprovinsi = Convert.ToInt16(provinsi_kecamatan.SelectedValue);
            var getProvinsi = context.Provinces.Find(idprovinsi);
            int iddistrict = Convert.ToInt16(kota_kecamatan.SelectedValue);
            var getKota = context.Districts.Find(iddistrict);
            regency.Name = TextKecamatan.Text;
            regency.Districts = getKota;
            district.Provinces = getProvinsi;
            context.Regencies.Add(regency);
            context.SaveChanges();
        }

        private void AddKelurahan_Click(object sender, RoutedEventArgs e)
        {
            int idprovinsi = Convert.ToInt16(provinsi_kelurahan.SelectedValue);
            var getProvinsi = context.Provinces.Find(idprovinsi);
            int iddistrict = Convert.ToInt16(kota_kelurahan.SelectedValue);
            var getKota = context.Districts.Find(iddistrict);
            int idregency = Convert.ToInt16(kecamatan_kelurahan.SelectedValue);
            var getKecamatan = context.Regencies.Find(idregency);
            village.Name = TextKelurahan.Text;
            village.Regencies = getKecamatan;
            regency.Districts = getKota;
            district.Provinces = getProvinsi;
            context.Villages.Add(village);
            context.SaveChanges();
        }

        private void provinsi_kecamatan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt16(provinsi_kecamatan.SelectedValue);
            var getKotaKecamatan = context.Districts.Include("Provinces").Where(x => x.Provinces.Id == id).ToList();
            kota_kecamatan.ItemsSource = getKotaKecamatan;
        }

        private void provinsi_kelurahan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt16(provinsi_kelurahan.SelectedValue);
            var getKotaKelurahan = context.Districts.Include("Provinces").Where(x => x.Provinces.Id == id).ToList();
            kota_kelurahan.ItemsSource = getKotaKelurahan;
        }

        private void kota_kelurahan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt16(kota_kelurahan.SelectedValue);
            var getKecamatanKelurahan = context.Regencies.Include("Districts").Where(x => x.Districts.Id == id).ToList();
            kecamatan_kelurahan.ItemsSource = getKecamatanKelurahan;
        }

        private void ProvinsiHotel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt16(ProvinsiHotel.SelectedValue);
            var getkotahotel = context.Districts.Include("Provinces").Where(x => x.Provinces.Id == id).ToList();
            KotaHotel.ItemsSource = getkotahotel;
        }

        private void KotaHotel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt16(KotaHotel.SelectedValue);
            var getkecamatanhotel = context.Regencies.Include("Districts").Where(x => x.Districts.Id == id).ToList();
            KecamatanHotel.ItemsSource = getkecamatanhotel;
        }

        private void KecamatanHotel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt16(KecamatanHotel.SelectedValue);
            var getkelurahanhotel = context.Villages.Include("Regencies").Where(x => x.Regencies.Id == id).ToList();
            KelurahanHotel.ItemsSource = getkelurahanhotel;
        }


        private void AddHotel_Click(object sender, RoutedEventArgs e)
        {
            hotel.Name = NamaHotel.Text;
            string bintang = null;
            if (BintangSatu.IsChecked == true) bintang ="BintangSatu";
            else if (BintangDua.IsChecked == true) bintang="BintangDua";
            else if (BintangTiga.IsChecked == true) bintang="BintangTiga";
            else if (BintangEmpat.IsChecked == true) bintang="BintangEmpat";
            else bintang="BintangLima";
            hotel.Star = bintang;
            int idprovinsi = Convert.ToInt16(ProvinsiHotel.SelectedValue);
            var getprovinsihotel = context.Provinces.Find(idprovinsi);
            int iddistrict = Convert.ToInt16(KotaHotel.SelectedValue);
            var getkotahotel = context.Districts.Find(iddistrict);
            int idregency = Convert.ToInt16(KecamatanHotel.SelectedValue);
            var getkecamatanhotel = context.Regencies.Find(idregency);
            int idvillage = Convert.ToInt16(KelurahanHotel.SelectedValue);
            var getkelurahanhotel = context.Villages.Find(idvillage);
            hotel.Districts=getkotahotel;
            context.Hotels.Add(hotel);
            context.SaveChanges();
        }

        private void AddKamar_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt16(hotelroom.SelectedValue);
            var gethotelroom = context.Hotels.Find(id);
            room.Name = NamaKamar.Text;
            room.Hotels = gethotelroom;
            context.Rooms.Add(room);
            context.SaveChanges();
        }

        private void DataKamar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object hotelkamar = DataKamar.SelectedValue;
            hotelroom.Text = (DataKamar.SelectedCells[0].Column.GetCellContent(hotelkamar) as TextBlock).Text;
            object cell = DataKamar.SelectedItem;
            NamaKamar.Text = (DataKamar.SelectedCells[1].Column.GetCellContent(cell) as TextBlock).Text;
        }


        private void AddFasilitas_Click(object sender, RoutedEventArgs e)
        {
            facility.Name = namafasilitas.Text;
            context.Facilities.Add(facility);
            context.SaveChanges();
        }

        private void datafasilitas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object cell = datafasilitas.SelectedItem;
            namafasilitas.Text = (datafasilitas.SelectedCells[0].Column.GetCellContent(cell) as TextBlock).Text;
        }

        private void hoteldetailroom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt16(hoteldetailroom.SelectedValue);
            var getroomfacility = context.Rooms.Include("Hotels").Where(x => x.Hotels.Id == id).ToList();
            roomfacility.ItemsSource = getroomfacility;
        }

        private void datadetailroom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = Convert.ToInt16(hoteldetailroom.SelectedValue);
            var gethoteldetail = context.Hotels.Find(id);
        }

        private void single_Checked(object sender, RoutedEventArgs e)
        {

            datadetailroom.Items.Add(
                new
                {
                    datafasilitasdetail = single.Content.ToString(),
                    datahoteldetail = hoteldetailroom.SelectedValue,
                    dataroomdetail = roomfacility.SelectedValue,
                    datahargadetail = harga.Text
                });
                
        }

        private void singlesingle_Checked(object sender, RoutedEventArgs e)
        {
            datadetailroom.Items.Add(
                new
                {
                    datafasilitasdetail = singlesingle.Content.ToString(),
                    datahoteldetail = hoteldetailroom.SelectedValue,
                    dataroomdetail = roomfacility.SelectedValue,
                    datahargadetail = harga.Text
                });
        }

        private void dobel_Checked(object sender, RoutedEventArgs e)
        {
            datadetailroom.Items.Add(
                new
                {
                    datafasilitasdetail = dobel.Content.ToString(),
                    datahoteldetail = hoteldetailroom.SelectedValue,
                    dataroomdetail = roomfacility.SelectedValue,
                    datahargadetail = harga.Text
                });
        }

        private void dobell_Checked(object sender, RoutedEventArgs e)
        {
            datadetailroom.Items.Add(
                new
                {
                    datafasilitasdetail = dobell.Content.ToString(),
                    datahoteldetail = hoteldetailroom.SelectedValue,
                    dataroomdetail = roomfacility.SelectedValue,
                    datahargadetail = harga.Text
                });
        }

        private void tv_Checked(object sender, RoutedEventArgs e)
        {
            datadetailroom.Items.Add(
                new
                {
                    datafasilitasdetail = tv.Content.ToString(),
                    datahoteldetail = hoteldetailroom.SelectedValue,
                    dataroomdetail = roomfacility.SelectedValue,
                    datahargadetail = harga.Text
                });
        }

        private void ac_Checked(object sender, RoutedEventArgs e)
        {
            datadetailroom.Items.Add(
                new
                {
                    datafasilitasdetail = ac.Content.ToString(),
                    datahoteldetail = hoteldetailroom.SelectedValue,
                    dataroomdetail = roomfacility.SelectedValue,
                    datahargadetail = harga.Text
                });
        }

        private void bottle_Checked(object sender, RoutedEventArgs e)
        {
            datadetailroom.Items.Add(
                new
                {
                    datafasilitasdetail = bottle.Content.ToString(),
                    datahoteldetail = hoteldetailroom.SelectedValue,
                    dataroomdetail = roomfacility.SelectedValue,
                    datahargadetail = harga.Text
                });
        }

        private void maker_Checked(object sender, RoutedEventArgs e)
        {
            datadetailroom.Items.Add(
                new
                {
                    datafasilitasdetail = maker.Content.ToString(),
                    datahoteldetail = hoteldetailroom.SelectedValue,
                    dataroomdetail = roomfacility.SelectedValue,
                    datahargadetail = harga.Text
                });
        }

        private void hair_Checked(object sender, RoutedEventArgs e)
        {
            datadetailroom.Items.Add(
                new
                {
                    datafasilitasdetail = hair.Content.ToString(),
                    datahoteldetail = hoteldetailroom.SelectedValue,
                    dataroomdetail = roomfacility.SelectedValue,
                    datahargadetail = harga.Text
                });
        }

        private void iron_Checked(object sender, RoutedEventArgs e)
        {
            datadetailroom.Items.Add(
                new
                {
                    datafasilitasdetail = iron.Content.ToString(),
                    datahoteldetail = hoteldetailroom.SelectedValue,
                    dataroomdetail = roomfacility.SelectedValue,
                    datahargadetail = harga.Text
                });
        }

        private void slipper_Checked(object sender, RoutedEventArgs e)
        {
            datadetailroom.Items.Add(
                new
                {
                    datafasilitasdetail = slipper.Content.ToString(),
                    datahoteldetail = hoteldetailroom.SelectedValue,
                    dataroomdetail = roomfacility.SelectedValue,
                    datahargadetail = harga.Text
                });
        }

        private void toilet_Checked(object sender, RoutedEventArgs e)
        {
            datadetailroom.Items.Add(
                new
                {
                    datafasilitasdetail = toilet.Content.ToString(),
                    datahoteldetail = hoteldetailroom.SelectedValue,
                    dataroomdetail = roomfacility.SelectedValue,
                    datahargadetail = harga.Text
                });
        }

        private void hot_Checked(object sender, RoutedEventArgs e)
        {
            datadetailroom.Items.Add(
                new
                {
                    datafasilitasdetail = hot.Content.ToString(),
                    datahoteldetail = hoteldetailroom.SelectedValue,
                    dataroomdetail = roomfacility.SelectedValue,
                    datahargadetail = harga.Text
                });
        }

        private void add_detail_Click(object sender, RoutedEventArgs e)
        {
            var get = datadetailroom.Items;
            int rowcount = datadetailroom.Items.Count;
            for (int i = 0; i < rowcount; i++)
            {
                var jenisruangan = context.Rooms.Find(Convert.ToInt16((datadetailroom.Columns[1].GetCellContent(get[i]) as TextBlock).Text));
                detailroom.Rooms = jenisruangan;
                string datadetailroomm = (datadetailroom.Columns[2].GetCellContent(get[i]) as TextBlock).Text;
                var fasilitasruangan = context.Facilities.SingleOrDefault(x => x.Name.Equals(datadetailroomm));
                detailroom.Facilities = fasilitasruangan;
                detailroom.Price =  Convert.ToDouble(harga.Text);
                context.DetailRooms.Add(detailroom);
                context.SaveChanges();

            }



            //string jenisruangan = roomfacility.Text;
            //string fasilitasruangan = 
        }

        private void single_Unchecked(object sender, RoutedEventArgs e)
        {
                    datadetailroom.Items.Remove(
            new
            {
                datafasilitasdetail = single.Content.ToString(),
                datahoteldetail = hoteldetailroom.SelectedValue,
                dataroomdetail = roomfacility.SelectedValue,
                datahargadetail = harga.Text
            });
        }

        private void singlesingle_Unchecked(object sender, RoutedEventArgs e)
        {
                    datadetailroom.Items.Remove(
            new
            {
                datafasilitasdetail = singlesingle.Content.ToString(),
                datahoteldetail = hoteldetailroom.SelectedValue,
                dataroomdetail = roomfacility.SelectedValue,
                datahargadetail = harga.Text
            });
        }

        private void dobel_Unchecked(object sender, RoutedEventArgs e)
        {
                        datadetailroom.Items.Remove(
            new
            {
            datafasilitasdetail = dobel.Content.ToString(),
            datahoteldetail = hoteldetailroom.SelectedValue,
            dataroomdetail = roomfacility.SelectedValue,
            datahargadetail = harga.Text
            });
        }

        private void dobell_Unchecked(object sender, RoutedEventArgs e)
        {
                            datadetailroom.Items.Remove(
                new
                {
                datafasilitasdetail = dobell.Content.ToString(),
                datahoteldetail = hoteldetailroom.SelectedValue,
                dataroomdetail = roomfacility.SelectedValue,
                datahargadetail = harga.Text
                });
        }

        private void tv_Unchecked(object sender, RoutedEventArgs e)
        {
                            datadetailroom.Items.Remove(
                new
                {
                datafasilitasdetail = tv.Content.ToString(),
                datahoteldetail = hoteldetailroom.SelectedValue,
                dataroomdetail = roomfacility.SelectedValue,
                datahargadetail = harga.Text
                });
        }

        private void ac_Unchecked(object sender, RoutedEventArgs e)
        {
                            datadetailroom.Items.Remove(
                new
                {
                datafasilitasdetail = ac.Content.ToString(),
                datahoteldetail = hoteldetailroom.SelectedValue,
                dataroomdetail = roomfacility.SelectedValue,
                datahargadetail = harga.Text
                });
        }

        private void bottle_Unchecked(object sender, RoutedEventArgs e)
        {
                            datadetailroom.Items.Remove(
                new
                {
                datafasilitasdetail = bottle.Content.ToString(),
                datahoteldetail = hoteldetailroom.SelectedValue,
                dataroomdetail = roomfacility.SelectedValue,
                datahargadetail = harga.Text
                });
        }

        private void maker_Unchecked(object sender, RoutedEventArgs e)
        {
                            datadetailroom.Items.Remove(
                new
                {
                datafasilitasdetail = maker.Content.ToString(),
                datahoteldetail = hoteldetailroom.SelectedValue,
                dataroomdetail = roomfacility.SelectedValue,
                datahargadetail = harga.Text
                });
        }

        private void hair_Unchecked(object sender, RoutedEventArgs e)
        {
                            datadetailroom.Items.Remove(
                new
                {
                datafasilitasdetail = hair.Content.ToString(),
                datahoteldetail = hoteldetailroom.SelectedValue,
                dataroomdetail = roomfacility.SelectedValue,
                datahargadetail = harga.Text
                });
        }

        private void iron_Unchecked(object sender, RoutedEventArgs e)
        {
                            datadetailroom.Items.Remove(
                new
                {
                datafasilitasdetail = iron.Content.ToString(),
                datahoteldetail = hoteldetailroom.SelectedValue,
                dataroomdetail = roomfacility.SelectedValue,
                datahargadetail = harga.Text
                });
        }

        private void slipper_Unchecked(object sender, RoutedEventArgs e)
        {
                            datadetailroom.Items.Remove(
                new
                {
                datafasilitasdetail = slipper.Content.ToString(),
                datahoteldetail = hoteldetailroom.SelectedValue,
                dataroomdetail = roomfacility.SelectedValue,
                datahargadetail = harga.Text
                });
        }

        private void toilet_Unchecked(object sender, RoutedEventArgs e)
        {
                            datadetailroom.Items.Remove(
                new
                {
                datafasilitasdetail = toilet.Content.ToString(),
                datahoteldetail = hoteldetailroom.SelectedValue,
                dataroomdetail = roomfacility.SelectedValue,
                datahargadetail = harga.Text
                });
        }

        private void hot_Unchecked(object sender, RoutedEventArgs e)
        {
                            datadetailroom.Items.Remove(
                new
                {
                datafasilitasdetail = hot.Content.ToString(),
                datahoteldetail = hoteldetailroom.SelectedValue,
                dataroomdetail = roomfacility.SelectedValue,
                datahargadetail = harga.Text
                });
        }
        
        private void updateroom_Click(object sender, RoutedEventArgs e)
        {
            var cell = context.Rooms.SingleOrDefault(x => x.Name.Equals(NamaKamar.Text));
            cell.Name = NamaKamar.Text;
            cell.UpdateDate = DateTimeOffset.Now.LocalDateTime;
            context.Entry(cell).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}