using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CuaHangTheThao.Data;
using System;
using System.Linq;

namespace CuaHangTheThao.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CuaHangTheThaoContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CuaHangTheThaoContext>>()))
            {
                // Kiểm tra thông tin cuốn sách đã tồn tại hay chưa
                if (context.DoTheThao.Any())
                {
                    return; // Không thêm nếu cuốn sách đã tồn tại trong DB
                }

                context.DoTheThao.AddRange(
                new DoTheThao
                {
                    Title = "Áo Juventus",
                    ReleaseDate = DateTime.Parse("2022-10-16"),
                    Genre = "M",
                    Price = 11.98M,
                    Rating = "20"
                },
                new DoTheThao
                {
                    Title = "Áo Bacralona",
                    ReleaseDate = DateTime.Parse("2021-8-3"),
                    Genre = "S",
                    Price = 18.59M,
                    Rating = "20"
                },
                new DoTheThao
                {
                    Title = "Áo Seribe ",
                    ReleaseDate = DateTime.Parse("2019-3-20"),
                    Genre = "XXL",
                    Price = 11.98M,
                    Rating = "25"
                }
                );
                context.SaveChanges();//lưu dữ liệu
            }
        }
    }
}