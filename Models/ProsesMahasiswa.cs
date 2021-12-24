using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace absensionline.Models
{
    public class ProsesMahasiswa
    {
        koneksiDB db = null;
        public ProsesMahasiswa()
        {

            db = new koneksiDB();
        }
        public List<DataMahasiswa> getMahasiswa()
        {
            List<DataMahasiswa> mhs = new List<DataMahasiswa>();
            using (MySqlConnection connection = db.openConnection())
            {
                string query = "Select * from tbl_mhs";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = connection;
                    connection.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mhs.Add(new DataMahasiswa
                            {
                                Id = Convert.ToInt32(sdr["id"]),
                                Nim = sdr["nim"].ToString(),
                                Nama = sdr["nama"].ToString(),
                                Kelas = sdr["kelas"].ToString(),
                                Jurusan = sdr["jurusan"].ToString()

                            });
                        }
                    }
                    connection.Close();
                }
            }
            return mhs;
        }

        public DataMahasiswa GetMahasiswaById(string id)
        {
            DataMahasiswa mahasiswa = new DataMahasiswa();
            using (MySqlConnection connection = db.openConnection())
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from tbl_mhs where id=@id";
                    command.Parameters.Add("id", MySqlDbType.Int32).Value = Int32.Parse(id);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mahasiswa = new DataMahasiswa
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Nim = reader["nim"].ToString(),
                                Nama = reader["nama"].ToString(),
                                Kelas = reader["kelas"].ToString(),
                                Jurusan = reader["jurusan"].ToString()

                            };
                        }
                    }
                    connection.Close();
                }
            }
            return mahasiswa;
        }
        public bool updateMahasiswa(DataMahasiswa mahasiswa)
        {
            bool hasil = false;
            using (MySqlConnection connection = db.openConnection())
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "update tbl_mhs set nim=@nim,nama=@nama,kelas=@kelas,jurusan=@jurusan where id=@id";
                    command.Parameters.Add("nim", MySqlDbType.VarChar).Value = mahasiswa.Nim;
                    command.Parameters.Add("nama", MySqlDbType.VarChar).Value = mahasiswa.Nama;
                    command.Parameters.Add("kelas", MySqlDbType.VarChar).Value = mahasiswa.Kelas;
                    command.Parameters.Add("jurusan", MySqlDbType.VarChar).Value = mahasiswa.Jurusan;
                    command.Parameters.Add("id", MySqlDbType.Int32).Value = mahasiswa.Id;
                    command.ExecuteReader();
                    connection.Close();
                    hasil = true;
                }
            }
            return hasil;
        }
        public bool deleteMahasiswa(string id)
        {
            bool hasil = false;
            using (MySqlConnection connection = db.openConnection())
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    command.Connection = connection;
                    connection.Open();
                    command.CommandText = "delete from tbl_mhs where id=@id";
                    command.Parameters.Add("id", MySqlDbType.Int32).Value = Int32.Parse(id);
                    command.ExecuteReader();
                    connection.Close();
                    hasil = true;
                }
            }
            return hasil;
        }
        public bool saveMahasiswa(DataMahasiswa mahasiswa)
        {
            bool hasil = false;
            using (MySqlConnection connection = db.openConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = connection;
                    connection.Open();
                    cmd.CommandText = "insert into tbl_mhs(nim,nama,kelas,jurusan)" +
                                     "value(@Nim,@Nama,@Kelas,@Jurusan)";
                    cmd.Parameters.Add("Nim", MySqlDbType.VarChar).Value = mahasiswa.Nim;
                    cmd.Parameters.Add("Nama", MySqlDbType.VarChar).Value = mahasiswa.Nama;
                    cmd.Parameters.Add("Kelas", MySqlDbType.VarChar).Value = mahasiswa.Kelas;
                    cmd.Parameters.Add("Jurusan", MySqlDbType.VarChar).Value = mahasiswa.Jurusan;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    hasil = true;
                }
            }
            return hasil;
        }
    }
}