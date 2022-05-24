using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace CuaHangTheThao.Models
{
    public class DothethaoGenreViewModel
    {
        public List<DoTheThao>? DoTheThaos { get; set; }
        public SelectList? Genres { get; set; }
        public string? DoTheThaoGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
