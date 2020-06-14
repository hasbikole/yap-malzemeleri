using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YapiMalzemeleriOdev.Models.EntityFramework;

namespace YapiMalzemeleriOdev.ViewModels
{
    public class KategoriFormViewModels
    {
        public IEnumerable<Kategori> Kategoriler { get; set; }
        public Urunler urunler { get; set; }
    }
}