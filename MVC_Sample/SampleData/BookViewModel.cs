using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace SampleData
{
    public class BookViewModel : ViewModelBase
    {
        public BookViewModel() : base()
        {
            Books = new List<Book>();
            SearchEntity = new Book();
            Entity = new Book();
        }

        public Book Entity { get; set; }
        
        public List<Book> Books { get; set; }
        public Book SearchEntity { get; set; }

        public override void HandleRequest()
        {
            base.HandleRequest();
        }

        protected override void Init()
        {
            Books = new List<Book>();
            SearchEntity = new Book();
            Entity = new Book();
            base.Init();
        }

        protected override void Save()
        {
            BookManager mgr = new BookManager();

            if(Mode.Equals("Add"))
            {
                mgr.Insert(Entity);
            }
            else
            {
                mgr.Update(Entity);
            }

            ValidationErrors = mgr.ValidationErrors;
            base.Save();         
        }        

        protected override void Add()
        {
            IsValid = true;
            Entity = new Book();
            Entity.Name = "The Lord of the Rings";
            Entity.ISBN = "0618640150";
            Entity.Author = "J.R.R. Tolkien";
            Entity.Price = Convert.ToDecimal(12.43);
            base.Add();
        }

        protected override void Edit()
        {
            BookManager mgr = new BookManager();
            Entity = mgr.Get(Convert.ToInt32(EventArgument));
            base.Edit();
        }

        protected override void Delete()
        {
            BookManager mgr = new BookManager();
            Entity = new Book();
            Entity.Id = Convert.ToInt32(EventArgument);

            mgr.Delete(Entity);

            Get();
            base.Delete();
        }             

        protected override void ResetSearch()
        {
            SearchEntity = new Book();
            base.ResetSearch();
        }

        protected override void Get()
        {
            BookManager mgr = new BookManager();
            Books = mgr.Get(SearchEntity);
            base.Get();
        }
    }
}
                          