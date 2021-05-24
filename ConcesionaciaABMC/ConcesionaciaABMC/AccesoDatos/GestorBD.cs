using ConcesionaciaABMC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ConcesionaciaABMC.AccesoDatos
{
    public class GestorBD
    {

        //para insertar autos
        public void InsertarAuto(Auto auto)
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);

            try
            {
                var sql = "INSERT INTO Autos (patente, IdMarca, km, promocion, precio) VALUES (@patente, @idMarca, @km, @promocion,@precio)";
                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);

                cmd.Parameters.AddWithValue("@patente", auto.patente);
                cmd.Parameters.AddWithValue("@idMarca", auto.idMarca);
                cmd.Parameters.AddWithValue("@km", auto.km);
                cmd.Parameters.AddWithValue("@promocion", auto.promocion);
                cmd.Parameters.AddWithValue("@precio", auto.precio);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        // para listar los autos con las 2 tablas
        public List<DTOAuto> ListadoAutos()
        {
            var lista = new List<DTOAuto>();

            var sql = @"SELECT a.idAuto, a.patente, m.nombre, a.km, a.promocion, a.precio
                        FROM Autos a
                        JOIN Marcas m ON a.idMarca = m.idMarca";
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DTOAuto aut = new DTOAuto();

                aut.patente = (string)dr["patente"];
                aut.nombre = (string)dr["nombre"];
                aut.km = (int)dr["km"];
                aut.promocion = (bool)dr["promocion"];
                aut.precio = (double)dr["precio"];


                lista.Add(aut);
            }
            dr.Close();
            conexion.Close();

            return lista;

        }

        //para cargar el combo
        public List<Marca> ListadoMarcas()
        {
            var lista = new List<Marca>();

            var sql = "SELECT * FROM Marcas";
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Marca marca = new Marca();

                marca.idMarca = (int)dr["idMarca"];
                marca.nombre = (string)dr["nombre"];


                lista.Add(marca);
            }

            dr.Close();
            conexion.Close();

            return lista;
        }

        public DTOAuto UsadoMasNuevo()
        {

            var sql = @"SELECT TOP 1 patente,km,precio
                        FROM Autos
                        WHERE km != 0
                        order by km";
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            DTOAuto auto = null;

            if (dr.Read())
            {

                auto = new DTOAuto();
                auto.patente = (string)dr["patente"];
                auto.km = (int)dr["km"];
                auto.precio = (double)dr["precio"];

            }
            dr.Close();
            conexion.Close();

            return auto;
        }
    }
}