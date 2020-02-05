﻿using System;
using System.Collections.Generic;
using System.Text;

namespace buscarros.core.Config
{
    public class BuscarrosDatabaseSettings : IBuscarrosDatabaseSettings
    {
        public string BuscarrosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IBuscarrosDatabaseSettings
    {
        string BuscarrosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
