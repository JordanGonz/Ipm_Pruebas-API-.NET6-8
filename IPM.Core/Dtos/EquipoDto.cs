using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{
    public class EquipoDto
    {
        [JsonPropertyName("idEquipo")]
        public int IdEquipo { get; set; }

        [JsonPropertyName("nombreEquipo")]
        public string? NombreEquipo { get; set; }

        [JsonPropertyName("codigo")]
        public string? Codigo { get; set; }

        [JsonPropertyName("marca")]
        public string? Marca { get; set; }

        [JsonPropertyName("modelo")]
        public string? Modelo { get; set; }

        [JsonPropertyName("serviceTag")]
        public string? ServiceTag { get; set; }

        [JsonPropertyName("expressServiceCode")]
        public string? ExpressServiceCode { get; set; }

        [JsonPropertyName("color")]
        public string? Color { get; set; }

        [JsonPropertyName("procesador")]
        public string? Procesador { get; set; }

        [JsonPropertyName("memoria")]
        public string? Memoria { get; set; }

        [JsonPropertyName("discoDuro")]
        public string? DiscoDuro { get; set; }

        [JsonPropertyName("sistemaOperativo")]
        public string? SistemaOperativo { get; set; }

        [JsonPropertyName("lector")]
        public string? Lector { get; set; }

        [JsonPropertyName("conectividad")]
        public string? Conectividad { get; set; }

        [JsonPropertyName("camara")]
        public string? Camara { get; set; }

        [JsonPropertyName("pantalla")]
        public string? Pantalla { get; set; }

        [JsonPropertyName("usb")]
        public string? Usb { get; set; }

        [JsonPropertyName("bateria")]
        public string? Batería { get; set; }

        [JsonPropertyName("office")]
        public string? Office { get; set; }

        [JsonPropertyName("cargadorModel")]
        public string? CargadorModel { get; set; }

        [JsonPropertyName("serial")]
        public string? Serial { get; set; }

        [JsonPropertyName("marcaMouse")]
        public string? MarcaMouse { get; set; }

        [JsonPropertyName("modeloMouse")]
        public string? ModeloMouse { get; set; }

        [JsonPropertyName("serieMouse")]
        public string? SerieMouse { get; set; }

       

    }


    public class EquipoCreacionDto
    {

        [JsonPropertyName("nombreEquipo")]
        public string? NombreEquipo { get; set; }

        [JsonPropertyName("codigo")]
        public string? Codigo { get; set; }

        [JsonPropertyName("marca")]
        public string? Marca { get; set; }

        [JsonPropertyName("modelo")]
        public string? Modelo { get; set; }

        [JsonPropertyName("serviceTag")]
        public string? ServiceTag { get; set; }

        [JsonPropertyName("expressServiceCode")]
        public string? ExpressServiceCode { get; set; }

        [JsonPropertyName("color")]
        public string? Color { get; set; }

        [JsonPropertyName("procesador")]
        public string? Procesador { get; set; }

        [JsonPropertyName("memoria")]
        public string? Memoria { get; set; }

        [JsonPropertyName("discoDuro")]
        public string? DiscoDuro { get; set; }

        [JsonPropertyName("sistemaOperativo")]
        public string? SistemaOperativo { get; set; }

        [JsonPropertyName("lector")]
        public string? Lector { get; set; }

        [JsonPropertyName("conectividad")]
        public string? Conectividad { get; set; }

        [JsonPropertyName("camara")]
        public string? Camara { get; set; }

        [JsonPropertyName("pantalla")]
        public string? Pantalla { get; set; }

        [JsonPropertyName("usb")]
        public string? Usb { get; set; }

        [JsonPropertyName("bateria")]
        public string? Batería { get; set; }

        [JsonPropertyName("office")]
        public string? Office { get; set; }

        [JsonPropertyName("cargadorModel")]
        public string? CargadorModel { get; set; }

        [JsonPropertyName("serial")]
        public string? Serial { get; set; }

        [JsonPropertyName("marcaMouse")]
        public string? MarcaMouse { get; set; }

        [JsonPropertyName("modeloMouse")]
        public string? ModeloMouse { get; set; }

        [JsonPropertyName("serieMouse")]
        public string? SerieMouse { get; set; }


    }

    public class EquipoSistemOperativo
    {
        [JsonPropertyName("nombreEquipo")]
        public string? NombreEquipo { get; set; }

        [JsonPropertyName("codigo")]
        public string? Codigo { get; set; }

        [JsonPropertyName("marca")]
        public string? Marca { get; set; }

        [JsonPropertyName("modelo")]
        public string? Modelo { get; set; }

        [JsonPropertyName("serviceTag")]
        public string? ServiceTag { get; set; }

        [JsonPropertyName("expressServiceCode")]
        public string? ExpressServiceCode { get; set; }

        [JsonPropertyName("color")]
        public string? Color { get; set; }

        [JsonPropertyName("procesador")]
        public string? Procesador { get; set; }

        [JsonPropertyName("memoria")]
        public string? Memoria { get; set; }

        [JsonPropertyName("discoDuro")]
        public string? DiscoDuro { get; set; }

        [JsonPropertyName("sistemaOperativo")]
        public string? SistemaOperativo { get; set; }

        [JsonPropertyName("lector")]
        public string? Lector { get; set; }

        [JsonPropertyName("conectividad")]
        public string? Conectividad { get; set; }

        [JsonPropertyName("camara")]
        public string? Camara { get; set; }

        [JsonPropertyName("pantalla")]
        public string? Pantalla { get; set; }

        [JsonPropertyName("usb")]
        public string? Usb { get; set; }

        [JsonPropertyName("bateria")]
        public string? Batería { get; set; }

        [JsonPropertyName("office")]
        public string? Office { get; set; }

        [JsonPropertyName("cargadorModel")]
        public string? CargadorModel { get; set; }

        [JsonPropertyName("serial")]
        public string? Serial { get; set; }

        [JsonPropertyName("marcaMouse")]
        public string? MarcaMouse { get; set; }

        [JsonPropertyName("modeloMouse")]
        public string? ModeloMouse { get; set; }

        [JsonPropertyName("serieMouse")]
        public string? SerieMouse { get; set; }
    }
}
