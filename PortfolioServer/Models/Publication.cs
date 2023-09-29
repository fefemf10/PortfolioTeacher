﻿namespace PortfolioServer.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Form { get; set; }
        public string OutputData { get; set; }
        public int Size { get; set; }
        public string CoAuthor { get; set; }
    }
}