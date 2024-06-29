using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_MarketX.Data.Entities
{
    public class Producto
    {
        [Required(ErrorMessage = "El Id del producto es obligatorio.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El nombre  es obligatorio.")]
        [MaxLength(200, ErrorMessage = "El nombre del producto no puede exceder los 200 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El descripcion  es obligatorio.")]
        [MaxLength(255, ErrorMessage = "La descripcion del producto no puede exceder los 255 caracteres")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El precio  es obligatorio.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio del producto debe ser mayor o igual a cero")]
        public decimal Precio { get; set; }
    }

}

