using Parcial2Prog3.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Parcial2Prog3.AccesoDatos
{
    public class GestorBD
    {
        public void InsertarPedido(Pedido pedido)
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);

            try
            {
                var sql = "INSERT INTO Pedidos (Cliente, IdTipoDesayuno, IdTipoDelivery, Porciones) VALUES (@cliente, @idTipoDesayuno, @idTipoDelivery, @porciones)";
                conexion.Open();
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@cliente", pedido.Cliente);
                cmd.Parameters.AddWithValue("@idTipoDesayuno", pedido.IdTipoDesayuno);
                cmd.Parameters.AddWithValue("@idTipoDelivery", pedido.IdTipoDelivery);
                cmd.Parameters.AddWithValue("@porciones", pedido.Porciones);
               

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

        public List<DTOPedido> ListadoPedidos()
        {
            var lista = new List<DTOPedido>();

            var sql = @"SELECT p.Id, p.Cliente, td.NombreDesayuno, tde.NombreDelivery, td.Precio
                        FROM Pedidos p
                        JOIN TiposDesayuno td ON p.IdTipoDesayuno = td.Id
                        JOIN TiposDelivery tde ON p.IdTipoDelivery = tde.Id";
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                DTOPedido ped = new DTOPedido();

                ped.Cliente = (string)dr["Cliente"];
                ped.TipoDesayuno = (string)dr["NombreDesayuno"];
                ped.TipoDelivery = (string)dr["NombreDelivery"];
                ped.PrecioTotal = (double)dr["Precio"];



                lista.Add(ped);
            }
            dr.Close();
            conexion.Close();

            return lista;
        }

        public List<TipoDesayuno> ListadoTipoDesayuno()
        {
            var lista = new List<TipoDesayuno>();

            var sql = "SELECT * FROM TiposDesayuno";
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TipoDesayuno desayuno = new TipoDesayuno();

                desayuno.Id = (int)dr["Id"];
                desayuno.Nombre = (string)dr["NombreDesayuno"];


                lista.Add(desayuno);
            }

            dr.Close();
            conexion.Close();

            return lista;
        }

        public List<TipoDelivery> ListadoTipoDelivery()
        {
            var lista = new List<TipoDelivery>();

            var sql = "SELECT * FROM TiposDelivery";
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                TipoDelivery delivery = new TipoDelivery();

                delivery.Id = (int)dr["Id"];
                delivery.Nombre = (string)dr["NombreDelivery"];


                lista.Add(delivery);
            }

            dr.Close();
            conexion.Close();

            return lista;
        }

        public List<DTOCantidadPorDelivery> CantidadPorDeliver()
        {
            var lista = new List<DTOCantidadPorDelivery>();

            var sql = @"SELECT NombreDelivery, COUNT(*) as cantidad
                        FROM Pedidos p
                        JOIN TiposDelivery t ON p.IdTipoDelivery = t.Id
                        GROUP BY NombreDelivery";
            SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["BD"].ConnectionString);
            conexion.Open();
            SqlCommand cmd = new SqlCommand(sql, conexion);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                DTOCantidadPorDelivery delivery = new DTOCantidadPorDelivery();

                delivery.Nombre = dr.GetString(0);
                delivery.Cantidad = dr.GetInt32(1);

                lista.Add(delivery);
            }

            dr.Close();
            conexion.Close();

            return lista;
        }
    }
}