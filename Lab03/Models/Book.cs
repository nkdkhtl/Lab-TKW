using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab02.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Summary { get; set; }


        public List<Book> GetBookList()
        {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/images/products/ChiPheo.webp",
                    Price = 80000,
                    Summary = "",
                    TotalPage = 200

                },

                new Book()
                {
                    Id = 2,
                    Title = "Lão Hạc",
                    AuthorId = 2,
                    GenreId = 2,
                    Image = "/images/products/LaoHac.webp",
                    Price = 100000,
                    Summary = "",
                    TotalPage = 100

                },

                new Book()
                {
                    Id = 3,
                    Title = "Vợ Nhặt",
                    AuthorId = 3,
                    GenreId = 3,
                    Image = "/images/products/VoNhat.webp",
                    Price = 120000,
                    Summary = "",
                    TotalPage = 200

                },

                new Book()
                {
                    Id = 4,
                    Title = "Truyện Kiều",
                    AuthorId = 4,
                    GenreId = 4,
                    Image = "/images/products/TruyenKieu.webp",
                    Price = 180000,
                    Summary = "",
                    TotalPage = 200

                },

                new Book()
                {
                    Id = 5,
                    Title = "Những người khốn khổ",
                    AuthorId = 5,
                    GenreId = 5,
                    Image = "/images/products/NhungNguoiKhonKho.webp",
                    Price = 199000,
                    Summary = "",
                    TotalPage = 321
                }




            };

            return books;
        }

        public Book GetBookById(int Id)
        {
            Book book = this.GetBookList().FirstOrDefault(x => x.Id == Id);
            return book;
        }

        public List<SelectListItem> Authors { get; } = new List<SelectListItem>()
        {
            new SelectListItem { Value = "1", Text = "Nam Cao"},
            new SelectListItem { Value = "2", Text = "Nam Cao"},
            new SelectListItem { Value = "3", Text = "Kim Lân"},
            new SelectListItem {Value = "4", Text = "Nguyễn Du" },
            new SelectListItem { Value = "5", Text = "Victor Hugo"}
        };

        public List<SelectListItem> Genres { get; } = new List<SelectListItem>()
        {
            new SelectListItem { Value = "1", Text = "Truyện ngắn"},
            new SelectListItem { Value = "2", Text = "Truyện ngắn"},
            new SelectListItem { Value = "3", Text = "Truyện ngắn"},
            new SelectListItem {Value = "4", Text = "Thơ lục bát" },
            new SelectListItem { Value = "5", Text = "Tiểu thuyết"}
        };
    }
}
