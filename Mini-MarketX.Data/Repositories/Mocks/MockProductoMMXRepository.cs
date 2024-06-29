using Microsoft.EntityFrameworkCore;
using Mini_MarketX.Data.Context;
using Mini_MarketX.Data.Entities;
using Mini_MarketX.Data.Exceptions;
using Mini_MarketX.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mini_MarketX.Data.Repositories.Mocks
{
    public class MockProductoMMXRepository : IProductoMMXRepository
    {
        private readonly Mini_MarketXContext context;

        public MockProductoMMXRepository(Mini_MarketXContext context)
        {
            this.context = context;
            this.CargarDatos();
        }

        public void Actualizar(Producto producto)
        {
            if (EsProductoNull(producto))
                throw new ProductoNullException("El objeto producto no debe ser nulo.");

            Producto ProductoToUpdate = this.context.Productos.Find(producto.ProductoId);

            if (ProductoToUpdate is null)
                throw new ProductoNotExistsException("El producto no se encuentra registrado");

            ProductoToUpdate.Nombre = producto.Nombre;
            ProductoToUpdate.Descripcion = producto.Descripcion;
            ProductoToUpdate.Precio = producto.Precio;

            this.context.Entry(ProductoToUpdate).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void Agregar(Producto producto)
        {
            if (EsProductoNull(producto))
                throw new ProductoNullException("El objeto producto no debe ser nulo.");

            if (ExisteProducto(producto.ProductoId, producto.Nombre))
                throw new ProductoDuplicadoException($"Este producto {producto.ProductoId} para este MiniMarket: {producto.Nombre} se encuentra registrado");

            Producto ProductoToAdd = new Producto()
            {
                ProductoId = producto.ProductoId,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
            };

            this.context.Productos.Add(ProductoToAdd);
            this.context.SaveChanges();
        }

        public void Eliminar(Producto producto)
        {
            if (EsProductoNull(producto))
                throw new ProductoNullException("El objeto producto no debe ser nulo.");

            Producto productoToRemove = this.context?.Productos?.Find(producto.ProductoId);

            if (productoToRemove is null)
                throw new ProductoNotExistsException("El producto no se encuentra registrado.");

            this.context?.Productos?.Remove(productoToRemove);
            this.context?.SaveChanges();
        }

        public Producto ObtenerporId(int ProductoId)
        {
            return this.context.Productos.Find(ProductoId);
        }

        public List<Producto> TraerTodos()
        {
            return this.context?.Productos?.ToList() ?? new List<Producto>();
        }

        private void CargarDatos()
        {
            try
            {
                if (!this.context.Productos.Any())
                {
                    List<Producto> productos = new List<Producto>
                    {
                        new Producto()
                        {
                            ProductoId = 1,
                            Nombre = "Producto1",
                            Descripcion = "Descripcion del Producto1",
                            Precio = 1,
                        },
                        new Producto()
                        {
                            ProductoId = 2,
                            Nombre = "Producto2",
                            Descripcion = "Descripcion del Producto2",
                            Precio = 2,
                        },
                        new Producto()
                        {
                            ProductoId = 3,
                            Nombre = "Producto3",
                            Descripcion = "Descripcion del Producto3",
                            Precio = 3,
                        },
                        new Producto()
                        {
                            ProductoId = 4,
                            Nombre = "Producto4",
                            Descripcion = "Descripcion del Producto4",
                            Precio = 4,
                        },
                    };

                    this.context.Productos.AddRange(productos);
                    this.context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new CargadeDatosException("Ocurrio un error en la carga de los datos.", ex);
            }
        }

        private bool EsProductoNull(Producto producto)
        {
            return producto == null;
        }

        private bool ExisteProducto(int ProductoId, string Nombre)
        {
            return this.context.Productos.Any(p => p.ProductoId == ProductoId && p.Nombre == Nombre);
        }

        private void LimpiarDatos(List<Producto> productos)
        {
            this.context.Productos.RemoveRange(productos);
            this.context.SaveChanges();
        }
    }
}
