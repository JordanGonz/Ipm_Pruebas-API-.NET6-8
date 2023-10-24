﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IPM.Core.Dtos
{
    public class RolesPermisoDto
    {
        [JsonPropertyName("idRol")]
        public int RolId { get; set; }

        [JsonPropertyName("idPermiso")]
        public int PermisoId { get; set; }

        [JsonPropertyName("idRolPermiso")]
        public int RolPermisoId { get; set; }
    }
}