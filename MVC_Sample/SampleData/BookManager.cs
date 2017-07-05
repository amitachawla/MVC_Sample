using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData
{
    public class BookManager
    {
        public BookManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }

        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public bool Validate(Book entity)
        {
            ValidationErrors.Clear();

            if(!String.IsNullOrEmpty(entity.Name))
            {
                if(entity.Name.ToLower().Equals(entity.Name))
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("Name", "Book Name cannot be all lower case."));

                }
            }
            return ValidationErrors.Count == 0;
        }

        public bool Delete(Book entity)
        {
            return true;
        }

        public Book Get(int Id)
        {
            List<Book> list = new List<Book>();
            Book ret = new Book();
            list = CreateMockData();

            ret = list.Find(p => p.Id == Id);

            return ret;
        }

        public bool Update(Book entity)
        {
            bool ret = false;

            ret = Validate(entity);
            if(ret)
            {

            }
            return ret;
        }

        public bool Insert(Book entity)
        {
            bool ret = false;
            ret = Validate(entity);
            if(ret)
            {
                //insert into db
            }
            return ret;
        }

        public List<Book> Get(Book entity)
        {
            List<Book> ret = new List<Book>();
            ret = CreateMockData();

            if(!string.IsNullOrEmpty(entity.Name))
            {
                ret = ret.FindAll(p => p.Name.ToLower().StartsWith(entity.Name, StringComparison.InvariantCultureIgnoreCase));
            }

            return ret;
        }

        private List<Book> CreateMockData()
        {
            List<Book> ret = new List<Book>();

            ret.Add(new Book()
            {
                Id = 1,
                Name = "Harry Potter And The Sorcerer's Stone",
                Author = "J.K. Rowling",
                ISBN = "0439708184",
                Price = Convert.ToDecimal(7.34)
            });

            ret.Add(new Book()
            {
                Id = 1,
                Name = "Harry Potter And The Chamber of Secrets",
                Author = "J.K. Rowling",
                ISBN = "0439064872",
                Price = Convert.ToDecimal(7.38)
            });

            ret.Add(new Book()
            {
                Id = 1,
                Name = "Harry Potter And The Prisoner of Azkaban",
                Author = "J.K. Rowling",
                ISBN = "04397004391363698184",
                Price = Convert.ToDecimal(7.38)
            });

            ret.Add(new Book()
            {
                Id = 1,
                Name = "Harry Potter And The Goblet Of Fire",
                Author = "J.K. Rowling",
                ISBN = "0439139600",
                Price = Convert.ToDecimal(7.64)
            });

            ret.Add(new Book()
            {
                Id = 1,
                Name = "Harry Potter And The Order Of The Phoenix",
                Author = "J.K. Rowling",
                ISBN = "0439358078",
                Price = Convert.ToDecimal(8.64)
            });

            ret.Add(new Book()
            {
                Id = 1,
                Name = "Harry Potter And The Half Blood Prince",
                Author = "J.K. Rowling",
                ISBN = "0439785960",
                Price = Convert.ToDecimal(8.64)
            });

            ret.Add(new Book()
            {
                Id = 1,
                Name = "Harry Potter And The Deathly Hallows",
                Author = "J.K. Rowling",
                ISBN = "0545139708",
                Price = Convert.ToDecimal(9.62)
            });

            return ret;
        }
    }
}
